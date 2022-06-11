using UnityEngine;

namespace MP.Levels
{
    class Persist : MonoBehaviour
    {
        void Start() => DontDestroyOnLoad(gameObject);
    }
}
