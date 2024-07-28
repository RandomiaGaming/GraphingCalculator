public static class Program
{
    public static void Main()
    {
        System.Console.WriteLine(MathHelper.AngleNonLoopDif((60) * MathHelper.DegToRad, (45 + 360 + 360 + 360) * MathHelper.DegToRad) * MathHelper.RadToDeg);
        System.Console.ReadLine();
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.Abs);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.ACos);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.ACot);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.ACsc);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.AngleClamp);
        //GraphingCalculator.GraphingCalculator.Graph(MathHelper.AngleDif);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.ASec);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.ASin);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.ATan);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.Cbrt);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.Ceil);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.CeilMag);
        //GraphingCalculator.GraphingCalculator.Graph(MathHelper.Clamp);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.Clamp01);
        //GraphingCalculator.GraphingCalculator.Graph(MathHelper.ConstInterp);
        //GraphingCalculator.GraphingCalculator.Graph(MathHelper.ConstLoopInterp);
        //GraphingCalculator.GraphingCalculator.Graph(MathHelper.ConstPingPongInterp);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.Cos);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.Cot);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.Csc);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.Cube);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.DegToRadAcc);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.Exp);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.Fact);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.Floor);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.FloorMag);
        //GraphingCalculator.GraphingCalculator.Graph(MathHelper.IsInt);
        //GraphingCalculator.GraphingCalculator.Graph(MathHelper.IsRealNumber);
       // GraphingCalculator.GraphingCalculator.Graph(MathHelper.LinInterp);
        //GraphingCalculator.GraphingCalculator.Graph(MathHelper.LinLoopInterp);
        //GraphingCalculator.GraphingCalculator.Graph(MathHelper.LinPingPongInterp);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.Ln);
        //GraphingCalculator.GraphingCalculator.Graph(MathHelper.Log);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.Log10);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.Log2);
        //GraphingCalculator.GraphingCalculator.Graph(MathHelper.LoopClamp);
        //Left off here
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.LoopClamp01);
        //GraphingCalculator.GraphingCalculator.Graph(MathHelper.Max);
        //GraphingCalculator.GraphingCalculator.Graph(MathHelper.MaxMag);
        //GraphingCalculator.GraphingCalculator.Graph(MathHelper.Min);
        //GraphingCalculator.GraphingCalculator.Graph(MathHelper.MinMag);
        //GraphingCalculator.GraphingCalculator.Graph(MathHelper.PingPongClamp);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.PingPongClamp01);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.RadToDegAcc);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.Recip);
        //GraphingCalculator.GraphingCalculator.Graph(MathHelper.Rem);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.Round);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.Sec);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.Sign);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.Sin);
        //GraphingCalculator.GraphingCalculator.Graph(MathHelper.SinInterp);
        //GraphingCalculator.GraphingCalculator.Graph(MathHelper.SinLoopInterp);
        //GraphingCalculator.GraphingCalculator.Graph(MathHelper.SinPingPongInterp);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.Sqr);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.Sqrt);
        GraphingCalculator.GraphingCalculator.Graph(MathHelper.Tan);
    }
    public static double TestMethod(double input)
    {
        return MathHelper.AngleNonLoopDif(input, 0);
    }
}