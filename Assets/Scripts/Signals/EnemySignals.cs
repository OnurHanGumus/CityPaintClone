using Enums;
using Extentions;
using System;
using System.Collections.Generic;
using UnityEngine.Events;

namespace Signals
{
    public class EnemySignals : MonoSingleton<EnemySignals>
    {
        public UnityAction onEnemyShooted = delegate { };

    }
}