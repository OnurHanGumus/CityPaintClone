using System;
using System.Collections.Generic;
using Commands;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Signals;
using UnityEngine;
using PaintIn3D;



namespace Managers
{
    public class MapManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serialized Variables
        [SerializeField] private P3dChannelCounter channelCounter;

        #endregion

        #region Private Variables
        
        #endregion

        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            
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
            CoreGameSignals.Instance.onRestartLevel += OnResetLevel;


            channelCounter.OnUpdated += OnSliderValueUpdated;

        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onRestartLevel -= OnResetLevel;


            channelCounter.OnUpdated -= OnSliderValueUpdated;
        }


        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        private void OnPlay()
        {
        }

        private void OnEnemyShooted()
        {
            //EnemySignals.Instance.onChannelColorIncreased?.Invoke(channelCounter.CountA);
        }
        private void OnBulletHitGround()
        {
            //EnemySignals.Instance.onChannelColorIncreased?.Invoke(channelCounter.CountA);
        }

        private void OnSliderValueUpdated()
        {
            UISignals.Instance.onChannelColorIncreased?.Invoke(channelCounter.CountA);
        }
        private void OnResetLevel()
        {

        }
    }
}