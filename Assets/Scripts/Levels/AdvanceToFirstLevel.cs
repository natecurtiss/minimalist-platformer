using System.Collections;
using UnityEngine;
using static UnityEngine.Input;

namespace MP.Levels
{
    class AdvanceToFirstLevel : MonoBehaviour
    {
        [SerializeField] LevelOrder _levels;
        
        IEnumerator Start()
        {
            yield return new WaitUntil(() => GetKeyDown(KeyCode.Space));
            SceneTransition.Main.Play(_levels.Level1);
        }
    }
}