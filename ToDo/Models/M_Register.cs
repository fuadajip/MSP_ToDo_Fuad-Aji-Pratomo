using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes;

namespace ToDo.Models
{
    class M_Register
    {
        [PrimaryKey, AutoIncrement]
        public int Id { set; get; }
        public String Fullname { set; get; }
        public String Email { set; get; }
        public String Password { set; get; }
        public String CreatedAt { set; get; }
        public String UpdatedAt { set; get; }
    }
}
