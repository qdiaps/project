using System.Collections;
using System.Collections.Generic;
using Configs;
using TMPro;
using UnityEngine;
using VContainer;

namespace Core.Hint
{
    public class HintWriter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _hintText;
        
        private GameConfig _config;
        private float _symbolWriteTime;
        private float _timeout;
        private Queue<string> _activeHints = new Queue<string>();
        private Coroutine _activeWriter;

        [Inject]
        private void Construct(GameConfig config)
        {
            _config = config;
            _symbolWriteTime = config.HintConfig.SymbolWriteTime;
            _timeout = config.HintConfig.Timeout;
        }

        public void Write(HintType type)
        {
            _activeHints.Enqueue(_config.HintConfig.Hints[(int)type]);
            if (_activeWriter == null)
                _activeWriter = StartCoroutine(WriteText());
        }

        public void Clear()
        {
            _activeHints.Clear();
            if (_activeWriter != null)
            {
                StopCoroutine(_activeWriter);
                _activeWriter = null;
            }
            ClearHint();
        }

        private IEnumerator WriteText()
        {
            while (_activeHints.Count > 0)
            {
                string hint = _activeHints.Dequeue();
                foreach (var c in hint)
                {
                    _hintText.text += c;
                    yield return new WaitForSeconds(_symbolWriteTime);
                }
                yield return new WaitForSeconds(_timeout);
                ClearHint();
            }
            _activeWriter = null;
        }
        
        private void ClearHint() =>
            _hintText.text = "";
    }
}