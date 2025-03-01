using Character.Models;
using UnityEngine;

namespace Character.Views
{
    [RequireComponent(typeof(SpriteRenderer), 
        typeof(Animator),
        typeof(Rigidbody2D))]
    public class CharacterView : MonoBehaviour, ICharacterView
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Animator _animator;
        [SerializeField] private Rigidbody2D _rigidbody2D;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public Animator Animator => _animator;
        public Rigidbody2D Rigidbody2D => _rigidbody2D;
    }
}