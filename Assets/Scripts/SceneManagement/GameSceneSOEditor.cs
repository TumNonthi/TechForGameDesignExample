#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MyPlatformer
{
    public abstract partial class GameSceneSO : ScriptableObject, ISerializationCallbackReceiver
    {
        private SceneAsset prevSceneAsset;

        public void OnAfterDeserialize()
        {
        }

        public void OnBeforeSerialize()
        {
            PopulateScenePath();
        }

        private void OnEnable()
        {
            prevSceneAsset = null;
            PopulateScenePath();
        }

        void PopulateScenePath()
        {
            if (sceneAsset != null)
            {
                if (prevSceneAsset != sceneAsset)
                {
                    prevSceneAsset = sceneAsset;
                    scenePath = AssetDatabase.GetAssetPath(sceneAsset);
                }
            }
            else
            {
                scenePath = string.Empty;
            }
        }
    }
}

#endif
