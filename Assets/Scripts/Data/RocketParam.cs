using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = nameof(RocketParam))]
    public class RocketParam: ScriptableObject
    {
        public float engineForce = 20f;
        public float turnForce = 10f;
    }
}