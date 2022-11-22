using UnityEngine;

public class GoalKeeper : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject centroPorteria;
    [SerializeField] private Animator GkAnimator;
    private bool isSaving = false;
    private bool _isIdle = true;

    private void Start()
    {
        GkAnimator.SetBool("GkReady", true);
    }

    public void SetIdle(bool isIdle)
    {
        _isIdle = isIdle;
    }

    public void SetMove(bool left)
    {
        if (left)
        {
            GkAnimator.SetBool("GkSidestepLeft", true);
            GkAnimator.SetBool("GkSidestepRight", false);
            GkAnimator.SetBool("GkSaveLeft", true);
        }
        else
        {
            GkAnimator.SetBool("GkSidestepRight", true);
            GkAnimator.SetBool("GkSidestepLeft", false);
            GkAnimator.SetBool("GkSaveRight", true);
        }
    }

    private void Update()
    {
        //Si el ball esta lejos, idle
        //Si el ball se acerca preparar animacion
        //Lanzar a un lado o arriba
        //var distancia = Vector3.Distance(transform.position , ball.transform.position);
        //if (distancia < 15 && !isSaving)
        //{
        //    GkAnimator.SetBool("GkSaveLeft", true);
        //    isSaving = true;
        //}

        if (_isIdle)
        {
            var pos = Vector3.Lerp(centroPorteria.transform.position, ball.transform.position, 0.1f);
            transform.position = pos;

            //Quaternion toRotation = Quaternion.LookRotation(ball.transform.position);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 1 * Time.deltaTime);
            transform.LookAt(ball.transform);
        }

    }

}
