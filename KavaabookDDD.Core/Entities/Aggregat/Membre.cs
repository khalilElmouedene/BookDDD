using BookDDD.Core.Entities.Event;
using BookDDD.Core.Entities.ObjectValue;
using BookDDD.Core.Enums;
using System;
using System.Collections.Generic;
using BookDDD.Core.Base;

namespace BookDDD.Core.Entities
{
    public class Membre : User, IAggregateRoot
    {
        public virtual ICollection<Post> Posts { get; private set; }
        public virtual ICollection<Comments> Comments { get; private set; }
        public virtual ICollection<Reacts> Reacts { get; private set; }
        private readonly List<SignalMembre> _membresSignal = new List<SignalMembre>();
        public virtual IEnumerable<SignalMembre> MembresSignal => _membresSignal.AsReadOnly();
        public virtual ICollection<SignalMembre> MembresWhoSignaled { get; private set; }
        public virtual ICollection<CommentSignal> CommentSignals { get; private set; }
        public virtual ICollection<PostSignal> PostSignals { get; private set; }
        public MemberStatut MembreStatut { get; private set; }
        public Boolean IsRemove { get; private set; }
        public DateTime DateRemove { get; private set; }
        public string RemovedReason { get; private set; }
        public DateTime DateEdit { get; private set; }

        private Membre()
        {
        }

        public Membre(string fullName, DateTime birthDate, string urlPicture)
        {
            FullName = fullName;
            BirthDate = birthDate;
            UrlPicture = urlPicture;
            MembreStatut = MemberStatut.Active;
        }

        public void Update(string fullName, DateTime birthDate, string urlPicture)
        {
            FullName = fullName;
            BirthDate = birthDate;
            UrlPicture = urlPicture;
            DateEdit = DateTime.UtcNow;
        }

        public void Delete(int MembreId, string removedReason)
        {
            if (Id != MembreId) return;

            IsRemove = true;
            DateRemove = DateTime.UtcNow;
            RemovedReason = removedReason;
        }

        public void SignalMembre(int membreSignaledId, int membreWhoSignalId, string commenterSignaler)
        {
            var createMemberSignal = new SignalMembre(membreSignaledId, membreWhoSignalId, commenterSignaler);
            _membresSignal.Add(createMemberSignal);

            var addEvent = new OnSignalMembreAddedDomainEvent(createMemberSignal);

            Events.Add(addEvent);
        }

        public void Desactiver(int MembreId)
        {
            if (Id != MembreId)
            {
                return;
            }

            MembreStatut = MemberStatut.Deactivated;
            var addEvent = new OnDesactiverMembreEvent(MembreId);
            Events.Add(addEvent);
        }
    }
}