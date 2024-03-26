using UnityEngine;

namespace AmayaTest.Data
{
    
    [CreateAssetMenu (fileName = "new LevelSettings", menuName = "Levels Settings", order = 11)]
    public sealed class LevelSettings : ScriptableObject
    {
        [SerializeField] 
        private Vector2Int[] _levelSizes;
        
        public Vector2Int[] LevelSizes => _levelSizes;

    }
}