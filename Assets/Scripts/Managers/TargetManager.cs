using System;
using System.Collections.Generic;
using Commands;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Signals;
using UnityEngine;

namespace Managers
{
    public class TargetManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serialized Variables

        #endregion

        #region Private Variables
        private TargetData _data;
        private TargetMovementController _movementController;
        private List<int> _playerUpgradeList;
        #endregion

        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _data = GetData();
            _movementController = GetComponent<TargetMovementController>();
        }
        public TargetData GetData() => Resources.Load<CD_Target>("Data/CD_Target").Data;

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onPlay += _movementController.OnPlay;
            CoreGameSignals.Instance.onLevelSuccessful += _movementController.OnLevelSuccess;
            CoreGameSignals.Instance.onLevelFailed += _movementController.OnLevelFailed;
            CoreGameSignals.Instance.onRestartLevel += _movementController.OnRestartLevel;
            CoreGameSignals.Instance.onRestartLevel += OnResetLevel;
            InputSignals.Instance.onInputDragged += _movementController.OnInputDragged;

        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onPlay -= _movementController.OnPlay;
            CoreGameSignals.Instance.onLevelSuccessful -= _movementController.OnLevelSuccess;
            CoreGameSignals.Instance.onLevelFailed -= _movementController.OnLevelFailed;
            CoreGameSignals.Instance.onRestartLevel -= _movementController.OnRestartLevel;
            CoreGameSignals.Instance.onRestartLevel -= OnResetLevel;
            InputSignals.Instance.onInputDragged -= _movementController.OnInputDragged;

        }


        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        private void OnPlay()
        {
        }

        private void OnInitializePlayerUpgrades(List<int> upgradeList)
        {
            _playerUpgradeList = upgradeList;
        }


        private void OnResetLevel()
        {

        }
    }
}