using Data.ValueObject;
using Keys;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class TargetMovementController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        #endregion
        #region Private Variables
        private Rigidbody _rig;
        private TargetManager _manager;
        private TargetData _data;

        private bool _isNotStarted = true;
        private InputParams _lastInput;

        #endregion
        #endregion

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _rig = GetComponent<Rigidbody>();
            _manager = GetComponent<TargetManager>();
            _data = _manager.GetData();
        }


        private void FixedUpdate()
        {
            Move();
        }



        private void Move()
        {

            if (_isNotStarted)
            {
                return;
            }
            ClampControl();
            _rig.velocity = transform.TransformDirection(new Vector3(_lastInput.XValue, _lastInput.ZValue, 0) * _data.Speed);

        }

        public void OnInputDragged(InputParams input)
        {
            _lastInput = input;
        }
        private void ClampControl()
        {
            if ((_lastInput.XValue < 0 && _rig.position.x <= -_data.MaksHorizontalPoint) ||
                (_lastInput.XValue > 0 && _rig.position.x >= _data.MaksHorizontalPoint)) 
            {
                _lastInput.XValue = 0;
            }
            if ((_lastInput.ZValue < 0 && _rig.position.y <= _data.MinVerticalPoint) ||
                (_lastInput.ZValue > 0 && _rig.position.y >= _data.MaksVerticalPoint))
            {
                _lastInput.ZValue = 0;
            }


        }

        public void OnReleased()
        {
        }


        public void OnPlay()
        {
            _isNotStarted = false;


        }
        public void OnLevelFailed()
        {
            _rig.velocity = Vector3.zero;

        }
        public void OnLevelSuccess()
        {
            _rig.velocity = Vector3.zero;
        }
        public void OnRestartLevel()
        {
        }
    }
}