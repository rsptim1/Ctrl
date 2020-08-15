using Stride.Core.Mathematics;

namespace Ctrl
{
	public struct InputControlState
	{
		public bool IsPressed { get; set; }
		public float Axis { get; set; }
		public Vector2 Vector { get; set; }
	}
}
