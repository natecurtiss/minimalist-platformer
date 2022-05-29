using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MP.Levels
{
    [CreateAssetMenu(fileName = "Levels", menuName = "Level Order Asset", order = 0)]
    class LevelOrder : ScriptableObject, ISerializationCallbackReceiver 
    {
#if UNITY_EDITOR
        [SerializeField] SceneAsset _menu;
        [SerializeField] List<SceneAsset> _levels;
#endif
        readonly List<string> _levelNames = new();

        public string Menu { get; private set; }
        public string Level1 => _levelNames[0];

        public void OnBeforeSerialize()
        {
            if (_levels.Count > 0)
                _levels.ForEach(s => _levelNames.Add(s.name));
            if (_menu != null)
                Menu = _menu.name;
        }

        public void OnAfterDeserialize() { }

        public string NextLevel(string level) => _levelNames.Find(l => l == level);
    }
}