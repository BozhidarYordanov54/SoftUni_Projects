using SeminarHub.Models;

namespace SeminarHub.Contracts
{
    public interface ISeminarService
    {
        //General logic for the seminar service(CRUD)
        Task<IEnumerable<SeminarInfoViewModel>> GetAllSeminarsAsync();
        Task<SeminarFormViewModel> GetSeminarById(int id);
        Task<SeminarDeleteViewModel> GetSeminarByIdDelete(int id);
        Task AddSeminarAsync(SeminarFormViewModel seminar);
        Task EditSeminarAsync(SeminarFormViewModel seminar, int id);
        Task DeleteSeminarAsync(SeminarDeleteViewModel seminar, int id);
        Task<SeminarDetailsViewModel> Details(int id);
        
    }
}
