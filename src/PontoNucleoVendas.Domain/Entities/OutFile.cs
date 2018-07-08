using System;

namespace PontoNucleoVendas.Domain.Entities
{
    public class OutFile : Entity
    {
        public OutFile(Guid id,
                       string content) : 
            base(id)
        {
            Content = content;
        }

        public string Content { get; }
    }
}