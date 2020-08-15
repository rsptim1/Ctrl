using Stride.Core.Mathematics;
using Stride.Input;
using System.Collections.Generic;

namespace Ctrl
{
	public class TwoAxisPlayerAction : PlayerAction
	{
		private List<AxisControlPair> axisControls = new List<AxisControlPair>();

		public TwoAxisPlayerAction(string name, PlayerActionSet owner) : base(name, owner)
		{
		}

		public Vector2 Vector => thisState.Vector;

		internal override void Update()
		{
			Vector2 value = Vector2.Zero;

			// Iterate through each bind and find the input with greatest magnitude
			foreach (Vector2 control in axisControls)
			{
				if (control.LengthSquared() > value.LengthSquared())
				{
					value = control;
				}
			}

			thisState.Vector = value;
		}

		public void AddBinding(GamePadAxis bindX, GamePadAxis bindY)
		{
			var x = new GamepadAxisControl(bindX, this);
			var y = new GamepadAxisControl(bindY, this);
			axisControls.Add(new AxisControlPair { X = x, Y = y });
		}

		public void AddBinding(MouseAxis bindX, MouseAxis bindY)
		{
			var x = new MouseAxisControl(bindX, this);
			var y = new MouseAxisControl(bindY, this);
			axisControls.Add(new AxisControlPair { X = x, Y = y });
		}

		public void AddBinding(Keys left, Keys right, Keys up, Keys down)
		{
			var x = new KeyAxisControl(right, left, this);
			var y = new KeyAxisControl(up, down, this);
			axisControls.Add(new AxisControlPair { X = x, Y = y });
		}

		private struct AxisControlPair
		{
			public AxisControl X { get; set; }
			public AxisControl Y { get; set; }

			public static implicit operator Vector2(AxisControlPair pair)
			{
				return new Vector2(pair.X, pair.Y);
			}
		}
	}
}
