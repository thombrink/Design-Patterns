/*
   Coding             : M. Krop
   Date               : 3 augustus 2015
   Purpose            : Examples of various Design Patterns
   Intended audience  : Students HBO-ICT of Windesheim University of Applied Sciences
   Copyright          : (c)2015 by M.V. Krop
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

	public class GameBoard
	{
		protected GraphicsDeviceManager graphics;
		protected Texture2D pixelBlack, pixelWhite;
		protected Vector2 position;
		protected List<GameEntity> whitePieces, blackPieces;
		protected EntityFactory humanEntityFactory, orcEntityFactory;

		public GameBoard (GraphicsDeviceManager g, Vector2 pos, EntityFactory oef, EntityFactory hef)
		{
			graphics = g;
			position = pos;
			humanEntityFactory = hef;
			orcEntityFactory = oef;

			pixelBlack = new Texture2D(graphics.GraphicsDevice, 1, 1);
			pixelBlack.SetData(new Color[] { Color.Black});

			pixelWhite = new Texture2D(graphics.GraphicsDevice, 1, 1);
			pixelWhite.SetData(new Color[] { Color.White});


			Vector2 tempPos = new Vector2 ();
			tempPos.X = position.X + (Globals.pieceSize / 4);
			tempPos.Y = position.Y + (Globals.pieceSize / 4);

			whitePieces = new List<GameEntity> ();
			blackPieces = new List<GameEntity> ();

			#region Factory Method Pattern
			GameEntity ge;

			ge = humanEntityFactory.createEntity("tower", graphics, tempPos);
			whitePieces.Add (ge);
			tempPos.X += Globals.pieceSize; 
			ge = humanEntityFactory.createEntity("horse", graphics, tempPos);
			whitePieces.Add (ge);
			tempPos.X += Globals.pieceSize; 
			ge = humanEntityFactory.createEntity("bishop", graphics, tempPos);
			whitePieces.Add (ge);
			tempPos.X += Globals.pieceSize; 
			ge = humanEntityFactory.createEntity("king", graphics, tempPos);
			whitePieces.Add (ge);
			tempPos.X += Globals.pieceSize; 
			ge = humanEntityFactory.createEntity("queen", graphics, tempPos);
			whitePieces.Add (ge);
			tempPos.X += Globals.pieceSize; 
			ge = humanEntityFactory.createEntity("bishop", graphics, tempPos);
			whitePieces.Add (ge);
			tempPos.X += Globals.pieceSize; 
			ge = humanEntityFactory.createEntity("horse", graphics, tempPos);
			whitePieces.Add (ge);
			tempPos.X += Globals.pieceSize; 
			ge = humanEntityFactory.createEntity("tower", graphics, tempPos);
			whitePieces.Add (ge);

			tempPos.X -= Globals.pieceSize*7;
			tempPos.Y += Globals.pieceSize;
			for (int i=0;i<8;i++){
				ge = humanEntityFactory.createEntity("pawn", graphics, tempPos);
				whitePieces.Add (ge);
				tempPos.X += Globals.pieceSize; 
			}

			// Positioning the Orcs
			tempPos.X -= Globals.pieceSize*8;
			tempPos.Y += Globals.pieceSize*5;

			for (int i=0;i<8;i++){
				ge = orcEntityFactory.createEntity("pawn", graphics, tempPos);
				blackPieces.Add (ge);
				tempPos.X += Globals.pieceSize; 
			}


			tempPos.X -= Globals.pieceSize*8;
			tempPos.Y += Globals.pieceSize;

			ge = orcEntityFactory.createEntity("tower", graphics, tempPos);
			blackPieces.Add (ge);
			tempPos.X += Globals.pieceSize; 
			ge = orcEntityFactory.createEntity("horse", graphics, tempPos);
			blackPieces.Add (ge);
			tempPos.X += Globals.pieceSize; 
			ge = orcEntityFactory.createEntity("bishop", graphics, tempPos);
			blackPieces.Add (ge);
			tempPos.X += Globals.pieceSize; 
			ge = orcEntityFactory.createEntity("king", graphics, tempPos);
			blackPieces.Add (ge);
			tempPos.X += Globals.pieceSize; 
			ge = orcEntityFactory.createEntity("queen", graphics, tempPos);
			blackPieces.Add (ge);
			tempPos.X += Globals.pieceSize; 
			ge = orcEntityFactory.createEntity("bishop", graphics, tempPos);
			blackPieces.Add (ge);
			tempPos.X += Globals.pieceSize; 
			ge = orcEntityFactory.createEntity("horse", graphics, tempPos);
			blackPieces.Add (ge);
			tempPos.X += Globals.pieceSize; 
			ge = orcEntityFactory.createEntity("tower", graphics, tempPos);
			blackPieces.Add (ge);


			#endregion
		}

		public void Update (GameTime gt)
		{
		}


		public void Draw (SpriteBatch sb, GameTime gt)
		{
			bool flip;
			Vector2 tempPos = new Vector2 ();

			flip = true;
			// Draw chessboard
			for (int x = 0; x < 8; x++) {
				for (int y = 0; y < 8; y++) {
					tempPos.X = position.X + (x * Globals.pieceSize);
					tempPos.Y = position.Y + (y * Globals.pieceSize);
					if (flip)
						sb.Draw (pixelWhite, tempPos, null, Color.White, 0f, Vector2.Zero, Globals.pieceSize, SpriteEffects.None, 0f); 
					else
						sb.Draw (pixelBlack, tempPos, null, Color.White, 0f, Vector2.Zero, Globals.pieceSize, SpriteEffects.None, 0f); 
					flip = !flip;
					if (y == 7)
						flip = !flip;
				}
			}

			foreach(GameEntity ge in whitePieces)
				ge.Draw (sb, gt);

			foreach(GameEntity ge in blackPieces)
				ge.Draw (sb, gt);
		}

	}
}

