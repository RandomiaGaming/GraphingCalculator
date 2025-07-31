using System;
namespace GraphingCalculator
{
	public sealed class TestGraph : Graph
	{
		public const double RadToDeg = 57.295779513082323;
		public const double DegToRad = 0.017453292519943295;
		public const double PI = 3.1415926535897931;
		public const double E = 2.7182818284590451;
		public override double[] Sample(double x, double y)
		{
			return new double[2] { x, y };
		}
		public static double MinMag(double a, double b)
		{
			if (a == double.NaN || a == double.PositiveInfinity || a == double.NegativeInfinity)
			{
				throw new System.Exception("a must be a real number.");
			}
			if (b == double.NaN || b == double.PositiveInfinity || b == double.NegativeInfinity)
			{
				throw new System.Exception("b must be a real number.");
			}
			if (a >= 0 && b >= 0)
			{
				if (a > b)
				{
					return b;
				}
				return a;
			}
			else if (a < 0 && b < 0)
			{
				if (a < b)
				{
					return b;
				}
				return a;
			}
			else if (a >= 0 && b < 0)
			{
				if (a > -b)
				{
					return b;
				}
				return a;
			}
			else if (a < -b)
			{
				return b;
			}
			return a;
		}
		public static double Arctan2(double x, double y)
		{
			double systemReturn = System.Math.Atan2(y, x);
			if (systemReturn < 0)
			{
				systemReturn += 2 * PI;
			}
			return systemReturn * RadToDeg;
		}
	}
}