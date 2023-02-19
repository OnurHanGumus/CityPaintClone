using System;
using System.Collections.Generic;
using Commands;
using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Extentions;
using Keys;
using Signals;
using UnityEngine;
using Enums;
using System.Collections;
using TMPro;
using DG.Tweening;

namespace Managers
{
    public class StoreManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private List<TextMeshProUGUI> levelTxt;
        [SerializeField] private List<TextMeshProUGUI> upgradeTxt;
        [SerializeField] private List<int> itemLevels;



        #endregion
        private AllItemPricesData _data;
        #endregion



        private void Awake()
        {
            Init();
        }


        private void Init()
        {
            _data = GetData();
        }
        private AllItemPricesData GetData() => Resources.Load<CD_Prices>("Data/CD_Prices").Data;
        private void Start()
        {
            UpdateTexts();

        }

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            SaveSignals.Instance.onInitializePlayerUpgrades += OnGetStoreLevels;
        }

        private void UnsubscribeEvents()
        {
            SaveSignals.Instance.onInitializePlayerUpgrades -= OnGetStoreLevels;

        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        public void UpgradeItem(int id)
        {
            if (itemLevels[id] >= 3)
            {
                return;
            }


            if (ScoreSignals.Instance.onGetMoney() > _data.itemPrices[id].prices[itemLevels[id]])
            {
                ScoreSignals.Instance.onScoreDecrease(ScoreTypeEnums.Money, _data.itemPrices[id].prices[itemLevels[id]]);
                itemLevels[id] = itemLevels[id] + 1;
                SaveSignals.Instance.onUpgradePlayer?.Invoke(itemLevels, SaveLoadStates.PlayerImprovements, SaveFiles.SaveFile);
                UpdateTexts();
                AudioSignals.Instance.onPlaySound?.Invoke(Enums.AudioSoundEnums.Click);

            }
        }

        private void OnGetStoreLevels(List<int> levels)
        {
            if (levels.Count.Equals(0))
            {
                levels = new List<int>() { 0, 0, 0, 0 };
            }

            itemLevels = levels;
            UpdateTexts();
        }

        private void UpdateTexts()
        {
            for (int i = 0; i < itemLevels.Count; i++)//textleri initialize et
            {
                if (itemLevels[i] < 3)
                {

                    //levelTxt[i].text = "LEVEL " + (itemLevels[i] + 1).ToString();
                    upgradeTxt[i].text = _data.itemPrices[i].prices[itemLevels[i]].ToString() + "$";
                }
                else
                {
                    //levelTxt[i].text = "LEVEL " + (itemLevels[i] + 1).ToString();
                    upgradeTxt[i].text = "MAX";

                }
            }
        }
    }
}