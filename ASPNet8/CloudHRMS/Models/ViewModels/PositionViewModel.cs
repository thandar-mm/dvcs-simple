using System.ComponentModel.DataAnnotations;

namespace CloudHRMS.Models.ViewModels
{
    public class PositionViewModel
    {
        public string Id { get; set; }//edit,update,delete
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Level { get; set; }
    }
}
