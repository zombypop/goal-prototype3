using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootMouse : MonoBehaviour
{
    private Rigidbody rb;
    private float _speed;
    private float _timePresed;
    private float _shootSpeed;
    private bool _isShooting = false;
    public Slider slider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log($"tiempo press: {Time.time-_timePresed} slider: {slider.value}");
            slider.value = Time.time - _timePresed;
        }
        if (Input.GetMouseButtonDown(0))
        {
            _timePresed = Time.time;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _shootSpeed = Time.time - _timePresed;
            _isShooting = true;
            Debug.Log($"suelta click: {Time.time - _timePresed} slider: {slider.value}");
            slider.value = 0;
        }

        if (transform.position.y < -10)
        {
            transform.position = Vector3.zero;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    private void FixedUpdate()
    {
        if (_isShooting && _shootSpeed > 0 && rb.velocity == Vector3.zero)
        {
            if (Input.GetKey(KeyCode.A))
                rb.AddForce((Vector3.forward * _shootSpeed * 50) + Vector3.up + (Vector3.left * _shootSpeed * 50), ForceMode.Impulse);
            if (Input.GetKey(KeyCode.D))
                rb.AddForce((Vector3.forward * _shootSpeed * 50) + Vector3.up + ( Vector3.right * _shootSpeed * 50), ForceMode.Impulse);
            _shootSpeed = 0;
            slider.value = 0;
        }
    }
}
