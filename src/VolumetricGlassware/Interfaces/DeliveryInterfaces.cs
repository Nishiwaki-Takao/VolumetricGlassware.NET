using System;
using UnitsNet;
using UnitsNet.Units;

namespace VolumetricGlassware;

/// <summary>
/// 分取/定容の共通インターフェース。
/// </summary>
public interface IDelivery
{
    Volume Volume { get; }
    Volume StandardUncertainty { get; }

    string Unit => Volume.Unit.ToString();

    IDelivery ToUnit(VolumeUnit unit);

}
