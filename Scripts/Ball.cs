using Godot;

namespace LearnBrickBreaker.Scripts;

public partial class Ball : RigidBody2D
{
	[Export] public Vector2 StartingVelocity { get; set; } = Vector2.Zero;
	[Export] public float Speed { get; set; } = 300;
	
	[Export] public int Power { get; set; } = 1;
	
	public override void _Ready()
	{
		LinearVelocity = StartingVelocity * Speed;
	}

	private void OnBodyEntered(Node body)
	{
		if (body is Brick brick)
		{
			brick.TakeDamage(Power);
		}
	}
}
