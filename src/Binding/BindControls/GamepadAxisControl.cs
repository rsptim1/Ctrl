using Stride.Input;

namespace Ctrl
{
	internal class GamepadAxisControl : AxisControl
	{
		private readonly GamePadAxis axis;

		public GamepadAxisControl(GamePadAxis axis, PlayerAction owner) : base(axis.ToString(), owner)
		{
			this.axis = axis;
			DeadZone = 0.2f;
		}

		public override float Value
		{
			get
			{
				float value = Owner.Device.GetAxis(axis);
				return !IsInDeadZone(value) ? value : 0f;
			}
		}
	}
}
