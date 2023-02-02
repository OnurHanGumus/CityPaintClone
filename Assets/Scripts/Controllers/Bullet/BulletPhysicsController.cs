using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

public class BulletPhysicsController : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables
    //[SerializeField] private BulletManager manager;


    #endregion

    #region Private Variables
    #endregion
    #endregion
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            transform.gameObject.SetActive(false);
        }
    }


}
