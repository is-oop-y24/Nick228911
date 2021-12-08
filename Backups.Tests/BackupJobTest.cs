using Backups.Storages;
using NUnit.Framework;

namespace Backups.Tests
{
    public class BackupJobTest
    {
        [Test]
        public void Test1()
        {
            var backupJob = new BackupJob("A", new SplitStorage(), new TestRepository(""));
            backupJob.AddJobObject("File1");
            backupJob.AddJobObject("File2");
            backupJob.CreateRestorePoint();
            backupJob.RemoveJobObject("File1");
            backupJob.CreateRestorePoint();

            Assert.AreEqual(2, backupJob.RestorePoints.Count);

            int countStorages = backupJob.RestorePoints[0].Storages.Count + backupJob.RestorePoints[1].Storages.Count;
            Assert.AreEqual(3, countStorages);
        }
    }
}
