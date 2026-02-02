using UnitsNet;

namespace VolumetricGlassware;

/// <summary>
/// メスフラスコ（容量器具）情報。
/// 校正温度や許容差（JIS/ISO）も本当は持たせたいが、まずは最小限。
/// </summary>
public sealed record VolumetricFlask(
    string Id,
    Volume NominalVolume,                  // 例: 100 mL
    Temperature CalibrationTemperature,     // 例: 20 °C
    Volume? TolerancePlusMinus = null,      // 例: ±0.10 mL
    CalibrationType Calibration = CalibrationType.TC,
    GlasswareClass? Class = null,
    VolumetricFlaskNeck? Neck = null
) : ITCGlassware
{
    public Measured<Volume> FinalVolume()
        => throw new NotImplementedException();

    public bool IsNeckSpecSatisfied(VolumetricFlaskNeck actualNeck)
        => throw new NotImplementedException();
}
