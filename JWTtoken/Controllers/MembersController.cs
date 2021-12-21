using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

using JWTtoken;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTtokenControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IJwtAuth jwtAuth;
        private List<Member1> OneMember = new List<Member1>()
        {
            new Member1(){ Id = 1, Name = "Sankeerth" },
            new Member1() {Id=2, Name="Nitya" },
            new Member1(){ Id = 3, Name = "pankaj" } };

        // GET: api/<MembersController>
        public MembersController(IJwtAuth jwtAuth)
        {
            this.jwtAuth = jwtAuth;
        }

        [HttpGet]
        public IEnumerable<Member1> AllMembers() => (IEnumerable<Member1>)OneMember;

        // GET api/<MembersController>/5
        [HttpGet("{id}")]
        public Member1 MemberByid(int id) =>OneMember.Find(s => s.Id == id);
        

// POST api/<MembersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MembersController>/5
        [AllowAnonymous]
        // POST api/<MembersController>
        [HttpPost("authentication")]
        public IActionResult Authentication([FromBody] UserCredential userCredential)
        {
            var token = jwtAuth.Authentication(userCredential.UserName, userCredential.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
//IActionResult Ok(object token)
//{
//    throw new NotImplementedException();
//}