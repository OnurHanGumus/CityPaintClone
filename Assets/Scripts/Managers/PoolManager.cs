using Enums;
using Signals;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject particlePrefabR, particlePrefabG, particlePrefabB, particlePrefabP, particlePrefabY;

    [SerializeField] private Dictionary<PoolEnums, List<GameObject>> poolDictionary;
    [SerializeField] private Dictionary<PoolEnums, List<GameObject>> particleDirectory;


    [SerializeField] private int amountBullets = 50;
    [SerializeField] private int amountEnemies = 8;
    [SerializeField] private int amountParticle = 3;



    #endregion
    #region Private Variables
    private int _levelId = 0;
    #endregion
    #endregion
    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        _levelId = LevelSignals.Instance.onGetCurrentModdedLevel();
        poolDictionary = new Dictionary<PoolEnums, List<GameObject>>();
        InitializePool(PoolEnums.Bullet, bulletPrefab, amountEnemies);
        InitializePool(PoolEnums.Enemy, enemyPrefab, amountBullets);
        InitializePool(PoolEnums.ParticleR, particlePrefabR, amountParticle);
        InitializePool(PoolEnums.ParticleG, particlePrefabG, amountParticle);
        InitializePool(PoolEnums.ParticleB, particlePrefabB, amountParticle);
        InitializePool(PoolEnums.ParticleP, particlePrefabP, amountParticle);
        InitializePool(PoolEnums.ParticleY, particlePrefabY, amountParticle);
    }



    #region Event Subscriptions

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        PoolSignals.Instance.onGetPoolManagerObj += OnGetPoolManagerObj;
        PoolSignals.Instance.onGetObject += OnGetObject;
        PoolSignals.Instance.onGetObjectOnPosition += OnGetObjectOnPosition;
        CoreGameSignals.Instance.onRestartLevel += OnReset;

    }

    private void UnsubscribeEvents()
    {
        PoolSignals.Instance.onGetPoolManagerObj -= OnGetPoolManagerObj;
        PoolSignals.Instance.onGetObject -= OnGetObject;
        PoolSignals.Instance.onGetObjectOnPosition -= OnGetObjectOnPosition;
        CoreGameSignals.Instance.onRestartLevel -= OnReset;

    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    #endregion

    private void InitializePool(PoolEnums type, GameObject prefab, int size)
    {
        List<GameObject> tempList = new List<GameObject>();
        GameObject tmp;

        for (int i = 0; i < size; i++)
        {
            tmp = Instantiate(prefab, transform);
            tmp.SetActive(false);
            tempList.Add(tmp);
        }
        poolDictionary.Add(type, tempList);
    }

    public GameObject OnGetObject(PoolEnums type)
    {
        for (int i = 0; i < poolDictionary[type].Count; i++)
        {
            if (!poolDictionary[type][i].activeInHierarchy)
            {
                return poolDictionary[type][i];
            }
        }
        return null;
    }
    public GameObject OnGetObjectOnPosition(PoolEnums type, Vector3 position)
    {
        for (int i = 0; i < poolDictionary[type].Count; i++)
        {
            if (!poolDictionary[type][i].activeInHierarchy)
            {
                poolDictionary[type][i].transform.position = position;
                poolDictionary[type][i].gameObject.SetActive(true);

                return poolDictionary[type][i];
            }
        }
        return null;
    }

    public Transform OnGetPoolManagerObj()
    {
        return transform;
    }


    private void OnReset()
    {
        //reset
        ResetPool(PoolEnums.Bullet);
        ResetPool(PoolEnums.Enemy);
        ResetPool(PoolEnums.ParticleR);
        ResetPool(PoolEnums.ParticleG);
        ResetPool(PoolEnums.ParticleB);
        ResetPool(PoolEnums.ParticleP);
        ResetPool(PoolEnums.ParticleY);
    }

    private void ResetPool(PoolEnums type)
    {
        foreach (var i in poolDictionary[type])
        {
            i.SetActive(false);
        }
    }
}
