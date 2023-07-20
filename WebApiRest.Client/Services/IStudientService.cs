using WebApiRest.Shared;

namespace WebApiRest.Client.Services
{
    public interface IStudientService
    {
        Task<List<StudientDTO>> GetAllStudients();
        Task<StudientDTO> GetStudient(int id);
        Task<int> InsertStudient (StudientDTO studient);
        Task<int> EditStudient(StudientDTO studient);
        Task<bool> DeleteStudient (int id);
        Task<int> SaveHandle(StudientDTO studient);
    }
}
