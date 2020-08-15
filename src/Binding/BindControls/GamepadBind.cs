using Stride.Input;

namespace Ctrl
{
	public sealed class GamepadBind : Bind
	{
		private GamePadButton bind;

		public GamepadBind(GamePadButton bind, PlayerAction owner) : base(bind.ToString(), owner)
		{
			this.bind = bind;
		}

		public override float Value => State ? 1f : 0f;

		public override bool State => Owner.Device.GetButton(bind);
	}
}
