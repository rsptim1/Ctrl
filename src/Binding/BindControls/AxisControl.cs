namespace Ctrl
{
	internal abstract class AxisControl : Bind
	{
		public float DeadZone { get; set; } = 0.0f;

		protected AxisControl(string name, PlayerAction owner) : base(name, owner)
		{
		}

		public override bool State => !IsInDeadZone(Value);

		protected bool IsInDeadZone(float value)
		{
			return value <= DeadZone && value >= -DeadZone;
		}
	}
}
