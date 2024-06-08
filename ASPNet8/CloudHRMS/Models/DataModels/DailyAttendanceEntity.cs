using System.ComponentModel.DataAnnotations.Schema;

namespace CloudHRMS.Models.DataModels
{
    [Table("DailyAttendance")]
    public class DailyAttendanceEntity:BaseEntity
    {
        public DateTime AttendanceDate { get; set; }
        public TimeSpan InTime { get; set; }
        public TimeSpan OutTime { get; set; }

        [ForeignKey("EmployeeId")]
        public string EmployeeId { get; set; }
        public virtual EmployeeEntity Employee { get; set; }
        [ForeignKey("DepartmentId")]
        public string DepartmentId { get; set; }
        public virtual DepartmentEntity Department { get; set; }

    }
}
