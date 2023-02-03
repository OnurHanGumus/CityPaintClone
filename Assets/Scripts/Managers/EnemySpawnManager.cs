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

        private IEnumerator Spawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                Vector2 rand = Random.insideUnitCircle * 3.5f;
                Vector3 position = new Vector3(rand.x, -2.9f, rand.y);
                Vector3 mapOffset = new Vector3(0, 0, 2.63f);
                PoolSignals.Instance.onGetObjectOnPosition?.Invoke(PoolEnums.Enemy, position + mapOffset);

            }

        }
        private void OnPlay()
        {
            StartCoroutine(Spawn());
        }
        private void OnResetLevel()
        {
            StopAllCoroutines();
        }
    }
}