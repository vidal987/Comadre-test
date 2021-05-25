using System;

namespace teste_comadre.Models
{
    //ABSTRACT NÃO PODE SER INSTANCIADA, PODE SER HERDADA
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        
    }     
}