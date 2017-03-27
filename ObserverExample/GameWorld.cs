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
		Texture2D background, tekst;

		Game game;

		List<GameEntity> game_elements = new List<GameEntity> ();
		TownCenter tc;


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
			Knight k;
			Horseman hm;
			Bishop b;
			Clockworkbeast cwb;
			Mathbeast mb;
			MadDog md;

			background = game.Content.Load<Texture2D>("grass.jpg");
			tekst = game.Content.Load<Texture2D>("tekst.png");

//			game_elements.Add (new Knight (graphics, new Vector2 (0,30), new Vector2(1,1)));
//			game_elements.Add (new Horseman (graphics, new Vector2(200,30), new Vector2(1,1)));

			tc = new TownCenter (graphics, new Vector2 (400, 300), new Vector2(1,1));

			Random rnd = new Random ();

			int xpos, ypos, xdir, ydir ,type;
			for (int i = 0; i<1000; i++) {
				xpos = rnd.Next (Globals.left, Globals.right);
				ypos = rnd.Next (Globals.top, Globals.bottom);
				xdir = 1;
				ydir = 1;
				type = rnd.Next (1, 6 + 1);
				switch (type) {
				case 1:
					k = new Knight (graphics, new Vector2 (xpos, ypos), new Vector2 (xdir, ydir), tc);
					game_elements.Add (k);
					#region Observer Pattern
					tc.RegisterObserver (k);
					#endregion
					break;
				case 2:
					hm = new Horseman (graphics, new Vector2 (xpos, ypos), new Vector2 (xdir, ydir), tc);
					game_elements.Add (hm);
					#region Observer Pattern
					tc.RegisterObserver(hm);
					#endregion
					break;
				case 3:
					b = new Bishop (graphics, new Vector2 (xpos, ypos), new Vector2 (xdir, ydir), tc);
					game_elements.Add (b);
					#region Observer Pattern
					tc.RegisterObserver (b);
					#endregion
					break;
				case 4:
					cwb = new Clockworkbeast (graphics, new Vector2 (xpos, ypos), new Vector2 (xdir, ydir), tc);
					game_elements.Add (cwb);
					#region Observer Pattern
					tc.RegisterObserver (cwb);
					#endregion
					break;
				case 5:
					mb = new Mathbeast (graphics, new Vector2 (xpos, ypos), new Vector2 (xdir, ydir), tc);
					game_elements.Add (mb);
					#region Observer Pattern
					tc.RegisterObserver (mb);
					#endregion
					break;
				case 6:
					md = new MadDog (graphics, new Vector2 (xpos, ypos), new Vector2 (xdir, ydir), tc);
					game_elements.Add (md);
					#region Observer Pattern
					tc.RegisterObserver (md);
					#endregion
					break;
				}
				System.Threading.Thread.Sleep(1);
			}
		}


		public void Update (GameTime gt)
		{
			tc.Update (gt);

			foreach (GameEntity ge in game_elements)
				ge.Update (gt);
		}

		public void Draw (SpriteBatch sb, GameTime gt)
		{

			sb.Draw(background, new Vector2(Globals.left,Globals.top), Color.White);

			foreach (GameEntity ge in game_elements) {
				ge.Draw (sb, gt);

			}
			tc.Draw (sb, gt);

			sb.Draw(tekst, new Vector2(Globals.left+5,Globals.top+6), Color.White);
		}
	}
}
