using System;
using System.Collections.Generic;
using Commands;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Extentions;
using Keys;
using Signals;
using UnityEngine;
using Enums;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables


        #endregion

        #region Serialized Variables


        #endregion

        #region Private Variables
        private ScoreData _data;

        private int _money;

        public int Money
        {
            get { return _money; }
            set { _money = value; }
        }



        #endregion

        #endregion

        private void Awake()
        {
            Init();
        }
        private void Init()
        {

        }
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            ScoreSignals.Instance.onScoreIncrease += OnScoreIncrease;
            ScoreSignals.Instance.onScoreDecrease += OnScoreDecrease;
            ScoreSignals.Instance.onGetScore += OnGetScore;
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onRestartLevel += OnRestartLevel;
        }

        private void UnsubscribeEvents()
        {
            ScoreSignals.Instance.onScoreIncrease -= OnScoreIncrease;
            ScoreSignals.Instance.onScoreDecrease -= OnScoreDecrease;
            ScoreSignals.Instance.onGetScore -= OnGetScore;
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onRestartLevel -= OnRestartLevel;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnPlay()
        {
            Money = SaveSignals.Instance.onGetScore(SaveLoadStates.Money, SaveFiles.SaveFile);
        }
        private void OnScoreIncrease(ScoreTypeEnums type, int amount)
        {
            Money += amount;
            UISignals.Instance.onMoneyIncreased?.Invoke(Money);
        }

        private void OnScoreDecrease(ScoreTypeEnums type, int amount)
        {

        }


        private int OnGetScore()
        {
            return Money;
        }

        private void OnRestartLevel()
        {
        }
    }
}