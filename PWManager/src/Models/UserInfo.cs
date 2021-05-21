using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWManager.src.Models
{
    class UserInfo
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public DirectoryInfo PWManagmentDIR { get; set; }
    }
}
