using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Desktop.Model
{
    public class Context : DbContext
    {
        public Context() : base("BetaKP")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<TypeUser> TypesUsers { get; set; }
    }
}
