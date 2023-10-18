using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int TypeUserId { get; set; }
        public virtual TypeUser TypeUser { get; set; }

        // пользовательские свойства
        public string Fio { get { return $"{FirstName} {MiddleName} {LastName}"; } }
    }
}
