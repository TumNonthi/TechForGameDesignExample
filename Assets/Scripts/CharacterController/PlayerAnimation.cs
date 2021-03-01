using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    public class PlayerAnimation : BaseCharacterAnimation
    {
        [SerializeField] HorizontalMovement _horizontalMovement;

        [SerializeField] string idleName = "PlayerIdle";
        [SerializeField] string walkName = "PlayerWalk";

        protected override void UpdateAnimations(float dt)
        {
            if (_horizontalMovement.IsWalking)
            {
                PlayAnimIfNotAlreadyPlaying(walkName);
            }
            else
            {
                PlayAnimIfNotAlreadyPlaying(idleName);
            }
        }
    }
}
