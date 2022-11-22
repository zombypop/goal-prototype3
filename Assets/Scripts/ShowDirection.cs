using UnityEngine;

public class ShowDirection : MonoBehaviour
{
    private LineController lineController;
    public GameObject leftGoal;
    public GameObject rightGoal;

    private void Awake()
    {
        lineController = GetComponent<LineController>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.D))
                lineController.SetLine(transform.position, rightGoal.transform.position);
            if (Input.GetKey(KeyCode.A))
                lineController.SetLine(transform.position, leftGoal.transform.position);
        }

    }
}
