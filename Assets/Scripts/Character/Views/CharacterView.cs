using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Utilities.Bindings;

namespace Character.Views
{
    [RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
    public class CharacterView : MonoBehaviour, ICharacterView
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private IntBinding _moveBinding;
        
        private Vector2 _direction;
        
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        public Transform Transform => transform;
        
        public event Action OnJumpButtonDown;
        
        public bool IsSpriteFlipped
        {
            get => _spriteRenderer.flipX;
            set => _spriteRenderer.flipX = value;
        }

        public Vector2 Direction => _direction;
        public void JumpButtonDown()
        {
            OnJumpButtonDown?.Invoke();
        }

        public int MoveState
        {
            set => _moveBinding.Value = value;
        }
        
        public void SetDirection(InputAction.CallbackContext context)
        {
            _direction = context.ReadValue<Vector2>();
        }
    }
}