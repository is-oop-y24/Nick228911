using System.ComponentModel.DataAnnotations;

public class UpdateEmployeeDto
{
    [StringLength(20, MinimumLength = 1)] public string Username { get; set; }

    public ulong? SupervisorId { get; set; }
}