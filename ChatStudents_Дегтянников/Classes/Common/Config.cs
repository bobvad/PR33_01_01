using Microsoft.EntityFrameworkCore;
namespace ChatStudents_Дегтянников.Classes.Common
{
    public class Config
    {
        //public static readonly string config = "Server=student.permaviat.ru;Trusted_Connection=No;DataBase=;User=;PWD=;";
        public static string ConnectionConfig = "server=127.0.0.1;uid=root;pwd=; database=ChatMessage";
        public static MySqlServerVersion Version = new MySqlServerVersion(new Version(8, 0, 11));
    }
}
