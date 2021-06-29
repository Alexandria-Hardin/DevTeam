using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoRepo
{
    public class DevTeam
    {
        public string TeamName { get; set; }
        public int Teamid { get; set; }
        public List<Developer> listOfDevelopers = new List<Developer>();
        public DevTeam()
        { }
        public DevTeam(string teamName, int teamid)
        {
            TeamName = teamName;
            Teamid = teamid;
        }
    }
}
