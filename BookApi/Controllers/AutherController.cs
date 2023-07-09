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
    public class AutherController : ControllerBase
    {
        private readonly IAutherRep auther;
        private readonly IMapper mapper;
        public AutherController(IAutherRep auther, IMapper mapper)
        {
            this.auther = auther;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var Data = await auther.GetAll();
                return Ok(Data);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        [HttpPost]
        public async Task<IActionResult> Creat(AutherVM autherVM)
        {
            try
            {
                var data = mapper.Map<Auther>(autherVM);
                await auther.Create(data);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]AutherVM autherVM)
        {
            try
            {
                var data = mapper.Map<Auther>(autherVM);
               var result = await auther.Edit(id, data);
                return  Ok();
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
                await auther.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return Ok("Bad Request");

            }

        }
    }
}
