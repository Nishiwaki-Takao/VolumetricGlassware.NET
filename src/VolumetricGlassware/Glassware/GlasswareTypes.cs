using UnitsNet;

namespace VolumetricGlassware;

/// <summary>
/// JIS/ISO で使われる等級。
/// </summary>
public enum GlasswareClass
{
    A,
    B,
    SuperGrade,
    HighGrade
}

/// <summary>
/// 校正の定義（TC/TD）。
/// </summary>
public enum CalibrationType
{
    TC,
    TD
}

/// <summary>
/// ビュレットの形式。
/// </summary>
public enum BuretteType
{
    Graduated,
    Mohr
}

/// <summary>
/// 乳脂計の形式。
/// </summary>
public enum ButyrometerType
{
    Gerber,
    Babcock
}

/// <summary>
/// ピペットのカラーコード色。
/// </summary>
public enum GlasswareColor
{
    Blue,
    White,
    Red,
    Green,
    Yellow,
    Orange,
    Black
}

/// <summary>
/// ピペットのカラーコード情報。
/// </summary>
public sealed record GlasswareColorCode(GlasswareColor Color, int NumberOfRing);

/// <summary>
/// メスフラスコ首部の太さ区分。
/// </summary>
public enum NeckWidth
{
    Narrow,
    Wide
}

/// <summary>
/// メスフラスコの首部（目盛線付近）の寸法。
/// </summary>
public sealed record VolumetricFlaskNeck(
    NeckWidth NarrowWide,
    Length DScoreMax,
    Length? DScoreMin = null
);

/// <summary>
/// 乳脂計の胴部容量（最大/最小）。
/// </summary>
public sealed record ButyrometerBodyCapacity(Volume Max, Volume Min);
