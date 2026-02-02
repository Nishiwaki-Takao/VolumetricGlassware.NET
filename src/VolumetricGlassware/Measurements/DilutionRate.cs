using System;
using System.Runtime.CompilerServices;
using UnitsNet;
using UnitsNet.Units;

namespace VolumetricGlassware;

/// <summary>
/// 希釈率を保持する値オブジェクト（TD: 分取体積 / TC: 定容体積）。
/// </summary>
public record DilutionState 
{
    public Volume TotalVolume { get; init; } = Volume.Zero;
    public Volume StandardUncertainty { get; init; } = Volume.Zero;
    /// <summary>
    /// 希釈率（TC / TD）。
    /// </summary>
    public Ratio DilutionRate { get; init; }= Ratio.Zero;

    public DilutionState Apply(TDDelivery tdDelivery)
    {
        Volume newTotalVolume = this.TotalVolume + tdDelivery.Volume;
        Volume newStandardUncertainty;

        if (Equals(this.TotalVolume, Volume.Zero))
        {
            newStandardUncertainty = tdDelivery.StandardUncertainty;
        }
        else
        {
            newStandardUncertainty = UncertaintyCalculator(
                this.StandardUncertainty,
                tdDelivery.StandardUncertainty
            );
        }
        return this with
        {
            TotalVolume = newTotalVolume,
            StandardUncertainty = newStandardUncertainty,
            DilutionRate = this.DilutionRate
        };
    }

    public DilutionState Apply(TCDelivery tcDelivery)
    {
        // 希釈倍率を計算する。TC/TDを計算式とする。
        Ratio newDilutionRate = Ratio.FromDecimalFractions(tcDelivery.Volume/this.TotalVolume);
        //累積TD体積はリセットする。
        Volume newTotalVolume = Volume.Zero;
        //伝播する不確かさを計算する。
        Volume newStandardUncertainty;
        if (Equals(this.TotalVolume, Volume.Zero))
        {
            newStandardUncertainty = tcDelivery.StandardUncertainty;
        }
        else
        {
            newStandardUncertainty = UncertaintyCalculator(
                this.StandardUncertainty,
                tcDelivery.StandardUncertainty
            );
        }
        return this with
        {
            TotalVolume = newTotalVolume,
            StandardUncertainty = newStandardUncertainty,
            DilutionRate = newDilutionRate
        };
    }

    private Volume UncertaintyCalculator(
        Volume standardUncertainty,
        Volume anotherStandardUncertainty,
        VolumeUnit unit = VolumeUnit.Milliliter
    )
    {   
        standardUncertainty = standardUncertainty.ToUnit(unit);
        anotherStandardUncertainty = anotherStandardUncertainty.ToUnit(unit);

        double innerUncertainty = Math.Sqrt(
            Math.Pow(standardUncertainty.Value, 2) + Math.Pow(anotherStandardUncertainty.Value, 2)
        );
        return Volume.From(innerUncertainty, unit);
    }
}
