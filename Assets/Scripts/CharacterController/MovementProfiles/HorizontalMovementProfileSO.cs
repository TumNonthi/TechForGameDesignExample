using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    [CreateAssetMenu(menuName = "Movement/Horizontal Movement Profile")]
    public class HorizontalMovementProfileSO : ScriptableObject
    {
        [SerializeField] private float _speed;
        public float Speed
        {
            get
            {
                return _speed;
            }
        }
    }
}
