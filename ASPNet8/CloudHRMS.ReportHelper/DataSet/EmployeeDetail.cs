﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace CloudHRMS.ReportHelper.DataSet
{
    public class EmployeeDetail
    {
        
        
        public string Code { get; set; }
       
        public string Name { get; set; }
   
        public string Email { get; set; }
      
        public DateTime DOB { get; set; }

        public DateTime DOE { get; set; }
        public DateTime? DOR { get; set; }
   
        public decimal BasicSalary { get; set; }
    
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string DepartmentInfo { get; set; }
        public string PositionInfo { get; set; }

    }
}
