using LibaryMng.Entities;
using LibaryMng.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibaryMng.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowerController : ControllerBase
    {
        private readonly ILibaryService _libaryService;
        public BorrowerController(ILibaryService libaryService)
        {
            _libaryService = libaryService;
        }

        [HttpPost("borrow")]
        public async Task<ActionResult> borrow([FromBody] string borrowerId, string bookId)
        {
            await _libaryService.LoadBorrowers();
           if( await _libaryService.borrow(borrowerId, bookId))
                return Ok();
            return StatusCode(500, "something went wrong😭");
        }
      
        [HttpPost("return")]
        public async Task<ActionResult> returnBook(string bookId)
        {
            if (await _libaryService.returnBook(bookId))
                return Ok();
            return StatusCode(500, "something went wrong😭");
        }

        [HttpGet]
        public async Task<ActionResult<User>> Get([FromQuery] string borrowerName)
        {
            await _libaryService.LoadBorrowers();
            Borrower borrower =  _libaryService.getBorrowerByName(borrowerName);
            if (borrower != null)
                return Ok(borrower);
            return NoContent();
        }

        [HttpPost("addBorrower")]
        public async Task<ActionResult<Book>> AddBorrower([FromBody] Borrower borrowerToAdd)
        {
            await _libaryService.LoadBorrowers();
            Borrower newBorrower = await _libaryService.addBorrower(borrowerToAdd);
            return Ok(newBorrower);
        }


        //    //set borrower as no-active
    }
}
