using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_Engine
{
    public class ICOSAEDRO
    {

            public ICOSAEDRO(float radius, ref Mesh mesh)
            {
                float phi = (float)(1 + Math.Sqrt(5)) / 2; // razón áurea
                float a = radius / (float)Math.Sqrt(phi * phi + 1);
                float b = a * phi;

                PointF3D[] vertices = new PointF3D[]
                {
                new PointF3D(-a, 0, b),
                new PointF3D(a, 0, b),
                new PointF3D(-a, 0, -b),
                new PointF3D(a, 0, -b),
                new PointF3D(0, b, a),
                new PointF3D(0, b, -a),
                new PointF3D(0, -b, a),
                new PointF3D(0, -b, -a),
                new PointF3D(b, a, 0),
                new PointF3D(-b, a, 0),
                new PointF3D(b, -a, 0),
                new PointF3D(-b, -a, 0)
                };

                int[,] faces = new int[,]
                {
                {0,4,1}, {0,9,4}, {9,5,4}, {4,5,8}, {4,8,1},
                {8,10,1}, {8,3,10}, {5,3,8}, {5,2,3}, {2,7,3},
                {7,10,3}, {7,6,10}, {7,11,6}, {11,0,6}, {0,1,6},
                {6,1,10}, {9,0,11}, {9,11,2}, {9,2,5}, {7,2,11}
                };

                for (int i = 0; i < faces.GetLength(0); i++)
                {
                    Triangle t = new Triangle();
                    for (int j = 0; j < 3; j++)
                    {
                        t.Add(vertices[faces[i, j]]);
                    }
                    mesh.Figures.Add(t);
                }
            }
        }
    }


