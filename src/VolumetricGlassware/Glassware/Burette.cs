using UnitsNet;

namespace VolumetricGlassware;

/// <summary>
/// ビュレット（TD）情報。
/// </summary>
public sealed record Burette(
    string Id,
    Volume NominalVolume,                  // 例: 50 mL
    Temperature CalibrationTemperature,     // 例: 20 °C
    Volume Subdivision,                     // 例: 0.1 mL
    GlasswareClass Class,
    BuretteType Type,
    CalibrationType Calibration = CalibrationType.TD,
    Volume? TolerancePlusMinus = null       // 例: ±0.05 mL
) : ITDGlassware
{
    public Volume Delivered(Volume start, Volume end)
        => throw new NotImplementedException();

    public Volume RoundToSubdivision(Volume reading)
        => throw new NotImplementedException();

    public bool IsReadingValid(Volume reading)
        => throw new NotImplementedException();
}
