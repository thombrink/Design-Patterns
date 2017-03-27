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
		bool selectMode, translateMode;

		#region Composite Pattern
		GameEntityGroup selectedGroup;
		#endregion

		Rectangle selectRectangle;
		List<GameEntity> game_elements;

		Vector2 translateOffset;

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

			selectRectangle = new Rectangle ();
			game_elements = new List<GameEntity> ();

			#region Composite Pattern
			selectedGroup = new GameEntityGroup(graphics);
			#endregion

			translateOffset = new Vector2 (0, 0);

			selectMode = false;
			translateMode = false;

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
			Vector2 pos = new Vector2 (selectRectangle.X, selectRectangle.Y);

			sb.Draw(background, new Vector2(Globals.left,Globals.top), Color.White);


			sb.Draw(selectedArea, pos, selectRectangle, Color.Teal, 0f, Vector2.Zero, 1f , SpriteEffects.None, 1f); 

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
			KeyboardState state = Keyboard.GetState();
			MouseState mouse = Mouse.GetState ();

			// if S is pressed
			if (state.IsKeyDown (Keys.S) & !previousState.IsKeyDown (Keys.S)) {
				// All the game entities get their old behaviour back
				foreach (GameEntity ge in game_elements) {
					ge.moveBehaviour = ge.oldBehaviour;
				}

				#region Composite Pattern
				// The group is deleted & recreated
				selectedGroup = null;
				selectedGroup = new GameEntityGroup (graphics);
				#endregion
			}



			// Left mouse button pressed.
			if ((mouse.LeftButton == ButtonState.Pressed) & (previousmouseState.LeftButton != ButtonState.Pressed)) {

				#region Composite Pattern
				if (selectedGroup.ClickInArea (new Vector2 (mouse.X, mouse.Y))) {
				#endregion
					translateMode = true;
					translateOffset.X = mouse.X;
					translateOffset.Y = mouse.Y;
				}
				else {
					selectRectangle.X = mouse.X;
					selectRectangle.Y = mouse.Y;
					selectMode = true;
				}
			}

			// while left mouse button pressed. Update the Width & Height of the selectRectangle
			if ((mouse.LeftButton == ButtonState.Pressed)) {
				if (translateMode) {

					#region Composite Pattern
					selectedGroup.Translate (new Vector2 (mouse.X - translateOffset.X, mouse.Y - translateOffset.Y));
					#endregion
					translateOffset.X = mouse.X;
					translateOffset.Y = mouse.Y;
				}
				if (selectMode) {
					selectRectangle.Width = mouse.X - selectRectangle.X;
					selectRectangle.Height = mouse.Y - selectRectangle.Y;
				}
			}

			// Left mouse button released. End of select mode
			if ((mouse.LeftButton == ButtonState.Released) & (previousmouseState.LeftButton != ButtonState.Released)) {

				if (translateMode) {
					translateMode = false;
				} else if (selectMode) {

					selectMode = false;

					#region Composite Pattern
					// A new entity group is created.
					GameEntityGroup newGroup = new GameEntityGroup (graphics);
					#endregion
					// All the game entities that are part of the selected area
					foreach (GameEntity ge in game_elements) {
						if ((ge.position.X >= selectRectangle.X) && 
							(ge.position.X <= (selectRectangle.X + selectRectangle.Width)) &&
							(ge.position.Y >= selectRectangle.Y) &&
							(ge.position.Y <= (selectRectangle.Y + selectRectangle.Height))) {
							ge.moveBehaviour = new NoWalk ();

							#region Composite Pattern
							// Adding the game entity to a new group. All the game entities in the selection have NoWalk behaviour
							newGroup.Add (ge);
							#endregion

						}
						if ((ge.position.X <= selectRectangle.X) && 
							(ge.position.X >= (selectRectangle.X + selectRectangle.Width)) &&
							(ge.position.Y <= selectRectangle.Y) &&
							(ge.position.Y >= (selectRectangle.Y + selectRectangle.Height))) {
							ge.moveBehaviour = new NoWalk ();

							#region Composite Pattern
							// Adding the game entity to a new group. All the game entities in the selection have NoWalk behaviour
							newGroup.Add (ge);
							#endregion

						}


					}
					// Adding the complete group to the composite structure

					newGroup.Left = selectRectangle.X;
					newGroup.Top = selectRectangle.Y;
					newGroup.Right = selectRectangle.X + selectRectangle.Width;
					newGroup.Bottom = selectRectangle.Y + selectRectangle.Height;

					// If the selection was from right to left
					if (newGroup.Left >= newGroup.Right) {
						int temp = newGroup.Right;
						newGroup.Right = newGroup.Left;
						newGroup.Left = temp;
					}

					// If the selection was from bottom to top
					if (newGroup.Top >= newGroup.Bottom) {
						int temp = newGroup.Bottom;
						newGroup.Bottom = newGroup.Top;
						newGroup.Top = temp;
					}

					#region Composite Pattern
					selectedGroup.Add (newGroup);
					#endregion

					selectRectangle.Width = 0;
					selectRectangle.Height = 0;
				}
			}
			// set the old states of the keyboard & mouse
			previousState = state;
			previousmouseState = mouse;
		}
	}
}

