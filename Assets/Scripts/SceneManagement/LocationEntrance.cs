using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    public class LocationEntrance : MonoBehaviour
    {
        [SerializeField] private PathSO _entrancePath;

        public PathSO EntrancePath => _entrancePath;
        /*
        public PathSO EntrancePath
        {
            get
            {
                return _entrancePath;
            }
        }
        */

        public virtual void RunPlayerSpawnSequence(PlayerCharacter playerCharacter, System.Action<PlayerCharacter> callback)
        {
            // spawn character
            playerCharacter.transform.position = transform.position;

            // tell the caller that the player has completed the spawn sequences.
            callback.Invoke(playerCharacter);
        }
    }
}
