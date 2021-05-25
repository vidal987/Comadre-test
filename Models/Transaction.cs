using System;

namespace teste_comadre.Models
{
    public class Transaction : BaseEntity
    {
        public int IdSender { get; set; }
        public int IdReceiver { get; set; }
        public decimal Value  { get;  set; }
        public bool IsCanceled { get; set; }
        
    }
}