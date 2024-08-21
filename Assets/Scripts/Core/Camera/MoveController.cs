using Configs.Camera;
using UnityEngine;
using VContainer;

namespace Core.Camera
{
    public class MoveController : MonoBehaviour
    {
        private const string MouseX = "Mouse X";
        private const string MouseY = "Mouse Y";
        
        private UnityEngine.Camera _camera;
        private CameraConfig _config;
        private float _pitch;

        private void Awake()
        {
            _camera = GetComponentInChildren<UnityEngine.Camera>();
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            if (_config == null)
                return;
            if (_config.CameraCanMove)
                Move();
        }

        [Inject]
        private void Construct(CameraConfig config)
        {
            _config = config;
        }

        private void Move()
        {
            var yaw = transform.localEulerAngles.y + Input.GetAxis(MouseX) * _config.MouseSensitivity;
            _pitch -= _config.MouseSensitivity * Input.GetAxis(MouseY);
            
            _pitch = Mathf.Clamp(_pitch, -_config.MaxLookAngle, _config.MaxLookAngle);
            
            transform.localEulerAngles = new Vector3(0, yaw, 0);
            _camera.transform.localEulerAngles = new Vector3(_pitch, 0, 0);
        }
    }
}