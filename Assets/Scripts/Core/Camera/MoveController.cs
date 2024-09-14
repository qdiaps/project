using Architecture.FiniteStateMachine.States.Game;
using Architecture.Model;
using Architecture.Model.State;
using Configs;
using UnityEngine;
using VContainer;

namespace Core.Camera
{
    public class MoveController : MonoBehaviour
    {
        private const string MouseX = "Mouse X";
        private const string MouseY = "Mouse Y";
        
        private UnityEngine.Camera _camera;
        private GameConfig _config;
        private IModel<StateData> _gameState;
        private float _pitch;

        private void Awake() => 
            _camera = GetComponentInChildren<UnityEngine.Camera>();

        private void Update()
        {
            if (_config == null || _gameState == null)
                return;
            if (_config.CameraConfig.CameraCanMove && _gameState.Read().State == typeof(Play))
                Move();
        }

        [Inject]
        private void Construct(GameConfig config, IModel<StateData> gameState)
        {
            _config = config;
            _gameState = gameState;
        }

        private void Move()
        {
            var yaw = transform.localEulerAngles.y + Input.GetAxis(MouseX) * _config.CameraConfig.MouseSensitivity;
            _pitch -= _config.CameraConfig.MouseSensitivity * Input.GetAxis(MouseY);
            
            _pitch = Mathf.Clamp(_pitch, -_config.CameraConfig.MaxLookAngle, _config.CameraConfig.MaxLookAngle);
            
            transform.localEulerAngles = new Vector3(0, yaw, 0);
            _camera.transform.localEulerAngles = new Vector3(_pitch, 0, 0);
        }
    }
}