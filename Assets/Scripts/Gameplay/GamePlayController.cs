using System;
using System.Collections;
using AmayaTest.Data;
using AmayaTest.Grid;
using AmayaTest.UI;
using UnityEngine;

namespace AmayaTest
{
    public class GamePlayController : MonoBehaviour
    {
        [SerializeField] private float nextLevelDelay = 1f;
        [SerializeField] private float inputDelay = 0.5f;
        
        [SerializeField] 
        private GamePlayFactory _factory;

        [SerializeField] 
        private GridController _grid;
        
        [SerializeField] 
        private GoalBar _goalUI;
        
        [SerializeField] 
        private SceneController _restartUI;

        [SerializeField] 
        private InputManager _input;
        

        private int _currentLevel;
        
        private GamePlayData _gamePlanData;

        private void Awake()
        {
            ResetLevels();
            _grid.OnRightAnswer += GetRightAnswer;
        }

        public void ResetLevels()
        {
            _gamePlanData = _factory.GetGamePlan();
            _currentLevel = 0;
            MoveNextLevel();
            _goalUI.FadeFromOpaque();
            _restartUI.TurnOff();
            StartCoroutine(DelayedInputTurn());
        }

        /// <summary>
        /// переход к следующему этапу
        /// </summary>
        private void MoveNextLevel()
        {
            if (_currentLevel > _gamePlanData.NumberOfLevels - 1)
            {
                LevelsEnd();
                return;
            }

            StartCoroutine(DelayedInputTurn());
            _grid.SetLevel(_gamePlanData.LevelData[_currentLevel]);
            _goalUI.SetGoal(_gamePlanData.LevelData[_currentLevel].AnswerData.Identifier);
            _currentLevel++;
        }

        private void LevelsEnd()
        {
            _input.TurnOff();
            _restartUI.TurnOn();
        }

        private void OnDestroy()
        {
            _grid.OnRightAnswer -= GetRightAnswer;
        }

        private void GetRightAnswer()
        {
            StartCoroutine(DelayedNextLevel());
        }

        IEnumerator DelayedNextLevel()
        {
            _input.TurnOff();
            yield return new WaitForSeconds(nextLevelDelay);
            MoveNextLevel(); ;
        }
        
        IEnumerator DelayedInputTurn()
        {
            yield return new WaitForSeconds(inputDelay);
            _input.TurnOn();
        }
    }
}
