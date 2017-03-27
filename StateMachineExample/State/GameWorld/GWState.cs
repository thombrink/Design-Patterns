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
	public interface GWState
	{
		void ClickArea (MouseState mouse, ref GameEntityGroup selectedGroup);
		void ReleaseSelection (List<GameEntity> game_elements, ref GameEntityGroup selectedGroup);
		void ReleaseTranslation ();
		void HoldSelection (MouseState mouse, ref GameEntityGroup selectedGroup);
		void HoldTranslation (MouseState mouse, ref GameEntityGroup selectedGroup);
		void PressReset (List<GameEntity> game_elements, ref GameEntityGroup selectedGroup);
	}
	#endregion
}

