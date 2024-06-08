using System.ComponentModel.DataAnnotations;

namespace CloudHRMS.Models.ViewModels
{
    public class DepartmentViewModel
    {
        public string Id { get; set; }//edit,update,delete
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string? ExtensionPhone { get; set; }

        public int TotalEmployeeCount { get; set; }
    }
}
