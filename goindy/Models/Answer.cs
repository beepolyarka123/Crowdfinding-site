using System;
using System.Collections.Generic;

namespace MyApplication.Models
{
    public partial class Answer
    {
        public Answer()
        {
            CommentsNavigation = new HashSet<Comment>();
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Info { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int TagsId { get; set; }
        public string Comments { get; set; } = null!;

        public virtual ICollection<Comment> CommentsNavigation { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
