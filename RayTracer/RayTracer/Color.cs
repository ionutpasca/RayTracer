using System;

namespace RayTracer
{
    public class Color
    {
        public double Blue;
        public double Green;
        public double Red;

        public Color()
        {
            Red = 0;
            Green = 0;
            Blue = 0;
        }

        public Color(double r, double g, double b)
        {
            Red = r;
            Green = g;
            Blue = b;
        }

        public Color(Color col)
        {
            Red = col.Red;
            Green = col.Green;
            Blue = col.Blue;
        }

        public static Color operator +(Color c1, Color c2)
        {
            var result = new Color
            {
                Red = c1.Red + c2.Red,
                Green = c1.Green + c2.Green,
                Blue = c1.Blue + c2.Blue
            };

            return result;
        }

        public static Color operator -(Color c1, Color c2)
        {
            var result = new Color
            {
                Red = c1.Red - c2.Red,
                Green = c1.Green - c2.Green,
                Blue = c1.Blue - c2.Blue
            };

            return result;
        }

        public static Color operator *(Color c1, Color c2)
        {
            var result = new Color
            {
                Red = c1.Red * c2.Red,
                Green = c1.Green * c2.Green,
                Blue = c1.Blue * c2.Blue
            };

            return result;
        }

        public static Color operator *(Color col, double f)
        {
            var result = new Color
            {
                Red = col.Red * f,
                Green = col.Green * f,
                Blue = col.Blue * f
            };

            return result;
        }

        public static Color operator /(Color col, double f)
        {
            var result = new Color
            {
                Red = col.Red / f,
                Green = col.Green / f,
                Blue = col.Blue / f
            };

            return result;
        }

        public void Limit()
        {
            Red = Red > 0.0 ? (Red > 1.0 ? 1.0f : Red) : 0.0f;
            Green = Green > 0.0 ? (Green > 1.0 ? 1.0f : Green) : 0.0f;
            Blue = Blue > 0.0 ? (Blue > 1.0 ? 1.0f : Blue) : 0.0f;
        }

        public void ToBlack()
        {
            Red = 0;
            Green = 0;
            Blue = 0;
        }

        public double Distance(Color color)
        {
            var dist = Math.Abs(Red - color.Red) + Math.Abs(Green - color.Green) + Math.Abs(Blue - color.Blue);
            return dist;
        }

        public Color Blend(Color other, double weight)
        {
            var result = this * (1 - weight) + other * weight;
            return result;
        }

        public System.Drawing.Color ToArgb()
        {
            return System.Drawing.Color.FromArgb((int)(Red * 255), (int)(Green * 255), (int)(Blue * 255));
        }
    }
}