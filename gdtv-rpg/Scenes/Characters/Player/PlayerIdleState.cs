using Godot;
using System;

public partial class PlayerIdleState : Node
{
	// Called when the node enters the scene tree for the first time.
	private PlayerRoot playerCharacter;
	public override void _Ready()
	{
		playerCharacter = GetOwner<PlayerRoot>();
	}

	public override void _Notification(int what)
	{
		base._Notification(what);
		if (what == 5001)
		{
			playerCharacter.AnimPlayerNode.Play(RPGGameConstants.ANIM_IDLE);
		}
	}

    public override void _PhysicsProcess(double delta)
    {
		if (playerCharacter.playerInputVector.X != 0 || playerCharacter.playerInputVector.Y != 0)
		{}
			
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
