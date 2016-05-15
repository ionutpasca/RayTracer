using RayTracer.Material;
using RayTracer.Ray_Intersection;
using System.Collections.Generic;

namespace RayTracer.Shape
{
    public interface IShape
    {
        //Position of the element
        Vector Position { get; set; }
        IMaterial Material { get; set; }
        IntersectInfo Intersect(Ray ray);
    }

    public class Shapes : List<IShape>
    {
    }

    public abstract class BaseShape : IShape
    {
        protected BaseShape()
        {
            Position = new Vector(0, 0, 0);
            Material = new SolidMaterial(new Color(1, 0, 1), 0, 0, 0);
        }

        public Vector Position { get; set; }
        public IMaterial Material { get; set; }
        public abstract IntersectInfo Intersect(Ray ray);
    }
}