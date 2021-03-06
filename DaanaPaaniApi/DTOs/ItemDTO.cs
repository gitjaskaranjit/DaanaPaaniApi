﻿using System.Collections.Generic;

namespace DaanaPaaniApi.DTOs
{
    public class ItemDTO
    {
        public int? ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemPrice { get; set; }
        public bool Combo { get; set; }
        public ICollection<ItemItemDTO> ChildItems { get; set; }
    }
}