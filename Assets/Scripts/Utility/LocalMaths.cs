using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BreakoutUtility
{
    public class LocalMaths {

        // Zusammenfassung:
        //  Returns a Percentage-Value where 100 represents 100%
        //
        public static float PercentOf(float value, float maxValue)
        {
            return value / (maxValue / 100f);
        }
    }
}