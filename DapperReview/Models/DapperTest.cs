using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperReview.Models
{
    public class DapperTest
    {
        public int? Id { get; set; }      // Databse deyaptigimiz duzen ve isimler le ayni olmali, ? koyduk yanina cunku propda sadece isim gostermek istiyoruz
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }

        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {Age} {Gender}";
            /*return $" {FirstName} {LastName}  {Gender}";*/      // propramda sadece isimleri gostermek icin Id ve age'i Tostring den cikaricaz
        }
    }
}
