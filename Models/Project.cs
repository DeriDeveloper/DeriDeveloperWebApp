using System.Collections.Generic;

namespace DeriDeveloperWebApp.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Image> ImagesPriview { get; set; } = new List<Image>();


    }
}
