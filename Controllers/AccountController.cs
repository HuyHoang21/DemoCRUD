using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoUI.IService;
using DemoUI.Models;
using DemoUI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoUI.Controllers
{
  [Route("api/account")]
  [ApiController]
  public class AccountController : ControllerBase
  {
    private IAccountService _oAccount;
    public AccountController(IAccountService oAccountService)
    {
      _oAccount = oAccountService;
    }
    // GET api/values/5
    [HttpGet("{id}")]
    public AccountModels Get(int id)
    {
      return _oAccount.Get(id);
    }

    // POST api/values
    [HttpPost]
    public bool Insert([FromBody] LoginModels oAccount)
    {
      return _oAccount.Insert(oAccount);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public bool Delete(int id)
    {
      return _oAccount.Delete(id);
    }
    [HttpPost("/login")]
    public AccountType Login([FromBody] LoginModels oLogin)
    {
      return _oAccount.Login(oLogin);
    }

  }
}
