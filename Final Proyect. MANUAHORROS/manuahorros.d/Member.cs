using manuahorros.D;

namespace manuahorros.D
{
    public class Member : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string StudentId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public DateTime JoinedAt { get; set; }
        public bool IsActive { get; set; }

        public Member()
        {
            JoinedAt = DateTime.Now;
            IsActive = true;
        }

        public Member(string fullName, string studentId) : this()
        {
            FullName = fullName;
            StudentId = studentId;
        }
    }
}
