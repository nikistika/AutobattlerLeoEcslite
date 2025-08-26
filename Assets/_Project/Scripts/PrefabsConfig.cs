using _Project.Scripts.ScriptableObjects;
using UnityEngine;

namespace _Project.Scripts
{
    public class PrefabsConfig : MonoBehaviour
    {
        public Transform ArcherBluePrefab;
        public Transform MageBluePrefab;
        public Transform WarBluePrefab;
        
        public Transform ArcherRedPrefab;
        public Transform MageRedPrefab;
        public Transform WarRedPrefab;

        public TeamSpawnConfig BlueTeamSpawnData;
        public TeamSpawnConfig RedTeamSpawnData;
    }
}