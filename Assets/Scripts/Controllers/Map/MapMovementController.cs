using Data.ValueObject;
using Managers;
using UnityEngine;
using DG.Tweening;

namespace Controllers
{
    public class MapMovementController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        #endregion
        #region Private Variables
        private Rigidbody _rig;
        private TargetManager _manager;
        private TargetData _data;

        private bool _isNotStarted = true;

        #endregion
        #endregion

        private void Awake()
        {
            Init();
            Move();
        }

        private void Init()
        {
            //_rig = GetComponent<Rigidbody>();
            //_data = _manager.GetData();
            //_manager = GetComponent<PlayerManager>();
        }

        private void Move()
        {
            transform.DORotate(transform.eulerAngles + new Vector3(0,-180,0), 5f).OnComplete(() =>
            {
                Move();
            }).SetEase(Ease.Linear).SetSpeedBased();
        }

        public void OnPlay()
        {

        }
        public void OnLevelFailed()
        {

        }
        public void OnLevelSuccess()
        {

        }
        public void OnRestartLevel()
        {

        }
    }
}