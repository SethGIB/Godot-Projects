using Godot;
using System;

public partial class PlayerMoveState : Node
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PlayerRoot playerCharacter = GetOwner<PlayerRoot>();
		playerCharacter.AnimPlayerNode.Play(RPGGameConstants.ANIM_MOVE);		
	}

	public override void _Notification(int what)
	{
		base._Notification(what);
		if (what == 5001)
		{
			PlayerRoot playerCharacter = GetOwner<PlayerRoot>();
			playerCharacter.AnimPlayerNode.Play(RPGGameConstants.ANIM_MOVE);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
