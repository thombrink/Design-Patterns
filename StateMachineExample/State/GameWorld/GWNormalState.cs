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
	public class GWNormalState : GWState
	{
		private GWStateMachine gwStateMachine;

		public GWNormalState (GWStateMachine gwStateMachine)
		{
			this.gwStateMachine = gwStateMachine;
		}

		public void ClickArea (MouseState mouse, ref GameEntityGroup selectedGroup){
			#region Composite Pattern
			if (selectedGroup.ClickInArea (new Vector2 (mouse.X, mouse.Y))) {
				#endregion
				this.gwStateMachine.translateOffset.X = mouse.X;
				this.gwStateMachine.translateOffset.Y = mouse.Y;
				this.gwStateMachine.SetState (this.gwStateMachine.gwTranslateState);
			}
			else {
				this.gwStateMachine.selectRectangle.X = mouse.X;
				this.gwStateMachine.selectRectangle.Y = mouse.Y;
				this.gwStateMachine.SetState (this.gwStateMachine.gwSelectState);
			}
		}

		public void ReleaseSelection (List<GameEntity> game_elements, ref GameEntityGroup selectedGroup){
		}	
		public void ReleaseTranslation (){
		}	
		public void HoldSelection (MouseState mouse, ref GameEntityGroup selectedGroup){
		}
		public void HoldTranslation (MouseState mouse, ref GameEntityGroup selectedGroup){
		}
		public void PressReset (List<GameEntity> game_elements, ref GameEntityGroup selectedGroup){
			// All the game entities get their old behaviour back
			foreach (GameEntity ge in game_elements) {
				ge.moveBehaviour = ge.oldBehaviour;
			}

			#region Composite Pattern
			// The group is deleted & recreated
			GraphicsDeviceManager g = selectedGroup.graphics;

			selectedGroup = null;
			selectedGroup = new GameEntityGroup (g);
			#endregion

		}

	}
	#endregion
}

