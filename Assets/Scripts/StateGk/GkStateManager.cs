using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GkStateManager : MonoBehaviour
{
    GkBaseState currentState;
    GkIdle idleState = new GkIdle();
    GkMoveLeft moveLeft = new GkMoveLeft();
    GkMoveRight moveRight = new GkMoveRight();
    // Start is called before the first frame update
    void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }
}
