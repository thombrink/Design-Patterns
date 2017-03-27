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
	public class Flock : ISubject
	{
		protected GraphicsDeviceManager graphics;

		protected List<IObserver> observers;

		KeyboardState previousState;


		public Flock ()
		{
			observers = new List<IObserver>();
			previousState = Keyboard.GetState();
		}


		// Implementing the ISubject interface


		public void RegisterObserver (IObserver o)
		{
			observers.Add (o);
		}

		public void RemoveObserver (IObserver o)
		{
			observers.Remove(o);
		}

		public void NotifyObservers()
		{
			foreach (IObserver o in observers)
				o.SignalChange ();
		}

	}
}

