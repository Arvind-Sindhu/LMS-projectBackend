using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Model
{
    public class ApplyLeave
    {
        [Key]
        public int Id
        {
            get;
            set;
        }
        
        public string? EmployeeName
        {
            get;
            set;
        }
        public DateTime StartDate
        {
            get;
            set; 
        }
        public DateTime EndDate
        {
            get;
            set;
        }
        public string? LeaveType
        {
            get;
            set;
        }
        public string? Reason
        {
            get;
            set;
        }
    }
}
