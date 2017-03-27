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
	public class GWSelectState : GWState
	{
		#region State Pattern
		GWStateMachine gwStateMachine;

		public GWSelectState (GWStateMachine gwStateMachine)
		{
			this.gwStateMachine = gwStateMachine;
		}

		public void ClickArea (MouseState mouse, ref GameEntityGroup selectedGroup){
		}

		public void ReleaseSelection (List<GameEntity> game_elements, ref GameEntityGroup selectedGroup){

			#region Composite Pattern
			// A new entity group is created.
			GameEntityGroup newGroup = new GameEntityGroup (selectedGroup.graphics);
			#endregion

			// All the game entities that are part of the selected area
			foreach (GameEntity ge in game_elements) {
				if ((ge.position.X >= this.gwStateMachine.selectRectangle.X) && 
				    (ge.position.X <= (this.gwStateMachine.selectRectangle.X + this.gwStateMachine.selectRectangle.Width)) &&
				    (ge.position.Y >= this.gwStateMachine.selectRectangle.Y) &&
				    (ge.position.Y <= (this.gwStateMachine.selectRectangle.Y + this.gwStateMachine.selectRectangle.Height))) {
					ge.moveBehaviour = new NoWalk ();

					#region Composite Pattern
					// Adding the game entity to a new group. All the game entities in the selection have NoWalk behaviour
					newGroup.Add (ge);
					#endregion

				}
				if ((ge.position.X <= this.gwStateMachine.selectRectangle.X) && 
				    (ge.position.X >= (this.gwStateMachine.selectRectangle.X + this.gwStateMachine.selectRectangle.Width)) &&
				    (ge.position.Y <= this.gwStateMachine.selectRectangle.Y) &&
				    (ge.position.Y >= (this.gwStateMachine.selectRectangle.Y + this.gwStateMachine.selectRectangle.Height))) {
					ge.moveBehaviour = new NoWalk ();

					#region Composite Pattern
					// Adding the game entity to a new group. All the game entities in the selection have NoWalk behaviour
					newGroup.Add (ge);
					#endregion

				}


			}
			// Adding the complete group to the composite structure

			newGroup.Left = this.gwStateMachine.selectRectangle.X;
			newGroup.Top = this.gwStateMachine.selectRectangle.Y;
			newGroup.Right = this.gwStateMachine.selectRectangle.X + this.gwStateMachine.selectRectangle.Width;
			newGroup.Bottom = this.gwStateMachine.selectRectangle.Y + this.gwStateMachine.selectRectangle.Height;

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

			this.gwStateMachine.selectRectangle.Width = 0;
			this.gwStateMachine.selectRectangle.Height = 0;

			this.gwStateMachine.SetState (this.gwStateMachine.gwNormalState);

		}	

		public void ReleaseTranslation (){
		}	

		public void HoldSelection (MouseState mouse, ref GameEntityGroup selectedGroup){
			this.gwStateMachine.selectRectangle.Width = mouse.X - this.gwStateMachine.selectRectangle.X;
			this.gwStateMachine.selectRectangle.Height = mouse.Y - this.gwStateMachine.selectRectangle.Y;
		}

		public void HoldTranslation (MouseState mouse, ref GameEntityGroup selectedGroup){
		}
		public void PressReset (List<GameEntity> game_elements, ref GameEntityGroup selectedGroup){
		}

	}
	#endregion
}

