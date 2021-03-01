using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    public class CharacterCollision : MonoBehaviour
    {
        [SerializeField] private LayerMask groundLayers;
        [SerializeField] private float groundCheckRadius;
        [SerializeField] private Vector2 bottomOffset;

        private Collider2D[] _groundColliders;

        public bool IsOverlappingGround
        {
            get;
            private set;
        }

        private void Update()
        {
            IsOverlappingGround = false;
            _groundColliders = Physics2D.OverlapCircleAll((Vector2)transform.position + bottomOffset, groundCheckRadius, groundLayers);

            if (_groundColliders.Length > 0)
            {
                IsOverlappingGround = true;
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, groundCheckRadius);
        }
    }
}
