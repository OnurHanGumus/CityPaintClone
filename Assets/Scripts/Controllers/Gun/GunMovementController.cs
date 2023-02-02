using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovementController : MonoBehaviour
{
    #region Self Variables

    #region Public Variables

    #endregion

    #region Serialized Variables
    [SerializeField] private Transform target;
    #endregion

    #region Private Variables

    #endregion

    #endregion

    private void Update()
    {
        transform.LookAt(target);
    }
}
