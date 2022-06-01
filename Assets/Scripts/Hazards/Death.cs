using MP.Levels;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.SceneManagement.SceneManager;

namespace MP.Hazards
{
    class Death : MonoBehaviour
    {
        [SerializeField] UnityEvent _callback;
        [SerializeField] float _abyss = -20f;
        bool _isDead;

        void Update()
        {
            if (!_isDead && transform.position.y <= _abyss)
                Die();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Hazard") && !_isDead) 
                Die();
        }

        void Die()
        {
            _isDead = true;
            _callback.Invoke();
            SceneTransition.Main.Play(GetActiveScene().name);
        }
    }
}
