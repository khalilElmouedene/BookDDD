using BookDDD.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDDD.Core.Entities.Event
{
    public class OnDesactiverMembreEvent : BaseDomainEvent
    {
        public OnDesactiverMembreEvent(int membreId)
        {
            MembreId = membreId;
        }

        public int MembreId { get; set; }
    }
}