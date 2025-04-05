using System.Runtime.CompilerServices;

namespace TakeLeaveMngSystem.Domain.Models
{
    public class ApprovalTicket
    {
        public Guid Id { get; set; }
        public string EmployeeCodeApprover { get; set; } = string.Empty; //employeeCode of approver
        public Guid TicketId { get; set; }
        public int Status { get; set; } = 0; //status pending and approval 0: pending, 1: approval
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
