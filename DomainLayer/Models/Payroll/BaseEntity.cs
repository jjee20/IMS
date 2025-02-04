using DomainLayer.Models.Accounts;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainLayer.Models.Payroll
{
    public class BaseEntity
    {
        [ForeignKey(nameof(AddedById))]
        public string AddedById { get; set; }
        public ApplicationUser AddedBy { get; set; }
        [ForeignKey(nameof(UpdatedId))]
        public string UpdatedId { get; set; }
        public ApplicationUser Updated { get; set; }
        [ForeignKey(nameof(DeletedId))]
        public string DeletedId { get; set; }
        public ApplicationUser Deleted { get; set; }
    }
}