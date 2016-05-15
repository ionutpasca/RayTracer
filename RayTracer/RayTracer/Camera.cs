using RayTracer.Ray_Intersection;

namespace RayTracer
{
    public class Camera
    {
        public Vector Direction;
        public Vector Equator;
        public Vector LookUp;
        public Vector Position;
        public Vector Screen;

        public Camera(Vector position, Vector dir, Vector up)
        {
            LookUp = up.Normalize();
            Position = position;
            Direction = dir;
            Equator = Direction.Normalize().Cross(LookUp);
            Screen = Position + Direction;
        }

        public Camera(Vector position, Vector dir)
            : this(position, dir, new Vector(0, 1, 0))
        {
        }

        public Ray GetRay(double vx, double vy)
        {
            var pos = Screen - LookUp * vy - Equator * vx;
            var dir = pos - Position;

            var ray = new Ray(pos, dir.Normalize());
            return ray;
        }
    }
}