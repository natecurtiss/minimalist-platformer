using UnityEngine;
using UnityEngine.Events;

namespace MP.Levels
{
    class SceneChanged : MonoBehaviour
    {
        [SerializeField] UnityEvent _callback;

        void Awake() => SceneTransition.OnStart += _callback.Invoke;
        void OnDestroy() => SceneTransition.OnStart -= _callback.Invoke;
    }
}