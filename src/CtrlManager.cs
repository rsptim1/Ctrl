using Stride.Engine;

namespace Ctrl
{
	public class CtrlManager : SyncScript
	{
		private static CtrlManager manager;

		public override void Start()
		{
			base.Start();

			if (manager == null)
			{
				manager = this;
				InputManager.Initialize(Input);
			}
			else
			{
				Entity.Remove(this);
			}
		}

		public override void Update()
		{
			if (!InputManager.Update((float)Game.UpdateTime.Elapsed.TotalSeconds))
			{
				// If the update fails, log warning
				Log.Warning("Ctrl InputManager failed to Update! Is it initialized?");
			}
		}
	}
}
