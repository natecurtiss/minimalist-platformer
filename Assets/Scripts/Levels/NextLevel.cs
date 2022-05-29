using UnityEngine;
using static UnityEngine.SceneManagement.SceneManager;

namespace MP.Levels
{
    class NextLevel : MonoBehaviour
    {
        [SerializeField] LevelOrder _levels;
        
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Next Level"))
            {
                Debug.Log(GetActiveScene().name);
                Debug.Log(_levels.NextLevel(GetActiveScene().name));
                SceneTransition.Main.Play(_levels.NextLevel(GetActiveScene().name));
            }
        }
    }
}