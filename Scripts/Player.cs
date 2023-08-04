using Godot;

namespace LearnBrickBreaker.Scripts;

public partial class Player : StaticBody2D
{
	[Export] public int Speed { get; set; } = 400;
	[Export] public float Width { get; set; } = 64;
	
	[Export] public PackedScene BallScene { get; set; }
	[Export] public float BallSpawnOffset { get; set; } = 16;
	
	private Vector2 screenSize;
	private Node sceneRootNode;
	private StringName moveLeftInputString = new("player_move_left");
	private StringName moveRightInputString = new("player_move_right");
	private StringName spawnBallInputString = new("spawn_ball");

	private float ScreenMinPosition => Width / 2;
	private float ScreenMaxPosition => screenSize.X - Width / 2;
	
	public override void _Ready()
	{
		screenSize = GetViewportRect().Size;
		sceneRootNode = GetTree().CurrentScene;
	}

	public override void _Process(double delta)
	{
		Vector2 velocity = Vector2.Zero;
		
		if (Input.IsActionPressed(moveLeftInputString))
		{
			velocity.X -= 1;
		}
		if (Input.IsActionPressed(moveRightInputString))
		{
			velocity.X += 1;
		}

		if (Input.IsActionJustPressed(spawnBallInputString))
		{
			Ball newBall = BallScene.Instantiate<Ball>();
			newBall.Position = Position + new Vector2(0, BallSpawnOffset);
			sceneRootNode.AddChild(newBall);
		}

		velocity = velocity.Normalized() * Speed;
		
		Vector2 currentPosition = Position;
		currentPosition.X += velocity.X * (float)delta;
		currentPosition.X = Mathf.Clamp(currentPosition.X, ScreenMinPosition, ScreenMaxPosition);
		
		Position = currentPosition;
	}
}