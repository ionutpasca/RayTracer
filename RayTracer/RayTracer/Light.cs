using System;
using System.Collections.Generic;

namespace RayTracer
{
    public class Light
    {
        public Color Color;
        public Vector Position;
        public double strength;

        public Light(Vector position, Color c)
        {
            Position = position;
            Color = c;
            strength = 10;
        }

        public double Strength(double distance)
        {
            return distance >= strength ? 0 : Math.Pow((strength - distance) / strength, .2);
        }
    }

    public class Lights : List<Light>
    {
    }
}