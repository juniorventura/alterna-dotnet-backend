using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Models;

public partial class DotnetTestContext : DbContext
{
    public DotnetTestContext()
    {
    }

    public DotnetTestContext(DbContextOptions<DotnetTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.HasKey(e => e.AttachmentId).HasName("attachments_pkey");

            entity.ToTable("attachments");

            entity.HasIndex(e => e.NoteId, "attachments_note_id_idx");

            entity.HasIndex(e => e.Title, "attachments_title_idx");

            entity.Property(e => e.AttachmentId).HasColumnName("attachment_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.NoteId).HasColumnName("note_id");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
            entity.Property(e => e.Url)
                .HasColumnType("character varying")
                .HasColumnName("url");

            entity.HasOne(d => d.Note).WithMany(p => p.Attachments)
                .HasForeignKey(d => d.NoteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("notes_attachment");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.NoteId).HasName("notes_pkey");

            entity.ToTable("notes");

            entity.HasIndex(e => e.Name, "notes_name_idx");

            entity.HasIndex(e => e.UserId, "notes_user_id_idx");

            entity.Property(e => e.NoteId).HasColumnName("note_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.IsDone).HasColumnName("is_done");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
