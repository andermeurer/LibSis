using System;
using LibSis.Domain.Core.Commands;

namespace LibSis.Domain.Commands
{
    public abstract class BookCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Author { get; protected set; }
    }
}