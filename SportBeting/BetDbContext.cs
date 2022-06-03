using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportBeting
{
    internal class BetDbContext: DbContext
    {

        public DbSet<SportBeting.Models.Teszt> teszts { get; set; }
    }
}
