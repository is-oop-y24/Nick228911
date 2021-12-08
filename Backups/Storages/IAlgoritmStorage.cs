using System;
using System.Collections.Generic;
using System.Text;

namespace Backups.Storages
{
    public interface IAlgoritmStorage
    {
        RestorePoint Save(List<JobObject> jobObjects, Repository repository);
    }
}
