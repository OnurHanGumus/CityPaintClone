using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Signals;
using Data.ValueObject;
using Data.UnityObject;
using System.Threading.Tasks;

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
    private float _fireRateValue = 1f;
    private StoreData _storeData;
    private int _bulletCountLevel, _fireRateLevel;
    private bool _isStarted = false;

    #endregion

    #endregion
    private StoreData GetData() => Resources.Load<CD_Store>("Data/CD_Store").Data;

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        _storeData = GetData();
    }
    private void Start()
    {

    }
    //private IEnumerator Shoot()
    //{
    //    while (true)
    //    {
    //        if (_bulletCount <= 0)
    //        {
    //            yield return new WaitForSeconds(2f);
    //            GunSignals.Instance.onReload?.Invoke(_maksBulletCount);

    //            Reload();
    //            AudioSignals.Instance.onPlaySound?.Invoke(Enums.AudioSoundEnums.Reload);


    //        }
    //        Fire();
    //        AudioSignals.Instance.onPlaySound?.Invoke(Enums.AudioSoundEnums.Fire);
    //        --_bulletCount;
    //        GunSignals.Instance.onFired?.Invoke(_bulletCount);
    //        yield return new WaitForSeconds(_fireRateValue);
    //    }

    //}

    private async Task Shoot()
    {
        while (_isStarted)
        {
            if (_bulletCount <= 0)
            {
                await Task.Delay(2000);
                GunSignals.Instance.onReload?.Invoke(_maksBulletCount);

                Reload();
                AudioSignals.Instance.onPlaySound?.Invoke(Enums.AudioSoundEnums.Reload);
            }
            Fire();
            AudioSignals.Instance.onPlaySound?.Invoke(Enums.AudioSoundEnums.Fire);
            --_bulletCount;
            GunSignals.Instance.onFired?.Invoke(_bulletCount);
            await Task.Delay((int)(_fireRateValue * 1000));
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
        _isStarted = true;
        Shoot();
    }
    public void OnGetStoreLevels(List<int> levels)
    {
        if (levels.Count.Equals(0))
        {
            levels = new List<int>() { 0, 0, 0, 0 };
        }

        _fireRateLevel = levels[2] + 1;
        _bulletCountLevel = levels[3] + 1;

        ValueUpdateAccordingToSave();
    }
    private void ValueUpdateAccordingToSave()
    {
        _maksBulletCount = _bulletCountLevel * _storeData.AmmoCapacityIncreaseValue;
        _fireRateValue = 1 - (_fireRateLevel * _storeData.FireRateDecreaseValue);

        _bulletCount = _maksBulletCount;
    }

    public void OnRestartLevel()
    {
        _isStarted = false;
        StopAllCoroutines();
    }
}
