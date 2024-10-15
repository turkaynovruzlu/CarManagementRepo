using System.Collections.Generic;

namespace CarManagementAPİ.Data.Entity
{
    public class Marka
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<SpeacialModel> SpeacialModels { get; set; }
    }
}
