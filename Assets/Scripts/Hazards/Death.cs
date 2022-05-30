using MP.Levels;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.SceneManagement.SceneManager;

namespace MP.Hazards
{
    class Death : MonoBehaviour
    {
        [SerializeField] UnityEvent _callback;
        bool _isDead;
        
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Hazard") && !_isDead)
            {
                _isDead = true;
                _callback.Invoke();
                SceneTransition.Main.Play(GetActiveScene().name);
            }
        }
    }
}
