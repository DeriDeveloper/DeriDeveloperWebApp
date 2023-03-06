using System.Collections.Generic;

namespace DeriDeveloperWebApp.Models
{
    public class Soft
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PathProgram { get; set; }

        public Image? ImageProgram { get; set; }
		public Image? ImageLogo { get; set; }


	}
}
