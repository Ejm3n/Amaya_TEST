using System;
using System.Collections.Generic;
using System.Linq;
using AmayaTest.Data;
using UnityEngine;
using Random = UnityEngine.Random;



namespace AmayaTest
{
    [Serializable]
    public class GamePlayFactory
    {
        [SerializeField] private List<CardDataBundle> cardDataBundles;

        [SerializeField] private LevelSettings _settings;
        
        private List<CardData> _answeredCards;

        private bool _isInited = false;

        private void Init()
        {
            _answeredCards = new List<CardData>();
            _isInited = true;
        }

        public GamePlayData GetGamePlan()
        {
            if (!_isInited)
                Init();

            var dataBundle = GetRandomCardDataBundle();

            var levelData = new LevelData[_settings.LevelSizes.Length];

            var possibleAnswers = dataBundle.CardData.Except(_answeredCards).ToList();

            for (var levelIndex = 0; levelIndex < _settings.LevelSizes.Length; levelIndex++)
            {
                var answer = possibleAnswers[Random.Range(0, possibleAnswers.Count)];
                possibleAnswers.Remove(answer);
                _answeredCards.Add(answer);

                //Cетка без ответа
                var gridData = GetRandomGridData(answer, _settings.LevelSizes[levelIndex], dataBundle);

                //Добавляем 1 ответ в рандомное место
                var xRandom = Random.Range(0, _settings.LevelSizes[levelIndex].x);
                var yRandom = Random.Range(0, _settings.LevelSizes[levelIndex].y);
                gridData[xRandom, yRandom] = answer;

                levelData[levelIndex] = new LevelData(gridData, new Vector2Int(xRandom, yRandom));
            }

            return new GamePlayData(levelData);
        }

        private CardDataBundle GetRandomCardDataBundle()
        {
            if (cardDataBundles.Count <= 0)
                throw new Exception("No Data Bundles for cards found. Maybe you answered a lot of them");

            var randomBundle = cardDataBundles[Random.Range(0, cardDataBundles.Count)];

            if (randomBundle.CardData.Except(_answeredCards).Count() < _settings.LevelSizes.Length)
            {
                cardDataBundles.Remove(randomBundle);
                return GetRandomCardDataBundle();
            }

            return randomBundle;
        }

        private CardData[,] GetRandomGridData(CardData exceptedElement, Vector2Int gridSize,
            CardDataBundle dataBundle)
        {
            var unusedIndex = Array.IndexOf(dataBundle.CardData, exceptedElement);

            var returnedValue = new CardData[gridSize.x, gridSize.y];

            for (var i = 0; i < gridSize.x; i++)
            for (var j = 0; j < gridSize.y; j++)
            {
                var randomIndex = Random.Range(0, dataBundle.CardData.Length - 1);
                if (randomIndex >= unusedIndex)
                {
                    randomIndex++;
                }

                returnedValue[i, j] = dataBundle.CardData[randomIndex];
            }

            return returnedValue;
        }
    }
}