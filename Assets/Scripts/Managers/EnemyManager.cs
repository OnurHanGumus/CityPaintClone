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
    public class EnemyManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serialized Variables
        [SerializeField] private EnemyMeshController meshController;
        #endregion

        #region Private Variables
        //private TargetData _data;
        private EnemyMovementController _movementController;
        #endregion

        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            //_data = GetData();
            _movementController = GetComponent<EnemyMovementController>();
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
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onRestartLevel -= OnResetLevel;
        }


        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        public Color GetMeshRenderer()
        {
            return meshController.GetMeshRendererColor();
        }
        public void OutOfMap()
        {
            _movementController.OutOfMap();
        }

        private void OnPlay()
        {

        }
        private void OnResetLevel()
        {

        }
    }
}