using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApiRest.Models;
using WebApiRest.Shared;
using Microsoft.EntityFrameworkCore;

namespace WebApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudientController : ControllerBase
    {
        private readonly CrudWebApiOneApiContext _context;

        public StudientController(CrudWebApiOneApiContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetAllStudients()
        {
            var responseApi = new ResponseApi<List<StudientDTO>>();
            var StudientDTOList = new List<StudientDTO>();

            try
            {
                foreach(var item in await _context.Studients.ToListAsync())
                {
                    StudientDTOList.Add(new StudientDTO
                    {
                        IdStudent = item.IdStudent,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        AdmissionDate = item.AdmissionDate,
                        Career = item.Career,
                        RegisterDate = item.RegisterDate,
                    });

                }

                responseApi.Success = true;
                responseApi.Value = StudientDTOList;

            } catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }


        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetStudient(int id)
        {
            var responseApi = new ResponseApi<StudientDTO>();
            var StudientDTO = new StudientDTO();

            try
            {
                var DbStudient =  await _context.Studients.FindAsync(id);

                if(DbStudient != null)
                {
                    StudientDTO.IdStudent = DbStudient.IdStudent;
                    StudientDTO.FirstName = DbStudient.FirstName;
                    StudientDTO.LastName = DbStudient.LastName;
                    StudientDTO.AdmissionDate = DbStudient.AdmissionDate;
                    StudientDTO.Career = DbStudient.Career;
                    StudientDTO.RegisterDate = DbStudient.RegisterDate;

                    responseApi.Success = true;
                    responseApi.Value = StudientDTO;
                }
                else
                {
                    responseApi.Success = false;
                    responseApi.Message = "Not found";
                }

            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }


        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> SaveStudient(StudientDTO studient)
        {
            var responseApi = new ResponseApi<int>();

            try
            {
                var DbStudient = new Studient
                {
                    IdStudent = studient.IdStudent,
                    FirstName = studient.FirstName,
                    LastName = studient.LastName,
                    AdmissionDate = studient.AdmissionDate,
                    Career = studient.Career,
                    RegisterDate = studient.RegisterDate,
                };

                _context.Studients.Add(DbStudient);
                await _context.SaveChangesAsync();

                if(DbStudient.IdStudent != 0 ) 
                {
                    responseApi.Success = true;
                    responseApi.Value = DbStudient.IdStudent;
                }
                else
                {
                    responseApi.Success = false;
                    responseApi.Message = "Not created";
                }


            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }


        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<IActionResult> EditStudient(StudientDTO studient, int id)
        {
            var responseApi = new ResponseApi<int>();

            try
            {
                var DbStudient = await _context.Studients.FindAsync(id);

                if (DbStudient != null)
                {
                    DbStudient.IdStudent = studient.IdStudent;
                    DbStudient.FirstName = studient.FirstName;
                    DbStudient.LastName = studient.LastName;
                    DbStudient.AdmissionDate = studient.AdmissionDate;
                    DbStudient.Career = studient.Career;
                    DbStudient.RegisterDate = studient.RegisterDate;

                    _context.Studients.Update(DbStudient);
                    await _context.SaveChangesAsync();

                    responseApi.Success = true;
                    responseApi.Value = DbStudient.IdStudent;
                }
                else
                {
                    responseApi.Success = false;
                    responseApi.Message = "Not found";
                }


            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteStudient(int id)
        {
            var responseApi = new ResponseApi<int>();

            try
            {
                var DbStudient = await _context.Studients.FindAsync(id);

                if (DbStudient != null)
                {
                    _context.Studients.Remove(DbStudient);
                    await _context.SaveChangesAsync();

                    responseApi.Success = true;
                }
                else
                {
                    responseApi.Success = false;
                    responseApi.Message = "Not found";
                }


            }
            catch (Exception ex)
            {
                responseApi.Success = false;
                responseApi.Message = ex.Message;
            }

            return Ok(responseApi);
        }
    }
}
