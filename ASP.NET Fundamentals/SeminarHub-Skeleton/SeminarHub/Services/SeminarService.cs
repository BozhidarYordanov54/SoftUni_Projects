using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SeminarHub.Contracts;
using SeminarHub.Data;
using SeminarHub.Models;
using System.Globalization;
using static SeminarHub.Data.DataConstants;

namespace SeminarHub.Services
{
    public class SeminarService : ISeminarService
    {
        private readonly SeminarHubDbContext _dbContext;

        public SeminarService(SeminarHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddSeminarAsync(SeminarFormViewModel seminar)
        {
            DateTime dateAndTime = DateTime.Now;

            DateTime.TryParseExact(
                    seminar.DateAndTime,
                    SeminarConstants.DateFormat,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out dateAndTime);

            var entity = new Seminar
            {
                Topic = seminar.Topic,
                Lecturer = seminar.Lecturer,
                Details = seminar.Details,
                DateAndTime = dateAndTime,
                Duration = seminar.Duration,
                OrganizerId = seminar.OrganizerId,
                CategoryId = seminar.CategoryId,
            };

            await _dbContext.Seminars.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteSeminarAsync(SeminarDeleteViewModel seminar, int id)
        {
            var entity = await _dbContext.Seminars.FindAsync(id);

            if (entity == null)
            {
                throw new InvalidOperationException("Seminar not found.");
            }

            _dbContext.Seminars.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<SeminarDetailsViewModel> Details(int id)
        {
            var entity = _dbContext.Seminars
                .Where(s => s.Id == id)
                .AsNoTracking()
                .Select(s => new SeminarDetailsViewModel
                {
                    Id = s.Id,
                    Topic = s.Topic,
                    Lecturer = s.Lecturer,
                    Details = s.Details,
                    DateAndTime = s.DateAndTime.ToString(SeminarConstants.DateFormat),
                    Duration = s.Duration,
                    Category = s.Category.Name,
                    Organizer = s.Organizer.UserName,
                })
                .FirstOrDefaultAsync();

            if (entity == null)
            {
                throw new InvalidOperationException("Entity was null");
            }

            return await entity;
        }

        public async Task EditSeminarAsync(SeminarFormViewModel seminar, int id)
        {
            var entity = await _dbContext.Seminars.FindAsync(id);

            if (entity == null)
            {
                throw new InvalidOperationException("Seminar entity was null");
            }

            DateTime dateAndTime = DateTime.Now;

            DateTime.TryParseExact(
                    seminar.DateAndTime,
                    SeminarConstants.DateFormat,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out dateAndTime);

            entity.Topic = seminar.Topic;
            entity.Lecturer = seminar.Lecturer;
            entity.Details = seminar.Details;
            entity.DateAndTime = dateAndTime;
            entity.Duration = seminar.Duration;
            entity.CategoryId = seminar.CategoryId;
            entity.OrganizerId = seminar.OrganizerId;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<SeminarInfoViewModel>> GetAllSeminarsAsync()
        {
            return await _dbContext.Seminars
                .AsNoTracking()
                .Select(s => new SeminarInfoViewModel(
                    s.Id,
                    s.Topic,
                    s.Lecturer,
                    s.Details,
                    s.Category.Name,
                    s.DateAndTime,
                    s.Organizer.UserName)
                ).ToListAsync();
        }

        public async Task<SeminarFormViewModel> GetSeminarById(int id)
        {
            var entity = await _dbContext.Seminars.FindAsync(id);

            if (entity == null)
            {
                throw new InvalidOperationException("Seminar not found.");
            }

            return new SeminarFormViewModel
            {
                Topic = entity.Topic,
                Lecturer = entity.Lecturer,
                Details = entity.Details,
                DateAndTime = entity.DateAndTime.ToString(SeminarConstants.DateFormat),
                Duration = entity.Duration,
                OrganizerId = entity.OrganizerId,
                CategoryId = entity.CategoryId,
            };
        }

        public async Task<SeminarDeleteViewModel> GetSeminarByIdDelete(int id)
        {
            var entity = await _dbContext.Seminars.FindAsync(id);

            if (entity == null)
            {
                throw new InvalidOperationException("Seminar not found.");
            }

            return new SeminarDeleteViewModel
            {
                Id = entity.Id,
                Topic = entity.Topic,
                DateAndTime = entity.DateAndTime.ToString(SeminarConstants.DateFormat),
            };
        }
    }
}
