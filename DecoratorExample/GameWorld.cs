/*
   Coding             : M. Krop
   Date               : 2 juli 2015
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
		GraphicsDeviceManager graphics;
		Texture2D background;
		Game game;

		List<GameEntity> game_elements = new List<GameEntity> ();

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


			#region Decorator Pattern
			RedDecorator rd;
			WhiteDecorator wd;
			BlueDecorator bd;
			YellowDecorator yd;
			#endregion

			Knight k;
			Bishop b;
			Clockworkbeast cb;
			Horseman h;
			Mathbeast mb;


			background = game.Content.Load<Texture2D>("grass.jpg");

			k = new Knight (graphics, new Vector2 (40, 100), new Vector2 (1, 1));
			#region Decorator Pattern
			rd = new RedDecorator (graphics);
			rd.SetGameEntity(k);
			game_elements.Add (rd);
			#endregion

			b = new Bishop (graphics, new Vector2 (80, 200), new Vector2 (-1, 1));
			#region Decorator Pattern
			wd = new WhiteDecorator (graphics);
			wd.SetGameEntity(b);
			game_elements.Add (wd);
			#endregion

			cb = new Clockworkbeast (graphics, new Vector2 (160, 200), new Vector2 (-1, 1));
			#region Decorator Pattern
			wd = new WhiteDecorator (graphics);
			wd.SetGameEntity(cb);
			game_elements.Add (wd);
			#endregion

			h = new Horseman (graphics, new Vector2 (560, 310), new Vector2 (1, 1));
			#region Decorator Pattern
			rd = new RedDecorator (graphics);
			rd.SetGameEntity(h);
			game_elements.Add (rd);
			#endregion

			mb = new Mathbeast (graphics, new Vector2 (660, 200), new Vector2 (1, 1));
			#region Decorator Pattern
			rd = new RedDecorator (graphics);
			rd.SetGameEntity (mb);
			wd = new WhiteDecorator (graphics);
			wd.SetGameEntity (rd);
			game_elements.Add (wd);
			#endregion

			mb = new Mathbeast (graphics, new Vector2 (260, 300), new Vector2 (1, 1));
			#region Decorator Pattern
			rd = new RedDecorator (graphics);
			rd.SetGameEntity (mb);
			wd = new WhiteDecorator (graphics);
			wd.SetGameEntity (rd);
			bd = new BlueDecorator (graphics);
			bd.SetGameEntity (wd);
			yd = new YellowDecorator (graphics);
			yd.SetGameEntity (bd);
			#endregion

			game_elements.Add (yd);
		}



		public void Update (GameTime gt)
		{

			foreach (GameEntity ge in game_elements)
				ge.Update (gt);
		}

		public void Draw (SpriteBatch sb, GameTime gt)
		{

			sb.Draw(background, new Vector2(Globals.left,Globals.top), Color.White);

			foreach (GameEntity ge in game_elements) {
				ge.Draw (sb, gt);

			}

		}



	}
}

