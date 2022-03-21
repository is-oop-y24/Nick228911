using System;
using ReportsBLL.Interfaces;

public class CommentDto : IViewModel
{
    public string Content { get; set; }
    public ulong EmployeeId { get; set; }
    public DateTime CreationTime { get; set; }
}