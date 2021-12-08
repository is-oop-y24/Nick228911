using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Backups
{
    public class DirectoryRepository : Repository
    {
        public DirectoryRepository(string directoryName)
            : base(directoryName)
        {
        }

        public override void CreateArchive(List<Storage> storages)
        {
            foreach (var item in storages)
            {
                string path = Path.ChangeExtension(item.Name, ".zip");

                using (ZipArchive archive = ZipFile.Open(path, ZipArchiveMode.Create))
                {
                    archive.CreateEntryFromFile(item.JobObjects[0].Name, Path.GetFileName(item.Name));
                }
            }
        }

        public override void CreateOneArchive(Storage storage)
        {
            string path = storage.Name + ".zip";
            using (ZipArchive archive = ZipFile.Open(path, ZipArchiveMode.Create))
            {
                foreach (var item in storage.JobObjects)
                {
                    archive.CreateEntryFromFile(item.Name, Path.GetFileName(item.Name));
                }
            }
        }
    }
}
