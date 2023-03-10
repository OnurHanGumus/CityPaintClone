using Data.ValueObject;
using UnityEngine;

namespace Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_Player", menuName = "Picker3D/CD_Player", order = 0)]
    public class CD_Target : ScriptableObject
    {
        public TargetData Data;
    }
}