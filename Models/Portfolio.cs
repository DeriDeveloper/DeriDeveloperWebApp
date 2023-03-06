using System;
using System.Collections.Generic;

namespace DeriDeveloperWebApp.Models
{
	public class Portfolio
	{
        public List<Category> categories { get; set; }

		public class Category
		{
			public long Id { get; set; }
			public string Title { get; set; }


			public List<Work> Works {get;set;}
		
			


        }

        public class Work
        {
            public long Id { get; set; }
            public long CategoryId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime Date { get; set; }
            public int NumberOfViews { get; set; }
            public List<Image> Images { get; set; }

            public List<Review> Reviews { get; set; }




        }

        public class Review
        {
            public long Id { get; set; }
            public long WorkId { get; set; }
            public string PathAvatar { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public int Estimation { get; set; }
            public string PathEmojiEstimation { get; set; }
            public DateTime Date { get; set; }
        }

        public class Image
        {
            public long Id { get; set; }
            public string Path { get; set; }
        }

    }

}
