using System;
using Microsoft.EntityFrameworkCore;
using CrudApi.Models;

namespace CrudApi.Database
{
    public class UserContext : DbContext
    {
        public UserContext()
        {
        }
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
        public DbSet<User> TUser { get; set; }

    }
}
