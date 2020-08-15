namespace Ctrl
{
	public abstract class Bind
	{
		public string Name { get; private set; }
		public PlayerAction Owner { get; private set; }

		protected Bind(string name, PlayerAction owner)
		{
			Name = name;
			Owner = owner;
		}

		public abstract float Value { get; }
		public abstract bool State { get; }

		public static implicit operator float(Bind axis)
		{
			return axis.Value;
		}
	}
}
