﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Notification
    {
        public int Id { get; set; }
        [Column(TypeName = "tinyint")]
        public int Type { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Title { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string? Content { get; set; }
        public string? Sender { get; set; }
        [Column(TypeName = "tinyint")]
        public int Status { get; set; }
    }
    
}
