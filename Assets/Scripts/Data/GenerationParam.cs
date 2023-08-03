using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = nameof(GenerationParam))]
    public class GenerationParam: ScriptableObject
    {
        public int rowsInstancesCount;
        public int deltaToRebuild;
        public float platformOffsetY;
        public float platformDefaultDeltaX;
        public float platformDefaultZ;
        [Range(0f, 80f)]
        public float chanceToChangedRow;
    }
}