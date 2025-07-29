using BookDDD.Core.Entities.Admin;
using BookDDD.Core.Entities.Event;
using BookDDD.Core.Entities.ObjectValue;
using BookDDD.Core.Enums;
using System;
using System.Collections.Generic;
using BookDDD.Core.Base;

namespace BookDDD.Core.Entities
{
    public class Comments : BaseEntity<int>, IAggregateRoot
    {
        public string Comment { get; private set; }
        public int PostId { get; private set; }
        public virtual Post Post { get; set; }
        public bool IsRemove { get; private set; }
        public DateTime DateRemove { get; private set; }
        public string RemovedReason { get; private set; }
        public DateTime DateEdit { get; private set; }
        public int MembreId { get; private set; }
        public CommentaireStatut CommentaireStatut { get; private set; }
        private readonly List<CommentSignal> _commentSignal = new List<CommentSignal>();
        public IEnumerable<CommentSignal> CommentSignals => _commentSignal.AsReadOnly();

        private Comments()
        {
        }

        public Comments(string comments, int membreId, int postId)
        {
            Comment = comments;
            IsRemove = false;
            MembreId = membreId;
            PostId = postId;
            CommentaireStatut = CommentaireStatut.Active;
        }

        public void SignalComment(string reason, int membreSignalId)
        {
            var createPostSignal = new CommentSignal(reason, this.Id, this.MembreId, membreSignalId);
            _commentSignal.Add(createPostSignal);

            var addEvent = new OnCommentSignalAddedDomainEvent(createPostSignal);

            Events.Add(addEvent);
        }

        public void Update(string content)
        {
            DateEdit = DateTime.UtcNow;
            Comment = content;
        }

        public void DeleteComment(int commentId, string removedReason)
        {
            if (Id != commentId) return;

            IsRemove = true;
            DateRemove = DateTime.UtcNow;
            RemovedReason = removedReason;
        }

        public void HideComment(int commentId)
        {
            if (Id != commentId) return;
            CommentaireStatut = CommentaireStatut.Report;
            var addEvent = new OnDesactiverCommentEvant(commentId);
            Events.Add(addEvent);
        }
    }
}