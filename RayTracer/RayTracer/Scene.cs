using RayTracer.Shape;

namespace RayTracer
{
    public class Scene
    {
        public Background Background;
        public Camera Camera;
        public Lights Lights;
        public Shapes Shapes;

        public Scene()
        {
            Camera = new Camera(new Vector(0, 0, -5), new Vector(0, 0, 1));
            Shapes = new Shapes();
            Lights = new Lights();
            Background = new Background(new Color(0, 0, .5), 0.2);
        }
    }
}