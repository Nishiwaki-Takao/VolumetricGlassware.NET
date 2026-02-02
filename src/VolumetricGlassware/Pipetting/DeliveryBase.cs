using UnitsNet;
using UnitsNet.Units;

namespace VolumetricGlassware;

/// <summary>
/// 分取(TD)/定容(TC)の共通実装。
/// </summary>
public abstract class DeliveryBase<TSelf> : IDelivery
    where TSelf : DeliveryBase<TSelf>
{
    public Volume Volume { get; init; } = Volume.Zero;
    public Volume StandardUncertainty { get; init; } = Volume.Zero;
    public string Unit => Volume.Unit.ToString();

    protected DeliveryBase(Volume volume, Volume standardUncertainty)
    {
        Volume = volume;
        StandardUncertainty = standardUncertainty.ToUnit(volume.Unit);
    }

    protected DeliveryBase(
        double volume,
        double standardUncertainty,
        VolumeUnit unit = VolumeUnit.Milliliter
    )
        : this(Volume.From(volume, unit), Volume.From(standardUncertainty, unit))
    {
    }

    protected abstract TSelf Create(Volume volume, Volume standardUncertainty);

    public TSelf ToUnit(VolumeUnit unit)
        => Create(Volume.ToUnit(unit), StandardUncertainty.ToUnit(unit));

    IDelivery IDelivery.ToUnit(VolumeUnit unit) => ToUnit(unit);
}
