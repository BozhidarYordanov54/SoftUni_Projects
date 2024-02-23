using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Contracts;
using SeminarHub.Data;
using SeminarHub.Models;
using System.Globalization;
using System.Security.Claims;

namespace SeminarHub.Controllers
{
    [Authorize]
    public class SeminarController : Controller
    {
        private readonly ISeminarService _seminarService;
        private readonly SeminarHubDbContext _dbContext;

        public SeminarController(ISeminarService seminarService, SeminarHubDbContext dbContext)
        {
            _seminarService = seminarService;
            _dbContext = dbContext;

        }

        public async Task<IActionResult> All()
        {
            var model = await _seminarService.GetAllSeminarsAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var entity = await _dbContext.Seminars
                .Where(s => s.Id == id)
                .Include(s => s.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if(!entity.SeminarsParticipants.Any(p => p.ParticipantId == userId))
            {
                entity.SeminarsParticipants.Add(new SeminarParticipant
                {
                    SeminarId = entity.Id,
                    ParticipantId = userId
                });

                await _dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Joined));
        }

        [HttpGet]
        public async Task<IActionResult> Joined(int id)
        {
            string userId = GetUserId();

            var model = await _dbContext.SeminarsParticipants
                .Where(p => p.ParticipantId == userId)
                .Select(p => new SeminarInfoViewModel(
                
                    p.SeminarId,
                    p.Seminar.Topic,
                    p.Seminar.Lecturer,
                    p.Seminar.Details,
                    p.Seminar.Category.Name,
                    p.Seminar.DateAndTime,
                    p.Seminar.Organizer.UserName
                ))
                .ToListAsync();

            return View(model);
        }

        public async Task<IActionResult> Leave(int id)
        {
            var entity = await _dbContext.Seminars
                .Where(s => s.Id == id)
                .Include(s => s.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            var participant = entity.SeminarsParticipants
                .FirstOrDefault(p => p.ParticipantId == userId);

            if (participant == null)
            {
                return BadRequest();
            }

            entity.SeminarsParticipants.Remove(participant);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new SeminarFormViewModel();
            model.Categories = await GetCategories();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SeminarFormViewModel seminar)
        {
            DateTime dateAndTime = DateTime.Now;

            if (!DateTime.TryParseExact(
                seminar.DateAndTime,
                DataConstants.SeminarConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateAndTime))
            {
                ModelState
                    .AddModelError(nameof(seminar.DateAndTime), $"Invalid date! Format must be: {DataConstants.SeminarConstants.DateFormat}");
            }

            if (!ModelState.IsValid)
            {
                return View(seminar);
            }

            seminar.OrganizerId = GetUserId();
            await _seminarService.AddSeminarAsync(seminar);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _seminarService.GetSeminarById(id);
            entity.Categories = await GetCategories();

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SeminarFormViewModel seminar, int id)
        {
            var entity = await _seminarService.GetSeminarById(id);
            seminar.Categories = await GetCategories();

            if (entity == null)
            {
                return BadRequest();
            }

            if(entity.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            DateTime dateAndTime = DateTime.Now;

            if (!DateTime.TryParseExact(
                seminar.DateAndTime,
                DataConstants.SeminarConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateAndTime))
            {
                ModelState
                    .AddModelError(nameof(seminar.DateAndTime), $"Invalid date! Format must be: {DataConstants.SeminarConstants.DateFormat}");
            }

            if (!ModelState.IsValid)
            {
                return View(seminar);
            }

            seminar.OrganizerId = GetUserId();

            await _seminarService.EditSeminarAsync(seminar, id);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _seminarService.GetSeminarByIdDelete(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(SeminarDeleteViewModel seminar, int id)
        {
            var existingSeminar = await _seminarService.GetSeminarById(id);

            if (existingSeminar == null)
            {                 
                return BadRequest();
            }

            await _seminarService.DeleteSeminarAsync(seminar, id);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _seminarService.Details(id);

            return View(model);
        }

        private async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            return await _dbContext.Categories
                .AsNoTracking()
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
