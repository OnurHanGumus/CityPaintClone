using Enums;
using Extentions;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class GunSignals : MonoSingleton<GunSignals>
    {
        public UnityAction<int> onFired = delegate { };
        public UnityAction<int> onReload = delegate { };
    }
}