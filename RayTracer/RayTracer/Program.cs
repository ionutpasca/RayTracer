using RayTracer.Ray_Intersection;
using RayTracer.Shape;
using System.Drawing;

namespace RayTracer
{
    internal class Program
    {
        public static bool RenderDiffuse = true;
        public static Scene scene = new Scene();

        private static void Main(string[] args)
        {
            var imageWidth = 1000;
            var imageHeight = 500;
            var image = new Bitmap(imageWidth, imageHeight);
            var c = new Color();
            //for (int i = 0; i < imageWidth; i++)
            //{
            //    for (int j = 0; j < imageHeight; j++)
            //    {

            //    }
            //}
            var rect = new Rectangle(0, 0, 300, 300);
            var bitmap = new Bitmap(rect.Width, rect.Height);

            var g = Graphics.FromImage(bitmap);

            RayTraceScene(g, bitmap, scene);


            image.Save("result.bmp");
        }

        public static void RayTraceScene(Graphics g, Bitmap viewport, Scene scene)
        {
            //g.Fill(Brushes.Black, viewport);
            var buffer = new Color[viewport.Width + 2, viewport.Height + 2];

            for (var y = 0; y < viewport.Height + 2; y++)
            {
                for (var x = 0; x < viewport.Width + 2; x++)
                {
                    double yp = y * 1.0f / viewport.Height * 2 - 1;
                    double xp = x * 1.0f / viewport.Width * 2 - 1;

                    var ray = scene.Camera.GetRay(xp, yp);

                    buffer[x, y] = CalculateColor(ray, scene);
                    Brush br = new SolidBrush(buffer[x, y].ToArgb());
                    //g.FillRectangle(br, viewport.Left + x - 1, viewport.Top + y - 2, 1, 1);

                    br.Dispose();
                }
            }
            for (var i = 0; i < viewport.Width; i++)
            {
                for (var j = 0; j < viewport.Height; j++)
                {
                    viewport.SetPixel(i, j, buffer[i, j].ToArgb());
                }
            }
            viewport.Save("asda.jpg");
        }

        private static IntersectInfo TestIntersection(Ray ray, Scene scene, IShape exclude)
        {
            var hitcount = 0;
            var best = new IntersectInfo { Distance = double.MaxValue };

            foreach (var elt in scene.Shapes)
            {
                if (elt == exclude)
                    continue;

                var info = elt.Intersect(ray);
                if (!info.IsHit || !(info.Distance < best.Distance) || !(info.Distance >= 0)) continue;
                best = info;
                hitcount++;
            }
            best.HitCount = hitcount;
            return best;
        }

        public static Color CalculateColor(Ray ray, Scene scene)
        {
            var info = TestIntersection(ray, scene, null);
            if (!info.IsHit) return scene.Background.Color;
            // execute the actual raytrace algorithm
            var c = RayTrace(info, ray, scene);
            return c;
        }

        public static Color RayTrace(IntersectInfo info, Ray ray, Scene scene)
        {
            var color = info.Color * scene.Background.Ambience;
            foreach (var light in scene.Lights)
            {
                var v = (light.Position - info.Position).Normalize();
                if (!RenderDiffuse) continue;
                var L = v.Dot(info.Normal);
                if (L > 0.0f)
                    color += info.Color * light.Color * L;
            }
            color.Limit();
            return color;
        }
    }
}