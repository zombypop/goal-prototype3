using UnityEngine;

public class MoveTransalte : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] Animator animator;
    [SerializeField] private GameObject arquero;
    private float originalSpeed;
    private BarSystem barSystem;
    public Transform pfPowerBar;
    private PowerBar powerBar;

    private void Start()
    {
        barSystem = new BarSystem(0);

        var powerBarTransform = Instantiate(pfPowerBar, transform.position + Vector3.up, Quaternion.identity);
        powerBar = powerBarTransform.GetComponent<PowerBar>();
        powerBar.transform.localScale = new Vector3(5, 10);
        powerBar.Setup(barSystem);

        originalSpeed = _speed;
    }

    private void Update()
    {
        if (ScoreManager.Instance.intentos >= 5) return;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();
        transform.Translate(movementDirection * _speed * Time.deltaTime, Space.World);
        if (movementDirection != Vector3.zero)
        {
            //transform.forward = movementDirection;
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.deltaTime);
            animator.SetBool("isRunning", true);
        } else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetMouseButton(0))
        {
            transform.LookAt(arquero.transform);
            barSystem.Increase(10);
        }    
        powerBar.transform.position = transform.position + Vector3.up;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void DefaultSpeed()
    {
        _speed = originalSpeed;
    }

}
