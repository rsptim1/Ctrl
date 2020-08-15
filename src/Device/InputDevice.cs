using Stride.Core.Mathematics;
using Stride.Input;

namespace Ctrl
{
	public class InputDevice
	{
		public static InputDevice Null = new InputDevice(null) { Enabled = false };

		public bool Enabled { get; set; } = true;
		public bool AllowAsActiveDevice { get; set; } = true;

		public string Name => device.Name;

		private readonly IGamePadDevice device;
		private GamePadState lastState;
		private GamePadState thisState;

		public InputDevice(IGamePadDevice device)
		{
			this.device = device;
		}

		internal void Update()
		{
			lastState = thisState;
			thisState = device.State;
		}

		public Vector2 LeftStick => thisState.LeftThumb;
		public Vector2 RightStick => thisState.RightThumb;

		public float LeftTrigger => GetAxis(GamePadAxis.LeftTrigger);
		public float RightTrigger => GetAxis(GamePadAxis.RightTrigger);

		public float GetAxis(GamePadAxis axis)
		{
			switch (axis)
			{
				case GamePadAxis.LeftThumbX:
					return thisState.LeftThumb.X;
				case GamePadAxis.LeftThumbY:
					return thisState.LeftThumb.Y;
				case GamePadAxis.RightThumbX:
					return thisState.RightThumb.X;
				case GamePadAxis.RightThumbY:
					return thisState.RightThumb.Y;
				case GamePadAxis.LeftTrigger:
					return thisState.LeftTrigger;
				case GamePadAxis.RightTrigger:
					return thisState.RightTrigger;
				default:
					return 0f;
			}
		}

		public bool GetButton(GamePadButton input)
		{
			return thisState.Buttons.HasFlag(input);
		}

		public bool AnyButtonIsPressed => thisState.Buttons.HasFlag(~GamePadButton.None);
		public bool AnyInput
		{
			get
			{
				bool triggers = RightTrigger > 0 || LeftTrigger > 0;
				bool sticks = LeftStick.LengthSquared() > 0 || RightStick.LengthSquared() > 0;
				return triggers || sticks || AnyButtonIsPressed;
			}
		}
	}
}
