using System;
using System.Collections.Generic;

namespace EvaluacionAdvanced.Data.Context
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
    }
}
