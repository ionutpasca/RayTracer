namespace RayTracer.Material
{
    public class SolidMaterial : BaseMaterial
    {
        private readonly Color color;

        public SolidMaterial(Color c, double reflection, double transparency, double gloss)
        {
            color = c;
            Reflection = reflection;
            Transparency = transparency;
            Gloss = gloss;
        }

        public override bool HasTexture => false;

        public override Color GetColor(double u, double v)
        {
            return color;
        }
    }
}