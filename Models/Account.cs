using System;

namespace teste_comadre.Models
{
    public class Account : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DocumentId { get; set; }
        public decimal InitialBalance { get; set; }
        public int UserId { get; set; }
    }

    
}