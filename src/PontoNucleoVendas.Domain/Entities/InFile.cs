using System;

namespace PontoNucleoVendas.Domain.Entities
{
    public class InFile : Entity
    {
        public InFile(int id,
                      string content) : 
            base(id)
        {
            Content = content;
        }

        public string Content { get; }
    }
}