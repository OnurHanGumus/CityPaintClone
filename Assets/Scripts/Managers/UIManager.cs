using Controllers;
using Enums;
using Signals;
using UnityEngine;
using Data.UnityObject;
using Data.ValueObject;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private UIPanelActivenessController uiPanelController;
        [SerializeField] private GameOverPanelController gameOverPanelController;
        [SerializeField] private LevelPanelController levelPanelController;
        [SerializeField] private HighScorePanelController highScorePanelController;

        #endregion
        #region Private Variables
        private UIData _data;

        #endregion
        #endregion

        #region Event Subscriptions
        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _data = GetData();
        }

        private UIData GetData() => Resources.Load<CD_UI>("Data/CD_UI").Data;
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onOpenPanel += OnOpenPanel;
            UISignals.Instance.onClosePanel += OnClosePanel;
            UISignals.Instance.onMoneyIncreased += levelPanelController.OnMoneyIncreased;
            UISignals.Instance.onMoneyDecreased += levelPanelController.OnMoneyDecreased;
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onPlay += levelPanelController.OnPlay;
            CoreGameSignals.Instance.onLevelFailed += OnLevelFailed;
            CoreGameSignals.Instance.onLevelSuccessful += OnLevelSuccessful;
            CoreGameSignals.Instance.onRestartLevel += levelPanelController.OnRestartLevel;
            ScoreSignals.Instance.onHighScoreChanged += highScorePanelController.OnUpdateText;
            UISignals.Instance.onChannelColorIncreased += levelPanelController.OnChannelCounterIncreased;
            GunSignals.Instance.onFired += levelPanelController.OnFired;
            GunSignals.Instance.onReload += levelPanelController.OnReload;
        }

        private void UnsubscribeEvents()
        {
            UISignals.Instance.onOpenPanel -= OnOpenPanel;
            UISignals.Instance.onClosePanel -= OnClosePanel;
            UISignals.Instance.onMoneyIncreased -= levelPanelController.OnMoneyIncreased;
            UISignals.Instance.onMoneyDecreased -= levelPanelController.OnMoneyDecreased;
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onPlay -= levelPanelController.OnPlay;
            CoreGameSignals.Instance.onLevelFailed -= OnLevelFailed;
            CoreGameSignals.Instance.onLevelSuccessful -= OnLevelSuccessful;
            CoreGameSignals.Instance.onRestartLevel -= levelPanelController.OnRestartLevel;
            ScoreSignals.Instance.onHighScoreChanged -= highScorePanelController.OnUpdateText;
            UISignals.Instance.onChannelColorIncreased -= levelPanelController.OnChannelCounterIncreased;
            GunSignals.Instance.onFired -= levelPanelController.OnFired;
            GunSignals.Instance.onReload -= levelPanelController.OnReload;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnOpenPanel(UIPanels panelParam)
        {
            uiPanelController.OpenMenu(panelParam);
        }

        private void OnClosePanel(UIPanels panelParam)
        {
            uiPanelController.CloseMenu(panelParam);
        }

        private void OnPlay()
        {
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.StartPanel);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.LevelPanel);
        }

        private void OnLevelFailed()
        {
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.LevelPanel);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.GameOverPanel);
            gameOverPanelController.ShowThePanel();
        }

        private void OnLevelSuccessful()
        {
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.LevelPanel);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.WinPanel);
        }

        public void Play()
        {
            CoreGameSignals.Instance.onPlay?.Invoke();
        }

        public void NextLevel()
        {
            CoreGameSignals.Instance.onNextLevel?.Invoke();
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.WinPanel);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.StartPanel);
        }

        public void RestartLevel()
        {
            CoreGameSignals.Instance.onRestartLevel?.Invoke();
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.FailPanel);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.StartPanel);
        }

        public void PauseButton()
        {
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.PausePanel);
            Time.timeScale = 0f;
        }
        public void HighScoreButton()
        {
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.HighScorePanel);
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.StartPanel);
        }
        public void OptionsButton()
        {
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.OptionsPanel);
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.StartPanel);
        }
    }
}