using System.Numerics;
using Raylib_cs;

namespace PuzzleCube;

class Program
{
    private static void Main(string[] args)
    {
        // Initialization
        const int screenWidth = 800;
        const int screenHeight = 450;
        
        Vector2 previousMousePosition = Vector2.Zero;
        
        var camera = new Camera3D
        {
            Position = new Vector3(5.0f, 5.0f, 5.0f), // Camera position
            Target = Vector3.Zero, // Camera target
            Up = new Vector3(0.0f, 1.0f, 0.0f), // Camera up vector (rotation towards target)
            FovY = 45.0f, // Camera field-of-view Y
            Projection = CameraProjection.Perspective
        };
        
        var cube = new Cube();

        Raylib.InitWindow(screenWidth, screenHeight, "PuzzleCube");

        while (!Raylib.WindowShouldClose())
        {
            var key = (char)Raylib.GetCharPressed();
            key = char.ToUpper(key);
            
            bool antiClockwise = Raylib.IsKeyDown(KeyboardKey.LeftShift);

            if (key == 'A')
            {
                cube.Shuffle();
            }
            else if(key != 0) cube.RotateFace(key, antiClockwise);

            if (Raylib.IsMouseButtonDown(MouseButton.Left))
            {
                var mouseDelta = Raylib.GetMouseDelta();
                
                camera.Target = Vector3.Zero;
                
                camera.Position = Vector3.Transform(camera.Position, Matrix4x4.CreateFromAxisAngle(Vector3.UnitY, -mouseDelta.X * 0.01f));
                
            }
            
            
            
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);
            
            cube.Draw(camera);

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}