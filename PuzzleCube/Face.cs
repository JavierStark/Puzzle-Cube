using System.Numerics;
using Raylib_cs;

namespace PuzzleCube;

public class Face(Color color, Vector3 position)
{
    private Vector3 _position = position;

    public void Draw()
    {
        Raylib.DrawCube(_position, 0.8f, 0.8f, 0.8f, color);
    }
    
    public void Rotate(Vector3 axis, float angle)
    {
        _position = Vector3.Transform(_position, Matrix4x4.CreateFromAxisAngle(axis, angle));
    }
}