﻿namespace WineCellar.API.Models
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Value { get; set; }

        public ICollection<Wine> Wines { get; set; }
    }
}
