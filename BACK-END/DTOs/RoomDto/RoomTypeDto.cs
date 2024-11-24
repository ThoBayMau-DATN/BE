using BACK_END.Models;
using Org.BouncyCastle.Pqc.Crypto.Picnic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACK_END.DTOs.RoomDto
{
    public class RoomTypeDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Area { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int NewPrice { get; set; }
        public float Rating { get; set; }
        public int TotalRoom { get; set; }
        public int TotalUser { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; } = DateTime.Now;
        public int? Status { get; set; }
        public virtual List<RoomTypeDto_Room>? Rooms { get; set; }
        public virtual List<RoomImageDto>? Images { get; set; }
        public virtual RoomTypeDto_Motel? Motel { get; set; }
    }

    public class RoomTypeDto_Motel
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public float Rating { get; set; }
        public int TotalRoom { get; set; }
        public int TotalUser { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }

    public class RoomTypeDto_Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int? TotalUser { get; set; }
        public int Status { get; set; }
    }

}
