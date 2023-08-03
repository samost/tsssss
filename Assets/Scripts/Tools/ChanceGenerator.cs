

using UnityEngine;

namespace Tools
{
    public class ChanceGenerator
    {
        public static bool HasChance(float percentChance)
        {
            int randomValue = Random.Range(0, 101);

            return randomValue <= percentChance;
        }
    }
}