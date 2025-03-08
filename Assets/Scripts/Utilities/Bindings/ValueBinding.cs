using System;
using UnityEngine;
using UnityEngine.Events;

namespace Utilities.Bindings
{
    [Serializable]
    public abstract class ValueBinding<T> : UnityEvent<T>
    {
        [SerializeField] protected Animator _animator;
        [SerializeField] protected string _parameter;

        protected T _value;
        
        public abstract T Value { get; set; }
    }
}