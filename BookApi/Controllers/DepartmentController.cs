using AutoMapper;
using BookApi.Interface;
using BookApi.Models;
using BookApi.ModelVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRep department;
        private readonly IMapper mapper;
        public DepartmentController(IDepartmentRep department, IMapper mapper)
        {
            this.department = department;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var Data = await department.GetAll();
                var result = mapper.Map<IEnumerable<DepartmentVM> >(Data);
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        [HttpPost]
        public async Task<IActionResult> Creat(DepartmentVM Department)
        {
            try
            {
                var data = mapper.Map<Department>(Department);
                await department.Create(data);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] DepartmentVM Department)
        {
            try
            {
                var data = mapper.Map<Department>(Department);
                var result = await department.Edit(id, data);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        [HttpPost("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await department.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return Ok("Bad Request");

            }

        }
    }
}
