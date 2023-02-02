using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPhysicsController : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables



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
