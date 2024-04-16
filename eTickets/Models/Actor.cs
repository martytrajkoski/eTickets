using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display (Name = "Profile Picture URL")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "FullName")]
        [Required(ErrorMessage = "FullName is required")]
        [StringLength (50, MinimumLength =3, ErrorMessage = "FullName must be between 3 and 50 chars")]
        public string FullName { get; set; }
        [Display (Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]
        public string Bio { get; set; }

        //Relations
        public List<Actor_Movie> Actor_Movies{ get; set; }
    }
}
