using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using SamplerState = Microsoft.Xna.Framework.Graphics.SamplerState;

namespace GameProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Rectangle _deelRectangle;
        private Texture2D _texture;
        private int schuifOp_X = 10;



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _deelRectangle = new Rectangle(schuifOp_X, 0, 35, 32);
            base.Initialize();


        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _texture = Content.Load<Texture2D>("Walk-Anim");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            float scale = 5f;
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(_texture, new Vector2(0, 0), _deelRectangle, Color.White,0f, new Vector2(0, 0), scale,0,0);
            _spriteBatch.End();

            schuifOp_X += 48;
            if (schuifOp_X > 180)
            {
                schuifOp_X = 10;
            }
            _deelRectangle.X = schuifOp_X;

            base.Draw(gameTime);
            


        }
    }
}