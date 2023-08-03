using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Plugzy.Domain.Entities;

public class Content
{
    public Guid Id { get; set; }
    [MaxLength(100)]
    public string Key { get; set; }
    public string Value { get; set; }
    [Column(TypeName = "tinyint")]
    public int Type { get; set; }
    [Column(TypeName = "tinyint")]
    public int Lang { get; set; }
    public bool IsActive { get; set; }

    public Content() 
    {
    }

    public Content(Guid id, string key, string value, int type, int lang, bool isActive)
    {
        Id = id;
        Key = key;
        Value = value;
        Type = type;
        Lang = lang;
        IsActive = isActive;
    }
}
