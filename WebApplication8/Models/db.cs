using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Auth_MVC.Models
{
    public class db:DbContext
    {
        public DbSet<Signup> Signups { get; set; }
    }
}