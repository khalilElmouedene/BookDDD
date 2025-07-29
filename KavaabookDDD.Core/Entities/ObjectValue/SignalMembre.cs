using BookDDD.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDDD.Core.Entities.ObjectValue
{
    public class SignalMembre : BaseEntity<int>
    {
        public int MembreSignaledId { get; set; }
        public virtual Membre MembreSignaled { get; set; }
        public int MembreWhoSignalId { get; set; }
        public virtual Membre MembreWhoSignal { get; set; }
        public string CommenterSignaler { get; set; }

        private SignalMembre()
        {
        }

        public SignalMembre(int membreSignaledId, int membreWhoSignalId, string commenterSignaler)
        {
            MembreSignaledId = membreSignaledId;
            MembreWhoSignalId = membreWhoSignalId;
            CommenterSignaler = commenterSignaler;
        }
    }
}