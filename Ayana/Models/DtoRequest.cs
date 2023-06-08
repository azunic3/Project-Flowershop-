using System.ComponentModel.DataAnnotations;
using Ayana.Data;

namespace Ayana.Models
{
    public class DtoRequest
    {
        [Key]
        public int DtoRequestID { get; set; }
        public Subscription subscription { get; set; }
        public Payment payment { get; set; }

        public ApplicationUser customer{ get; set; }

    }
}
