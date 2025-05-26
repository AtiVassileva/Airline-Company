using System.ComponentModel.DataAnnotations;

namespace AirlineCompany.Models
{
    public class BaseEntity
    {
        [Required]
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime LastModifiedOn { get; set; }

        [Timestamp]
        public byte[] VersionNo { get; set; } = null!;
    }
}