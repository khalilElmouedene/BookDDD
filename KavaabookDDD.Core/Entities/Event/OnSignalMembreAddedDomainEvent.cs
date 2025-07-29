using BookDDD.Core.Entities.ObjectValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDDD.Core.Base;

namespace BookDDD.Core.Entities.Event
{
    public class OnSignalMembreAddedDomainEvent : BaseDomainEvent
    {
        public OnSignalMembreAddedDomainEvent(SignalMembre signalMembre)
        {
            SignalMembre = signalMembre;
        }

        public SignalMembre SignalMembre { get; set; }
    }
}