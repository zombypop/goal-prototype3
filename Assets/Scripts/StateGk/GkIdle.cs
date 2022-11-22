using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GkIdle : GkBaseState
{
    public override void EnterState(GkStateManager state)
    {
        //GkAnimator.SetBool("GkReady", true);
        //var pos = Vector3.Lerp(centroPorteria.transform.position, ball.transform.position, 0.1f);
        //transform.position = pos;

        ////Quaternion toRotation = Quaternion.LookRotation(ball.transform.position);
        ////transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 1 * Time.deltaTime);
        //transform.LookAt(ball.transform);
    }

    public override void OnCollisionEnter(GkStateManager state)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateState(GkStateManager state)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
