using Tablazor.Attributes;

namespace Tablazor.Common;

public enum Colors
{
    Default,

    [CssClass("dark")]
    [CssVariable("--tblr-dark")]
    Dark,

    [CssClass("light")]
    [CssVariable("--tblr-light")]
    Light,

    [CssClass("blue")]
    [CssVariable("--tblr-blue")]
    Blue,
    
    [CssClass("blue-lt")]
    [CssVariable("--tblr-blue-lt")]
    BlueLight,
    
    [CssClass("azure")]
    [CssVariable("--tblr-azure")]
    Azure,
    
    [CssClass("azure-lt")]
    [CssVariable("--tblr-azure-lt")]
    AzureLight,

    [CssClass("indigo")]
    [CssVariable("--tblr-indigo")]
    Indigo,
    
    [CssClass("indigo-lt")]
    [CssVariable("--tblr-indigo-lt")]
    IndigoLight,

    [CssClass("pink")]
    [CssVariable("--tblr-pink")]
    Pink,
    
    [CssClass("pink-lt")]
    [CssVariable("--tblr-pink-lt")]
    PinkLight,

    [CssClass("purple")]
    [CssVariable("--tblr-purple")]
    Purple,
    
    [CssClass("purple-lt")]
    [CssVariable("--tblr-purple-lt")]
    PurpleLight,

    [CssClass("red")]
    [CssVariable("--tblr-red")]
    Red,
    
    [CssClass("red-lt")]
    [CssVariable("--tblr-red-lt")]
    RedLight,

    [CssClass("orange")]
    [CssVariable("--tblr-orange")]
    Orange,
    
    [CssClass("orange-lt")]
    [CssVariable("--tblr-orange-lt")]
    OrangeLight,

    [CssClass("yellow")]
    [CssVariable("--tblr-yellow")]
    Yellow,
    
    [CssClass("yellow-lt")]
    [CssVariable("--tblr-yellow-lt")]
    YellowLight,

    [CssClass("green")]
    [CssVariable("--tblr-green")]
    Green,
    
    [CssClass("green-lt")]
    [CssVariable("--tblr-green-lt")]
    GreenLight,

    [CssClass("teal")]
    [CssVariable("--tblr-teal")]
    Teal,
    
    [CssClass("teal-lt")]
    [CssVariable("--tblr-teal-lt")]
    TealLight,

    [CssClass("cyan")]
    [CssVariable("--tblr-cyan")]
    Cyan,
    
    [CssClass("cyan-lt")]
    [CssVariable("--tblr-cyan-lt")]
    CyanLight,

    [CssClass("black")]
    [CssVariable("--tblr-black")]
    Black,

    [CssClass("white")]
    [CssVariable("--tblr-white")]
    White,

    [CssClass("gray")]
    [CssVariable("--tblr-gray")]
    Gray,
    
    [CssClass("gray-dark")]
    [CssVariable("--tblr-gray-dark")]
    GrayDark,
    
    [CssClass("gray-100")]
    [CssVariable("--tblr-gray-100")]
    Gray100,
    
    [CssClass("gray-200")]
    [CssVariable("--tblr-gray-200")]
    Gray200,
    
    [CssClass("gray-300")]
    [CssVariable("--tblr-gray-300")]
    Gray300,
    
    [CssClass("gray-400")]
    [CssVariable("--tblr-gray-400")]
    Gray400,
    
    [CssClass("gray-500")]
    [CssVariable("--tblr-gray-500")]
    Gray500,
    
    [CssClass("gray-600")]
    [CssVariable("--tblr-gray-600")]
    Gray600,
    
    [CssClass("gray-700")]
    [CssVariable("--tblr-gray-700")]
    Gray700,
    
    [CssClass("gray-800")]
    [CssVariable("--tblr-gray-800")]
    Gray800,
    
    [CssClass("gray-900")]
    [CssVariable("--tblr-gray-900")]
    Gray900,
    
    [CssClass("gray-950")]
    [CssVariable("--tblr-gray-950")]
    Gray950,

    [CssClass("lime")]
    [CssVariable("--tblr-lime")]
    Lime,

    [CssClass("primary")]
    [CssVariable("--tblr-primary")]
    Primary,

    [CssClass("secondary")]
    [CssVariable("--tblr-secondary")]
    Secondary,

    [CssClass("success")]
    [CssVariable("--tblr-success")]
    Success,

    [CssClass("info")]
    [CssVariable("--tblr-info")]
    Info,

    [CssClass("warning")]
    [CssVariable("--tblr-warning")]
    Warning,

    [CssClass("danger")]
    [CssVariable("--tblr-danger")]
    Danger,

    [CssClass("facebook")]
    [CssVariable("--tblr-facebook")]
    Facebook,

    [CssClass("twitter")]
    [CssVariable("--tblr-twitter")]
    Twitter,

    [CssClass("google")]
    [CssVariable("--tblr-google")]
    Google,

    [CssClass("youtube")]
    [CssVariable("--tblr-youtube")]
    Youtube,

    [CssClass("vimeo")]
    [CssVariable("--tblr-vimeo")]
    Vimeo,

    [CssClass("dribbble")]
    [CssVariable("--tblr-dribbble")]
    Dribbble,

    [CssClass("github")]
    [CssVariable("--tblr-github")]
    Github,

    [CssClass("instagram")]
    [CssVariable("--tblr-instagram")]
    Instagram,

    [CssClass("pinterest")]
    [CssVariable("--tblr-pinterest")]
    Pintrest,

    [CssClass("vk")]
    [CssVariable("--tblr-vk")]
    Vk,

    [CssClass("rss")]
    [CssVariable("--tblr-rss")]
    Rss,

    [CssClass("flickr")]
    [CssVariable("--tblr-flickr")]
    Flickr,

    [CssClass("bitbucket")]
    [CssVariable("--tblr-bitbucket")]
    Bitbucket,

    [CssClass("tabler")]
    [CssVariable("--tblr-tabler")]
    Tabler
}