using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucrare_lab_10.Models
{
    class Student
    {
        [Key]
        public int NrMatricol { get; set; }
        public String Prenume { get; set; }
        public String Nume { get; set; }
        public double Medie { get; set; }
    }
}
