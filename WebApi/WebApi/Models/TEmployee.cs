using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Models
{
    public partial class TEmployee
    {
        public string FEmpId { get; set; }
        public string FName { get; set; }
        public string FGender { get; set; }
        public string FMail { get; set; }
        public int? FSalary { get; set; }
    }
}
