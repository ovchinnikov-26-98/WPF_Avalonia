using System;
using System.Collections.Generic;

namespace TSvsGTD_Avalonia.Models.AltaTS
{
    public partial class DocOutSklad
    {

        public string Id { get; set; }
        public string? IdDoc { get; set; }
        public string? Guid { get; set; }
        public string? GuidDt { get; set; }
        public int? Nid { get; set; }
        public string? Akt { get; set; }
        public DateTime DateDoc { get; set; }
        public string? TimeOut { get; set; }
        public string? TypeDoc { get; set; }
        public string NumDoc { get; set; }
        public string? Docregime { get; set; }
        public DateTime GtdVpdate { get; set; }
        public string? Ordnum { get; set; }
        public string? Idord { get; set; }
        public string? Formular { get; set; }
        public string? Dol { get; set; }
        public string? DolName { get; set; }
        public string? Comment { get; set; }
        public string? Ncar { get; set; }
        public int? Owner { get; set; }
        public string Name { get; set; }
        public short? TovKol { get; set; }
        public int? G6 { get; set; }
        public decimal? G35 { get; set; }
        public decimal? G46 { get; set; }
        public string? Lic { get; set; }
        public string? Npost { get; set; }
        public string? Idout { get; set; }
        public string? FFinish { get; set; }
        public string? UserId { get; set; }
        public short? Posted { get; set; }
        public DateTime? Postdate { get; set; }
        public string? TamSt { get; set; }
        public int UniqueIndexField { get; set; }

        //public List<DocOutSkladSub> docOutSkladSubs { get; set; }
    }
}
