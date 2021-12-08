using Backups.Storages;

namespace Backups
{
    internal class Program
    {
        private static void Main()
        {
            var backupJob = new BackupJob("back1", new SingleStorage(), new DirectoryRepository(@"C:\Audio\Backups"));
            backupJob.AddJobObject(@"C:\Audio\Source\fileA.txt");
            backupJob.AddJobObject(@"C:\Audio\Source\fileB.txt");
            backupJob.AddJobObject(@"C:\Audio\Source\fileC.txt");

            backupJob.CreateRestorePoint();
        }
    }
}
