using BookDDD.Application.Contracts;
using BookDDD.Core.Entities;
using BookDDD.Core.Entities.Event;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookDDD.Application.Handlers
{
    public class DesactivatePostHandler : INotificationHandler<OnPostDesactiveDomainEvent>
    {
        private readonly IRepository<Comments> _repository;

        public DesactivatePostHandler(IRepository<Comments> repository)
        {
            _repository = repository;
        }

        public async Task Handle(OnPostDesactiveDomainEvent notification, CancellationToken cancellationToken)
        {
            var list = await _repository.ListAsync();
            var listForDesactive = list.Where(p => p.PostId == notification.PostId).ToList();

            for (int i = 0; i < listForDesactive.Count; i++)
            {
                var comment = listForDesactive[i];
                comment.DeleteComment(comment.Id, "Something else");
                await _repository.UpdateAsync(comment);
            }
        }
    }
}