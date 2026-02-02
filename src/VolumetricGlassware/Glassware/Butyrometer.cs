using UnitsNet;

namespace VolumetricGlassware;

/// <summary>
/// 乳脂計情報（Gerber/Babcock）。
/// </summary>
public sealed record Butyrometer(
    string Id,
    Volume NominalVolume,                   // 例: 0.875 mL
    Volume Subdivision,                     // 例: 0.0125 mL
    ButyrometerBodyCapacity BodyCapacity,
    ButyrometerType Type,
    Volume? TolerancePlusMinus = null       // 例: ±0.0125 mL
);
