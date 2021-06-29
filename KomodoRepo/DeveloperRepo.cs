using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoRepo
{
    public class DeveloperRepo
    {
        protected readonly List<Developer> _contentDirectory = new List<Developer>();
        public bool AddContentToDirectory(Developer newContent)
        {
            int startingCount = _contentDirectory.Count;
            _contentDirectory.Add(newContent);
            bool wasAdded = (_contentDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        public List<Developer> GetContents()
        {
            return _contentDirectory;
        }

        public Developer FindDeveloperByName(string fullName)
        {
            foreach (Developer content in _contentDirectory)
            {

                if (content.FullName.ToLower() == fullName.ToLower())
                {
                    return content;
                }
            }
            return null;
        }
        public bool UpdateDeveloper(string originalName, Developer newContent)
        {
            Developer oldContent = FindDeveloperByName(originalName);
            if (oldContent != null)
            {
                oldContent.FirstName = newContent.FirstName;
                oldContent.LastName = newContent.LastName;
                oldContent.Devid = newContent.Devid;
                oldContent.HasPluralSightAccess = newContent.HasPluralSightAccess;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveDeveloper(Developer existingContent)
        {
            bool deleteResult = _contentDirectory.Remove(existingContent);
            return deleteResult;
        }
    }
}
