using System;
using System.Collections.Generic;

namespace MyApplication.Models
{
    public partial class Author
    {
        public Author()
        {
            Profiles = new HashSet<Profile>();
            Blogs = new HashSet<Blog>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Projects { get; set; }
        public int BlogId { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
