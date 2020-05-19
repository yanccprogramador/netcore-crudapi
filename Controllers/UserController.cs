using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudApi.Database;
using CrudApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace crudapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private ILogger<UserController> _logger;
        private readonly UserContext _context;

        public UserController(ILogger<UserController> logger,UserContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.TUser.ToList();
        }
        [HttpGet("id/{id}")]
        public User GetById(int id)
        {
            return _context.TUser.FirstOrDefault(i =>i.Id == id );
        }
        [HttpPut("id/{id}")]
        public IEnumerable<User> update(int id,[FromBody] User body)
        {
            body.Id=id;
            _context.TUser.Update(body);
            _context.SaveChanges();
            return _context.TUser.ToList();
        }

        [HttpDelete("id/{id}")]
        public IEnumerable<User> delete(int id)
        {
            _context.TUser.Remove(_context.TUser.FirstOrDefault(i =>i.Id == id ));
            _context.SaveChanges();
            return _context.TUser.ToList();
        }
        [HttpPost]
        public IEnumerable<User> save([FromBody] User body)
        {
            _context.Add(body);
            _context.SaveChanges();
            return _context.TUser.ToList();
        }
    }
}
