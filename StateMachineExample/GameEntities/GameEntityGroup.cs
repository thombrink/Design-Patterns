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
	#region Composite Pattern
	public class GameEntityGroup : GameEntity
	{
		List<GameEntity> gameEntities;

		Texture2D selectedArea;
		public int Left, Top, Right, Bottom;

		public GameEntityGroup (GraphicsDeviceManager g)
		{
			graphics = g;

			selectedArea = new Texture2D(graphics.GraphicsDevice, 1, 1);
			selectedArea.SetData(new Color[] { Color.White});

			gameEntities = new List<GameEntity> ();

			Left = 0;
			Right = 0;
			Top = 0;
			Bottom = 0;

		}

		public override void Add (GameEntity ge)
		{
				gameEntities.Add (ge);
		}

		public override void Remove (GameEntity ge)
		{
				gameEntities.Remove (ge);
		}

		public override GameEntity GetChild (int i)
		{
				return (GameEntity)gameEntities [i];
		}

		public override void Translate (Vector2 translateVector)
		{

			Left += (int)translateVector.X;
			Top += (int)translateVector.Y;
			Right += (int)translateVector.X;
			Bottom += (int)translateVector.Y;

			if (gameEntities != null) {
				foreach (GameEntity ge in gameEntities) {
					ge.Translate (translateVector);
				}
			}
		}

		public override bool ClickInArea(Vector2 pos)
		{
			bool inArea = false;
			foreach (GameEntityGroup geg in gameEntities) {
				if (pos.X >= geg.Left && pos.X <= geg.Right && pos.Y >= geg.Top && pos.Y <= geg.Bottom)
					inArea = true;
			}
			return inArea;
		}

		public override void Draw (SpriteBatch sb, GameTime gt)
		{

			Rectangle selectRectangle = new Rectangle ();
			Vector2 pos = new Vector2 ();

			pos.X = Left;
			pos.Y = Top;
			selectRectangle.X = Left;
			selectRectangle.Y = Top;
			selectRectangle.Width = Right - Left;
			selectRectangle.Height = Bottom - Top;

			sb.Draw(selectedArea, pos, selectRectangle, Color.Coral, 0f, Vector2.Zero, 1f , SpriteEffects.None, 1f); 

			if (gameEntities != null) {
				foreach (GameEntity ge in gameEntities) {
					ge.Draw (sb, gt);
				}
			}
		}
	
	}
	#endregion
}

