﻿using System.ComponentModel.DataAnnotations;

namespace ReportsBLL.DataTransferObjects.Employees;

public class UpdateEmployeeDto
{
    [StringLength(20, MinimumLength = 1)] public string Username { get; set; }

    public ulong? SupervisorId { get; set; }
}