using UnityEngine;

namespace AmayaTest.Data
{
    
    public sealed class LevelData
    {
        public LevelData(CardData[,] gridData, Vector2Int answerIndex)
        {
            GridData = gridData;
            AnswerIndex = answerIndex;
        }

        public CardData[,] GridData { get; }
        public Vector2Int AnswerIndex { get; }

        public CardData AnswerData => GridData[AnswerIndex.x, AnswerIndex.y];
    }
}