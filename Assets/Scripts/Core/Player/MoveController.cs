using Architecture.Services.Input;
using Configs;
using UnityEngine;
using VContainer;

namespace Core.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class MoveController : MonoBehaviour
    {
        private IJumpInputReader _jumpInputReader;
        private IMoveInputReader _moveInputReader;
        private GameConfig _config;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnDestroy()
        {
            if (_moveInputReader != null)
            {
                _moveInputReader.OnMove -= Move;
                _moveInputReader.OnSprintMove -= SprintMove;
            }
            
            if (_jumpInputReader != null)
                _jumpInputReader.OnJump -= Jump;
        }

        [Inject]
        private void Construct(IJumpInputReader jumpInputReader, IMoveInputReader moveInputReader, GameConfig config)
        {
            _jumpInputReader = jumpInputReader;
            _moveInputReader = moveInputReader;
            _config = config;
            Init();
        }

        private void Init()
        {
            SettingInput();
        }
        
        private void SettingInput()
        {
            _moveInputReader.OnMove += Move;
            _moveInputReader.OnSprintMove += SprintMove;
            _jumpInputReader.OnJump += Jump;
        }

        private void Move(Vector3 velocity) => 
            Move(velocity, _config.PlayerConfig.WalkSpeed);

        private void SprintMove(Vector3 velocity) => 
            Move(velocity, _config.PlayerConfig.SprintSpeed);

        private void Move(Vector3 velocity, float speed)
        {
            velocity = transform.TransformDirection(velocity) * speed;
            Vector3 velocityChange = velocity - _rigidbody.velocity;
            velocityChange.x = Mathf.Clamp(velocityChange.x, -_config.PlayerConfig.MaxVelocityChange, 
                _config.PlayerConfig.MaxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -_config.PlayerConfig.MaxVelocityChange,
                _config.PlayerConfig.MaxVelocityChange);
            velocityChange.y = 0;
            _rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
        }

        private void Jump()
        {
            if (CheckGround())
                _rigidbody.AddForce(0f, _config.PlayerConfig.JumpPower, 0f, ForceMode.Impulse);
        }
        
        private bool CheckGround()
        {
            Vector3 origin = new Vector3(transform.position.x, transform.position.y - (transform.localScale.y * .5f), transform.position.z);
            Vector3 direction = transform.TransformDirection(Vector3.down);
        
            return Physics.Raycast(origin, direction, out RaycastHit hit, _config.PlayerConfig.CheckGroundRayDistance);
        }
    }
}