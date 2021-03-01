using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    [CreateAssetMenu(menuName = "Movement/Jumping Profile")]
    public class JumpingProfileSO : ScriptableObject
    {
        [SerializeField] private float _jumpForce;
        public float JumpForce
        {
            get
            {
                return _jumpForce;
            }
        }
    }
}
