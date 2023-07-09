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
    public class BookController : ControllerBase
    {

        private readonly IBookRep book;
        private readonly IMapper mapper;
        public BookController(IBookRep book, IMapper mapper)
        {
            this.book = book;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var Data = await book.GetAll();
                var result = mapper.Map<IEnumerable<BookVM> >(Data);
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        [HttpPost]
        public async Task<IActionResult> Creat(BookVM bookVM)
        {
            try
            {
                var data = mapper.Map<Book>(bookVM);
                await book.Create(data);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BookVM bookVM)
        {
            try
            {
                var data = mapper.Map<Book>(bookVM);
                var result = await book.Edit(id, data);
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
                await book.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return Ok("Bad Request");

            }

        }
    }
}
