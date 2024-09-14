using System;
using UnityEngine;

namespace Configs.Settings
{
	[CreateAssetMenu(fileName="NewPathConfig", menuName="CustomConfigs/PathConfig")]
    public class PathConfig : ScriptableObject
    {
	    public string PlayerPrefab;
	    public ParticleSystem ScannerParticle;
    }
}