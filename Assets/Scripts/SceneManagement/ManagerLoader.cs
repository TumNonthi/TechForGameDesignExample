using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyPlatformer
{
    public class ManagerLoader : MonoBehaviour
    {
#if UNITY_EDITOR
        public PersistentManagersSO[] ManagerScenes;

        private void Awake()
        {
            LoadManagerScene();
        }

        void LoadManagerScene()
        {
            List<PersistentManagersSO> scenesToLoad = new List<PersistentManagersSO>();

            for (int i = 0; i < ManagerScenes.Length; i++)
            {
                PersistentManagersSO sceneSO = ManagerScenes[i];

                for (int j = 0; j < SceneManager.sceneCount; j++)
                {
                    Scene loadedScene = SceneManager.GetSceneAt(j);
                    if (loadedScene.path == sceneSO.scenePath)
                    {
                        break;
                    }
                    else if (j == SceneManager.sceneCount - 1)
                    {
                        scenesToLoad.Add(sceneSO);
                    }
                }
            }

            foreach (PersistentManagersSO sceneSO in scenesToLoad)
            {
                SceneManager.LoadScene(sceneSO.scenePath, LoadSceneMode.Additive);
            }
        }
#endif
    }
}
