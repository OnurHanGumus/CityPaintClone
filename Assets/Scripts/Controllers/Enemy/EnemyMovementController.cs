using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyMovementController : MonoBehaviour
{
    #region Self Variables

    #region Public Variables

    #endregion

    #region Serialized Variables
    #endregion

    #region Private Variables
    //private TargetData _data;
    private Vector3 _currentDirection;
    private Tween _moveTween;
    #endregion

    #endregion
    public void OnEnable()
    {
        ChangeRoute();
    }
    private void Move(Vector3 direction)
    {
        _moveTween.Kill();
        //_moveTween = transform.DOMove(transform.position + (direction * 10), 1f).SetSpeedBased();
        _moveTween = transform.DOPath(new Vector3[] { transform.position + (direction * 100)}, 1f).SetSpeedBased().SetLookAt(0.05f).SetEase(Ease.Linear);

    }
    public void ChangeRoute()
    {
        do
        {
            _currentDirection = new Vector3(Random.Range(-1f, 2f), 0, Random.Range(-1f, 2f));
        } while (_currentDirection == Vector3.zero);

        Move(_currentDirection);
    }
    public void OutOfMap()
    {
        _currentDirection *= -1;
        Move(_currentDirection);
    }

}
