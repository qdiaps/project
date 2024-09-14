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

        private void OnDestroy() => 
            _inputReader.OnScan -= Scan;

        [Inject]
        private void Construct(IScanInputReader inputReader)
        {
            _inputReader = inputReader;
            _inputReader.OnScan += Scan;
        }

        private void Scan() => 
            StartCoroutine(_scanner.Scan());
    }
}