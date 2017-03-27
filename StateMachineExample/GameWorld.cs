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
using System.Collections.Generic;
#endregion

namespace DesignPatternsExamples
{
	public class GameWorld
	{
		GraphicsDeviceManager graphics;
		Texture2D background;
		Texture2D selectedArea;
		Game game;

		KeyboardState previousState;
		MouseState previousmouseState;

		#region Composite Pattern
		GameEntityGroup selectedGroup;
		#endregion

		#region State Pattern
		private GWStateMachine gwStateMachine;
		#endregion

//		Rectangle selectRectangle;
		List<GameEntity> game_elements;


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

			game_elements = new List<GameEntity> ();

			#region Composite Pattern
			selectedGroup = new GameEntityGroup(graphics);
			#endregion

			#region State Pattern
			// The Gameworld State Machine is also a singleton 
			gwStateMachine = GWStateMachine.Instance;
			gwStateMachine.Initialize ();
			#endregion


			background = game.Content.Load<Texture2D>("grass.jpg");

			selectedArea = new Texture2D(graphics.GraphicsDevice, 1, 1);
			selectedArea.SetData(new Color[] { Color.White});

			Random rnd = new Random ();

			int xpos, ypos, xdir, ydir ,type;
			for (int i = 0; i<=1000; i++) {
				xpos = rnd.Next (Globals.left, Globals.right);
				ypos = rnd.Next (Globals.top, Globals.bottom);
				xdir = 1;
				ydir = 1;
				type = rnd.Next (1, 3 + 1);
				switch (type) {
				case 1:
					game_elements.Add (new Knight (graphics, new Vector2 (xpos, ypos), new Vector2 (xdir, ydir)));
					break;
				case 2:
					game_elements.Add (new Horseman (graphics, new Vector2 (xpos, ypos), new Vector2 (xdir, ydir)));
					break;
				case 3:
					game_elements.Add (new Bishop (graphics, new Vector2 (xpos, ypos), new Vector2 (xdir, ydir)));
					break;
				}
				System.Threading.Thread.Sleep(1);
			}


		}


		public void Update (GameTime gt)
		{
			UpdateInput ();
			foreach (GameEntity ge in game_elements)
				ge.Update (gt);
		}

		public void Draw (SpriteBatch sb, GameTime gt)
		{
			Vector2 pos = new Vector2 (gwStateMachine.selectRectangle.X, gwStateMachine.selectRectangle.Y);

			sb.Draw(background, new Vector2(Globals.left,Globals.top), Color.White);


			sb.Draw(selectedArea, pos, gwStateMachine.selectRectangle, Color.Teal, 0f, Vector2.Zero, 1f , SpriteEffects.None, 1f); 

			#region Composite Pattern
			// The selectgroup will be drawn. The complete composite with all the substructures (tree of Groups & Entities)
			selectedGroup.Draw (sb, gt);
			#endregion

			foreach (GameEntity ge in game_elements) {
				ge.Draw (sb, gt);

			}

		}

		private void UpdateInput()
		{
			#region State Pattern
			KeyboardState state = Keyboard.GetState();
			MouseState mouse = Mouse.GetState ();

			// if S is pressed
			if (state.IsKeyDown (Keys.S) & !previousState.IsKeyDown (Keys.S)) {
				gwStateMachine.PressReset (game_elements, ref selectedGroup);
			}

			// Left mouse button pressed.
			if ((mouse.LeftButton == ButtonState.Pressed) & (previousmouseState.LeftButton != ButtonState.Pressed)) {
				gwStateMachine.ClickArea (mouse, ref selectedGroup);
			}

			// while left mouse button pressed. Update the Width & Height of the selectRectangle
			if ((mouse.LeftButton == ButtonState.Pressed)) {
				gwStateMachine.HoldTranslation (mouse, ref selectedGroup);
				gwStateMachine.HoldSelection (mouse, ref selectedGroup);
			}

			// Left mouse button released. End of select mode

			if ((mouse.LeftButton == ButtonState.Released) & (previousmouseState.LeftButton != ButtonState.Released)) {
				gwStateMachine.ReleaseTranslation ();
				gwStateMachine.ReleaseSelection (game_elements, ref selectedGroup);
			}


			// set the old states of the keyboard & mouse
			previousState = state;
			previousmouseState = mouse;
			#endregion
		}
	}
}

