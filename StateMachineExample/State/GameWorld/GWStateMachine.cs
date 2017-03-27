/*
   Coding             : M. Krop
   Date               : 24 juli 2015
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
	#region State Pattern
	public class GWStateMachine
	{
		public GWState gwNormalState;
		public GWState gwSelectState;
		public GWState gwTranslateState;

		public GWState gwState;

		public Rectangle selectRectangle;
		public Vector2 translateOffset;


		private static readonly GWStateMachine instance = new GWStateMachine();

		private GWStateMachine ()
		{			

		}

		public static GWStateMachine Instance
		{
			get
			{
				return instance;
			}
		}

		public void Initialize ()
		{
			gwNormalState = new GWNormalState (this);
			gwSelectState = new GWSelectState (this);
			gwTranslateState = new GWTranslateState (this);
			gwState = gwNormalState;
			selectRectangle = new Rectangle ();
			translateOffset = new Vector2 (0, 0);
		}

		public void SetState(GWState gwState){
			this.gwState = gwState;
		}

		public void ClickArea (MouseState mouse, ref GameEntityGroup selectedGroup){
			gwState.ClickArea (mouse, ref selectedGroup);
		}

		public void ReleaseSelection (List<GameEntity> game_elements, ref GameEntityGroup selectedGroup){
			gwState.ReleaseSelection (game_elements, ref selectedGroup);
		}	
		public void ReleaseTranslation (){
			gwState.ReleaseTranslation ();
		}	
		public void HoldSelection (MouseState mouse, ref GameEntityGroup selectedGroup){
			gwState.HoldSelection (mouse, ref selectedGroup);
		}
		public void HoldTranslation (MouseState mouse, ref GameEntityGroup selectedGroup){
			gwState.HoldTranslation (mouse, ref selectedGroup);
		}
		public void PressReset (List<GameEntity> game_elements, ref GameEntityGroup selectedGroup){
			gwState.PressReset (game_elements, ref selectedGroup);
		}

	}
	#endregion
}

