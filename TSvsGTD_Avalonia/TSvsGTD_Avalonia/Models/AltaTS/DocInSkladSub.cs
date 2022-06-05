using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TSvsGTD_Avalonia.Models.AltaTS
{
    public partial class DocInSkladSub
    {

        [ForeignKey("MainId")]
        public string MainId { get; set; }
        public string? KeyId { get; set; }
        public short? PosId { get; set; }
        public short? G32 { get; set; }
        public string? G31 { get; set; }
        public string G33In { get; set; }
        public int G312 { get; set; }
        public decimal? G313 { get; set; }
        public string? G313a { get; set; }
        public string? G41a { get; set; }
        public string? G41aDt { get; set; }
        public decimal G35 { get; set; }
        public decimal? G38 { get; set; }
        public decimal G42 { get; set; }
        public string Curr { get; set; }
        public decimal? G46 { get; set; }
        public string? FG313 { get; set; }
        public string? Place { get; set; }
        public DateTime? DateChk { get; set; }
        public DateTime? DateChkDt { get; set; }
        public string? Series { get; set; }
        public DateTime? ExpDate { get; set; }
        public string? Info { get; set; }
        public int? Sender { get; set; }
        public string? Invoice { get; set; }
        public string? Country { get; set; }
        public string? Operation { get; set; }
        public int UniqueIndexField { get; set; }
        //public DocInSklad DocInSklad { get; set; }
    }
}
