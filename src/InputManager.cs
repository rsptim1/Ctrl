using System;
using System.Collections.Generic;
using Stride.Core.Mathematics;
using Stride.Input;
using StrideInputManager = Stride.Input.InputManager;

namespace Ctrl
{
	public static class InputManager
	{
		private static StrideInputManager StrideInputManager;

		private static readonly Dictionary<Guid, InputDevice> inputDevices = new Dictionary<Guid, InputDevice>();
		private static readonly List<PlayerActionSet> actionSets = new List<PlayerActionSet>();
		private static bool initialized;

		public static InputDevice ActiveDevice = InputDevice.Null;

		internal static void Initialize(StrideInputManager input)
		{
			if (!initialized)
			{
				initialized = true;

				// Setup the engine's input manager ref
				StrideInputManager = input;
			}
		}

		internal static bool Update(float deltaTime)
		{
			if (!initialized)
				return false;

			CheckForInputDevices();

			// Update each input device
			foreach (InputDevice device in inputDevices.Values)
			{
				if (device.Enabled)
				{
					device.Update();

					if (device.AnyInput && device.AllowAsActiveDevice && ActiveDevice != device)
						ActiveDevice = device;
				}
			}

			// Update each registered action set
			foreach (PlayerActionSet set in actionSets)
			{
				if (set.Enabled)
					set.Update();
			}

			return true;
		}

		private static void CheckForInputDevices()
		{
			foreach (var device in StrideInputManager.GamePads)
			{
				if (!inputDevices.ContainsKey(device.Id))
				{
					inputDevices.Add(device.Id, new InputDevice(device));
				}
			}
		}

		public static void SetMouseCursorLockState(bool locked)
		{
			if (locked)
			{
				StrideInputManager.LockMousePosition();
			}
			else
			{
				StrideInputManager.UnlockMousePosition();
			}
		}

		public static bool ToggleMouseCursorLockState()
		{
			bool result = StrideInputManager.IsMousePositionLocked;
			SetMouseCursorLockState(!result);

			return !result;
		}

		public static bool CheckKeyIsPressed(Keys k)
		{
			return StrideInputManager.IsKeyDown(k);
		}

		public static bool CheckMouseIsPressed(MouseButton m)
		{
			return StrideInputManager.IsMouseButtonDown(m);
		}

		public static float CheckAxis(MouseAxis axis)
		{
			if (axis == MouseAxis.Wheel)
				return StrideInputManager.MouseWheelDelta;

			Vector2 axisData = StrideInputManager.MouseDelta;
			return axis == MouseAxis.X ? axisData.X : axisData.Y;
		}

		internal static void AddActionSet(PlayerActionSet set)
		{
			if (!actionSets.Contains(set))
			{
				actionSets.Add(set);
			}
		}

		internal static void RemoveActionSet(PlayerActionSet set)
		{
			if (actionSets.Contains(set))
			{
				actionSets.Remove(set);
			}
		}
	}
}
