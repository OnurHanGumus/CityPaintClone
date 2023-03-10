using Enums;
using Extentions;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class PoolSignals : MonoSingleton<PoolSignals>
    {
        public Func<PoolEnums, GameObject> onGetObject = delegate { return null; };
        public Func<PoolEnums, Vector3, GameObject> onGetObjectOnPosition = delegate { return null; };
        public Func<PoolEnums, int, Vector3, GameObject> onGetParticleOnPosition = delegate { return null; };

        public Func<Transform> onGetPoolManagerObj = delegate { return null; };
    }
}
