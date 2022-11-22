using UnityEngine;
public abstract class GkBaseState
{
    public abstract void EnterState(GkStateManager state);
    public abstract void UpdateState(GkStateManager state);
    public abstract void OnCollisionEnter(GkStateManager state);

}
