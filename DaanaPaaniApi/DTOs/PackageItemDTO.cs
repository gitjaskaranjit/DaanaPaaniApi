﻿using DaanaPaaniApi.Model;

namespace DaanaPaaniApi.DTOs
{
    public class PackageItemDTO : IorderItem
    {
        public ItemDTO Item { get; set; }
        public int Quantity { get; set; }
    }
}