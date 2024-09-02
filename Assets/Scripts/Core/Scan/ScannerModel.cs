using System;
using System.Collections;
using Configs;
using UnityEngine;

namespace Core.Scan
{
    public class ScannerModel
    {
        private readonly GameConfig _config;

        private int _currentAttemptRate;
        private bool _isResetAttempts;

        public ScannerModel(GameConfig config)
        {
            _config = config;
            _currentAttemptRate = _config.ScannerConfig.AttemptRate;
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
            yield return new WaitForSeconds(_config.ScannerConfig.AllAttemptResetTime);
            _currentAttemptRate = _config.ScannerConfig.AttemptRate;
            _isResetAttempts = false;
            callback?.Invoke();
        }
    }
}