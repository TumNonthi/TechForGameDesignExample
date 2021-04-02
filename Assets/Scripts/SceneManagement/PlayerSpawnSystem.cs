using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    public class PlayerSpawnSystem : MonoBehaviour
    {
        [Header("Asset References")]
        [SerializeField] private PlayerSpawnSystemAnchor _spawnSystemAnchor;
        [SerializeField] private PlayerCharacter _playerPrefab;
        [SerializeField] private PathTakenManagerAnchor _pathTakenManagerAnchor;

        [Header("Scene-specific References")]
        [SerializeField] private LocationEntrance _defaultSpawnPoint;

        private LocationEntrance[] _spawnPoints;

        private void OnEnable()
        {
            _spawnSystemAnchor.SetReference(this);
        }

        private void OnDisable()
        {
            _spawnSystemAnchor.RemoveReference(this);
        }

        [ContextMenu("Spawn player")]
        public void SpawnPlayer()
        {
            _spawnPoints = FindObjectsOfType<LocationEntrance>();
            LocationEntrance spawnPoint = _defaultSpawnPoint;
            PathSO pathTaken = _pathTakenManagerAnchor.GetReference().GetPathTaken();
            if (pathTaken != null)
            {
                foreach (LocationEntrance anEntrance in _spawnPoints)
                {
                    if (anEntrance.EntrancePath == pathTaken)
                    {
                        spawnPoint = anEntrance;
                    }
                }
            }

            Spawn(spawnPoint);
        }

        void Spawn(LocationEntrance spawnPoint)
        {
            PlayerCharacter pc = Instantiate(_playerPrefab, spawnPoint.transform.position, _playerPrefab.transform.rotation);

            spawnPoint.RunPlayerSpawnSequence(pc, HandleSpawnSequenceFinished);
        }

        void HandleSpawnSequenceFinished(PlayerCharacter pc)
        {
            // TODO: enable movement, UI, etc.
        }
    }
}
