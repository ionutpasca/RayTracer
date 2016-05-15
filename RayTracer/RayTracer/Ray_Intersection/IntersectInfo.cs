using RayTracer.Shape;

namespace RayTracer.Ray_Intersection
{
    public class IntersectInfo
    {
        public Color Color; //color at intersection
        public double Distance; //distance from point to screen
        public IShape Element;
        public int HitCount;
        public bool IsHit;
        public Vector Normal; //normal vector on intersection point
        public Vector Position;
    }
}