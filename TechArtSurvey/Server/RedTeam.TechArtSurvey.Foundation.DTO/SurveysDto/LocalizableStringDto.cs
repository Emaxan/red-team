using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace RedTeam.TechArtSurvey.Foundation.Dto.SurveysDto
{
    [UsedImplicitly]
    public class LocalizableStringDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Default { get; set; }

        /// <summary>
        /// English
        /// </summary>
        public string En { get; set; }

        /// <summary>
        /// Russian
        /// </summary>
        public string Ru { get; set; }

        /// <summary>
        /// Japanese
        /// </summary>
        public string Ja { get; set; }

        /// <summary>
        /// Chinese Traditional
        /// </summary>
        public string ZhCn { get; set; }

        /// <summary>
        /// Chinese Simplified
        /// </summary>
        public string ZhTw { get; set; }

        /// <summary>
        /// Bulgarian
        /// </summary>
        public string Bg { get; set; }

        /// <summary>
        /// Polish
        /// </summary>
        public string Pl { get; set; }


        /// <summary>
        /// Spanish
        /// </summary>
        public string Es { get; set; }

        /// <summary>
        /// German
        /// </summary>
        public string De { get; set; }

        /// <summary>
        /// Danish
        /// </summary>
        public string Da { get; set; }

        /// <summary>
        /// Italian
        /// </summary>
        public string It { get; set; }

        /// <summary>
        /// Dutch
        /// </summary>
        public string Nl { get; set; }

        /// <summary>
        /// Indonesian
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Lithuanian
        /// </summary>
        public string Lt { get; set; }

        /// <summary>
        /// Latvian
        /// </summary>
        public string Lv { get; set; }

        /// <summary>
        /// Norwegian
        /// </summary>
        public string No { get; set; }

        /// <summary>
        /// Portuguese
        /// </summary>
        public string Pt { get; set; }

        /// <summary>
        /// Romanian
        /// </summary>
        public string Ro { get; set; }

        /// <summary>
        /// Swedish
        /// </summary>
        public string Sv { get; set; }

        /// <summary>
        /// Turkish
        /// </summary>
        public string Tr { get; set; }

        /// <summary>
        /// Korean
        /// </summary>
        public string Ko { get; set; }

        /// <summary>
        /// Georgian
        /// </summary>
        public string Ka { get; set; }

        /// <summary>
        /// Icelandic
        /// </summary>
        public string Is { get; set; }

        /// <summary>
        /// Hungarian
        /// </summary>
        public string Hu { get; set; }

        /// <summary>
        /// Hebrew
        /// </summary>
        public string He { get; set; }

        /// <summary>
        /// Greek
        /// </summary>
        public string Gr { get; set; }

        /// <summary>
        /// French
        /// </summary>
        public string Fr { get; set; }

        /// <summary>
        /// Finnish
        /// </summary>
        public string Fi { get; set; }

        /// <summary>
        /// Persian
        /// </summary>
        public string Fa { get; set; }

        /// <summary>
        /// Czech
        /// </summary>
        public string Cz { get; set; }

        /// <summary>
        /// Catalan
        /// </summary>
        public string Ca { get; set; }

        /// <summary>
        /// Arabian
        /// </summary>
        public string Ar { get; set; }
    }
}