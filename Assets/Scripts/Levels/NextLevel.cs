using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.SceneManagement.SceneManager;

namespace MP.Levels
{
    class NextLevel : MonoBehaviour
    {
        [SerializeField] LevelOrder _levels;
        [SerializeField] UnityEvent _callback;
        
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Next Level"))
            {
                SceneTransition.Main.Play(_levels.NextLevel(GetActiveScene().name));
                _callback.Invoke();
            }
        }
    }
}