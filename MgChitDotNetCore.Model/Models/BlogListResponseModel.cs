using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgChitDotNetCore.Model.Models
{
    public class BlogListResponseModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
