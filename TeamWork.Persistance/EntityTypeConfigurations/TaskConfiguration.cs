using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeamWork.Domain.Entities;

namespace TeamWork.Persistence.EntityTypeConfigurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasIndex(t => t.Title).IsUnique();
            builder.Property(t => t.Title).IsRequired().HasMaxLength(200);
            builder.Property(t => t.Description)
                .HasMaxLength(10000);

            builder.Property(t => t.Status)
                .HasConversion<string>();

            builder.Property(t => t.Priority)
                .HasConversion<string>();

            builder.Property(t => t.DueDate)
                .HasDefaultValueSql("NOW()");
        }
    }
}
