using UnityEngine;

namespace Configs.Hint
{
    [CreateAssetMenu(fileName="NewHintConfig", menuName="CustomConfigs/HintConfig")]
    public class HintConfig : ScriptableObject
    {
        public float SymbolWriteTime;
        public float Timeout;
        public string[] Hints;
    }
}