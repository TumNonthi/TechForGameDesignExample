using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyPlatformer
{
    public class SceneLoader : MonoBehaviour
    {
        [Header("Asset Reference")]
        [SerializeField] private SceneLoaderAnchor _sceneLoaderAnchor;

        [Header("Persistent Manager Scenes")]
        [SerializeField] private List<PersistentManagersSO> _managerScenes = new List<PersistentManagersSO>();

        private List<AsyncOperation> _scenesToLoadAsyncOperations = new List<AsyncOperation>();
        private List<Scene> _scenesToUnload = new List<Scene>();
        private GameSceneSO _activeScene;
        private List<GameSceneSO> _persistentScenes = new List<GameSceneSO>();

        private void OnEnable()
        {
            _sceneLoaderAnchor.SetReference(this);
        }

        private void OnDisable()
        {
            _sceneLoaderAnchor.RemoveReference(this);
        }

        public void LoadLocation(GameSceneSO[] locationsToLoad, bool showLoadingScreen)
        {
            // Set persistent scenes
            _persistentScenes.Clear();
            _persistentScenes.AddRange(_managerScenes);

            // Set gameplay scenes to unload
            AddScenesToUnload();

            // Load new scenes
            LoadScenes(locationsToLoad, showLoadingScreen);
        }

        private void LoadScenes(GameSceneSO[] locationsToLoad, bool showLoadingScreen)
        {
            _activeScene = locationsToLoad[0];
            UnloadScenes();

            if (showLoadingScreen)
            {
                // TODO: toggle loading screen on
            }

            if (_scenesToLoadAsyncOperations.Count == 0)
            {
                foreach (GameSceneSO location in locationsToLoad)
                {
                    _scenesToLoadAsyncOperations.Add(SceneManager.LoadSceneAsync(location.scenePath, LoadSceneMode.Additive));
                }
            }

            StartCoroutine(WaitForLoading(showLoadingScreen));
        }

        private IEnumerator WaitForLoading(bool showLoadingScreen)
        {
            bool _loadingDone = false;

            while (!_loadingDone)
            {
                for (int i = 0; i < _scenesToLoadAsyncOperations.Count; i++)
                {
                    if (!_scenesToLoadAsyncOperations[i].isDone)
                    {
                        break;
                    }
                    else if (i == _scenesToLoadAsyncOperations.Count - 1)
                    {
                        _loadingDone = true;
                        _scenesToLoadAsyncOperations.Clear();
                        _persistentScenes.Clear();
                        break;
                    }
                }

                yield return null;
            }

            SetActiveScene();
            if (showLoadingScreen)
            {
                // TODO: toggle loading screen off
            }
        }

        private void SetActiveScene()
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByPath(_activeScene.scenePath));
            // TODO: spawn player
        }

        private void AddScenesToUnload()
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                string scenePath = scene.path;
                for (int j = 0; j < _persistentScenes.Count; j++)
                {
                    if (scenePath != _persistentScenes[j].scenePath)
                    {
                        if (j == _persistentScenes.Count - 1)
                        {
                            _scenesToUnload.Add(scene);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private void UnloadScenes()
        {
            if (_scenesToUnload != null)
            {
                foreach (Scene scene in _scenesToUnload)
                {
                    SceneManager.UnloadSceneAsync(scene);
                }
                _scenesToUnload.Clear();
            }
        }

        private bool IsSceneLoaded(string scenePath)
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                if (scene.path == scenePath)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
