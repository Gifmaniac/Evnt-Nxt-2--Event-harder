using Evnt_Nxt_Business_.Enums;


namespace Evnt_Nxt_Business_.Mapper
{
    public static class GenreMapper
    {
        public static GenreEnums ToEnum(string genreName)
        {
            return genreName switch
            {
                "Techno" => GenreEnums.Techno,
                "RawStyle" => GenreEnums.RawStyle,
                "Hardcore" => GenreEnums.Hardcore,
                "Uptempo" => GenreEnums.Uptempo,
                "House" => GenreEnums.House,
                "Acid" => GenreEnums.Acid,
                "EDM" => GenreEnums.EDM,
                "HardStyle" => GenreEnums.HardStyle,
                "Hard Techno" => GenreEnums.HardTechno,
                _ => throw new ArgumentException($"Genre '{genreName}' is not recognized.")
            };
        }

        public static string ToString(GenreEnums genreEnum)
        {
            return genreEnum switch
            {
                GenreEnums.Techno => "Techno",
                GenreEnums.RawStyle => "RawStyle",
                GenreEnums.Hardcore => "Hardcore",
                GenreEnums.Uptempo => "Uptempo",
                GenreEnums.House => "House",
                GenreEnums.Acid => "Acid",
                GenreEnums.EDM => "EDM",
                GenreEnums.HardStyle => "Hardstyle",
                GenreEnums.HardTechno => "Hard Techno",
                _ => throw new ArgumentException($"Genre '{genreEnum}' is not recognized.")
            };
        }
    }
}
