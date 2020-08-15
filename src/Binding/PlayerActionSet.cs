using System;
using System.Collections.Generic;

namespace Ctrl
{
	public abstract class PlayerActionSet
	{
		public bool Enabled { get; set; } = true;
		public bool AllowSearchingForDevice { get; set; } = false;

		public InputDevice Device { get; private set; } = InputDevice.Null;

		// TODO: Figure out a better way of indexing these. Strings bad.
		private readonly Dictionary<string, PlayerAction> actions = new Dictionary<string, PlayerAction>();

		public PlayerActionSet()
		{
			InputManager.AddActionSet(this);
		}

		internal void Update()
		{
			if ((Device == InputDevice.Null || Device == null) && AllowSearchingForDevice)
			{
				// If the device has not been set and we're allowed to look for one
				Device = InputManager.ActiveDevice;
			}
			else
				Device.AllowAsActiveDevice = false;

			foreach (PlayerAction action in actions.Values)
			{
				action.PrepareUpdate();
				action.Update();
			}
		}

		protected PlayerAction CreatePlayerAction(string name)
		{
			if (actions.ContainsKey(name))
				return null;

			PlayerAction result = new PlayerAction(name, this);
			actions.Add(name, result);

			return result;
		}

		protected OneAxisPlayerAction CreateOneAxisPlayerAction(string name)
		{
			if (actions.ContainsKey(name))
				return null;

			OneAxisPlayerAction result = new OneAxisPlayerAction(name, this);
			actions.Add(name, result);

			return result;
		}

		protected TwoAxisPlayerAction CreateTwoAxisPlayerAction(string name)
		{
			if (actions.ContainsKey(name))
				return null;

			TwoAxisPlayerAction result = new TwoAxisPlayerAction(name, this);
			actions.Add(name, result);

			return result;
		}

		public void Destroy()
		{
			InputManager.RemoveActionSet(this);

			if (Device != InputDevice.Null)
			{
				Device.AllowAsActiveDevice = true;
			}
		}
	}
}
