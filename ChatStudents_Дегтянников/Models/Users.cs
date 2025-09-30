using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatStudents_Дегтянников.Models
{
    public class Users
    {
        public int Id { get; set; } 
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public byte[] Photo { get; set; }
        public Users(string LastName,string FirstName,string Surname, byte[] Photo)
        {
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Surname = Surname;
            this.Photo = Photo;
        }
        public string ToFIO()
        {
            return $"{LastName} {FirstName} {Surname}";
        }
    }
}
