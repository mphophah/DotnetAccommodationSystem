using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AMS.Models
{
    public class UploadImageViewModel
    {
        [Display(Name = "Picture")]
        public IFormFile SpeakerPicture { get; set; }
    }
}
