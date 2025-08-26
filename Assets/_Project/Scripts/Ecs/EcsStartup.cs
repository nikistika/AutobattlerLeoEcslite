using _Project.Scripts;
using _Project.Scripts.Systems;
using Leopotam.EcsLite;
using UnityEngine;

namespace Client {
    sealed class EcsStartup : MonoBehaviour {
        EcsWorld _world;        
        IEcsSystems _systems;
        
        [SerializeField] private PrefabsConfig _prefabsConfig;
        
        void Start () {
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world, _prefabsConfig);
            _systems
                .Add (new SpawnSystem())
                
#if UNITY_EDITOR
                .Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem ())
#endif
                .Init ();
            
            Destroy(_prefabsConfig);
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
            }
            
            if (_world != null) {
                _world.Destroy ();
                _world = null;
            }
        }
    }
}