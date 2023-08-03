namespace Plugzy.Domain.Entities;

public class Content
{
    public Guid Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
    public int Type { get; set; }
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
