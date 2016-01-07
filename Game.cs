using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace XNAControllerTest
{

    public class Game : Microsoft.Xna.Framework.Game
    {

	GraphicsDeviceManager graphics;
	SpriteBatch spriteBatch;

	Texture2D background, reticle, dot, cross;
	GamePadThumbSticks[] thumbsticks;
	bool leftStick = true;

	KeyboardState oldState, newState;
	PlayerIndex player;

	public Game()
	{
	    graphics = new GraphicsDeviceManager(this);
	    Content.RootDirectory = "Content";
	    this.Window.AllowUserResizing = true;
	    this.Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);

	}

	protected override void Initialize()
	{
	    base.Initialize();
	    oldState = Keyboard.GetState();
	    player = PlayerIndex.One;
	    thumbsticks = new GamePadThumbSticks[3];
	    spriteBatch = new SpriteBatch(GraphicsDevice);
	    
	}

	void Window_ClientSizeChanged(object sender, EventArgs e)
	{
	    
	}

	protected override void LoadContent() {
	    background = Content.Load<Texture2D>("background");
	    reticle    = Content.Load<Texture2D>("reticle");
	    dot        = Content.Load<Texture2D>("dot");
	    cross      = Content.Load<Texture2D>("cross");
	}
	
	protected override void Update(GameTime gameTime)
	{
	    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
		this.Exit();

	    newState = Keyboard.GetState();
	    
	    // Exit on ESC
	    if (newState.IsKeyDown(Keys.Escape))
		this.Exit();

	    // Switch stick being read if the spacebar is hit		
	    if(JustPressed(Keys.Space))
		leftStick =! leftStick;

	    // Hitting 1-4 changes controller
	    if(JustPressed(Keys.D1))
		player = PlayerIndex.One;
	    if(JustPressed(Keys.D2))
		player = PlayerIndex.Two;
	    if(JustPressed(Keys.D3))
		player = PlayerIndex.Three;
	    if(JustPressed(Keys.D4))
		player = PlayerIndex.Four;

	    thumbsticks[0] = GamePad.GetState(player, GamePadDeadZone.None).ThumbSticks;
	    thumbsticks[1] = GamePad.GetState(player, GamePadDeadZone.Circular).ThumbSticks;
	    thumbsticks[2] = GamePad.GetState(player, GamePadDeadZone.IndependentAxes).ThumbSticks;

	    
	    oldState = newState;
	    
	    base.Update(gameTime);
	}


	protected override void Draw(GameTime gameTime)
	{
	    
	    graphics.GraphicsDevice.Clear(Color.White);
	    
	    DrawCursors();

	    base.Draw(gameTime);
	}

	private void DrawCursors()
	{

	    int w = graphics.GraphicsDevice.Viewport.Width;
	    int h = graphics.GraphicsDevice.Viewport.Height;

	    // Center of left and right halfs of the viewport
	    var left = new Vector2(w/4, h/2);
	    var right = new Vector2(w-w/4, h/2);

	    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

	    // Backgrounds
	    spriteBatch.DrawCentered(background, left, Color.White);
	    spriteBatch.DrawCentered(background, right, Color.White);

	    // Right stick
	    spriteBatch.DrawCentered(reticle, left + thumbsticks[0].Left.FlipY() * background.Width/2, Color.White);
	    spriteBatch.DrawCentered(dot, left + thumbsticks[1].Left.FlipY() * background.Width/2, Color.White);
	    spriteBatch.DrawCentered(cross, left + thumbsticks[2].Left.FlipY() * background.Width/2, Color.White);

	    // Left stick
	    spriteBatch.DrawCentered(reticle, right + thumbsticks[0].Right.FlipY() * background.Width/2, Color.White);
	    spriteBatch.DrawCentered(dot, right + thumbsticks[1].Right.FlipY() * background.Width/2, Color.White);
	    spriteBatch.DrawCentered(cross, right + thumbsticks[2].Right.FlipY() * background.Width/2, Color.White);
	    
	    spriteBatch.End();
	}

	private bool JustPressed(Keys key)
	{
	    return (oldState.IsKeyUp(key) & newState.IsKeyDown(key));
	}
    }

    public static class Extensions
    {
	public static void DrawCentered(this SpriteBatch spriteBatch, Texture2D texture, Vector2 position, Color color)
	{
	    position.X -= ((float) texture.Width / 2);
	    position.Y -= ((float) texture.Height / 2);
	    spriteBatch.Draw(texture, position, color);
	}

	public static Vector2 FlipY(this Vector2 vector)
	{
	    vector.Y = -vector.Y;
	    return vector;
	}

    }

    
}

	



