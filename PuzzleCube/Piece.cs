using System.Numerics;
using System.Runtime.InteropServices;
using Raylib_cs;

namespace PuzzleCube;

public class Piece
{
    private const float FACE_DISPLACEMENT = 0.2f;
    
    public Vector3 Position { get; private set; }

    private List<Face> faces;

    
    
    public Piece(int x, int y, int z)
    {
        Position = new Vector3(x, y, z);
        
        faces = [
            new Face(Color.White, new Vector3(0, 1, 0) * FACE_DISPLACEMENT  + Position),
            new Face(Color.Yellow, new Vector3(0, -1, 0) * FACE_DISPLACEMENT  + Position),
            new Face(Color.Green, new Vector3(-1, 0, 0) * FACE_DISPLACEMENT  + Position),
            new Face(Color.Blue , new Vector3(1, 0, 0) * FACE_DISPLACEMENT  + Position),
            new Face(Color.Red, new Vector3(0, 0, 1) * FACE_DISPLACEMENT  + Position),
            new Face(Color.Orange, new Vector3(0, 0, -1) * FACE_DISPLACEMENT  + Position)
        ];
    }
    
    public void Draw()
    {
        Raylib.DrawCube(Position, 1, 1, 1, Color.Black);
        
        foreach (var face in faces)
        {
            face.Draw();
        }
    }
    
    public void Rotate(Vector3 axis, float angle)
    {
        Position = Vector3.Transform(Position, Matrix4x4.CreateFromAxisAngle(axis, angle));
        
        foreach (var face in faces)
        {
            face.Rotate(axis, angle);
        }
    }

}