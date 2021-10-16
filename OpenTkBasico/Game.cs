using System;
using System.Collections.Generic;
using System.Text;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenTkBasico
{
    class Game
    {
        GameWindow window;
        Double ani = 0.0;
        public Game(GameWindow window)
        {
            this.window = window;
            inciciar();
        }
        void inciciar()
        {
            window.Load += loaded;
            window.Resize += resize;
            window.RenderFrame += renderF;
            window.Run(1.0 / 60.0);
        }

        void resize(Object o, EventArgs e)
        {
            GL.Viewport(0, 0, window.Width, window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-50, 50.0,-50, 50,-1,1); // plano carteciano
            //Matrix4 matrix = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, window.Width / window.Height, 1.0f, 100.0f);
            //GL.LoadMatrix(ref matrix);
            GL.MatrixMode(MatrixMode.Modelview);
        }
        void renderF(Object o, EventArgs e)
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit |ClearBufferMask.DepthBufferBit);
            //GL.Translate(0, 0, -45); //para trasladar el plano
            GL.Rotate(ani, 0, 0, 1);


            addCuadrado(-12.5,0, -37.4, 0, -37.4 ,- 25, -12.5,- 25);
            addCuadrado(37.4,12.5,12.5,12.5,12.5,-12.5,37.4,-12.5);

            addLinea(-25, 20, 25, 30);
            addLinea(-37.4, 0, 12.5, 12.5);
            addLinea(-12.5, 0, 37.4, 12.5);

            addLinea(-37.4, -25, 12.5, -12.5);
            addLinea(37.4, -12.5, -12.5, -25);



            addTriangulo(12.5, 12.5, 25, 30, 37.4, 12.5);
            addTriangulo(-37.4, 0, -25,20 , -12.5, 0);
            window.SwapBuffers();

            ani += 1.0;
            if(ani> 360)
            {
                ani -= 360;
            }
        }
        void addLinea(Double X1, Double Y1, Double X2, Double Y2)
        {
            GL.Begin(BeginMode.Lines);
            GL.Color3(1.0f, 0.0f, 1.0f);
            GL.Vertex2(X1, Y1);
            GL.Vertex2(X2, Y2);
            GL.End();

        }
        void addTriangulo(Double X1,Double Y1, Double X2, Double Y2,Double X3, double Y3)
        {
            GL.Begin(BeginMode.Triangles);
            GL.Color3(1, 0.5, 0);
            GL.Vertex2(X1, Y1);// lado izquierdo
            GL.Vertex2(X2, Y2); // altura
            GL.Vertex2(X3, Y3); // lado derecho
            GL.End();
        }
        void addCuadrado(Double X1, Double Y1, Double X2, Double Y2, Double X3, double Y3,Double X4,Double Y4)
        {
            GL.Begin(BeginMode.Quads);
            GL.Color3(0, 0.5, 0);
            GL.Vertex2(X1, Y1);
            GL.Vertex2(X2, Y2);
            GL.Vertex2(X3, Y3);
            GL.Vertex2(X4, Y4);
            GL.End();

        }

        void cuadrado3D()
        {
            GL.Begin(BeginMode.Quads);

            GL.Color3(1.0, 1.0, 0.0);
            GL.Vertex3(-10.0, 10.0, 10.0);
            GL.Vertex3(-10.0, 10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, 10.0);

            GL.Color3(1.0, 0.0, 1.0);
            GL.Vertex3(10.0, 10.0, 10.0);
            GL.Vertex3(10.0, 10.0, -10.0);
            GL.Vertex3(10.0, -10.0, -10.0);
            GL.Vertex3(10.0, -10.0, 10.0);

            GL.Color3(0.0, 1.0, 1.0);
            GL.Vertex3(10.0, -10.0, 10.0);
            GL.Vertex3(10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, 10.0);

            GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex3(10.0, 10.0, 10.0);
            GL.Vertex3(10.0, 10.0, -10.0);
            GL.Vertex3(-10.0, 10.0, -10.0);
            GL.Vertex3(-10.0, 10.0, 10.0);

            GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex3(10.0, 10.0, -10.0);
            GL.Vertex3(10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, -10.0, -10.0);
            GL.Vertex3(-10.0, 10.0, -10.0);

            GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex3(10.0, 10.0, 10.0);
            GL.Vertex3(10.0, -10.0, 10.0);
            GL.Vertex3(-10.0, -10.0, 10.0);
            GL.Vertex3(-10.0, 10.0, 10.0);
            GL.End();

        }
        void loaded(Object o, EventArgs e)
        {
            GL.ClearColor(0, 0, 0, 0);
            GL.Enable(EnableCap.DepthTest);

        }
    }
}
