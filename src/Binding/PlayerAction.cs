using Stride.Input;
using System.Collections.Generic;

namespace Ctrl
{
	public class PlayerAction
	{
		public string Name { get; private set; }
		public PlayerActionSet Owner { get; private set; }
		public InputDevice Device => Owner.Device;
		protected List<Bind> binds = new List<Bind>(2);
		
		protected InputControlState lastState;
		protected InputControlState thisState;

		public PlayerAction(string name, PlayerActionSet owner)
		{
			Name = name;
			Owner = owner;
		}

		internal void PrepareUpdate()
		{
			lastState = thisState;
			thisState = new InputControlState();
		}

		internal virtual void Update()
		{
			foreach (var bind in binds)
			{
				thisState.IsPressed = thisState.IsPressed || bind.State;
			}
		}

		public void AddBinding(Bind bind)
		{
			binds.Add(bind);
		}

		public void AddBinding(MouseButton bind)
		{
			AddBinding(new MouseBind(bind, this));
		}

		public void AddBinding(Keys bind)
		{
			AddBinding(new KeyBind(bind, this));
		}

		public void AddBinding(GamePadButton bind)
		{
			AddBinding(new GamepadBind(bind, this));
		}

		public bool IsPressed => thisState.IsPressed;
		public bool WasPressed => lastState.IsPressed && !thisState.IsPressed;
	}
}
