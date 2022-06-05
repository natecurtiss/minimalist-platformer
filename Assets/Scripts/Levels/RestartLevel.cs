using UnityEngine;
using static UnityEngine.Input;
using static UnityEngine.KeyCode;
using static UnityEngine.SceneManagement.SceneManager;

namespace MP.Levels
{
    class RestartLevel : MonoBehaviour
    {
        void Update()
        {
            if (GetKeyDown(R))
                SceneTransition.Main.Play(GetActiveScene().name);
        }
    }
}
