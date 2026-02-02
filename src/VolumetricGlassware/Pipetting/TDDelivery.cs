using UnitsNet;
using UnitsNet.Units;

namespace VolumetricGlassware;

/// <summary>
/// ピペットによる「分取（アリコート）」。
/// 実務だと「1回分取 = 1滴」ではなく「N滴 or 連続吐出」なので、Droplets を保持して合算できるようにする。
/// </summary>
public sealed class TDDelivery : DeliveryBase<TDDelivery>
{
    public TDDelivery(
        double volume,
        double standardUncertainty,
        VolumeUnit unit = VolumeUnit.Milliliter
    )
        : base(volume, standardUncertainty, unit)
    {
    }

    public TDDelivery(Volume volume, Volume standardUncertainty)
        : base(volume, standardUncertainty)
    {
    }

    public TDDelivery(ITDGlassware pipette)
        : base(pipette.NominalVolume, pipette.VolumeStandardUncertainty)
    {
    }

    protected override TDDelivery Create(Volume volume, Volume standardUncertainty)
        => new(volume, standardUncertainty);
}
