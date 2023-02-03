using Data.UnityObject;
using Data.ValueObject;
using PaintIn3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeshController: MonoBehaviour
{
    #region Self Variables

    #region Serialized Variables

    #endregion

    #region Private Variables
    private SkinnedMeshRenderer _renderer;
    private ColorData _colorData;
    #endregion
    #endregion

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        _renderer = GetComponent<SkinnedMeshRenderer>();
        _colorData = GetData();
    }
    private ColorData GetData() => Resources.Load<CD_Color>("Data/CD_Color").Data;

    private void OnEnable()
    {
        int rand = Random.Range(0, _colorData.Colors.Count);
        _renderer.material.color = _colorData.Colors[rand];
    }
    public Color GetMeshRendererColor()
    {
        return _renderer.material.color;
    }

}
