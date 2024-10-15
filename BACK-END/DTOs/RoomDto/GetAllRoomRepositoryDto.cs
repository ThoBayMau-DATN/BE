using BACK_END.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BACK_END.DTOs.RoomDto
{
    public class GetAllRoomRepositoryDto
    {
        public int Id { get; set; }
        public double Area { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }
        public int TotalRating { get; set; }
        public string LinkTerm { get; set; } = string.Empty;
        public ModelDto? Motel { get; set; }
        public PriceDto? PriceOther { get; set; }
    }

    public class PriceDto
    {
        public double Water { get; set; } = 10000.00;
        public double Electric { get; set; } = 3000.00;
        public double Other { get; set; } = 30000.00;
    }
    public class ModelDto
    {
        public string NameOwner { get; set; } = "tro";
        public string Address { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int TotalRoom { get; set; }
    }

}