﻿using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.Models
{
    public class Room_History
    {
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; }
        [Column(TypeName = "tinyint")]
        public int? status { get; set; }
        public int? RoomId { get; set; }
        public Room? Room { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
