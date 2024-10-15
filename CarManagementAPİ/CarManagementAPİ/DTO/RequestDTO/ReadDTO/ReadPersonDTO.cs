using System;

namespace CarManagementAPİ.DTO.RequestDTO.ReadDTO
{
    public class ReadPersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int? SpecialModelId { get; set; }
    }
}
