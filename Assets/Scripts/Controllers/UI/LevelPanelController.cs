using Enums;
using Signals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Data.UnityObject;
using DG.Tweening;
using UnityEngine.UI;
using Data.ValueObject;

public class LevelPanelController : MonoBehaviour
{
    #region Self Variables
    #region Public Variables
    #endregion
    #region SerializeField Variables
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Slider slider;
    #endregion
    #region Private Variables
    private LevelData _data;
    private int _levelId;
    private int _totalPaintValue = 86400;
    private int _sliderMaksValue;

    private bool _isSuccessful = false;
    private bool _isStarted = false;

    #endregion
    #endregion
    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        _data = GetData();

    }
    public LevelData GetData() => Resources.Load<CD_Level>("Data/CD_Level").Data;

    public void OnPlay()
    {
        _isStarted = true;
        _levelId = LevelSignals.Instance.onGetLevelId();
        Debug.Log(_levelId);
        _sliderMaksValue = _totalPaintValue * _data.EnemyCounts[_levelId] / 100;
        slider.maxValue = _sliderMaksValue;
    }
    public void OnScoreUpdateText(ScoreTypeEnums type, int score)
    {
        if (type.Equals(ScoreTypeEnums.Score))
        {
            scoreText.text = score.ToString();
        }
    }

    public void OnChannelCounterIncreased(int currentValue)
    {
        if (!_isStarted || _isSuccessful)
        {
            return;
        }
        slider.value = currentValue;
        if (slider.value >= _sliderMaksValue)
        {
            CoreGameSignals.Instance.onLevelSuccessful?.Invoke();
            _isSuccessful = true;
        }
    }

    public void OnRestartLevel()
    {
        scoreText.text = 0.ToString();
        _isSuccessful = false;
        _isStarted = false;
    }
}
