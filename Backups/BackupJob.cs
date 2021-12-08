using System.Collections.Generic;
using Backups.Storages;

namespace Backups
{
    public class BackupJob
    {
        private List<JobObject> jobObjects = new List<JobObject>();
        private List<RestorePoint> restorePoints = new List<RestorePoint>();
        private IAlgoritmStorage algoritmSorage;
        private Repository repository;

        public BackupJob(string name, IAlgoritmStorage algoritmSorage, Repository repository)
        {
            Name = name;
            this.algoritmSorage = algoritmSorage;
            this.repository = repository;
        }

        public List<RestorePoint> RestorePoints => restorePoints;

        public string Name { get; }

        public void CreateRestorePoint()
        {
            RestorePoint restorePoint = algoritmSorage.Save(jobObjects, repository);
            restorePoints.Add(restorePoint);
        }

        public void AddJobObject(string filename)
        {
            var jobObject = new JobObject(filename);
            jobObjects.Add(jobObject);
        }

        public void RemoveJobObject(string filename)
        {
            jobObjects.RemoveAll(t => t.Name == filename);
        }
    }
}
