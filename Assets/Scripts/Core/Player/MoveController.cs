using Architecture.Services.Input;
using Configs.Player;
using UnityEngine;
using VContainer;

namespace Core.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class MoveController : MonoBehaviour
    {
        private IInputReader _inputReader;
        private PlayerConfig _config;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnDestroy()
        {
            if (_inputReader != null)
            {
                _inputReader.OnMove -= Move;
                _inputReader.OnSprintMove -= SprintMove;
                _inputReader.OnJump -= Jump;
            }
        }

        [Inject]
        private void Construct(IInputReader inputReader, PlayerConfig config)
        {
            _inputReader = inputReader;
            _config = config;
            Init();
        }

        private void Init()
        {
            SettingInput();
        }
        
        private void SettingInput()
        {
            _inputReader.OnMove += Move;
            _inputReader.OnSprintMove += SprintMove;
            _inputReader.OnJump += Jump;
        }

        private void Move(Vector3 velocity) => 
            Move(velocity, _config.WalkSpeed);

        private void SprintMove(Vector3 velocity) => 
            Move(velocity, _config.SprintSpeed);

        private void Move(Vector3 velocity, float speed)
        {
            if (CheckGround())
            {
                velocity = transform.TransformDirection(velocity) * speed;
                Vector3 velocityChange = velocity - _rigidbody.velocity;
                velocityChange.x = Mathf.Clamp(velocityChange.x, -_config.MaxVelocityChange, _config.MaxVelocityChange);
                velocityChange.z = Mathf.Clamp(velocityChange.z, -_config.MaxVelocityChange, _config.MaxVelocityChange);
                velocityChange.y = 0;
                _rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
            }
        }

        private void Jump()
        {
            if (CheckGround())
                _rigidbody.AddForce(0f, _config.JumpPower, 0f, ForceMode.Impulse);
        }
        
        private bool CheckGround()
        {
            Vector3 origin = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y * .5f), transform.position.z);
            Vector3 direction = transform.TransformDirection(Vector3.down);
        
            return Physics.Raycast(origin, direction, out RaycastHit hit, _config.CheckGroundRayDistance);
        }
    }
}