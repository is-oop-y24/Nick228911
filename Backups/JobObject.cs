using System;
using System.Collections.Generic;
using System.Text;

namespace Backups
{
    public class JobObject
    {
        public JobObject(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
