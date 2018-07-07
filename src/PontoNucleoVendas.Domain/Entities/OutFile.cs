using System;

namespace PontoNucleoVendas.Domain.Entities
{
    public class OutFile : Entity
    {
        public OutFile(int id,
                       string content) : 
            base(id)
        {
            Content = content;
        }

        public string Content { get; }
    }
}