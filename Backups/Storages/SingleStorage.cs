using System;
using System.Collections.Generic;
using System.Text;

namespace Backups.Storages
{
    public class SingleStorage : IAlgoritmStorage
    {
        private int number = 1;

        public RestorePoint Save(List<JobObject> jobObjects, Repository repository)
        {
            var storage = new Storage($"{repository.Location}\\AllArchive_{number}");
            storage.JobObjects.AddRange(jobObjects);
            number++;

            repository.CreateOneArchive(storage);
            return new RestorePoint(storage);
        }
    }
}
