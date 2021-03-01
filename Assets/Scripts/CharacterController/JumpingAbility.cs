using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    public class JumpingAbility : MovementAbility
    {
        [Header("Profile")]
        [SerializeField] private JumpingProfileSO jumpingProfileSO;
    }
}
