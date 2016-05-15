namespace RayTracer.Ray_Intersection
{
    public class Ray
    {
        public Vector Direction;
        public Vector Position;

        public Ray(Vector position, Vector dir)
        {
            Position = position;
            Direction = dir;
        }
    }
}