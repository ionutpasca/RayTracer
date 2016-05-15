namespace RayTracer.Material
{
    public interface IMaterial
    {
        // (Shininess) (1 - very shiny, 5 - matt)
        double Gloss { get; set; }

        //0 - opaque , 1 - transparent
        double Transparency { get; set; }

        //How much light the element will reflect
        //0 - no reflection, 1 - mirror like
        double Reflection { get; set; }

        //specifies how the material will bend the light rays
        //value between 0 and 1
        double Refraction { get; set; }

        bool HasTexture { get; }

        //the color of the material
        //u,v - coordonates
        Color GetColor(double u, double v);
    }

    public abstract class BaseMaterial : IMaterial
    {
        protected BaseMaterial()
        {
            Gloss = 2;
            Transparency = 0; //opaque
            Reflection = 0; //not reflection
            Refraction = 0.5;
        }

        public double Gloss { get; set; }
        public double Transparency { get; set; }
        public double Reflection { get; set; }
        public double Refraction { get; set; }
        public abstract bool HasTexture { get; }
        public abstract Color GetColor(double u, double v);
    }
}