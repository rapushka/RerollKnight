using System.Linq;
using Code.Component;
using Entitas.Generic;

namespace Code
{
	public static class FacesExtensions
	{
		public static Entity<GameScope> MarkAsActive(this Entity<GameScope> face)
		{
			face.GetOwner().SetActiveFace(face);

			return face;
		}

		public static Entity<GameScope> SetActiveFace(this Entity<GameScope> actor, Entity<GameScope> face)
		{
			actor.Replace<ActiveFace, int>(face.Get<Face>().Value);
			return actor;
		}

		public static bool IsActiveFace(this Entity<GameScope> face)
			=> face.GetOwner().Get<ActiveFace>().Value == face.Get<Face>().Value;

		public static Entity<GameScope> GetActiveFace(this Entity<GameScope> actor)
		{
			var activeFace = actor.Get<ActiveFace>().Value;
			return actor.GetDependants().Single((f) => f.GetOrDefault<Face>()?.Value == activeFace);
		}
	}
}