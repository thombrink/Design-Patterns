/*
   Coding             : M. Krop
   Date               : 20 juli 2015
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
	public class FlockingFly : MoveBase
	{

		public FlockingFly ()
		{
		}

		public override void Move (GameEntity ge, List<GameEntity> game_elements)
		{
			Vector2 alignment = new Vector2 (0, 0);
			Vector2 cohesion = new Vector2 (0, 0);
			Vector2 separation = new Vector2(0,0);

			alignment = ComputeAlignment (ge, game_elements);
			cohesion = ComputeCohesion (ge, game_elements);
			alignment = ComputeSeparation (ge, game_elements);

			ge.velocity.X += (alignment.X*1.08f) + (cohesion.X*1.14f) + (separation.X*1.1f);
			ge.velocity.Y += (alignment.Y*1.08f) + (cohesion.Y*1.14f) + (separation.Y*1.1f);

			Normalize (ref ge.velocity, 1f);

			ge.position.X += ge.velocity.X;
			ge.position.Y += ge.velocity.Y;

			base.Move (ge, game_elements);
		}

		private Vector2 ComputeAlignment (GameEntity myAgent, List<GameEntity>agentList)
		{
			int neighborCount = 0;
			Vector2 v = new Vector2(0,0);

			foreach (GameEntity agent in agentList) {
				if (agent != myAgent) {
					if (DistanceFrom (agent.position, myAgent.position) < 100) {
						v.X += agent.velocity.X;
						v.Y += agent.velocity.Y;
						neighborCount++;
					}

				}
			}
			if (neighborCount == 0)
				return v;
		
			v.X /= neighborCount;
			v.Y /= neighborCount;
			Normalize (ref v,1.0f);

			return v;
		}

		private Vector2 ComputeCohesion (GameEntity myAgent, List<GameEntity>agentList)
		{
			int neighborCount = 0;
			Vector2 v = new Vector2(0,0);

			foreach (GameEntity agent in agentList) {
				if (agent != myAgent) {
					if (DistanceFrom (agent.position, myAgent.position) < 100) {
						v.X += agent.position.X;
						v.Y += agent.position.Y;
						neighborCount++;
					}

				}
			}
			if (neighborCount == 0)
				return v;

			v.X /= neighborCount;
			v.Y /= neighborCount;
			v = new Vector2 (v.X - myAgent.position.X, v.Y - myAgent.position.Y);
			Normalize (ref v,1.0f);
			return v;

		}

		private Vector2 ComputeSeparation (GameEntity myAgent, List<GameEntity>agentList)
		{
			int neighborCount = 0;
			Vector2 v = new Vector2(0,0);

			foreach (GameEntity agent in agentList) {
				if (agent != myAgent) {
					if (DistanceFrom (agent.position, myAgent.position) < 100) {
						v.X += (agent.position.X - myAgent.position.X);
						v.Y += (agent.position.Y - myAgent.position.Y);
						neighborCount++;
					}

				}
			}
			if (neighborCount == 0)
				return v;

			v.X /= neighborCount;
			v.Y /= neighborCount;
			v.X *= -1;
			v.Y *= -1;
			Normalize (ref v,1.0f);
			return v;

		}


		// Pythagorean 
		private double DistanceFrom (Vector2 v1, Vector2 v2)
		{
			double A = (v2.X - v1.X) * (v2.X - v1.X);
			double B = (v2.Y - v1.Y) * (v2.Y - v1.Y);
			return Math.Sqrt (Math.Abs(A + B));
		}

		private void Normalize(ref Vector2 v1, double normal)
		{
			double length=0;

			double A = v1.X * v1.X;
			double B = v1.Y * v1.Y;

			length = Math.Sqrt(A + B);

			v1.X = v1.X / (float)(length*normal);
			v1.Y = v1.Y / (float)(length*normal);
		}
	}
}

