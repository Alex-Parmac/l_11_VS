using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucrare_lab_10.Models
{
    class StudentContext : DbContext
    {
        public DbSet<Student> Studenti { get; set; }
    }
}
