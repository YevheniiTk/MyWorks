﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.DataContext
{
    public class Comment
    {
        [Key()]
        public Guid CommentId { get; private set; }


        public Guid PostId { get; set; }

        public Guid AuthorId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateData { get; set; }
                
        public string Content { get; set; }
        
        [ForeignKey("CommentId")]
        public ICollection<Like> Likes { get; set; }

        public Comment()
        {
            this.CommentId = Guid.NewGuid();
        }

    }
}
