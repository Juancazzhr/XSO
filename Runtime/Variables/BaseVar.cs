using UnityEngine;
using UnityEngine.Events;

namespace Juancazzhr.Xso.Runtime.Variables
{
    /// <summary>
    /// Base class for variables with a value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseVar<T> : ScriptableObject
    {
        /// <summary>
        /// Create an instance of the variable. Creates an asset.
        /// </summary>
        /// <returns></returns>
        public static BaseVar<T> CreateInstance() => CreateInstance<BaseVar<T>>();

        /// <summary>
        /// The value of the variable.
        /// </summary>
        [Tooltip("The value of the variable.")]
        [SerializeField] protected T value;

        /// <summary>
        /// Event invoked when the value of the variable changes.
        /// </summary>
        [Tooltip("Event invoked when the value of the variable changes.")]
        [SerializeField] protected UnityEvent<T> onValueChanged = new();

        /// <summary>
        /// Get or set the value of the variable.
        /// </summary>
        public T Value
        {
            get => value;
            set
            {
                this.value = value;
                onValueChanged?.Invoke(value);
            }
        }

        /// <summary>
        /// Get the event invoked when the value of the variable changes.
        /// </summary>
        public event UnityAction<T> OnValueChanged
        {
            add => onValueChanged.AddListener(value);
            remove => onValueChanged.RemoveListener(value);
        }
    }
}