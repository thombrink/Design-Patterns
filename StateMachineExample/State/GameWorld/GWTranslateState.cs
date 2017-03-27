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
	public class GWTranslateState : GWState
	{
		GWStateMachine gwStateMachine;

		public GWTranslateState (GWStateMachine gwStateMachine)
		{
			this.gwStateMachine = gwStateMachine;
		}

		public void ClickArea (MouseState mouse, ref GameEntityGroup selectedGroup){
		}
		public void ReleaseSelection (List<GameEntity> game_elements, ref GameEntityGroup selectedGroup){
		}	
		public void ReleaseTranslation (){
			this.gwStateMachine.SetState (this.gwStateMachine.gwNormalState);
		}	

		public void HoldSelection (MouseState mouse, ref GameEntityGroup selectedGroup){
		}

		public void HoldTranslation (MouseState mouse, ref GameEntityGroup selectedGroup){
			#region Composite Pattern
			selectedGroup.Translate (new Vector2 (mouse.X - this.gwStateMachine.translateOffset.X, mouse.Y - this.gwStateMachine.translateOffset.Y));
			#endregion
			this.gwStateMachine.translateOffset.X = mouse.X;
			this.gwStateMachine.translateOffset.Y = mouse.Y;

		}
		public void PressReset (List<GameEntity> game_elements, ref GameEntityGroup selectedGroup){
		}

	}
	#endregion
}

