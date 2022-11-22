using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float _speed = 1;
    private float _dirH = 0;
    private float _dirV = 0;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    //private void Update()
    //{
    //    if (Input.GetKey(KeyCode.A))
    //    {
    //        transform.Translate(Vector3.up * _speed * Time.deltaTime);
    //    } else if (Input.GetKey(KeyCode.D))
    //    {
    //        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    //    } else if (Input.GetKey(KeyCode.W))
    //    {
    //        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    //    } else if (Input.GetKey(KeyCode.S))
    //    {
    //        transform.Translate(Vector3.left * _speed * Time.deltaTime);
    //    }
    //}

    private void Update()
    {
        _dirH = Input.GetAxis("Horizontal");
        _dirV = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) )
        {
            _rigidbody.AddForce(Vector3.right * _dirH * _speed * Time.deltaTime);
        } else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            _rigidbody.AddForce(Vector3.up * _dirV * _speed * Time.deltaTime);
        }
    }
}
