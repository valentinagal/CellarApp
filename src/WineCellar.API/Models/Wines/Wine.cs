﻿using System.ComponentModel.DataAnnotations.Schema;
using WineCellar.API.Models.WineTags;

namespace WineCellar.API.Models.Wines
{
    public class Wine
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string WineMaker { get; set; }
        public int Year { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }

        public string ImageURL { get; set; }

        [ForeignKey("WineTag")]
        public ICollection<WineTag> Tags { get; set; }

    }
}
