using System;

namespace Utilities.Bindings
{
    [Serializable]
    public class IntBinding : ValueBinding<int>
    {
        public override int Value
        {
            get => _value;
            set
            {
                _value = value;
                if (_animator && !string.IsNullOrEmpty(_parameter))
                {
                    _animator.SetInteger(_parameter, _value);
                }
            }
        }
    }
}