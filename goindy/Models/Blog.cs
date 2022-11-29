using System;
using System.Collections.Generic;

namespace MyApplication.Models
{
    public partial class Blog
    {
        public Blog()
        {
            Authors = new HashSet<Author>();
            TagsNavigation = new HashSet<Tag>();
        }

        public int Id { get; set; }
        public string ImagePath { get; set; } = null!;
        public string GameName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Tags { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Author { get; set; } = null!;
        public int Comments { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Tag> TagsNavigation { get; set; }
    }
}
