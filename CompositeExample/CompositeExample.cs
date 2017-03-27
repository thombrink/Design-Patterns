/*
   Coding             : M. Krop
   Date               : 21 juli 2015
   Purpose            : Examples of various Design Patterns
   Intended audience  : Students HBO-ICT of Windesheim University of Applied Sciences
   Copyright          : (c)2015 by M. Krop
*/

#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Input;

#endregion

namespace DesignPatternsExamples
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class CompositeExample : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;		
		private GameWorld gameWorld;



		public CompositeExample()
		{

			graphics = new GraphicsDeviceManager(this);

			Content.RootDirectory = "Content";	      
			//saving GD for use in drawing funtions

			//			gameWorld = new GameWorld(); // inaccessible due to protection level

			gameWorld = GameWorld.Instance;
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{

			// TODO: Add your initialization logic here
			base.Initialize();

		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);
            //Work out how much we need to scale our graphics to fill the screen

            //TODO: use this.Content to load your game content here
            gameWorld.LoadContent(graphics, this);

            //TODO: use this.Content to load your game content here 
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
			{
				Exit();
			}
			// TODO: Add your update logic here	


			gameWorld.Update (gameTime);
			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			graphics.PreferredBackBufferWidth = Globals.right;
			graphics.PreferredBackBufferHeight = Globals.bottom;
			graphics.ApplyChanges ();

			graphics.GraphicsDevice.Clear(Color.White);
			spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null,null);

			gameWorld.Draw (spriteBatch, gameTime);

			spriteBatch.End();

			base.Draw(gameTime);
		}

	}
}

