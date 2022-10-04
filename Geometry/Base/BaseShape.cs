﻿using System.Diagnostics.Metrics;
using System;
using System.Numerics;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Reflection;

namespace Geometry.Shapes
{
    public abstract class BaseShape
    {
        public abstract Vector3 Center { get; }
        public abstract float Area { get; }

        public static BaseShape GenerateShape() => GenerateShape(GenerateRandomVector3());

        public static BaseShape GenerateShape(Vector3 center3D)
        {
            Vector2 center2D = new Vector2(center3D.X, center3D.Y);

            Random random = new Random();
            int i = random.Next(0, 7);

            return i switch
            {
                0 => new Circle(center2D, random.Next(1, 20)),
                1 => new Cuboid(center3D, random.Next(1, 20)), //Cube
                2 => new Cuboid(center3D, GenerateRandomVector3()),
                3 => new Rectangle(center2D, GenerateRandomVector2()),
                4 => new Rectangle(center2D, random.Next(1, 20)), //Square
                5 => new Sphere(center3D, random.Next(1, 20)),
                6 => new Triangle(center3D, GenerateRandomVector2(), GenerateRandomVector2()),
            };
        }

        private static Vector2 GenerateRandomVector2()
        {
            Random random = new Random();
            return new Vector2(random.Next(1, 20), random.Next(1, 20));
        }

        private static Vector3 GenerateRandomVector3()
        {
            Random random = new Random();
            return new Vector3(random.Next(1, 20), random.Next(1, 20), random.Next(1, 20));
        }

    }

}

  