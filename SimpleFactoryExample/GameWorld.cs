/*
   Coding             : M. Krop
   Date               : 31 juli 2015
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
using System.Collections.Generic;
#endregion

namespace DesignPatternsExamples
{
	public class GameWorld
	{
		protected GraphicsDeviceManager graphics;
		protected Texture2D background;
		protected GameBoard gameBoard;
		protected Game game;
		protected EntityFactory entityFactory;

		private static readonly GameWorld instance = new GameWorld();

		private GameWorld ()
		{			

		}

		public static GameWorld Instance
		{
			get
			{
				return instance;
			}
		}

		public void LoadContent(GraphicsDeviceManager g, Game ga)
		{
			graphics = g;
			graphics.IsFullScreen = false;
			game = ga;

			background = game.Content.Load<Texture2D> ("grass.jpg");

			#region Simple Factory
			entityFactory = new EntityFactory ();
			#endregion

			gameBoard = new GameBoard (graphics, new Vector2 (20, 20), entityFactory);
		}

		public void Update (GameTime gt)
		{

//			foreach (GameEntity ge in game_elements)
//				ge.Update (gt);
		}

		public void Draw (SpriteBatch sb, GameTime gt)
		{

			sb.Draw(background, new Vector2(Globals.left,Globals.top), Color.White);
			
			gameBoard.Draw (sb, gt);
//			foreach (GameEntity ge in game_elements) {
//				ge.Draw (sb, gt);

//			}

		}



	}
}

