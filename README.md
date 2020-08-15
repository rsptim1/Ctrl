# Ctrl
*Ctrl* is a programmer-oriented wrapper for Stride's native input system. The goal is to make grabbing player inputs at runtime more standardized and configurable, and to allow easy rebinding of controls.

## Roadmap:

- [x] Basic binding controls for buttons and axes
- [ ] Advanced mouse controls and utilities
- [ ] Easy runtime rebinding
- [ ] Savable and loadable controller binding layouts

# Using Ctrl

The most configurable way to utilize *Ctrl* is by implementing the `PlayerActionSet` class and having `PlayerAction` fields to be read from.

```cs
public class InputController : PlayerActionSet
{
    private readonly TwoAxisPlayerAction exampleAxis;
    public TwoPlayerAxisAction => ExampleAxis;

    private readonly PlayerAction exampleButton;
    public PlayerAction => ExampleButton;

    public InputController() : base()
    {
        // Setup the axis action
        // Note: each PlayerAction must be assigned a unique name
        exampleAxis = CreateTwoAxisPlayerAction("Axis");
        exampleAxis.AddBinding(MouseAxis.X, MouseAxis.Y);

        // Setup the button action
        exampleAxis = CreatePlayerAction("Button");
        exampleAxis.AddBinding(Keys.Space);
    }
}
```

These player actions can now be read for input values.

```cs
var controller = new InputController();

bool isPressed = controller.ExampleButton.IsPressed;
Vector2 axisInput = controller.ExampleAxis.Vector;
```

<sup><sub>Yes, the name is a pun.</sub></sup>
