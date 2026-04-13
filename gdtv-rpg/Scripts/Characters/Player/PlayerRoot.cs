using Godot;
using System;

public partial class PlayerRoot : CharacterBody3D
{
    [ExportGroup("Nodes")]
    [Export]public AnimationPlayer AnimPlayerNode;
    [Export]public Sprite3D SpriteNode;

    public Vector2 playerInputVector = Vector2.Zero;
    
    public override void _Ready()
    {
        
    }
    public override void _PhysicsProcess(double delta)
    {
        Velocity = new Vector3(playerInputVector.X, 0, playerInputVector.Y) * 5;
        MoveAndSlide();
    }

    public override void _Input(InputEvent @event)
    {
        var lastX = playerInputVector.X;
        playerInputVector = Input.GetVector(RPGGameConstants.ACTION_MOVE_LEFT,
        RPGGameConstants.ACTION_MOVE_RIGHT,
        RPGGameConstants.ACTION_MOVE_FORWARD,
        RPGGameConstants.ACTION_MOVE_BACK);

        if (playerInputVector.X != 0 || playerInputVector.Y != 0)
        {
            flipPlayer(lastX);

        }
        else
        {
        }
    }

    private void flipPlayer(float lastX)
    {
            if (lastX != playerInputVector.X)
            {
                SpriteNode.FlipH = playerInputVector.X < 0;
            }

    }
}
