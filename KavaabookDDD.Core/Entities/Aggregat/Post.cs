using BookDDD.Core.Entities.Event;
using BookDDD.Core.Entities.ObjectValue;
using BookDDD.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using BookDDD.Core.Base;

namespace BookDDD.Core.Entities
{
    public class Post : BaseEntity<int>, IAggregateRoot
    {
        public string Content { get; private set; }
        public string UrlsImg { get; private set; }
        public Boolean IsRemove { get; private set; }
        public DateTime DateRemove { get; private set; }
        public string RemovedReason { get; private set; }
        public DateTime DateEdit { get; private set; }
        public int MembreId { get; private set; }
        public PostStatut PostStatuts { get; private set; }

        public IEnumerable<Reacts> Reacts => _postreact.AsEnumerable();
        private readonly List<Reacts> _postreact = new List<Reacts>();



        private readonly List<PostSignal> _postSignals = new List<PostSignal>();
        public IEnumerable<PostSignal> PostSignals => _postSignals.AsReadOnly();



        public virtual ICollection<Comments> Comments { get; private set; }

        private Post()
        {
        }

        public Post(string content, string urlsImg, int membreId, Boolean isRemove)
        {
            Content = content;
            UrlsImg = urlsImg;
            MembreId = membreId;
            PostStatuts = PostStatut.Active;
            IsRemove = isRemove;
        }

        public void SignalPost(string reason, int postId, int membreId, int membreSignalId)
        {
            var createPostSignal = new PostSignal(reason, this.Id, membreId, membreSignalId);
            _postSignals.Add(createPostSignal);

            var addEvent = new OnSignalPostAddedDomainEvent(createPostSignal);

            Events.Add(addEvent);
        }

        private void React(int typeReact, int membreId, int postId)
        {
            var rctAdd = new Reacts(typeReact, membreId, postId);
            _postreact.Add(rctAdd);
        }

        public void Update(string content, string urlsImg)
        {
            DateEdit = DateTime.UtcNow;
            Content = content;
            UrlsImg = urlsImg;
        }

        public void DeletePost(int postId, string removedReason)
        {
            if (Id != postId) return;

            IsRemove = true;
            DateRemove = DateTime.UtcNow;
            RemovedReason = removedReason;
        }

        public void HidePost(int postId)
        {
            if (Id != postId) return;
            PostStatuts = PostStatut.Deactivated;

            var addEvent = new OnPostDesactiveDomainEvent(postId);
            Events.Add(addEvent);
        }

        public void DisReact(int postId, int membreId, int typeReact, Reacts reacts)
        {
            if (postId == reacts?.PostId)
            {
                if (reacts?.TypeReact == typeReact)
                {
                    _postreact.Remove(reacts);
                }
                else
                {
                    _postreact.Remove(reacts);
                    React(typeReact, membreId, postId);
                }
            }
            else
            {
                _postreact.Remove(reacts);
                React(typeReact, membreId, postId);
            }

        }
    }
}