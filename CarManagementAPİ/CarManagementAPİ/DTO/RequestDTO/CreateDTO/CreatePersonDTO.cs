using System;

namespace CarManagementAPİ.DTO.RequestDTO.CreateDTO
{
    public class CreatePersonDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int? SpecialModelId { get; set; }
    }
}
