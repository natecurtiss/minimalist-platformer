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
        [SerializeField, HideInInspector] 
        List<string> _levelNames = new();

        public string Menu { get; private set; }
        public string Level1 => _levelNames[0];
        
        public void OnBeforeSerialize()
        {
#if UNITY_EDITOR
            _levels.ForEach(s =>
            {
                if (s != null)
                    _levelNames.Add(s.name);
            });
            if (_menu != null)
                Menu = _menu.name;
#endif
        }

        public void OnAfterDeserialize() { }

        public string NextLevel(string level)
        {
            var next = _levelNames.IndexOf(level) + 1;
            return next > _levelNames.Count - 1 ? level : _levelNames[next];
        }
    }
}