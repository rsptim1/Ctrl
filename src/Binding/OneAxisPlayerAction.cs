using Stride.Input;

namespace Ctrl
{
	public class OneAxisPlayerAction : PlayerAction
	{
		public OneAxisPlayerAction(string name, PlayerActionSet owner) : base(name, owner)
		{
		}

		public float Axis => thisState.Axis;

		internal override void Update()
		{
			float value = 0f;

			// Iterate through each bind and find the greatest magnitude
			foreach (float control in binds)
			{
				// TODO: There's probably a better way to do this
				float squaredValue = value * value;
				float squaredControl = control * control;

				if (squaredControl > squaredValue)
					value = control;
			}

			thisState.Axis = value;
			thisState.IsPressed = value != 0f;
		}

		public void AddBinding(GamePadAxis bind)
		{
			AddBinding(new GamepadAxisControl(bind, this));
		}

		public void AddBinding(MouseAxis bind)
		{
			AddBinding(new MouseAxisControl(bind, this));
		}

		public void AddBinding(Keys negative, Keys positive)
		{
			AddBinding(new KeyAxisControl(positive, negative, this));
		}
	}
}
