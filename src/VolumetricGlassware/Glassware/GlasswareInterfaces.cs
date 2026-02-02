using UnitsNet;

namespace VolumetricGlassware;

/// <summary>
/// 校正情報を持つ容量器具（TC/TD 共通）。
/// </summary>
public interface ICalibratedGlassware
{
    string Id { get; }
    Volume NominalVolume { get; }

    Volume VolumeStandardUncertainty { get; }
    Temperature CalibrationTemperature { get; }
    CalibrationType Calibration { get; }
}
/// <summary>
/// TC (to contain) 容量器具。
/// 例: メスフラスコ、メスシリンダーなど。
/// </summary>
public interface ITCGlassware : ICalibratedGlassware
{
}

/// <summary>
/// TD (to deliver) 容量器具。
/// 例: ホールピペット、メスピペット、ビュレットなど。
/// </summary>
public interface ITDGlassware : ICalibratedGlassware
{
}
