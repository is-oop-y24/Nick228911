using System;
using System.Collections.Generic;
using System.Text;

namespace Backups
{
    public class RestorePoint
    {
        private DateTime date;
        private List<Storage> storages = new List<Storage>();

        public RestorePoint(List<Storage> storages)
        {
            date = DateTime.Now;
            this.storages = storages;
        }

        public RestorePoint(Storage storage)
        {
            date = DateTime.Now;
            storages.Add(storage);
        }

        public List<Storage> Storages => storages;
    }
}
