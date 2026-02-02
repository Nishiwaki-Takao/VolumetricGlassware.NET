using UnitsNet;

namespace VolumetricGlassware;

/// <summary>
/// メスシリンダー（TC）情報。
/// </summary>
public sealed record MeasuringCylinder(
    string Id,
    Volume NominalVolume,                  // 例: 100 mL
    Temperature CalibrationTemperature,     // 例: 20 °C
    Volume Subdivision,                     // 例: 1 mL
    GlasswareClass Class,
    CalibrationType Calibration = CalibrationType.TC,
    Volume? TolerancePlusMinus = null       // 例: ±1 mL
) : ITCGlassware
{
    public Volume VolumeAtReading(Volume reading)
        => throw new NotImplementedException();

    public Volume RoundToSubdivision(Volume reading)
        => throw new NotImplementedException();
}
