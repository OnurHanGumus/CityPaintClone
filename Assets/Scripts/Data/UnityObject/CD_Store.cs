using Data.ValueObject;
using UnityEngine;

namespace Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_Store", menuName = "Picker3D/CD_Store", order = 0)]
    public class CD_Store : ScriptableObject
    {
        public StoreData Data;
    }
}