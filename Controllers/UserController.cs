using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoUI.IService;
using DemoUI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoUI.Controllers
{
  [Route("api/user")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private IUserService _oUserService;
    public UserController(IUserService oUserService)
    {
      _oUserService = oUserService;
    }
    // GET: api/values
    [HttpGet]
    public IEnumerable<UserModel> Get()
    {
      return _oUserService.Get();
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public UserModel Get(int id)
    {
      return _oUserService.Get(id);
    }

    // POST api/values
    [HttpPost]
    public UserModel Post([FromBody] UserModel oUser)
    {
      return _oUserService.Insert(oUser);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public UserModel Delete(int id)
    {
      return _oUserService.Delete(id);
    }
  }
}
