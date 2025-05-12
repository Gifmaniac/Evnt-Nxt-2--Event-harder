using Evnt_Nxt_Business_.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evnt_Nxt_Business_.Mapper
{
    public class ProvinceMapper
    {
        public static ProvinceEnums ToEnum(string provinceName)
        {
            return provinceName switch
            {
                "NoordBrabant" => ProvinceEnums.NoordBrabant,
                "Zeeland" => ProvinceEnums.Zeeland,
                "Limburg" => ProvinceEnums.Limburg,
                "Gelderland" => ProvinceEnums.Gelderland,
                "Utrecht" => ProvinceEnums.Utrecht,
                "ZuidHolland" => ProvinceEnums.ZuidHolland,
                "NoordHolland" => ProvinceEnums.NoordHolland,
                "Flevoland" => ProvinceEnums.Flevoland,
                "Overijssel" => ProvinceEnums.Overijssel,
                "Drenthe" => ProvinceEnums.Drenthe,
                "Groningen" => ProvinceEnums.Groningen,
                "Friesland" => ProvinceEnums.Friesland,
                _ => throw new ArgumentException($"Genre '{provinceName}' is not recognized.")
            };
        }
    }
}
