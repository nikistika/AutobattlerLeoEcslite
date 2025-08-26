using _Project.Scripts.ScriptableObjects;
using _Project.Scripts.ScriptableObjects.Characters;
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

        public Transform BlueTeamObject;
        public Transform RedTeamObject;
        
        public TeamSpawnConfig BlueTeamSpawnData;
        public TeamSpawnConfig RedTeamSpawnData;

        public ArcherConfig ArcherData;
        public MageConfig MageData;
        public WarConfig WarData;
    }
}