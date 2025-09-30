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

        public Users() { }

        public Users(string lastName, string firstName, string surname, byte[] photo)
        {
            LastName = lastName;
            FirstName = firstName;
            Surname = surname;
            Photo = photo;
        }

        public string ToFIO()
        {
            return $"{LastName} {FirstName} {Surname}";
        }
    }
}
