using UnityEngine;

namespace Character.Views
{
    public interface ICharacterView
    {
        SpriteRenderer SpriteRenderer { get; }
        Animator Animator { get; }
        Rigidbody2D Rigidbody2D { get; }
    }
}