using Business.Abstract;
using Business.Concreate;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        IUserService _userService;
        public TestController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("{id}/{a}")]
        public ActionResult Test([FromRoute]string id,string a)
        {
            return Ok();
        }
        [HttpPost("IncreaseCount")]
        public async Task<ActionResult> Increase()
        {
            var result = await _userService.GetCount();
            User user=result.Data;
            user.CounterNumber++;
            await _userService.UpdateCount(user);
            return Ok();
        }

        [HttpPost("add")]
        public async Task<ActionResult> AddUser(User user)
        {
            var result=await  _userService.Add(user);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet()]
        public async Task<ActionResult> Get()
        {
            var result= await _userService.GetCount();
            if (result.Success)
            {
                return Ok(result.Data.CounterNumber);
            }
            return BadRequest();
        }
    }
}
