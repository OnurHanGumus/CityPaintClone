using System;
using UnityEngine;

namespace Data.ValueObject
{
    [Serializable]
    public class TargetData
    {
        public float Speed = 5;
        public int InitializePosX, InitializePosY;
        public float MaksHorizontalPoint = 0.82f;
        public float MaksVerticalPoint = 5.82f;
        public float MinVerticalPoint = 3.8f;
    }
}