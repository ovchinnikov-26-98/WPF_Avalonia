using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TSvsGTD_Avalonia.Models.AltaTS
{
    public partial class DocInSklad
    {
        [Key]
        public string Id { get; set; }
        public string? Guid { get; set; }
        public string? GuidDt { get; set; }
        public int? Nid { get; set; }
        public string? Akt { get; set; }
        public DateTime DateDoc { get; set; }
        public string? TimeIn { get; set; }
        public string? TypeDoc { get; set; }
        public string? CarType { get; set; }
        public string? Ncar { get; set; }
        public string NumDoc { get; set; }
        public DateTime GtdDate { get; set; }
        public DateTime GtdVpdate { get; set; }
        public string? Docregime { get; set; }
        public int? Owner { get; set; }
        public string Name { get; set; }
        public string? Goods { get; set; }
        public string? TovStat { get; set; }
        public int? Snd { get; set; }
        public string? Dol { get; set; }
        public string? DolName { get; set; }
        public string? Place { get; set; }
        public DateTime? DateChk { get; set; }
        public short? TovKol { get; set; }
        public int? G6 { get; set; }
        public decimal? G35 { get; set; }
        public decimal? G38 { get; set; }
        public decimal? G42 { get; set; }
        public decimal? G46 { get; set; }
        public string? FG313 { get; set; }
        public string? Invoice { get; set; }
        public string? Contract { get; set; }
        public string? Comment { get; set; }
        public string? Status { get; set; }
        public string? UserId { get; set; }
        public short? Posted { get; set; }
        public DateTime? Postdate { get; set; }
        public string? Lic { get; set; }
        public string? Npost { get; set; }
        public string? Idinv { get; set; }
        public string? TamSt { get; set; }
        public string? Carname { get; set; }
        public string? Carcountry { get; set; }
        public int UniqueIndexField { get; set; }
        //public List<DocInSkladSub> DocInSkladSubs { get; set; }
    }
}
