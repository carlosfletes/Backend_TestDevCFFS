using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDevAPI.DTO
{
    public class CambiarPasswordDTO
    {
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}
