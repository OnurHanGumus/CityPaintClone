using System.Collections.Generic;
using DG.Tweening;
using Enums;
using Managers;
using UnityEngine;
using Data.UnityObject;
using Data.ValueObject;
using System;

namespace Controllers
{
    public class BulletMovementController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables



        #endregion

        #region Private Variables
        private Rigidbody _rig;
        //private BulletData _data;
        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }
        private void Init()
        {
            _rig = GetComponent<Rigidbody>();
            //_data = GetData();
        }

        //private BulletData GetData() => Resources.Load<CD_Bullet>("Data/CD_Bullet").Data;

        private void OnEnable()
        {
            _rig.AddRelativeForce(Vector3.forward * 35, ForceMode.Impulse);
        }
        private void OnDisable()
        {
            _rig.velocity = Vector3.zero;
        }

    }
}