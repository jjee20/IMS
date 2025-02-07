using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.Accounts
{
    public class BaseEntity
    {
        [ForeignKey(nameof(AddedById))]
        public string? AddedById { get; set; }
        public ApplicationUser? AddedBy { get; set; }
        [ForeignKey(nameof(UpdatedById))]
        public string? UpdatedById { get; set; }
        public ApplicationUser? UpdatedBy { get; set; }
        [ForeignKey(nameof(DeletedById))]
        public string? DeletedById { get; set; }
        public ApplicationUser? DeletedBy { get; set; }
    }
}