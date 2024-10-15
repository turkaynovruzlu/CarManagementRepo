using System;

namespace CarManagementAPİ.Data.Entity
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int? SpecialModelId { get; set; }
        public SpeacialModel SpeacialModel { get; set;}
   }
}