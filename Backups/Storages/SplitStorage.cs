using System;
using System.Collections.Generic;
using System.IO;

namespace Backups.Storages
{
    public class SplitStorage : IAlgoritmStorage
    {
        private int number = 1;

        public RestorePoint Save(List<JobObject> jobObjects, Repository repository)
        {
            var storages = new List<Storage>();
            foreach (var item in jobObjects)
            {
                string destinationName = $"{repository.Location}\\{Path.GetFileNameWithoutExtension(item.Name)}_{number}" +
                    $"{Path.GetExtension(item.Name)}";
                var storage = new Storage(destinationName);
                storage.JobObjects.Add(item);
                storages.Add(storage);
            }

            repository.CreateArchive(storages);

            number++;
            return new RestorePoint(storages);
        }
    }
}
