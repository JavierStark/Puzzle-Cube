using System.Numerics;
using Raylib_cs;

namespace PuzzleCube;

public class Cube
{
    private List<Piece> pieces =
    [
        new (-1, -1, -1),
        new (-1, -1, 0),
        new (-1, -1, 1),
        new (-1, 0, -1),
        new (-1, 0, 0),
        new (-1, 0, 1),
        new (-1, 1, -1),
        new (-1, 1, 0),
        new (-1, 1, 1),
        new (0, -1, -1),
        new (0, -1, 0),
        new (0, -1, 1),
        new (0, 0, -1),
        new (0, 0, 1),
        new (0, 1, -1),
        new (0, 1, 0),
        new (0, 1, 1),
        new (1, -1, -1),
        new (1, -1, 0),
        new (1, -1, 1),
        new (1, 0, -1),
        new (1, 0, 0),
        new (1, 0, 1),
        new (1, 1, -1),
        new (1, 1, 0),
        new (1, 1, 1)
    ];
    
    private const string movementSequence = "UDLRFB";
    
    private static Vector3 NotationToAxis(char face)
    {
        return face switch
        {
            'U' => new Vector3(0, 1, 0),
            'D' => new Vector3(0, -1, 0),
            'L' => new Vector3(-1, 0, 0),
            'R' => new Vector3(1, 0, 0),
            'F' => new Vector3(0, 0, 1),
            'B' => new Vector3(0, 0, -1),
            _ => new Vector3(0, 0, 0)
        };
    }
    
    public void Draw(Camera3D camera)
    {
        Raylib.BeginMode3D(camera);

        foreach (var piece in pieces)
        {
            piece.Draw();
        }

        Raylib.EndMode3D();
    }
    
    private void RotateFace(Vector3 axis, bool antiClockWise)
    {
        var angle = (antiClockWise ? 1 : -1) * MathF.PI / 2;
        foreach (var t in pieces.Where(t => Vector3.Dot(t.Position, axis) > 0.5))
        {
            t.Rotate(axis, angle);
        }
    }

    public void RotateFace(char face, bool antiClockwise = false)
    {
        RotateFace(NotationToAxis(face), antiClockwise);
    }

    public void Shuffle()
    {
        var random = new Random();
        var moves = new List<(char, bool)>();
        for (var i = 0; i < 20; i++)
        {
            moves.Add((movementSequence[random.Next(6)], random.Next(2) == 0));
        }

        foreach (var (face, antiClockwise) in moves)
        {
            RotateFace(face, antiClockwise);
        }
    }
}