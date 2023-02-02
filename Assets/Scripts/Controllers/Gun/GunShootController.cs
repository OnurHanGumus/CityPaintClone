using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Signals;

public class GunShootController : MonoBehaviour
{
    #region Self Variables

    #region Public Variables

    #endregion

    #region Serialized Variables
    #endregion

    #region Private Variables

    #endregion

    #endregion

    private void Awake()
    {
    }
    private void Start()
    {
        StartCoroutine(Shoot());
    }
    private IEnumerator Shoot()
    {
        while (true)
        {
            GameObject bullet = PoolSignals.Instance.onGetObject?.Invoke(Enums.PoolEnums.Bullet);
            bullet.transform.position = transform.position;
            bullet.transform.eulerAngles = transform.eulerAngles;
            bullet.SetActive(true);
            yield return new WaitForSeconds(1f);
        }

    }
}
