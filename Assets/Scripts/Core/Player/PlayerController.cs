using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private bool _cameraCanMove = true;
    [SerializeField] private float _mouseSensitivity = 5f;
    [SerializeField] private float _maxLookAngle = 50f;

    [Header("Cursor")]
    [SerializeField] private bool _lockCursor = true;

    [Header("Movement")]
    [SerializeField] private float _walkSpeed = 5f;
    [SerializeField] private float _maxVelocityChange = 10f;
    [SerializeField] private float _sprintSpeed = 9f;
    [SerializeField] private float _jumpPower = 5f;
    [SerializeField] private float _jumpRayDistance = .75f;

    [Header("Input")]
    [SerializeField] private KeyCode _sprintKey = KeyCode.LeftShift;
    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    
    private Rigidbody _rigidbody;
    private float _pitch;

    private void Awake() => 
        _rigidbody = GetComponent<Rigidbody>();

    private void Start()
    {
        if(_lockCursor)
            Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if(_cameraCanMove)
            MoveCamera();

        if(Input.GetKeyDown(_jumpKey) && CheckGround())
            Jump();
    }

    private void FixedUpdate()
    {
        Vector3 velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (CheckWalking(velocity))
        {
            if (Input.GetKey(_sprintKey))
                Move(velocity, _sprintSpeed);
            else
                Move(velocity, _walkSpeed);
        }
    }

    private void MoveCamera()
    {
        var yaw = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * _mouseSensitivity;
        _pitch -= _mouseSensitivity * Input.GetAxis("Mouse Y");
        
        _pitch = Mathf.Clamp(_pitch, -_maxLookAngle, _maxLookAngle);
        
        transform.localEulerAngles = new Vector3(0, yaw, 0);
        _playerCamera.transform.localEulerAngles = new Vector3(_pitch, 0, 0);
    }

    private bool CheckWalking(Vector3 velocity) => 
        (velocity.x != 0 || velocity.z != 0) && CheckGround();

    private void Move(Vector3 targetVelocity, float speed)
    {
        targetVelocity = transform.TransformDirection(targetVelocity) * speed;
        Vector3 velocityChange = targetVelocity - _rigidbody.velocity;
        velocityChange.x = Mathf.Clamp(velocityChange.x, -_maxVelocityChange, _maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -_maxVelocityChange, _maxVelocityChange);
        velocityChange.y = 0;
        
        _rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    private bool CheckGround()
    {
        Vector3 origin = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y * .5f), transform.position.z);
        Vector3 direction = transform.TransformDirection(Vector3.down);

        return Physics.Raycast(origin, direction, out RaycastHit hit, _jumpRayDistance);
    }

    private void Jump() => 
        _rigidbody.AddForce(0f, _jumpPower, 0f, ForceMode.Impulse);
}