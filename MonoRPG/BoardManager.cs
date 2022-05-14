using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoRPG
{
	public class BoardManager
	{
		private readonly Tile _baseTile;
		private readonly int _realWidth;
		private readonly int _realHeight;
		
		public int Width { get; private set; }
		public int Height { get; private set; }
		public Tile[,] Board { get; set; }

		public BoardManager(int width, int height, Tile baseTile)
		{
			Width = width;
			Height = height;
			_baseTile = baseTile;
			_realWidth = Width * _baseTile.Box.Width;
			_realHeight = Height * _baseTile.Box.Height;
			
			Board = new Tile[Width, Height];
			
			for (int i = 0; i < Width; i++)
			{
				for (int j = 0; j < Height; j++)
				{
					Board[i,j] = new Tile(_baseTile.Sprite,
										new Rectangle(i * _baseTile.Box.Width, j * _baseTile.Box.Height,
										_baseTile.Box.Width, _baseTile.Box.Height),
										Color.White);
				}
			}
		}
		
	}
}