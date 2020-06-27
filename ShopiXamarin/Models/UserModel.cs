using System;
namespace ShopiXamarin.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }


        public string FullName { get => $"{Name}{Surname}"; }
        public int Age { get => (int.Parse(DateTime.UtcNow.ToString("yyyyMMdd")) - int.Parse(BirthDate.ToString("yyyyMMdd"))) / 1000; }
    }
}
