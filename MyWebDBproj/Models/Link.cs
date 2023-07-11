using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebDBproj.Models
{
    public class Link
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Creation Date")]
        public DateTime creationDate { get; set; }
        [Display(Name = "Link")]
        public string? link { get; set; }
        [Display(Name = "Description")]
        public string description { get; set; } = "";

        [Display(Name = "Type")]
        public string type { get; set; } = "";
    }
}
