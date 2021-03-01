using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    public class MovementAbility : MonoBehaviour
    {
        protected Rigidbody2D rb;

        // Start is called before the first frame update
        protected virtual void Start()
        {
            TryGetComponent(out rb);
        }
    }
}
