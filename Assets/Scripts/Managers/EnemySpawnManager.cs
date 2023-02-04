using System;
using System.Collections;
using System.Collections.Generic;
using Commands;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Signals;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class EnemySpawnManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        #endregion

        #region Serialized Variables

        #endregion

        #region Private Variables
        private LevelData _data;
        private int _levelId = 0;
        private int _maksEnemyCount = 5;
        private int _currentEnemyCount = 0;
        #endregion

        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _data = GetData();
        }
        public LevelData GetData() => Resources.Load<CD_Level>("Data/CD_Level").Data;

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onRestartLevel += OnResetLevel;

            EnemySignals.Instance.onEnemyShooted += OnEnemyShooted;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onRestartLevel -= OnResetLevel;

            EnemySignals.Instance.onEnemyShooted -= OnEnemyShooted;
        }


        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private IEnumerator Spawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                if (_currentEnemyCount < _maksEnemyCount)
                {
                    Vector2 rand = Random.insideUnitCircle * 3.5f;
                    Vector3 position = new Vector3(rand.x, -2.9f, rand.y);
                    Vector3 mapOffset = new Vector3(0, 0, 2.63f);
                    PoolSignals.Instance.onGetObjectOnPosition?.Invoke(PoolEnums.Enemy, position + mapOffset);
                    ++_currentEnemyCount;
                }
            }
        }
        private void OnPlay()
        {
            _levelId = LevelSignals.Instance.onGetLevelId();
            StartCoroutine(Spawn());
        }

        private void OnEnemyShooted()
        {
            --_currentEnemyCount;
        }
        private void OnResetLevel()
        {
            StopAllCoroutines();
        }
    }
}