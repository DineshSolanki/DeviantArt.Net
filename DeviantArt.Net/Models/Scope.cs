using System.ComponentModel;
using System.Runtime.Serialization;

namespace DeviantArt.Net.Models;

public enum Scope
{
    [Description("basic")] [EnumMember(Value = "basic")]
    Basic,
    
    [Description("browse")] [EnumMember(Value = "browse")]
    Browse
}