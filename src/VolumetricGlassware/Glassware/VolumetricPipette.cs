using UnitsNet;

namespace VolumetricGlassware;

/// <summary>
/// ホールピペット（TD）情報。
/// </summary>
public sealed record VolumetricPipette(
    string Id,
    Volume NominalVolume,                  // 例: 10 mL
    Temperature CalibrationTemperature,     // 例: 20 °C
    GlasswareClass Class,
    GlasswareColorCode ColorCode,
    CalibrationType Calibration = CalibrationType.TD,
    Volume? TolerancePlusMinus = null       // 例: ±0.02 mL
) : ITDGlassware
{
    public Measured<Volume> DeliveredNominal()
        => throw new NotImplementedException();
}
