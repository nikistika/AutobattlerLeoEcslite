using UnityEngine;

namespace _Project.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "TeamSpawnData", menuName = "Spawn/New TeamSpawnData")]
    public class TeamSpawnConfig : ScriptableObject
    {
        [field:SerializeField] public float MinX { get; private set; }
        [field:SerializeField] public float MaxX { get; private set; }
        
        [field:SerializeField] public float MinY { get; private set; }
        [field:SerializeField] public float MaxY { get; private set; }
        
        [field:SerializeField] public float MinZ { get; private set; }
        [field:SerializeField] public float MaxZ { get; private set; }
    }
}

