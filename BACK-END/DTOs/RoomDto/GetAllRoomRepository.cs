using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACK_END.DTOs.RoomDto
{
    public class GetAllRoomRepository
    {
        public int Id { get; set; }
        public decimal Area { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; } = string.Empty;
        public  BoardingHouse? BoardingHouse { get; set; }
        public string RoomTypeName { get; set; } = string.Empty;
    }
    public class BoardingHouse
    {
        public string NameOwner { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

    }
}