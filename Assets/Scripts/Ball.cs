using System;
using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private bool stickToPlayer = false;
    public GameObject player;
    private Rigidbody rb;
    [SerializeField]
    private GameObject rightGoal;
    [SerializeField]
    private GameObject leftGoal;
    private float _shootSpeed;
    private float _timePresed;
    [SerializeField]
    private float _power;
    public bool _isShooting = false;
    private TrailRenderer trialRenderer;
    [SerializeField] Animator animator;
    [SerializeField] GoalKeeper goalKeeper;

    [SerializeField]  Cinemachine.CinemachineVirtualCamera virtualCamera;

    public event EventHandler isStick;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        trialRenderer = GetComponent<TrailRenderer>();
        trialRenderer.emitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log($"{transform.position - rightGoal.transform.position}");
        if (stickToPlayer)
        {
            var posicion = (player.transform.position + player.transform.forward / 2);
            transform.position = new Vector3(posicion.x, transform.position.y, posicion.z);
        }
        else
        {
            var distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            if (distanceToPlayer < 1.2f && !_isShooting)
            {
                stickToPlayer = true;
                if (isStick != null) isStick(this, EventArgs.Empty);
                trialRenderer.emitting = false;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            _timePresed = Time.time;
            //Debug.DrawLine(transform.position, rightGoal.transform.position);
            Debug.Log("Kick");
            animator.SetBool("isKicking", true);
            player.gameObject.GetComponent<MoveTransalte>().SetSpeed(1f);
        }
        if (Input.GetMouseButtonUp(0))
        {
            _shootSpeed = Time.time - _timePresed;
            _isShooting = true;
            goalKeeper.SetIdle(false);
            StartCoroutine(SetShooting(1f));
            player.gameObject.GetComponent<MoveTransalte>().DefaultSpeed();
        }

        if (transform.position.z > 9) virtualCamera.Follow = null;
    }

    private void FixedUpdate()
    {
        if (_isShooting && Input.GetKey(KeyCode.D) && stickToPlayer)
        {
            if (_shootSpeed > 0.3f) _shootSpeed = 0.3f;
            stickToPlayer = false;
            var offset = new Vector3(UnityEngine.Random.Range(-5.0f, 5.0f), UnityEngine.Random.Range(4.0f, 10.0f), 0);
            Debug.Log($"or: {(rightGoal.transform.position - transform.position).normalized} offset : {offset} total : {((rightGoal.transform.position - transform.position).normalized + offset)}");
            rb.AddForce(((rightGoal.transform.position + offset) - transform.position).normalized * _shootSpeed * _power, ForceMode.Impulse);
            //rb.AddForceAtPosition(rightGoal.transform.position * Random.Range(1, 10), transform.position, ForceMode.Impulse);
            _shootSpeed = 0;
            trialRenderer.emitting = true;
            goalKeeper.SetMove(true);
        } else if (_isShooting && Input.GetKey(KeyCode.A) && stickToPlayer)
        {
            if (_shootSpeed > 0.3f) _shootSpeed = 0.3f;
            var offset = new Vector3(UnityEngine.Random.Range(-5.0f, 5.0f), UnityEngine.Random.Range(4.0f, 10.0f), 0);
            Debug.Log($"or: {(rightGoal.transform.position - transform.position).normalized} offset : {offset} total : {((rightGoal.transform.position - transform.position).normalized + offset)}");
            stickToPlayer = false;
            rb.AddForce(((leftGoal.transform.position + offset) - transform.position).normalized   * _shootSpeed * _power, ForceMode.Impulse);
            _shootSpeed = 0;
            trialRenderer.emitting = true;
            goalKeeper.SetMove(false);
        } else if (_isShooting && stickToPlayer)
        {
            if (_shootSpeed > 0.3f) _shootSpeed = 0.3f;
            var offset = new Vector3(UnityEngine.Random.Range(-5.0f, 5.0f), UnityEngine.Random.Range(4.0f, 10.0f), 0);
            Debug.Log($"or: {(goalKeeper.transform.position - transform.position).normalized} offset : {offset} total : {((rightGoal.transform.position - transform.position).normalized + offset)}");
            stickToPlayer = false;
            rb.AddForce(((goalKeeper.transform.position + offset) - transform.position).normalized * _shootSpeed * _power, ForceMode.Impulse);
            _shootSpeed = 0;
            trialRenderer.emitting = true;
            goalKeeper.SetMove(false);
        }

    }

    private IEnumerator SetShooting(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            _isShooting = false;
        }
    }
}
