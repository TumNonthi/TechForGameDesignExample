using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    public class LocationExit : MonoBehaviour
    {
        [SerializeField] private GameSceneSO[] _locationsToLoad;
        [SerializeField] private SceneLoaderAnchor _sceneLoaderAnchor;

        [SerializeField] private PathSO _exitPath;
        [SerializeField] PathTakenManagerAnchor _pathTakenManagerAnchor;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out PlayerCharacter pc))
            {
                // save path taken
                _pathTakenManagerAnchor.GetReference()?.SetPathTaken(_exitPath);

                // load new scene
                _sceneLoaderAnchor.GetReference()?.LoadLocation(_locationsToLoad, true);
            }
        }
    }
}
