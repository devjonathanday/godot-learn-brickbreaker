using Godot;

namespace LearnBrickBreaker.Scripts;

public partial class Brick : StaticBody2D
{
	[Export] private Sprite2D sprite;
	[Export] private int health;
	[Export] private int textureHeight;

	public override void _Process(double delta)
	{
		Rect2 newRect = sprite.RegionRect;
		Vector2 newRectPosition = newRect.Position;
		newRectPosition.Y = textureHeight * (health - 1);
		newRect.Position = newRectPosition;
		sprite.RegionRect = newRect;
	}

	public void TakeDamage(int damageAmount)
	{
		health -= damageAmount;
		if (health == 0)
		{
			QueueFree();
		}
	}
}
