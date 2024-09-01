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
        private bool _isResetAllAttempt;

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

        public IEnumerator ResetAttempt(Action callback = null)
        {
            if (_currentAttemptRate >= _config.AttemptRate)
                yield break;
            yield return new WaitForSeconds(_config.AttemptResetTime);
            if (_isResetAllAttempt == false)
            {
                _currentAttemptRate++;
                callback?.Invoke();
            }
        }

        public IEnumerator ResetAllAttempt(Action callback = null)
        {
            if (_currentAttemptRate != 0 || _isResetAllAttempt)
                yield break;
            _isResetAllAttempt = true;
            yield return new WaitForSeconds(_config.AllAttemptResetTime);
            _currentAttemptRate = _config.AttemptRate;
            _isResetAllAttempt = false;
            callback?.Invoke();
        }
    }
}