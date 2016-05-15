using System;

namespace RayTracer
{
    public class Vector
    {
        public static Vector Null;
        public static Vector Infinate;
        public double x;
        public double y;
        public double z;

        static Vector()
        {
            Null = new Vector(0, 0, 0);
            Infinate = new Vector(double.MaxValue, double.MaxValue, double.MaxValue);
        }

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        //Copy constructor
        public Vector(Vector v) : this(v.x, v.y, v.z)
        {
        }

        public Vector Normalize()
        {
            var t = Magnitude();
            return new Vector(x / t, y / t, z / t);
        }

        public static Vector operator +(Vector v, Vector w)
        {
            return new Vector(w.x + v.x, w.y + v.y, w.z + v.z);
        }

        public static Vector operator -(Vector v, Vector w)
        {
            return new Vector(v.x - w.x, v.y - w.y, v.z - w.z);
        }

        public static Vector operator *(Vector v, Vector w)
        {
            return new Vector(v.x * w.x, v.y * w.y, v.z * w.z);
        }

        public static Vector operator *(Vector v, double f)
        {
            return new Vector(v.x * f, v.y * f, v.z * f);
        }

        public static Vector operator /(Vector v, double f)
        {
            return new Vector(v.x / f, v.y / f, v.z / f);
        }

        public double Dot(Vector w)
        {
            return x * w.x + y * w.y + z * w.z;
        }

        public Vector Cross(Vector w)
        {
            return new Vector(-z * w.y + y * w.z,
                z * w.x - x * w.z,
                -y * w.x + x * w.y);
        }

        public double Magnitude()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2})", x, y, z);
        }
    }
}