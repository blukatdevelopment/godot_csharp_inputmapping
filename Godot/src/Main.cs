using Godot;
using System;
using System.Collections.Generic;
using Input;

public class Main : Node2D
{
	public static InputState state;
	public Menu menu;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		state = new InputState(InputConstants.DefaultKeyMappings(), InputConstants.DefaultAxisMappings());
		AddChild(state);
		menu = new Menu();
		AddChild(menu);
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
