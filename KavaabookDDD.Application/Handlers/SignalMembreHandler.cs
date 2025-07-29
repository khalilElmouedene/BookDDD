using BookDDD.Application.Contracts;
using BookDDD.Core.Entities;
using BookDDD.Core.Entities.Event;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookDDD.Application.Handlers
{
    public class SignalMembreHandler : INotificationHandler<OnDesactiverMembreEvent>
    {
        private readonly IRepository<Post> _postRepository;
        private readonly IRepository<Comments> _commentsrepository;

        public SignalMembreHandler(IRepository<Post> postRepository, IRepository<Comments> commentsrepository)
        {
            _postRepository = postRepository;
            _commentsrepository = commentsrepository;
        }

        public async Task Handle(OnDesactiverMembreEvent notification, CancellationToken cancellationToken)
        {
            var list = await _postRepository.ListAsync();
            var listForDesactive = list.Where(p => p.MembreId == notification.MembreId).ToList();

            for (int i = 0; i < listForDesactive.Count; i++)
            {
                var post = listForDesactive[i];
                post.DeletePost(post.Id, "Something else");
                await _postRepository.UpdateAsync(post);
            }

            var listcommenter = await _commentsrepository.ListAsync();
            var listForDesactiveComment = listcommenter.Where(p => p.MembreId == notification.MembreId).ToList();

            for (int i = 0; i < listForDesactiveComment.Count; i++)
            {
                var comment = listForDesactiveComment[i];
                comment.DeleteComment(comment.Id, "Something else");
                await _commentsrepository.UpdateAsync(comment);
            }
        }
    }
}