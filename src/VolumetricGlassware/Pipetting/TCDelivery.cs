using UnitsNet;
using UnitsNet.Units;

namespace VolumetricGlassware;

/// <summary>
/// 定容（TC）体積。
/// </summary>
public sealed class TCDelivery : DeliveryBase<TCDelivery>
{
    public TCDelivery(
        double volume,
        double standardUncertainty,
        VolumeUnit unit = VolumeUnit.Milliliter
    )
        : base(volume, standardUncertainty, unit)
    {
    }

    public TCDelivery(Volume volume, Volume standardUncertainty)
        : base(volume, standardUncertainty)
    {
    }

    public TCDelivery(ITCGlassware flask)
        : base(flask.NominalVolume, flask.VolumeStandardUncertainty)
    {
    }

    protected override TCDelivery Create(Volume volume, Volume standardUncertainty)
        => new(volume, standardUncertainty);
}
