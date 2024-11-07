using GraphQLApiDemo.Data;
using GraphQLApiDemo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDetailsRepository repo;
        public UserController(UserDetailsRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var user = repo.GetAll();
            return Ok(user);
        }
        [HttpGet("{EmpCode}")]
        public IActionResult GetByEmpcode(string EmpCode)
        {
            var user = repo.GetByEmpcode(EmpCode);
            return Ok(user);
        }
        [HttpPost]
        public IActionResult Add([FromBody] UserDetail user)
        {
            repo.Add(user);
            return StatusCode(200, "User Added Successfully.");
        }
        [HttpPut("{EmpCode}")]
        public IActionResult Update([FromBody] UserDetail User, string EmpCode)
        {
            repo.Update(User,EmpCode);
            return StatusCode(200, "");
        }
        [HttpDelete("{EmpCode}")]
        public IActionResult Delete(string EmpCode)
        {
            repo.Delete(EmpCode);
            return StatusCode(200, "");
        }
    }
}
