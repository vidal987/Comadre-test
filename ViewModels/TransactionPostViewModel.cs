using System;

namespace teste_comadre.ViewModels
{
    public class TransactionPostViewModel 
    {
        public int IdSender { get; set; }
        public int IdReceiver { get; set; }
        public decimal Value  { get;  set; }
    }
}