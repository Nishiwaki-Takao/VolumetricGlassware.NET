using UnitsNet;

namespace VolumetricGlassware;

// ------------------------
// 使い方例
// ------------------------
public static class Example
{
    public static void Demo()
    {
        var stock = new SolutionSource("STD-Fe", "Fe standard solution");

        // 1滴=0.050 mL ±0.005 mL みたいなモデル（本当は滴下条件で変動）
        var d1 = new PipetteDroplet(stock,
            new Measured<Volume>(Volume.FromMilliliters(0.050), Volume.FromMilliliters(0.005)),
            Temperature.FromDegreesCelsius(20),
            DateTimeOffset.Now,
            "first drop");

        var d2 = d1 with { At = DateTimeOffset.Now.AddSeconds(2), Note = "second drop" };

        var aliquot = new Aliquot
        {
            Source = stock,
            Droplets = new[] { d1, d2 } // 2滴分取
        };

        var flask = new VolumetricFlask(
            Id: "VF-100mL-A",
            NominalVolume: Volume.FromMilliliters(100),
            CalibrationTemperature: Temperature.FromDegreesCelsius(20),
            TolerancePlusMinus: Volume.FromMilliliters(0.10)
        );

        var madeUp = new MadeUpSolution
        {
            Flask = flask,
            AddedAliquots = new[] { aliquot }
        };

        // 例：母液 0.100 mol/L を 2滴（合計0.100 mL）分取して 100 mL 定容
        var c2 = madeUp.DilutedConcentrationFromStock(0.100);
        Console.WriteLine($"C2 = {c2:G6} mol/L");
    }
}
