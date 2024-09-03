using System.ComponentModel;

namespace DeviantArt.Net.Models;

public enum Scope
{
    [Description("basic")]
    Basic,
    [Description("browse")]
    Browse
}