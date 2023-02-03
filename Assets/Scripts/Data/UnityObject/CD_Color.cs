using Data.ValueObject;
using UnityEngine;

namespace Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_Color", menuName = "Picker3D/CD_Color", order = 0)]
    public class CD_Color : ScriptableObject
    {
        public ColorData Data;
    }
}