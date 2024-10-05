using Architecture.Services.Input;
using UnityEngine;
using VContainer;

namespace Core.Scan
{
    [RequireComponent(typeof(Scanner))]
    public class ScannerController : MonoBehaviour
    {
        private Scanner _scanner;
        private IScanInputReader _inputReader;

        private void Awake() => 
            _scanner = GetComponent<Scanner>();

        private void OnDestroy()
        {
            _inputReader.OnStartScan -= StartScan;
            _inputReader.OnStopScan -= StopScan;
        }

        [Inject]
        private void Construct(IScanInputReader inputReader)
        {
            _inputReader = inputReader;
            _inputReader.OnStartScan += StartScan;
            _inputReader.OnStopScan += StopScan;
        }

        private void StartScan()
        {
            _scanner.CanScan = true;
            StartCoroutine(_scanner.Scan());
        }
        
        private void StopScan() =>
            _scanner.CanScan = false;
    }
}