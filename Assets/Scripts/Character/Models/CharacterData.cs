using System;
using UnityEngine;

namespace Character.Models
{
    [Serializable]
    public class CharacterData : ICharacterData
    {
        [SerializeField] private string styleName;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce;
        
        public string StyleName => styleName;
        public float MoveSpeed => moveSpeed;
        public float JumpForce => jumpForce;

        public CharacterData(string styleName, float moveSpeed, float jumpForce)
        {
            this.styleName = styleName;
            this.moveSpeed = moveSpeed;
            this.jumpForce = jumpForce;
        }
    }
}