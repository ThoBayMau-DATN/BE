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
        public int PriceRoom { get; set; }
        public int PriceElectric { get; set; }
        public int PriceWater { get; set; }
        public int PriceOther { get; set; }
        public int TotalRoom { get; set; }
        public int UserId { get; set; }

    }

}