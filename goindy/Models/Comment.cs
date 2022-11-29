using System;
using System.Collections.Generic;

namespace MyApplication.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string? Avatar { get; set; }
        public string Nickname { get; set; } = null!;
        public string Text { get; set; } = null!;
        public DateTime Data { get; set; }
        public int AnswerId { get; set; }

        public virtual Answer Answer { get; set; } = null!;
    }
}
