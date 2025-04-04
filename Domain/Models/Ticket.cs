using System.ComponentModel.DataAnnotations.Schema;

namespace TakeLeaveMngSystem.Domains.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }
        public string? EmployeeCode { get; set; }
        public string? Name { get; set; }
        public string? Reason { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int Status { get; set; } = 1; //1,2,3,4, created, pending, complete, reject
        public int TypeLeave {  get; set; } //1. nghi ca ngay co phep, nghi sang co phep, nghi chieu co phep, nghi khong luong, nghi om, nghi thai san, nghi,...

        [Column(TypeName = "nvarchar(max)")]
        public List<ApprovalStep?>? Process { get; set; } = [];
        public string? MetaData { get; set; } = "{}";
        public string? Image {  get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }

    public class ApprovalStep
    {
        public string? Approver { get; set; } = string.Empty;
        public DateTime? ApprovedAt { get; set; }
        public string? Status { get; set; } = "Created"; // "Created", "Pending", "Approved", "Rejected", "Register Complete",...
    }
}
