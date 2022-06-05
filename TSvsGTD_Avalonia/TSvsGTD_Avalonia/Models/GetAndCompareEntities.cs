using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSvsGTD_Avalonia.Models.AltaTS;
using TSvsGTD_Avalonia.Models.ArmDb;

namespace TSvsGTD_Avalonia.Models
{
    public class Mistakes
    {
        public string Number { get; set; }
        public string DateTimeDoc { get; set; }
        public string GTD { get; set; }
        public string GtdDate { get; set; }
        public string PlaceOfError { get; set; }
        public string Error { get; set; }
        public string ValueInAlta { get; set; }
        public string ValueInArm { get; set; }
        public string NameOfCompany { get; set; }

    }
    public class GetAndCompareEntities
    {

        static string _connStrOracle;
        static string ConnStrOracle
        {
            get
            {
                _connStrOracle = ConfigurationManager.ConnectionStrings["Oracle"].ConnectionString;
                return _connStrOracle;
            }
        }

        /// <summary>
        /// Поиск товра и компании из арм за интервал времени 
        /// </summary>
        /// <param name="dateTime_1"></param>
        /// <param name="dateTime_2"></param>
        /// <returns></returns>
        public static List<ArmDbContext> GetEntitiesFromArm(DateTimeOffset beginDate, DateTimeOffset endDate)
        {
            DateTime BeginDate = beginDate.Date;
            DateTime EndDate = endDate.Date;
            List<ArmDbContext> list = new List<ArmDbContext>();
            string queryString = $@"select distinct tovar.g33, head.g071, head.tg072, head.tg073, tovar.g35, tovar.g31_2,
tovar.G42, head.g022_082, sost.id_gtd, head.G221
from SPRUT4.kb_sost sost
left join SPRUT4.kb_spros spros on spros.id = sost.id_obsl
left join SPRUT4.kb_dclhead head on head.id = sost.id_gtd
left join SPRUT4.kb_dcltovar tovar on tovar.id_head = head.id
where head.tg072 >= :BeginDate and head.tg072 <= :EndDate";
            using (OracleConnection oracleConnection = new OracleConnection(ConnStrOracle))
            {

                using (OracleCommand command = new OracleCommand(queryString, oracleConnection))
                {
                    command.Parameters.Add(":BeginDate", OracleDbType.Date).Value = BeginDate;
                    command.Parameters.Add(":EndDate", OracleDbType.Date).Value = EndDate;
                    oracleConnection.Open();
                    OracleDataReader reader = command.ExecuteReader();
                    while ((reader != null) && reader.Read())
                    {
                        string tnved = reader.IsDBNull(0) ? ""
                            : reader.GetString(0);
                        string customs = reader.IsDBNull(1)
                                   ? ""
                                   : reader.GetOracleString(1).Value;
                        var regDate = reader.IsDBNull(2)
                                ? DateTime.Today
                                : reader.GetDateTime(2);
                        string declNumber = reader.IsDBNull(3)
                                ? ""
                                : reader.GetOracleString(3).Value;
                        var weight = reader.IsDBNull(4)
                                ? 0
                                : reader.GetDecimal(4);
                        var _numberOfSeats = reader.IsDBNull(5)
                                ? 0
                                : reader.GetDecimal(5);
                        var _price = reader.IsDBNull(6)
                                ? 0
                                : reader.GetDecimal(6);
                        string _companyName = reader.IsDBNull(7)
                                   ? ""
                                   : reader.GetOracleString(7).Value;
                        string _currency = reader.IsDBNull(9)
                                   ? ""
                                   : reader.GetOracleString(9).Value;
                        list.Add(new ArmDbContext
                        {
                            DeclNumber = $"{customs}/{regDate.ToString("ddMMyy")}/{declNumber}",
                            TNVED = tnved,
                            Weight = weight,
                            NumberOfSeats = (int)_numberOfSeats,
                            Price = _price,
                            CompanyName = _companyName,
                            Currency = _currency
                        });
                    }
                    reader.Close();
                }

            }
            return list;

        }

        public static List<DocInSklad> GetEntitiesInSclad(DateTime BeginDate, DateTime EndDate)
        {
            using (AltaTS4DbContext dbContext = new AltaTS4DbContext())
            {
                return dbContext.DocInSklads.Where(e => e.GtdDate >= BeginDate && e.GtdDate <= EndDate).ToList();
            }
        }

        public static List<DocInSkladSub> GetEntitiesInScladSub(List<DocInSklad> docInSklads)
        {
            List<DocInSkladSub> ls = new List<DocInSkladSub>();
            foreach (var doc in docInSklads)
            {
                using (AltaTS4DbContext dbContext = new AltaTS4DbContext())
                {
                    List<DocInSkladSub> aa = dbContext.DocInSkladSubs.Where(e => e.MainId.Equals(doc.Id)).ToList();
                    ls.AddRange(aa);
                }

            }
            return ls;
        }

        public static List<DocOutSklad> GetEntitiesOutSclad(DateTime BeginDate, DateTime EndDate)
        {
            using (AltaTS4DbContext dbContext = new AltaTS4DbContext())
            {
                return dbContext.DocOutSklads.Where(e => e.GtdVpdate >= BeginDate && e.GtdVpdate <= EndDate).ToList();
            }
        }

        public static List<DocOutSkladSub> GetEntitiesOutScladSub(List<DocOutSklad> docOutSklads)
        {
            List<DocOutSkladSub> ls = new List<DocOutSkladSub>();
            foreach (var doc in docOutSklads)
            {
                using (AltaTS4DbContext dbContext = new AltaTS4DbContext())
                {
                    List<DocOutSkladSub> aa = dbContext.DocOutSkladSubs.Where(e => e.MainId.Equals(doc.Id)).ToList();
                    ls.AddRange(aa);
                }

            }
            return ls;
        }

        /// <summary>
        /// Сравнение данных из арма и альты ( прихода )
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public static List<Mistakes> CompareAltaInSkladWithArm(DateTime BeginDate, DateTime EndDate)
        {
            List<DocInSklad> docInSklads = GetEntitiesInSclad(BeginDate, EndDate);
            List<DocInSkladSub> docInSkladSubs = GetEntitiesInScladSub(docInSklads);
            List<ArmDbContext> armDbs = GetEntitiesFromArm(BeginDate, EndDate);

            List<Mistakes> alltMistakesInSklad = new List<Mistakes>();

            foreach (var inSclad in docInSklads)
            {
                List<Mistakes> resultMistakesInkalsd = new List<Mistakes>();
                var coincidenceArm = armDbs.Where(e => e.DeclNumber.Equals(inSclad.NumDoc))
                    .OrderBy(e => e.TNVED).ThenBy(e => e.Price).ThenBy(e => e.Weight).ToList();
                var coinsidenceInSclad = docInSkladSubs.Where(e => e.MainId == inSclad.Id)
                    .OrderBy(e => e.G33In).ThenBy(e => e.G42).ThenBy(e => e.G35).ToList();
                for (int i = 0, j = 0; (i < coincidenceArm.Count && j < coinsidenceInSclad.Count); i++, j++)
                {
                    if (!(coincidenceArm[i].TNVED == coinsidenceInSclad[j].G33In))
                    {
                        alltMistakesInSklad.Add(new Mistakes
                        {
                            Number = inSclad.Id,
                            DateTimeDoc = inSclad.DateDoc.ToString("d"),
                            GTD = inSclad.NumDoc,
                            GtdDate = inSclad.GtdDate.ToString("d"),
                            PlaceOfError = "прием",
                            Error = "ТН ВЭД",
                            ValueInAlta = coinsidenceInSclad[j].G33In,
                            ValueInArm = coincidenceArm[i].TNVED,
                            NameOfCompany = inSclad.Name
                        });
                    }
                    if (!(coincidenceArm[i].Weight == coinsidenceInSclad[j].G35))
                    {
                        alltMistakesInSklad.Add(new Mistakes
                        {
                            Number = inSclad.Id,
                            DateTimeDoc = inSclad.DateDoc.ToString("d"),
                            GTD = inSclad.NumDoc,
                            GtdDate = inSclad.GtdDate.ToString("d"),
                            PlaceOfError = "прием",
                            Error = "вес",
                            ValueInAlta = coinsidenceInSclad[j].G35.ToString(),
                            ValueInArm = coincidenceArm[i].Weight.ToString(),
                            NameOfCompany = inSclad.Name
                        });
                    }
                    if (!(coincidenceArm[i].NumberOfSeats == coinsidenceInSclad[j].G312))
                    {
                        alltMistakesInSklad.Add(new Mistakes
                        {
                            Number = inSclad.Id,
                            DateTimeDoc = inSclad.DateDoc.ToString("d"),
                            GTD = inSclad.NumDoc,
                            GtdDate = inSclad.GtdDate.ToString("d"),
                            PlaceOfError = "прием",
                            Error = "мест",
                            ValueInAlta = coinsidenceInSclad[j].G312.ToString(),
                            ValueInArm = coincidenceArm[i].NumberOfSeats.ToString(),
                            NameOfCompany = inSclad.Name
                        });
                    }
                    if (!(coincidenceArm[i].Price == coinsidenceInSclad[j].G42))
                    {
                        alltMistakesInSklad.Add(new Mistakes
                        {
                            Number = inSclad.Id,
                            DateTimeDoc = inSclad.DateDoc.ToString("d"),
                            GTD = inSclad.NumDoc,
                            GtdDate = inSclad.GtdDate.ToString("d"),
                            PlaceOfError = "прием",
                            Error = "стоимость",
                            ValueInAlta = coinsidenceInSclad[j].G42.ToString(),
                            ValueInArm = coincidenceArm[i].Price.ToString(),
                            NameOfCompany = inSclad.Name
                        });
                    }
                    if (!(coincidenceArm[i].Currency == coinsidenceInSclad[j].Curr))
                    {
                        alltMistakesInSklad.Add(new Mistakes
                        {
                            Number = inSclad.Id,
                            DateTimeDoc = inSclad.DateDoc.ToString("d"),
                            GTD = inSclad.NumDoc,
                            GtdDate = inSclad.GtdDate.ToString("d"),
                            PlaceOfError = "прием",
                            Error = "валюта",
                            ValueInAlta = coinsidenceInSclad[j].Curr,
                            ValueInArm = coincidenceArm[i].Currency.ToString(),
                            NameOfCompany = inSclad.Name
                        });
                    }
                    if (!(coincidenceArm[i].CompanyName.ToLower() == inSclad.Name.ToLower()))
                    {
                        alltMistakesInSklad.Add(new Mistakes
                        {
                            Number = inSclad.Id,
                            DateTimeDoc = inSclad.DateDoc.ToString("d"),
                            GTD = inSclad.NumDoc,
                            GtdDate = inSclad.GtdDate.ToString("d"),
                            PlaceOfError = "прием",
                            Error = "название компании",
                            ValueInAlta = inSclad.Name,
                            ValueInArm = coincidenceArm[i].CompanyName,
                            NameOfCompany = inSclad.Name
                        });
                    }


                }


            }
            return alltMistakesInSklad.ToList();
        }

        /// <summary>
        /// Сравнение данных арма и альты (Выдача)
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public static List<Mistakes> CompareAltaOutSkladaWithArm(DateTime BeginDate, DateTime EndDate)
        {

            List<DocOutSklad> docOutSklads = GetEntitiesOutSclad(BeginDate, EndDate);
            List<DocOutSkladSub> docOutSkladSubs = GetEntitiesOutScladSub(docOutSklads);
            List<ArmDbContext> armDbs = GetEntitiesFromArm(BeginDate, EndDate);

            List<Mistakes> alltMistakesOutSklad = new List<Mistakes>();

            foreach (var outSclad in docOutSklads)
            {
                List<Mistakes> resultMistakesInkalsd = new List<Mistakes>();
                var coincidenceArm = armDbs.Where(e => e.DeclNumber.Equals(outSclad.NumDoc))
                    .OrderBy(e => e.TNVED).ThenBy(e => e.Price).ThenBy(e => e.Weight).ToList();
                var coinsidenceOutSclad = docOutSkladSubs.Where(e => e.MainId == outSclad.Id)
                    .OrderBy(e => e.G33Out).ThenBy(e => e.G42Move).ThenBy(e => e.G35Move).ToList();
                for (int i = 0, j = 0; (i < coincidenceArm.Count && j < coinsidenceOutSclad.Count); i++, j++)
                {
                    if (!(coincidenceArm[i].TNVED == coinsidenceOutSclad[j].G33Out))
                    {
                        alltMistakesOutSklad.Add(new Mistakes
                        {
                            Number = coinsidenceOutSclad[i].MainId,
                            DateTimeDoc = outSclad.DateDoc.ToString("d"),
                            GTD = outSclad.NumDoc,
                            GtdDate = outSclad.GtdVpdate.ToString("d"),
                            PlaceOfError = "Выдача",
                            Error = "ТН ВЭД",
                            ValueInAlta = coinsidenceOutSclad[j].G33Out,
                            ValueInArm = coincidenceArm[i].TNVED,
                            NameOfCompany = outSclad.Name
                        });
                    }
                    if (!(coinsidenceOutSclad[j].G35Move.ToString().Contains(coincidenceArm[i].Weight.ToString())))
                    {
                        alltMistakesOutSklad.Add(new Mistakes
                        {
                            Number = coinsidenceOutSclad[i].MainId,
                            DateTimeDoc = outSclad.DateDoc.ToString("d"),
                            GTD = outSclad.NumDoc,
                            GtdDate = outSclad.GtdVpdate.ToString("d"),
                            PlaceOfError = "Выдача",
                            Error = "вес",
                            ValueInAlta = coinsidenceOutSclad[j].G35Move.ToString(),
                            ValueInArm = coincidenceArm[i].Weight.ToString(),
                            NameOfCompany = outSclad.Name
                        });
                    }
                    if (!(coincidenceArm[i].NumberOfSeats == coinsidenceOutSclad[j].G312Move))
                    {
                        alltMistakesOutSklad.Add(new Mistakes
                        {
                            Number = coinsidenceOutSclad[i].MainId,
                            DateTimeDoc = outSclad.DateDoc.ToString("d"),
                            GTD = outSclad.NumDoc,
                            GtdDate = outSclad.GtdVpdate.ToString("d"),
                            PlaceOfError = "Выдача",
                            Error = "мест",
                            ValueInAlta = coinsidenceOutSclad[j].G312Move.ToString(),
                            ValueInArm = coincidenceArm[i].NumberOfSeats.ToString(),
                            NameOfCompany = outSclad.Name
                        });
                    }
                    if (!((double)coincidenceArm[i].Price == coinsidenceOutSclad[j].G42Move))
                    {
                        alltMistakesOutSklad.Add(new Mistakes
                        {
                            Number = coinsidenceOutSclad[i].MainId,
                            DateTimeDoc = outSclad.DateDoc.ToString("d"),
                            GTD = outSclad.NumDoc,
                            GtdDate = outSclad.GtdVpdate.ToString("d"),
                            PlaceOfError = "Выдача",
                            Error = "стоимость",
                            ValueInAlta = coinsidenceOutSclad[j].G42Move.ToString(),
                            ValueInArm = coincidenceArm[i].Price.ToString(),
                            NameOfCompany = outSclad.Name
                        });
                    }
                    if (!(coincidenceArm[i].Currency == coinsidenceOutSclad[j].Curr))
                    {
                        alltMistakesOutSklad.Add(new Mistakes
                        {
                            Number = coinsidenceOutSclad[i].MainId,
                            DateTimeDoc = outSclad.DateDoc.ToString("d"),
                            GTD = outSclad.NumDoc,
                            GtdDate = outSclad.GtdVpdate.ToString("d"),
                            PlaceOfError = "Выдача",
                            Error = "валюта",
                            ValueInAlta = coinsidenceOutSclad[j].Curr,
                            ValueInArm = coincidenceArm[i].Currency.ToString(),
                            NameOfCompany = outSclad.Name
                        });
                    }
                    if (!(coincidenceArm[i].CompanyName.ToLower() == outSclad.Name.ToLower()))
                    {
                        alltMistakesOutSklad.Add(new Mistakes
                        {
                            Number = coinsidenceOutSclad[i].MainId,
                            DateTimeDoc = outSclad.DateDoc.ToString("d"),
                            GTD = outSclad.NumDoc,
                            GtdDate = outSclad.GtdVpdate.ToString("d"),
                            PlaceOfError = "Выдача",
                            Error = "название компании",
                            ValueInAlta = outSclad.Name,
                            ValueInArm = coincidenceArm[i].CompanyName,
                            NameOfCompany = outSclad.Name
                        });
                    }


                }


            }
            return alltMistakesOutSklad.ToList();
        }
    }
}
