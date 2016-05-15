using RayTracer.Material;
using RayTracer.Ray_Intersection;
using System;

namespace RayTracer.Shape
{
    public class SphereShape : BaseShape
    {
        public double R;

        public SphereShape(Vector pos, double r, IMaterial material)
        {
            R = r;
            Position = pos;
            Material = material;
        }

        public override IntersectInfo Intersect(Ray ray)
        {
            var info = new IntersectInfo();
            info.Element = this;

            var dst = ray.Position - Position;
            var B = dst.Dot(ray.Direction);
            var C = dst.Dot(dst) - R * R;
            var D = B * B - C;

            if (D > 0)
            {
                info.IsHit = true;
                info.Distance = -B - Math.Sqrt(D);
                info.Position = ray.Position + ray.Direction * info.Distance;
                info.Normal = (info.Position - Position).Normalize();

                info.Color = Material.GetColor(0, 0);
            }
            else
            {
                info.IsHit = false;
            }
            return info;
        }

        public override string ToString()
        {
            return $"Sphere ({Position.x},{Position.y},{Position.z}) Radius {R}";
        }
    }
}