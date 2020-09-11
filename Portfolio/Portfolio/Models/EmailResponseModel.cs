using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portfolio.Models
{
    public class EmailResponseModel
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public bool State { get; set; }
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
    }
}