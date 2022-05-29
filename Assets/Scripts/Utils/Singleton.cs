using UnityEngine;
using static System.Char;
using static System.String;
using static System.Text.RegularExpressions.Regex;

namespace MP.Utils
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        static T _instance;
        protected static T Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new GameObject(Name()).AddComponent<T>();
                    DontDestroyOnLoad(_instance);
                }
                return _instance;
            }
        }

        static string Name() => Replace
        (
            typeof(T).FullName ?? Empty, 
            "[a-z][A-Z]", 
            m => $"{m.Value[0]} {ToLower(m.Value[1])}"
        );
    }
}