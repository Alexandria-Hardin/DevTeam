using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoRepo
{
        //POCO
        public class Developer
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string FullName
            {
                get
                {
                    string fullName = FirstName + " " + LastName;
                    return fullName;
                }
            }
            public int Devid { get; set; }
            public bool HasPluralSightAccess { get; set; }

            public Developer()
            { }
            public Developer(string firstName, string lastName, bool hasPluralSightAccess, int developerid)
            {
                FirstName = firstName;
                LastName = lastName;
                Devid = developerid;
                HasPluralSightAccess = hasPluralSightAccess;
            }
        }
}
