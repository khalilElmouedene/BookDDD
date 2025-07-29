using BookDDD.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookDDD.Infrastructure.Data.Config
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasMany(p => p.Reacts).WithOne(o => o.Post).HasForeignKey(u => u.PostId).OnDelete(DeleteBehavior.ClientCascade);
            builder.HasMany(p => p.Comments).WithOne(o => o.Post).HasForeignKey(u => u.PostId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.PostSignals).WithOne(o => o.Post).HasForeignKey(u => u.PostId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}