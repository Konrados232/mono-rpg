using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoRPG
{
	public class InfoBox
	{
		public Vector2 Position { get; set; }
		public Rectangle Box { get; set; }
		public bool IsShown { get; set; }
		public List<InfoString> StringInfo { get; set; }
		public SpriteFont Font { get; private set; }

		public InfoBox(Rectangle box, List<InfoString> stringInfo, SpriteFont font)
		{
			Box = box;
			IsShown = false;
			StringInfo = stringInfo;
			Font = font;
		}
	}
}