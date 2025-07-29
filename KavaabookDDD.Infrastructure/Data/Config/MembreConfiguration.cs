using BookDDD.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookDDD.Infrastructure.Data.Config
{
    internal class MembreConfiguration : IEntityTypeConfiguration<Membre>
    {
        public void Configure(EntityTypeBuilder<Membre> builder)
        {
            builder.HasMany(p => p.MembresSignal).WithOne(o => o.MembreSignaled).HasForeignKey(u => u.MembreSignaledId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.MembresWhoSignaled).WithOne(o => o.MembreWhoSignal).HasForeignKey(u => u.MembreWhoSignalId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.PostSignals).WithOne(o => o.Membre).HasForeignKey(u => u.MembreId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.MembresSignal).WithOne(o => o.MembreSignaled).HasForeignKey(u => u.MembreSignaledId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.CommentSignals).WithOne(o => o.MembreOwnerComment).HasForeignKey(u => u.MembreId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}