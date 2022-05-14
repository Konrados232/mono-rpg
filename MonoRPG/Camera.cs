using Microsoft.Xna.Framework;

namespace MonoRPG
{
	public class Camera
	{
		public float Zoom { get; set; }
		public float Rotation { get; set; }
		
		public Vector2 Position { get; set; }
		public Vector2 Origin { get; set; }
		
		public Camera()
		{
			Rotation = 0.0f;
			Zoom = 1.0f;
			Position = Vector2.Zero;
			Origin = Vector2.Zero;
		}
		
		public void MoveCamera(Vector2 movePosition) 
		{
			Position += movePosition;
		}
		
		public Matrix GetTransformMatrix() 
		{
			var translationMatrix = Matrix.CreateTranslation(new Vector3(-Position.X, -Position.Y, 0.0f));
			var rotationMatrix = Matrix.CreateRotationZ(Rotation);
			var scaleMatrix = Matrix.CreateScale(Zoom);
			var originMatrix = Matrix.CreateTranslation(new Vector3(Origin.X, Origin.Y, 0.0f));
			
			return translationMatrix * scaleMatrix * rotationMatrix * originMatrix;
		}
	}
}