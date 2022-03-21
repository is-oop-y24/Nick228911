﻿using System.ComponentModel.DataAnnotations;
using ReportsBLL.Models.Employees;
using ReportsBLL.Tools;
using ReportsBLL.Tools.Exceptions;

namespace ReportsBLL.Models.Problems;

public class Comment : BaseEntity
{
    protected Comment()
    {
    }

    public Comment(string content, ISubordinate employee, Problem problem)
    {
        if (string.IsNullOrEmpty(content))
            throw new DomainException(
                "Comment's content can't be null or empty!",
                new ArgumentNullException(nameof(content)));
        Content = content;

        Employee = employee ?? throw new DomainException(
            "Assigned employee can't be null!",
            new ArgumentNullException(nameof(employee)));
        EmployeeId = employee.Id;

        if (employee.Problems.All(p => !p.Equals(problem)))
            throw new DomainException(
                $"Employee {employee.Username} not assigned for problem Id={problem.Id}!");

        Problem = problem ?? throw new DomainException(
            "Commenting problem can't be null!",
            new ArgumentNullException(nameof(problem)));
        ProblemId = problem.Id;
    }

    public string Content { get; }
    public DateTime CreationTime { get; } = DateTime.Now;

    public IPerson Employee { get; }
    public ulong EmployeeId { get; }

    public Problem Problem { get; }
    public ulong ProblemId { get; }
}