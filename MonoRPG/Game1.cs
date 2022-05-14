using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;

namespace MonoRPG
{
	public class Game1 : Game
	{
		// Monogame variables
		private GraphicsDeviceManager _graphicsDeviceManager;
		private SpriteBatch _spriteBatch;

		private const int SCREEN_WIDTH = 1600;
		private const int SCREEN_HEIGHT = 900;

		// sprites
		Texture2D baseTile;
		
		// fonts
		SpriteFont gameFont;
		
		Vector2 targetPosition = new Vector2(300,300);
		MouseState mouseState;
		int score = 0;
		
		
		public Camera Camera { get; set; }
		
		
		public Game1()
		{
			_graphicsDeviceManager = new GraphicsDeviceManager(this);
			Camera = new Camera();
			Content.RootDirectory = "Content";
			IsMouseVisible = true;			
		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
			_graphicsDeviceManager.IsFullScreen = false;
			_graphicsDeviceManager.PreferredBackBufferWidth = SCREEN_WIDTH;
			_graphicsDeviceManager.PreferredBackBufferHeight = SCREEN_HEIGHT;			
			_graphicsDeviceManager.ApplyChanges();
			
			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			baseTile = Content.Load<Texture2D>("BaseTile");	
			
			gameFont = Content.Load<SpriteFont>("galleryFont");		
		}

		protected override void Update(GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keys.D))
			{
				Camera.MoveCamera(new Vector2(10, 0));
			}
			
			if (Keyboard.GetState().IsKeyDown(Keys.A)) 
			{
				Camera.MoveCamera(new Vector2(-10, 0));
			}
			
			if (Keyboard.GetState().IsKeyDown(Keys.W)) 
			{
				Camera.MoveCamera(new Vector2(0, -10));
			}
			
			if (Keyboard.GetState().IsKeyDown(Keys.S)) 
			{
				Camera.MoveCamera(new Vector2(0, 10));
			}
			
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
				
				
			mouseState = Mouse.GetState();
			
			
			if (mouseState.LeftButton == ButtonState.Pressed) 
			{
				score++;
			}
			
		
			

			base.Update(gameTime);
		}

		private readonly int _tileSize = 100;
		
		protected override void Draw(GameTime gameTime)
		{
			_graphicsDeviceManager.GraphicsDevice.Clear(Color.CornflowerBlue);			
			
			
			_spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied,
								null, null, null, null, Camera.GetTransformMatrix());
			
			for (int i = 0; i < 20; i++)
			{
				for (int j = 0; j < 20; j++)
				{
					_spriteBatch.Draw(baseTile, new Rectangle(i * _tileSize, j * _tileSize, _tileSize, _tileSize), Color.White);
				}
			}
			
					
			_spriteBatch.DrawString(gameFont, "New game here", new Vector2(100,100), Color.White);
			
			_spriteBatch.DrawString(gameFont, _graphicsDeviceManager.PreferredBackBufferHeight.ToString(), new Vector2(400,200), Color.White);
			
			_spriteBatch.DrawString(gameFont, score.ToString(), new Vector2(0,300), Color.White);
			
					
			_spriteBatch.End();
			
			base.Draw(gameTime);
		}
	}
}
