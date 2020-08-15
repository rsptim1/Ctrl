using Stride.Core.Mathematics;

namespace Ctrl
{
	internal static class Extensions
	{
		/// <summary>
		/// Does a container of Vec2 width and height contain a point?
		/// </summary>
		/// <param name="container"></param>
		/// <param name="point"></param>
		/// <returns></returns>
		public static bool ContainsPoint(this Vector2 container, Vector2 point)
		{
			if (point.X > container.X || point.X < -container.X)
				return false;
			if (point.Y > container.Y || point.Y < -container.Y)
				return false;
			
			return true;
		}
	}
}
