﻿using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ReportsBLL.Models.Employees;

namespace ReportsDAL.Data.Repositories;

public class EmployeeRepository : BaseRepository<Employee>
{
    public EmployeeRepository(ReportsDbContext dbContext)
        : base(dbContext)
    {
    }

    public override async Task<bool> DeleteAsync(Employee entity)
    {
        foreach (var subordinate in entity.Subordinates) subordinate.Supervisor = entity.Supervisor;

        return await base.DeleteAsync(entity);
    }

    public override async Task<Employee?> FindAsync(Expression<Func<Employee, bool>> expression)
    {
        return await DbSet.Include(e => e.Supervisor)
            .Include(e => e.Subordinates)
            .ThenInclude(s => s.Report)
            .ThenInclude(r => r.Problems)
            .Include(e => e.Problems)
            .ThenInclude(p => p.Comments)
            .Include(e => e.Report)
            .ThenInclude(e => e.Problems)
            .FirstOrDefaultAsync(expression);
    }

    public override Task<List<Employee>> GetListAsync(Expression<Func<Employee, bool>> expression)
    {
        return DbSet.Include(e => e.Problems)
            .ThenInclude(p => p.Comments)
            .Where(expression)
            .ToListAsync();
    }
}