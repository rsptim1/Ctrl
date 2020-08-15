using Stride.Input;

namespace Ctrl
{
	internal class MouseAxisControl : AxisControl
	{
		private readonly MouseAxis axis;

		public MouseAxisControl(MouseAxis axis, PlayerAction owner) : base(axis.ToString(), owner)
		{
			this.axis = axis;
		}

		public override float Value
		{
			get
			{
				float value = InputManager.CheckAxis(axis);
				return !IsInDeadZone(value) ? value : 0f;
			}
		}
	}
}
