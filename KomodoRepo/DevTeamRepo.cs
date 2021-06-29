using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoRepo
{
    public class DevTeamRepo
    {
        protected readonly List<DevTeam> _contentDirectory = new List<DevTeam>();
        public bool AddDevTeam(DevTeam newContent)
        {
            int startingCount = _contentDirectory.Count;
            _contentDirectory.Add(newContent);
            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<DevTeam> GetContents()
        {
            return _contentDirectory;
        }

        public DevTeam FindDeveloperTeamByTeamName(string teamName)
        {
            foreach (DevTeam content in _contentDirectory)
            {

                if (content.TeamName.ToLower() == teamName.ToLower())
                {
                    return content;
                }
            }
            return null;
        }
        public bool UpdateDeveloperTeam(string originalName, DevTeam newContent)
        {
            DevTeam oldContent = FindDeveloperTeamByTeamName(originalName);
            if (oldContent != null)
            {
                oldContent.TeamName = newContent.TeamName;
                oldContent.Teamid = newContent.Teamid;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveDeveloperTeam(DevTeam existingContent)
        {
            bool deleteResult = _contentDirectory.Remove(existingContent);
            return deleteResult;
        }
    }
}
