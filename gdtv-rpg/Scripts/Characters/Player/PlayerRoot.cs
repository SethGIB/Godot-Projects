using Godot;
using System;

public partial class PlayerRoot : CharacterBody3D
{
    [ExportGroup("Nodes")]
    [Export]private AnimationPlayer AnimPlayerNode;
    [Export]private Sprite3D SpriteNode;

    public Vector2 m_InputVector = Vector2.Zero;
    
    public override void _Ready()
    {
        AnimPlayerNode.Play(RPGGameConstants.ANIM_IDLE);
    }
    public override void _PhysicsProcess(double delta)
    {
        Velocity = new Vector3(m_InputVector.X, 0, m_InputVector.Y) * 5;
        MoveAndSlide();
    }

    public override void _Input(InputEvent @event)
    {
        var lastX = m_InputVector.X;
        m_InputVector = Input.GetVector(RPGGameConstants.ACTION_MOVE_LEFT,
        RPGGameConstants.ACTION_MOVE_RIGHT,
        RPGGameConstants.ACTION_MOVE_FORWARD,
        RPGGameConstants.ACTION_MOVE_BACK);

        if (m_InputVector.X != 0 || m_InputVector.Y != 0)
        {
            flipPlayer(lastX);

            AnimPlayerNode.Play(RPGGameConstants.ANIM_MOVE);
        }
        else
        {
            AnimPlayerNode.Play(RPGGameConstants.ANIM_IDLE);
        }
    }

    private void flipPlayer(float lastX)
    {
            if (lastX != m_InputVector.X)
            {
                SpriteNode.FlipH = m_InputVector.X < 0;
            }

    }
}
