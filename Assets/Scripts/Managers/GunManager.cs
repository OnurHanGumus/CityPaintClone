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
    public class GunManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serialized Variables
        [SerializeField] private GunShootController shootController;
        #endregion

        #region Private Variables
        private TargetData _data;
        #endregion

        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            //_data = GetData();
        }
        public TargetData GetData() => Resources.Load<CD_Target>("Data/CD_Player").Data;

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onPlay += shootController.OnPlay;
            CoreGameSignals.Instance.onRestartLevel += OnRestartLevel;
            CoreGameSignals.Instance.onRestartLevel += shootController.OnRestartLevel;
            SaveSignals.Instance.onInitializePlayerUpgrades += shootController.OnGetItemLevels;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onPlay -= shootController.OnPlay;
            CoreGameSignals.Instance.onRestartLevel -= OnRestartLevel;
            CoreGameSignals.Instance.onRestartLevel -= shootController.OnRestartLevel;
            SaveSignals.Instance.onInitializePlayerUpgrades -= shootController.OnGetItemLevels;
        }


        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        private void OnPlay()
        {

        }
        private void OnRestartLevel()
        {

        }
    }
}