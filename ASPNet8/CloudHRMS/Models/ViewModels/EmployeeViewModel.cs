﻿using System.ComponentModel.DataAnnotations;

namespace CloudHRMS.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public string Id { get; set; }//edit,update,delete
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DOB { get; set; }

        public DateTime DOE { get; set; }
        public DateTime? DOR { get; set; }
        [Required]
        public decimal BasicSalary { get; set; }
        [Required]
        public string Gender { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string DepartmentId { get; set; }//for entry/update
        //IList<DepartmentViewModel> Departments ;//for selection box
        public string PositionId { get; set; }//for entry/update
        //IList<PositionViewModel> Positions ; 
        public string DepartmentInfo { get; set; }
        public string PositionInfo { get; set; }
    }
}
