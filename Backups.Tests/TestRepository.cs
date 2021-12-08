using System;
using System.Collections.Generic;
using System.Text;

namespace Backups.Tests
{
    public class TestRepository : Repository
    {
        public TestRepository(string location) : base(location)
        {
        }

        public override void CreateArchive(List<Storage> storages)
        {
        }

        public override void CreateOneArchive(Storage storage)
        {
        }
    }
}
