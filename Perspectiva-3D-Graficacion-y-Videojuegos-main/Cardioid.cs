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
        public Cardioid(double radius, double height, int numPoints, ref Mesh mesh)
        {

            PointF3D[] vertices = new PointF3D[numPoints];
            

            // Generate points on the cardioid curve
            for (float j = 0; j < 2; j=j+(float)(1))
            {
                for (int i = 0; i < numPoints; i++)
                {
                    double t = 2 * Math.PI * i / numPoints;
                    double x = radius * (2 * Math.Cos(t) - Math.Cos(2 * t));
                    double y = height * (2 * Math.Sin(t) - Math.Sin(2 * t));
                    
                    vertices[i] = new PointF3D((float)x, (float)y, (float)(j - 0.5));
                }

                // Generate triangles to form the surface of the cardioid
                for (int i = 0; i < numPoints; i++)
                {
                    Triangle t = new Triangle();
                    t.Add(vertices[i]);
                    t.Add(vertices[(i + 1) % numPoints]);
                    t.Add(new PointF3D(0, 0, (float)(j - 0.5)));
                    mesh.Figures.Add(t);
                }
            }

                int verticesPerCardioid = numPoints;
                PointF3D[] verticesTop = new PointF3D[verticesPerCardioid];
                PointF3D[] verticesBottom = new PointF3D[verticesPerCardioid];

                // Generate points on the cardioid curve for the top and bottom halves
                for (int i = 0; i < verticesPerCardioid; i++)
                {
                    double t = 2 * Math.PI * i / numPoints;
                    double x = radius * (2 * Math.Cos(t) - Math.Cos(2 * t));
                    double y = height * (2 * Math.Sin(t) - Math.Sin(2 * t));

                    verticesTop[i] = new PointF3D((float)x, (float)y, (float)0.5);
                    verticesBottom[i] = new PointF3D((float)x, (float)y, (float)-0.5);
                }

                // Generate triangles to form the surface connecting the top and bottom halves
                for (int i = 0; i < verticesPerCardioid; i++)
                {
                    Triangle t = new Triangle();
                    t.Add(verticesTop[i]);
                    t.Add(verticesTop[(i + 1) % numPoints]);
                    t.Add(verticesBottom[(i + 1) % numPoints]);
                    mesh.Figures.Add(t);

                    t = new Triangle();
                    t.Add(verticesTop[i]);
                    t.Add(verticesBottom[(i + 1) % numPoints]);
                    t.Add(verticesBottom[i]);
                    mesh.Figures.Add(t);
                }
            

            // Generate triangles to form the surface of the cardioid
            /*for (int i = 0; i < numPoints; i++)
            {
                Triangle t = new Triangle();
                t.Add(vertices[i]);
                t.Add(vertices[(i + 1) % numPoints]);
                t.Add(new PointF3D(0, 0, 0));
                mesh.Figures.Add(t);
            }*/
        }
    }
}