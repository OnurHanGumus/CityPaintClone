using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Signals;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelPanelController : MonoBehaviour
{
    #region Self Variables
    #region Public Variables
    #endregion
    #region SerializeField Variables
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private Slider slider;
    #endregion
    #region Private Variables
    private LevelData _data;
    private int _levelId;
    private int _totalPaintValue = 86400;
    private int _sliderMaksValue;
    private int _money;

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
        _money = SaveSignals.Instance.onGetScore(SaveLoadStates.Money, SaveFiles.SaveFile);

        moneyText.text = "$" + _money.ToString();
        _isStarted = true;
        _levelId = LevelSignals.Instance.onGetLevelId();
        _sliderMaksValue = _totalPaintValue * _data.EnemyCounts[_levelId] / 100;
        slider.maxValue = _sliderMaksValue;
    }
    public void OnMoneyIncreased(int money)
    {
        moneyText.text = "$" + money.ToString();
        SaveSignals.Instance.onSaveScore?.Invoke(money, SaveLoadStates.Money, SaveFiles.SaveFile);
    }
    public void OnMoneyDecreased(int money)
    {
        moneyText.text = "$" + money.ToString();
        SaveSignals.Instance.onSaveScore?.Invoke(money, SaveLoadStates.Money, SaveFiles.SaveFile);
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
        _isSuccessful = false;
        _isStarted = false;
    }
}
