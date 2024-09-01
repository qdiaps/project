using Architecture.Services.Input;
using UnityEngine;
using VContainer;

namespace Core.Scan
{
    [RequireComponent(typeof(Scanner))]
    public class ScannerController : MonoBehaviour
    {
        private Scanner _scanner;
        private ScannerModel _model;
        private IScanInputReader _inputReader;

        private void Awake() => 
            _scanner = GetComponent<Scanner>();

        private void OnDestroy() => 
            _inputReader.OnScan -= Scan;

        [Inject]
        private void Construct(ScannerModel model, IScanInputReader inputReader)
        {
            _model = model;
            _inputReader = inputReader;
            _inputReader.OnScan += Scan;
        }

        private void Scan()
        {
            if (_model.UseAttempt())
            {
                _scanner.Scan();
                StartCoroutine(_model.ResetAttempt());
            }
            else
                StartCoroutine(_model.ResetAllAttempt());
        }
    }
}