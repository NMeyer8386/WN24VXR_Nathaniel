using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    BaseState currentState;

    IdleState idleState = new IdleState();
    AlertState alertState = new AlertState();
    FleeState fleeState = new FleeState();

}
