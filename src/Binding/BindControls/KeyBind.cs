using Stride.Input;

namespace Ctrl
{
	public sealed class KeyBind : Bind
	{
		private readonly Keys bind;

		public KeyBind(Keys bind, PlayerAction owner) : base(bind.ToString(), owner)
		{
			this.bind = bind;
		}

		public override float Value => State ? 1f : 0f;

		public override bool State => InputManager.CheckKeyIsPressed(bind);
	}
}
