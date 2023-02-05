using System;
using UnityEngine;

namespace Data.ValueObject
{
    [Serializable]
    public class SaveData
    {
        public int IncomeIncreaseValue = 1;
        public int EnemyCountIncreaseValue = 1;
        public float FireRateDecreaseValue = 0.15f;
        public int AmmoCapacityIncreaseValue = 9;
    }
}