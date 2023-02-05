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
    private int _bulletCount = 9;
    private int _maksBulletCount = 9;
    #endregion

    #endregion

    private void Awake()
    {
    }
    private void Start()
    {

    }
    private IEnumerator Shoot()
    {
        while (true)
        {
            if (_bulletCount <= 0)
            {
                yield return new WaitForSeconds(2f);
                GunSignals.Instance.onReload?.Invoke(_maksBulletCount);

                Reload();

            }
            Fire();
            --_bulletCount;
            GunSignals.Instance.onFired?.Invoke(_bulletCount);
            yield return new WaitForSeconds(1f);
        }

    }

    private void Fire()
    {
        GameObject bullet = PoolSignals.Instance.onGetObject?.Invoke(Enums.PoolEnums.Bullet);
        bullet.transform.position = transform.position;
        bullet.transform.eulerAngles = transform.eulerAngles;
        bullet.SetActive(true);
    }

    private void Reload()
    {
        _bulletCount = _maksBulletCount;
    }

    public void OnPlay()
    {
        StartCoroutine(Shoot());

    }
    

    public void OnRestartLevel()
    {
        StopAllCoroutines();
    }
}
