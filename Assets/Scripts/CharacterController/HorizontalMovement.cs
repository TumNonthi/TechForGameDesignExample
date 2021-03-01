using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    public class HorizontalMovement : MovementAbility
    {
        public IMovementInputSource movementInputSource;

        [Header("Profile")]
        [SerializeField] private HorizontalMovementProfileSO movementProfileSO;

        [Header("References")]
        [SerializeField] private BaseCharacterAnimation characterAnimation;

        public bool IsWalking
        {
            get;
            private set;
        }

        private float _horizontalIntent = 0f;

        protected override void Start()
        {
            base.Start();

            // Do something more
        }

        // Update is called once per frame
        void Update()
        {
            RequestMovementInput();

            Walk(_horizontalIntent);
            IsWalking = Mathf.Abs(_horizontalIntent) > Mathf.Epsilon;

            if (_horizontalIntent > 0f)
            {
                characterAnimation.Flip(true);
            }
            else if (_horizontalIntent < 0f)
            {
                characterAnimation.Flip(false);
            }
        }

        /// <summary>
        /// Request an input value from the movement input source.
        /// </summary>
        void RequestMovementInput()
        {
            if (movementInputSource != null)
            {
                _horizontalIntent = movementInputSource.GetMovementInput().x;
            }
            else
            {
                _horizontalIntent = 0f;
            }
        }

        /// <summary>
        /// Move the character to the right if 'direction' is positive.
        /// Move the caharcter to the left if 'direction' is negative.
        /// Otherwise, stay still.
        /// </summary>
        /// <param name="direction">The direction of movement.</param>
        void Walk(float direction)
        {
            if (direction != 0f)
            {
                direction = Mathf.Sign(direction);
            }

            rb.velocity = new Vector2(direction * movementProfileSO.Speed, rb.velocity.y);
        }
    }
}
