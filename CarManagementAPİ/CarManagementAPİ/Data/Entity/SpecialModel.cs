using System.Collections.Generic;

namespace CarManagementAPİ.Data.Entity
{
    public class SpeacialModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int MarkaId { get; set; }
        public Marka Marka { get; set; }
        public ICollection<Person> Persons { get; set; }
    }
}
