using System;
using System.Collections;
using Configs.Scanner;
using UnityEngine;

namespace Core.Scan
{
    public class ScannerModel
    {
        private readonly ScannerConfig _config;

        private int _currentAttemptRate;
        private bool _isResetAttempts;

        public ScannerModel(ScannerConfig config)
        {
            _config = config;
            _currentAttemptRate = _config.AttemptRate;
        }

        public bool UseAttempt()
        {
            if (_currentAttemptRate == 0)
                return false;
            _currentAttemptRate--;
            return true; 
        }

        public IEnumerator ResetAttempts(Action callback = null)
        {
            if (_currentAttemptRate != 0 || _isResetAttempts)
                yield break;
            _isResetAttempts = true;
            yield return new WaitForSeconds(_config.AllAttemptResetTime);
            _currentAttemptRate = _config.AttemptRate;
            _isResetAttempts = false;
            callback?.Invoke();
        }
    }
}