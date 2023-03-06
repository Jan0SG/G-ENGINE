using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_Engine
{
    public class Cardioid
    {
        public Cardioid(float radius, float height, int numPoints, ref Mesh mesh)
        {
            PointF3D[] vertices = new PointF3D[numPoints];

            // Generate points on the cardioid curve
            for (int i = 0; i < numPoints; i++)
            {
                double t = 2 * Math.PI * i / numPoints;
                double x = radius * (2 * Math.Cos(t) - Math.Cos(2 * t));
                double y = height * (2 * Math.Sin(t) - Math.Sin(2 * t));
                vertices[i] = new PointF3D((float)x, (float)y, 0);
            }

            // Generate triangles to form the surface of the cardioid
            for (int i = 0; i < numPoints; i++)
            {
                Triangle t = new Triangle();
                t.Add(vertices[i]);
                t.Add(vertices[(i + 1) % numPoints]);
                t.Add(new PointF3D(0, 0, 0));
                mesh.Figures.Add(t);
            }
        }
    }
}







