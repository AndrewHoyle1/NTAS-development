using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ButtonAssignments
{
    Left,
    Right,
    Shift,
    Down,
    Space,
    C,
    E
}

public enum Condition
{
    GreaterThan,
    LessThan
}

[System.Serializable]
public class InputAxisState
{
    public string axisName;
    public float offValue;
    public ButtonAssignments button;
    public Condition condition;

    public bool value
    {
        get
        {
            var val = Input.GetAxis(axisName);
            switch (condition)
            {
                case Condition.GreaterThan:
                    return val > offValue;
                case Condition.LessThan:
                    return val < offValue;
            }
            return false;
        }
    }
}

public class InputManager : MonoBehaviour
{
    public InputAxisState[] inputs;
    public InputState inputState;
    public GameObject gameManager;
    public GameObject player;

    // function to make newly-instantiated Player (and its scripts) available to InputManager
    void GetPlayer()
    {
        // get reference to GameManager
        gameManager = GameObject.Find("GameManager");
        // referenceinstantiated Player 
        player = gameManager.GetComponent<FullGameManager>().player;
        // get inputState on instantiated Player 
        inputState = player.GetComponent<InputState>();
    }

    // Update is called once per frame
    void Update()
    {
        // if player doesn't exist then create (should only happen once)
        if (!player)
        {
            GetPlayer();
        }
        foreach (var input in inputs)
        {
            inputState.SetButtonValue(input.button, input.value);
        }
    }
}
