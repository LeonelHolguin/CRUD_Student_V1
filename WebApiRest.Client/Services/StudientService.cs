using System.Net.Http.Json;
using WebApiRest.Shared;


namespace WebApiRest.Client.Services
{
    public class StudientService : IStudientService
    {
        Uri baseAddress = new Uri("http://localhost:5014/api");
        private readonly HttpClient _client;

        public StudientService()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        public async Task<List<StudientDTO>> GetAllStudients()
        {
            var result = await _client.GetFromJsonAsync<ResponseApi<List<StudientDTO>>>(_client.BaseAddress + "/Studient/Get");

            if (result!.Success)
                return result.Value!;
            else
                throw new Exception(result.Message);
            
        }

        public async Task<StudientDTO> GetStudient(int id)
        {
            var result = await _client.GetFromJsonAsync<ResponseApi<StudientDTO>>(_client.BaseAddress + $"/Studient/Get/{id}");

            if (result!.Success)
                return result.Value!;
            else
                throw new Exception(result.Message);
        }

        public async Task<int> InsertStudient(StudientDTO studient)
        {
            var result = await _client.PostAsJsonAsync(_client.BaseAddress + "/Studient/Save", studient);
            var response = await result.Content.ReadFromJsonAsync<ResponseApi<int>>();

            if (response!.Success)
                return response.Value!;
            else
                throw new Exception(response.Message);
        }

        public async Task<int> EditStudient(StudientDTO studient)
        {
            var result = await _client.PutAsJsonAsync(_client.BaseAddress + $"/Studient/Edit/{studient.IdStudent}", studient);
            var response = await result.Content.ReadFromJsonAsync<ResponseApi<int>>();

            if (response!.Success)
                return response.Value!;
            else
                throw new Exception(response.Message);
        }

        public async Task<bool> DeleteStudient(int id)
        {
            var result = await _client.DeleteAsync(_client.BaseAddress + $"/Studient/Delete/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseApi<int>>();

            if (response!.Success)
                return response.Success;
            else
                throw new Exception(response.Message);
        }

        public async Task<int> SaveHandle(StudientDTO studient)
        {
            if (studient.IdStudent > 0)
                return await EditStudient(studient);
            else
                return await InsertStudient(studient);
        }
    }
}
