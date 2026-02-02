using UnitsNet;

namespace VolumetricGlassware;

/// <summary>
/// メスピペット（TD）情報。
/// </summary>
public sealed record GraduatedPipette(
    string Id,
    Volume NominalVolume,                  // 例: 10 mL
    Temperature CalibrationTemperature,     // 例: 20 °C
    Volume Subdivision,                     // 例: 0.1 mL
    GlasswareClass Class,
    GlasswareColorCode ColorCode,
    CalibrationType Calibration = CalibrationType.TD,
    Volume? TolerancePlusMinus = null       // 例: ±0.02 mL
) : ITDGlassware
{
    public Volume DeliveredByMarks(Volume start, Volume end)
        => throw new NotImplementedException();

    public Volume Delivered(Volume reading)
        => throw new NotImplementedException();

    public Volume RoundToSubdivision(Volume reading)
        => throw new NotImplementedException();
}
