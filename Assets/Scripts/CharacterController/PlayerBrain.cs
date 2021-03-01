using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatformer
{
    public class PlayerBrain : MonoBehaviour, IMovementInputSource
    {
        [SerializeField] HorizontalMovement _horizontalMovement;

        private PlayerControls _playerControls;

        private void Awake()
        {
            _playerControls = new PlayerControls();
        }

        private void OnEnable()
        {
            if (_horizontalMovement != null)
            {
                _horizontalMovement.movementInputSource = this;
            }

            _playerControls.Enable();
        }

        private void OnDisable()
        {
            if (_horizontalMovement != null)
            {
                if (_horizontalMovement.movementInputSource.Equals(this))
                {
                    _horizontalMovement.movementInputSource = null;
                }
            }

            _playerControls.Disable();
        }

        public Vector2 GetMovementInput()
        {
            return _playerControls.Player.Move.ReadValue<Vector2>();
        }
    }
}
