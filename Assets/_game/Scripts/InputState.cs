using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonState
{
    public bool value;
    public float holdTime = 0;
}
public class InputState : MonoBehaviour
{

    private Dictionary<ButtonAssignments, ButtonState> buttonStates = new Dictionary<ButtonAssignments, ButtonState>();


    public void SetButtonValue(ButtonAssignments key, bool value)
    {
        if (!buttonStates.ContainsKey(key))
            buttonStates.Add(key, new ButtonState());

        var state = buttonStates[key];
        

        if (state.value && !value)
        {
            Debug.Log("Button " + key + " released" + state.holdTime);
            state.holdTime = 0;
        }
        else if (state.value && value)
        {
            Debug.Log("Button " + key + " down");
            state.holdTime += Time.deltaTime;
        }
        state.value = value;
    }
}

