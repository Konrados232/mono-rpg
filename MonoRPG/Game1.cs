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
		Texture2D baseSprite;
		
		// fonts
		SpriteFont gameFont;
		
		// 
		MouseState mouseState;
		Vector2 translatedMousePos = Vector2.Zero;
		
		int score = 0;
		
		private Tile _baseTile;
		public Camera Camera { get; set; }
		
		public BoardManager BoardManager { get; set; }
		
		public InputController InputController { get; set; }
		

		public Game1()
		{
			_graphicsDeviceManager = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			Camera = new Camera();
			IsMouseVisible = true;			
		}

		protected override void Initialize()
		{
			_graphicsDeviceManager.IsFullScreen = false;
			_graphicsDeviceManager.PreferredBackBufferWidth = SCREEN_WIDTH;
			_graphicsDeviceManager.PreferredBackBufferHeight = SCREEN_HEIGHT;			
			_graphicsDeviceManager.ApplyChanges();
			
			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			baseSprite = Content.Load<Texture2D>("BaseTile");
			
			gameFont = Content.Load<SpriteFont>("galleryFont");		
						
			_baseTile = new Tile(baseSprite, new Rectangle(0, 0, 100, 100), Color.White);
			BoardManager = new BoardManager(20, 20, _baseTile);
			InputController = new InputController();
		}

		private bool IsOutsideBounds(Point mousePos) 
		{
			return (mousePos.X < 0 || mousePos.X > SCREEN_WIDTH)
						|| (mousePos.Y < 0 || mousePos.Y > SCREEN_HEIGHT);

		}
		
		private void TranslateMousePosition(Vector2 screenMousePosition, Vector2 cameraOffset) 
		{
			translatedMousePos.X = screenMousePosition.X + cameraOffset.X;
			translatedMousePos.Y = screenMousePosition.Y + cameraOffset.Y;
		}
		
		bool locked = false;
		
		protected override void Update(GameTime gameTime)
		{
			mouseState = Mouse.GetState();
			
			if (mouseState.LeftButton == ButtonState.Pressed && !IsOutsideBounds(mouseState.Position))
			{
				Vector2 mousePos = new Vector2(mouseState.X, mouseState.Y);
				TranslateMousePosition(mousePos, Camera.OffsetFromOrigin);
				
				var chosenTile = BoardManager.GetTileFromTranslatedMousePosition(translatedMousePos);
				
				if (chosenTile != null)
				{
					chosenTile.Color = Color.BlueViolet;
				}
			}
			
			InputController.UpdateInput(mouseState);
			
			if (InputController.IsPressedOnce(MouseInput.LeftButton)) 
			{
				score++;
			}
			
			
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


			base.Update(gameTime);
		}
		
		protected override void Draw(GameTime gameTime)
		{
			_graphicsDeviceManager.GraphicsDevice.Clear(Color.CornflowerBlue);			
			
			// game
			_spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied,
								null, null, null, null, Camera.GetTransformMatrix());
			
			foreach (var tile in BoardManager.Board)
			{
				_spriteBatch.Draw(tile.Sprite, tile.Box, tile.Color);
			}
			
			_spriteBatch.Draw(baseSprite, new Rectangle(-2 * 100, -2 * 100, 100, 100), Color.White);
					
			_spriteBatch.End();
			
			
			// UI
			_spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied,
								null, null, null, null, null);
								
			_spriteBatch.DrawString(gameFont, "New game here", new Vector2(100,100), Color.White);
			
			_spriteBatch.DrawString(gameFont, _graphicsDeviceManager.PreferredBackBufferHeight.ToString(), new Vector2(400,200), Color.White);
			
			_spriteBatch.DrawString(gameFont, score.ToString(), new Vector2(0,300), Color.White);
						
			_spriteBatch.End();
			
			
			base.Draw(gameTime);
		}
	}
}
