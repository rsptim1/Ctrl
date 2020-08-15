using Stride.Input;

namespace Ctrl
{
	internal class KeyAxisControl : AxisControl
	{
		private readonly Keys positive;
		private readonly Keys negative;

		public KeyAxisControl(Keys positive, Keys negative, PlayerAction owner) : base($"{positive}-{negative}", owner)
		{
			this.positive = positive;
			this.negative = negative;
		}

		public override float Value
		{
			get
			{
				float result = 0;
				result += CheckKeyIsPressed(positive) ? 1 : 0;
				result -= CheckKeyIsPressed(negative) ? 1 : 0;
				return result;
			}
		}

		private bool CheckKeyIsPressed(Keys k) => InputManager.CheckKeyIsPressed(k);
	}
}
