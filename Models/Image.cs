namespace DeriDeveloperWebApp.Models
{

    public class Image
    {
        public long Id { get; set; }
        public string Path { get; set; } = DeriLibrary.WorkerImages.PathImageNoPhoto;

    }

}