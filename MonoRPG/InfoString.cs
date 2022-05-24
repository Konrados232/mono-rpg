using Microsoft.Xna.Framework;

namespace MonoRPG
{
	public class InfoString
	{
		public Vector2 Position { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }

		public InfoString(Vector2 position, string name, string description)
		{
			Position = position;
			Name = name;
			Description = description;
		}
		
		public string FormatString()
		{
			return $"{Name} : {Description}";
		}
	}
}