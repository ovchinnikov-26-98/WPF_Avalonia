using System;
using System.Collections.Generic;

namespace TSvsGTD_Avalonia.Models.AltaTS
{
    public partial class DocOutSkladSub
    {

        public string MainId { get; set; }
        public string IdDoc { get; set; }
        public string? KeyId { get; set; }
        public string? KeyId2 { get; set; }
        public string NumDoc { get; set; }
        public string? Name { get; set; }
        public string? Formular { get; set; }
        public short? G32 { get; set; }
        public string? G31 { get; set; }
        public string G33In { get; set; }
        public string? G313a { get; set; }
        public string? G41a { get; set; }
        public int G312 { get; set; }
        public decimal? G313 { get; set; }
        public decimal? G35 { get; set; }
        public decimal G42 { get; set; }
        public string Curr { get; set; }
        public decimal? G46 { get; set; }
        public int G312Move { get; set; }
        public decimal? G313Move { get; set; }
        public decimal G35Move { get; set; }
        public decimal? G38Move { get; set; }
        public double G42Move { get; set; }
        public decimal? G46Move { get; set; }
        public short? G32Out { get; set; }
        public string G33Out { get; set; }
        public string? G31Out { get; set; }
        public string? Country { get; set; }
        public string? Series { get; set; }
        public DateTime? ExpDate { get; set; }
        public string? Info { get; set; }
        public int? Sender { get; set; }
        public string? FFinish { get; set; }
        public int UniqueIndexField { get; set; }
    }
}
