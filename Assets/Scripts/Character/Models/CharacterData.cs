using System;
using UnityEngine;

namespace Character.Models
{
    [Serializable]
    public class CharacterData : ICharacterData
    {
        [SerializeField]
        private float _moveSpeed;
        [SerializeField]
        private float _jumpForce;
        
        public float MoveSpeed => _moveSpeed;
        public float JumpForce => _jumpForce;
    }
}