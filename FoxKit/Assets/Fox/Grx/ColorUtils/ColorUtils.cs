using UnityEngine;

namespace Fox.Grx
{
    public static class ColorUtils
    {
        public static Vector2 CalculateBlackBodyPrimaries(float temperature)
        {
            float fVar1;
            float fVar2;
            float fVar3 = 4000.0 <= temperature
                ? (2107038.0f / (temperature * temperature)) -
                        (3.025847e+09f / (temperature * temperature * temperature)) + (222.6347f / temperature) +
                        0.24039f
                : (877.6956f / temperature) -
                        ((2.661239e+08f / (temperature * temperature * temperature)) +
                        (234358.0f / (temperature * temperature))) + 0.17991f;
            fVar2 = 2222.0 <= temperature
                ? 4000.0 <= temperature
                    ? (fVar3 * fVar3 * fVar3 * 3.081758f) - (fVar3 * fVar3 * 5.873387f) + (fVar3 * 3.75113f) -
                            0.3700148f
                    : (fVar3 * 2.09137f) - ((fVar3 * fVar3 * fVar3 * 0.9549476f) + (fVar3 * fVar3 * 1.374186f)) -
                            0.1674887f
                : (fVar3 * 2.185558f) - ((fVar3 * fVar3 * fVar3 * 1.106381f) + (fVar3 * fVar3 * 1.34811f)) -
                        0.2021968f;
            fVar1 = 1.0f / ((fVar2 * 12.0f) - (fVar3 * 2.0f) + 3.0f);

            return new Vector2(fVar3 * 4.0f * fVar1, fVar2 * 6.0f * fVar1);
        }

        public static Color CalculateBlackBodyColor(float temperature, float colorDeflection, float lumen)
        {
            float fVar1;
            float fVar3;
            float fVar2;
            float fVar4;

            Vector2 bbA;
            bbA = CalculateBlackBodyPrimaries(temperature);
            Vector2 bbB;
            bbB = CalculateBlackBodyPrimaries(temperature + 1.0f);

            fVar2 = bbA.x - bbB.x;
            fVar3 = bbB.y - bbA.y;
            fVar1 = 1.0f / Mathf.Sqrt((fVar2 * fVar2) + (fVar3 * fVar3));
            fVar4 = bbA.y + (fVar1 * fVar2 * colorDeflection);
            fVar3 = bbA.x + (fVar1 * fVar3 * colorDeflection);
            fVar1 = 1.0f / ((fVar3 * 2.0f) - (fVar4 * 8.0f) + 4.0f);
            fVar2 = fVar3 * 3.0f * fVar1;
            fVar1 = fVar4 * 2.0f * fVar1;
            fVar3 = lumen / fVar1;
            fVar1 = (1.0f - fVar2 - fVar1) * fVar3;
            fVar3 *= fVar2;

            Color outColor = Color.white;
            outColor.r = (fVar3 * 3.240479f) - (lumen * 1.53715f) - (fVar1 * 0.498535f);
            outColor.g = (lumen * 1.875991f) - (fVar3 * 0.969256f) + (fVar1 * 0.041556f);
            outColor.b = (fVar3 * 0.055648f) - (lumen * 0.204043f) + (fVar1 * 1.057311f);

            return outColor;
        }

        public static Color AdjustColorForWhitePoint(float temperature, float colorDeflection, Color color, float lumen)
        {
            Color w = CalculateBlackBodyColor(6500, 0, 1);
            Color c = CalculateBlackBodyColor(temperature, colorDeflection, lumen);

            Color outColor = new Color(c.r / w.r * w.g, c.g, c.b / w.b * w.g, 1) * color;

            return outColor;
        }
    }
}