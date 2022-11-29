using System;
using System.Collections.Generic;

namespace MyApplication.Models
{
    public partial class Profile
    {
        public int Id { get; set; }
        public string? Avatar { get; set; }
        public string Nickname { get; set; } = null!;
        public string? About { get; set; }
        public int? Projects { get; set; }
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; } = null!;
    }
}
