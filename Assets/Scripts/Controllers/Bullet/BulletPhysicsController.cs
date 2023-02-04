using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;
using Signals;

public class BulletPhysicsController : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables
    //[SerializeField] private BulletManager manager;


    #endregion

    #region Private Variables
    #endregion
    #endregion
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            transform.gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            transform.gameObject.SetActive(false);
        }
    }


}
