using UnityEngine;

namespace AmayaTest.Data
{
    public sealed class GamePlayData 
    {
        public GamePlayData(LevelData[] stageData)
        {
            LevelData = stageData;
        }

        public LevelData[] LevelData { get; }
        
        public int NumberOfLevels => LevelData.Length;
    }
}