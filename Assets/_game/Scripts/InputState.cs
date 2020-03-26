using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonState
{
    public bool value;
    public float holdTime = 0;
}

public enum Directions
{
    Right = 1,
    Left = -1
}

public class InputState : MonoBehaviour
{
    public Directions direction = Directions.Right;
    private Dictionary<ButtonAssignments, ButtonState> buttonStates = new Dictionary<ButtonAssignments, ButtonState>();


    public void SetButtonValue(ButtonAssignments key, bool value)
    {
        if (!buttonStates.ContainsKey(key))
            buttonStates.Add(key, new ButtonState());

        var state = buttonStates[key];
        

        if (state.value && !value)
        {
            state.holdTime = 0;
        }
        else if (state.value && value)
        {
            state.holdTime += Time.deltaTime;
        }
        state.value = value;
    }

    public bool GetButtonValue(ButtonAssignments key)
    {
        if (buttonStates.ContainsKey(key))
            return buttonStates[key].value;
        else
            return false;
    }
}

