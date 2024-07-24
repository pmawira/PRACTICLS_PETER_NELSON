using System.ComponentModel.DataAnnotations;

namespace KilimoHighSchool.Settings
{
    public class SQLServerSettings
    {
        [Required(AllowEmptyStrings = false)] public string ConnectionString { get; set; } = null!;

    }
}
