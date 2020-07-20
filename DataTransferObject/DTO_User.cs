using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluacionAdvanced.DataTransferObject
{
    public class DTO_User
    {
        public DTO_User()
        {

        }

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
    }
}
