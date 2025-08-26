using _Project.Scripts.Components;
using _Project.Scripts.Components.Characters;
using _Project.Scripts.ScriptableObjects;
using Leopotam.EcsLite;
using UnityEngine;

namespace _Project.Scripts.Systems
{
    internal class SpawnSystem : IEcsInitSystem
    {
        
        private EcsWorld _world;
        private PrefabsConfig _prefabConfig;
        
        private TeamSpawnConfig _blueTeamSpawnConfig;
        private TeamSpawnConfig _redTeamSpawnConfig;
        
        private EcsPool<BlueTeam> _blueTeamPool;
        private EcsPool<RedTeam> _redTeamPool;
        private EcsPool<Archer> _archerTeamPool;
        private EcsPool<Mage> _mageTeamPool;
        private EcsPool<War> _warTeamPool;
        
        
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _prefabConfig = systems.GetShared<PrefabsConfig>();
            
            _blueTeamSpawnConfig = _prefabConfig.BlueTeamSpawnData;
            _redTeamSpawnConfig = _prefabConfig.RedTeamSpawnData;
            
            _blueTeamPool = _world.GetPool<BlueTeam>();
            _redTeamPool = _world.GetPool<RedTeam>();
            _archerTeamPool = _world.GetPool<Archer>();
            _mageTeamPool = _world.GetPool<Mage>();
            _warTeamPool = _world.GetPool<War>();
            
            SpawnUnit(_prefabConfig.ArcherBluePrefab, _blueTeamPool, _archerTeamPool, _blueTeamSpawnConfig);
            SpawnUnit(_prefabConfig.WarBluePrefab, _blueTeamPool, _warTeamPool, _blueTeamSpawnConfig);
            SpawnUnit(_prefabConfig.MageBluePrefab, _blueTeamPool, _mageTeamPool, _blueTeamSpawnConfig);
            
            SpawnUnit(_prefabConfig.ArcherRedPrefab, _redTeamPool, _archerTeamPool, _redTeamSpawnConfig);
            SpawnUnit(_prefabConfig.WarRedPrefab, _redTeamPool, _warTeamPool, _redTeamSpawnConfig);
            SpawnUnit(_prefabConfig.MageRedPrefab, _redTeamPool, _mageTeamPool, _redTeamSpawnConfig);
        }

        private void SpawnUnit<T1, T2>(Transform prefab, EcsPool<T1> teamComponent, EcsPool<T2> characterComponent, TeamSpawnConfig spawnConfig)
            where T1 : struct
            where T2 : struct
        {
            Vector3 position = new (Random.Range(spawnConfig.MinX, spawnConfig.MaxX), 
                Random.Range(spawnConfig.MinY, spawnConfig.MaxY), Random.Range(spawnConfig.MinZ, spawnConfig.MaxZ));
            
            GameObject character = Object.Instantiate(prefab.gameObject, position, Quaternion.identity);
            
            int entity = _world.NewEntity();

            teamComponent.Add(entity);
            characterComponent.Add(entity);
        }
        
    }
}