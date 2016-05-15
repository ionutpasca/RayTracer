namespace RayTracer
{
    public class Background
    {
        public double Ambience; //the ambient light used [0,1]
        public Color Color; //the color of the background

        public Background(Color c, double amb)
        {
            Color = c;
            Ambience = amb;
        }
    }
}