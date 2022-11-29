using System;
using System.Collections.Generic;

namespace MyApplication.Models
{
    public partial class Tag
    {
        public Tag()
        {
            Blogs = new HashSet<Blog>();
        }

        public int Id { get; set; }
        public string Tag1 { get; set; } = null!;
        public int BlogId { get; set; }
        public int AnswerId { get; set; }
        public int ProjectsId { get; set; }

        public virtual Answer Answer { get; set; } = null!;

        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
