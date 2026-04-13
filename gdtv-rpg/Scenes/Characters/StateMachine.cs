using Godot;
using System;
using System.ComponentModel;

public partial class StateMachine : Node
{
	[Export] private Node CurrentState;
	[Export] private Node[] AnimationStates;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		CurrentState.Notification(5001);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void TransitionToState<T>()
	{
		Node nextState = null;
		foreach (var state in AnimationStates)
		{
			if (state is T)
			{
				nextState = state;
			}
		}
	}

}
