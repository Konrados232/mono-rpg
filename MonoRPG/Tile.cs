using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

// TO-DO change Tile to interface so I can have multiple types of Tiles

namespace MonoRPG
{
	public class Tile
	{		
		public Texture2D Sprite { get; set; }
		public Rectangle Box { get; set; }
		public Color Color { get; set; }

		public Tile(Texture2D sprite, Rectangle box, Color color)
		{
			Sprite = sprite;
			Box = box;
			Color = color;
		}
	}
}