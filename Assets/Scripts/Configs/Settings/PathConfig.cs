using UnityEngine;

namespace Configs.Settings
{
	[CreateAssetMenu(fileName="NewPathConfig", menuName="CustomConfigs/PathConfig")]
    public class PathConfig : ScriptableObject
    {
	    public string PlayerPrefab;
	    public string KeyPrefab;
	    public ParticleSystem ScannerDefaultParticle;
	    public ParticleSystem ScannerKeyParticle;
	    public ParticleSystem ScannerDoorParticle;
    }
}