using _Project.Scripts.Ecs.Components.Characters;
using _Project.Scripts.Ecs.Components.Teams;
using _Project.Scripts.ScriptableObjects;
using _Project.Scripts.ScriptableObjects.Characters;
using Leopotam.EcsLite;
using UnityEngine;

namespace _Project.Scripts.Ecs.Systems
{
    internal class InitializationSystem : IEcsInitSystem
    {
        
        private EcsWorld _world;
        private PrefabsConfig _prefabConfig;
        
        private TeamSpawnConfig _blueTeamSpawnConfig;
        private TeamSpawnConfig _redTeamSpawnConfig;

        private ArcherConfig _archerData;
        private MageConfig _mageData;
        private WarConfig _warData;
        
        private EcsPool<BlueTeam> _blueTeamPool;
        private EcsPool<RedTeam> _redTeamPool;
        private EcsPool<Archer> _archerTeamPool;
        private EcsPool<Mage> _mageTeamPool;
        private EcsPool<War> _warTeamPool;
        private EcsPool<Character> _characterPool;

        private Transform _blueTeamObject;
        private Transform _redTeamObject;
            
        public void Init(IEcsSystems systems)
        {
            _world = systems.GetWorld();
            _prefabConfig = systems.GetShared<PrefabsConfig>();
            
            _blueTeamSpawnConfig = _prefabConfig.BlueTeamSpawnData;
            _redTeamSpawnConfig = _prefabConfig.RedTeamSpawnData;

            _blueTeamObject = _prefabConfig.BlueTeamObject;
            _redTeamObject = _prefabConfig.RedTeamObject;
                
            _blueTeamPool = _world.GetPool<BlueTeam>();
            _redTeamPool = _world.GetPool<RedTeam>();
            _archerTeamPool = _world.GetPool<Archer>();
            _mageTeamPool = _world.GetPool<Mage>();
            _warTeamPool = _world.GetPool<War>();

            _characterPool = _world.GetPool<Character>();
            
            _archerData = _prefabConfig.ArcherData;
            _mageData = _prefabConfig.MageData;
            _warData = _prefabConfig.WarData;

            
            SpawnUnit(_prefabConfig.ArcherBluePrefab, _blueTeamPool, _archerTeamPool, _blueTeamSpawnConfig, 
                _blueTeamObject, _archerData);
            SpawnUnit(_prefabConfig.WarBluePrefab, _blueTeamPool, _warTeamPool, _blueTeamSpawnConfig,
                _blueTeamObject, _warData);
            SpawnUnit(_prefabConfig.MageBluePrefab, _blueTeamPool, _mageTeamPool, _blueTeamSpawnConfig,
                _blueTeamObject, _mageData);
            
            SpawnUnit(_prefabConfig.ArcherRedPrefab, _redTeamPool, _archerTeamPool, _redTeamSpawnConfig,
                _redTeamObject, _archerData);
            SpawnUnit(_prefabConfig.WarRedPrefab, _redTeamPool, _warTeamPool, _redTeamSpawnConfig,
                _redTeamObject, _warData);
            SpawnUnit(_prefabConfig.MageRedPrefab, _redTeamPool, _mageTeamPool, _redTeamSpawnConfig,
                _redTeamObject, _mageData);
        }

        private void SpawnUnit<T1, T2, T3>(Transform prefab, EcsPool<T1> teamComponent, EcsPool<T2> characterComponent, 
            TeamSpawnConfig spawnConfig, Transform parentTeamObject, T3 data)
            where T1 : struct
            where T2 : struct
            where T3 : CharacterConfig
        {
            Vector3 position = new (Random.Range(spawnConfig.MinX, spawnConfig.MaxX), 
                Random.Range(spawnConfig.MinY, spawnConfig.MaxY), Random.Range(spawnConfig.MinZ, spawnConfig.MaxZ));
            
            GameObject character = Object.Instantiate(prefab.gameObject, position, Quaternion.identity);
            character.transform.SetParent(parentTeamObject);
            
            int entity = _world.NewEntity();

            teamComponent.Add(entity);
            characterComponent.Add(entity);
            _characterPool.Add(entity);

            ref var characterData = ref _characterPool.Get(entity);

            characterData.Heath = data.Heath;
            characterData.DamageMin = data.DamageMin;
            characterData.DamageMax = data.DamageMax;
            characterData.CooldownAttackMin = data.CooldownAttackMin;
            characterData.CooldownAttackMax = data.CooldownAttackMax;
        }
        
    }
}