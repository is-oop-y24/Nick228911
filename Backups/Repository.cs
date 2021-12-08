using System;
using System.Collections.Generic;
using System.Text;

namespace Backups
{
    public abstract class Repository
    {
        public Repository(string location)
        {
            Location = location;
        }

        public string Location { get; }

        public abstract void CreateArchive(List<Storage> storages);
        public abstract void CreateOneArchive(Storage storage);
    }
}
