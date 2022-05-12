using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoRPG
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;

		// sprites
		Texture2D baseTile;
		
		// fonts
		SpriteFont gameFont;

		Vector2 targetPosition = new Vector2(300,300);
		MouseState mouseState;
		int score = 0;
		
		
		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			// TODO: Add your initialization logic here
			_graphics.IsFullScreen = false;
			_graphics.PreferredBackBufferWidth = 1920;
			_graphics.PreferredBackBufferHeight = 1080;			
			_graphics.ApplyChanges();
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
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
				
			mouseState = Mouse.GetState();
			
			if (mouseState.LeftButton == ButtonState.Pressed) 
			{
				score++;
			}

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			
			_spriteBatch.Begin();
			
			_spriteBatch.Draw(baseTile, new Vector2(0,0), Color.White);
			_spriteBatch.Draw(baseTile, new Vector2(100,200), Color.White);
			_spriteBatch.Draw(baseTile, new Vector2(300,400), Color.White);
			
			_spriteBatch.Draw(baseTile, new Vector2(300,400), Color.White);
			
			_spriteBatch.Draw(baseTile, new Rectangle(100, 100, 16 * 4, 16 * 4),  new Rectangle(0, 0, 16, 16), Color.White);
			
			_spriteBatch.DrawString(gameFont, "New game here", new Vector2(100,100), Color.White);
			
			_spriteBatch.DrawString(gameFont, _graphics.PreferredBackBufferHeight.ToString(), new Vector2(400,200), Color.White);
			
			_spriteBatch.DrawString(gameFont, score.ToString(), new Vector2(0,300), Color.White);			
			_spriteBatch.End();
			
			base.Draw(gameTime);
		}
	}
}
