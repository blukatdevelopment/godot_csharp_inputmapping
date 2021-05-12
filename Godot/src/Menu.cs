using Godot;
using Input;
using System;
using System.Collections.Generic;

public class Menu : Container
{

    private Dictionary<ActionEnum, Button> actionButtons;
    private ActionEnum actionToRemap;

    public Menu()
    {
        actionToRemap = ActionEnum.None;
        InitActionButtons();
    }

    public override void _Process(float delta)
    {
        if(actionToRemap != ActionEnum.None && Main.state.actionToRemap == ActionEnum.None)
        {
            actionToRemap = ActionEnum.None;
            InitActionButtons();
        }
    }

    private void InitActionButtons()
    {
        if(actionButtons != null)
        {
            foreach(ActionEnum action in actionButtons.Keys)
            {
                actionButtons[action].QueueFree();
            }
        }

        int row = 0;
        actionButtons = new Dictionary<ActionEnum, Button>();
        foreach(KeyMapping map in Main.state.keyMappings)
        {
            if(map.mode != InputModeEnum.PressEnd && !actionButtons.ContainsKey(map.action))
            {
                Button button = new Button();
                button.Text = map.action.ToString() + ": " + map.key.ToString();
                actionButtons.Add(map.action, button);
                AddChild(button);
                button.SetSize(new Vector2(100f, 30f));
                button.SetPosition(new Vector2(0f, row * 30));
                row++;

                button.onClick = () =>
                {
                    UpdateMapping(map.action);
                };
            }
        }
    }

    private void UpdateMapping(ActionEnum action)
    {
        if(actionToRemap != ActionEnum.None)
        {
            return;
        }
        GD.Print("Updating mapping " + action);
        actionToRemap = action;
        Main.state.RemapAction(action);
        actionButtons[action].Text = "<Press any key to set " + action + ">";
    }

}