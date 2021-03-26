using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    public class LocationExit : MonoBehaviour
    {
        [SerializeField] private GameSceneSO[] _locationsToLoad;
        [SerializeField] private SceneLoaderAnchor _sceneLoaderAnchor;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out PlayerCharacter pc))
            {
                _sceneLoaderAnchor.GetReference()?.LoadLocation(_locationsToLoad, true);
            }
        }
    }
}
