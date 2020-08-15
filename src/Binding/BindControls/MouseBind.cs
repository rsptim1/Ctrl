using Stride.Input;

namespace Ctrl
{
	public sealed class MouseBind : Bind
	{
		private MouseButton bind;

		public MouseBind(MouseButton bind, PlayerAction owner) : base(bind.ToString(), owner)
		{
			this.bind = bind;
		}

		public override float Value => State ? 1f : 0f;

		public override bool State => InputManager.CheckMouseIsPressed(bind);
	}
}
