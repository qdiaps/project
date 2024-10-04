using UnityEngine;

namespace Configs.Learning
{
    [CreateAssetMenu(fileName="NewLearningConfig", menuName="CustomConfigs/LearningConfig")]
    public class LearningConfig : ScriptableObject
    {
        public int BuildIndexScene;
        public string PathToSave;
        public Sprite[] LearningSprites;
    }
}