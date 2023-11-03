using UnityEngine;

namespace Runtime.SOScripts.EnemySO
{
    [CreateAssetMenu(fileName = "Enemy Data", menuName = "Enemy/Enemy Data")]
    public class EnemySoScript : ScriptableObject
    {
        public float healthValue;
        public float speedValue;
        public float damageValue;
    }
}
