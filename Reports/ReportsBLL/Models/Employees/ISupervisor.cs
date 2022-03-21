using System.Collections.Generic;

namespace ReportsBLL.Models.Employees
{
    public interface ISupervisor : IPerson
    {
        IEnumerable<ISubordinate> Subordinates { get; }
        void AddSubordinate(ISubordinate subordinate);
        void AddSubordinate(string username);
        bool TryRemoveSubordinate(ISubordinate subordinate);
    }
}