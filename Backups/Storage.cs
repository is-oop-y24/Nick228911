using System;
using System.Collections.Generic;
using System.Text;

namespace Backups
{
    public class Storage
    {
        public Storage(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public List<JobObject> JobObjects { get; set; } = new List<JobObject>();
    }
}
