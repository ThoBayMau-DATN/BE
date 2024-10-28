using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACK_END.DTOs.RoomDto
{
    public class AddMotelAndRoomDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Area { get; set; }
        public int Price { get; set; }
        public int TotalRoom { get; set; }
        public int UserId { get; set; }
        public AddPriceDto? PriceOther { get; set; }

    }
    public class AddPriceDto
    {
        public int Water { get; set; }
        public int Electric { get; set; }
        public int Other { get; set; }

    }

}