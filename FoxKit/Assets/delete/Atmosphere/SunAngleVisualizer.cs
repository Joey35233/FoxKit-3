using UnityEngine;

namespace FoxKit.Gr.Atmosphere
{
    [ExecuteInEditMode]
    public class SunAngleVisualizer : MonoBehaviour
    {
        private const float NIGHT_END_CLOCK = 21873;   // 06:04:33
        private const float NIGHT_START_CLOCK = 65653; // 18:14:13

        public Light Sun;
        public Light Moon;
        private static readonly Vector3 fixedLightDirSunRise = -Fox.Kernel.Math.FoxToUnityVector3(new Vector3(-0.853044f, -0.48479f, 0.193119f));
        private static readonly Vector3 fixedLightDirSunSet = -Fox.Kernel.Math.FoxToUnityVector3(new Vector3(0.195711f, -0.484843f, -0.852422f));
        private static readonly Vector3 fixedLightDirMoonRise = -Fox.Kernel.Math.FoxToUnityVector3(new Vector3(0.423196f, -0.484807f, -0.765419f));
        private static readonly Vector3 fixedLightDirMoonSet = -Fox.Kernel.Math.FoxToUnityVector3(new Vector3(-0.768373f, -0.48485f, 0.41776f));
        private static readonly Vector3 fixedRisingSunDir = -Fox.Kernel.Math.FoxToUnityVector3(new Vector3(-0.708764f, 0.137421f, 0.691931f));
        private static readonly Vector3 fixedFallingSunDir = -Fox.Kernel.Math.FoxToUnityVector3(new Vector3(0.695227f, 0.137408f, -0.705534f));
        private static readonly Vector3 fixedRisingMoonDir = -Fox.Kernel.Math.FoxToUnityVector3(new Vector3(0.834518f, 0.137422f, -0.533568f));
        private static readonly Vector3 fixedFallingMoonDir = -Fox.Kernel.Math.FoxToUnityVector3(new Vector3(-0.536711f, 0.137452f, 0.832496f));

        private void Update()
        {
            const uint SecondsInDay = 60 * 60 * 24;

            double absoluteTime = Time.unscaledTimeAsDouble;
            double timeModDay = absoluteTime % SecondsInDay;

            const float TPPTimeScale = 20;
            const float CustomTimeScale = 200;

            timeModDay *= TPPTimeScale;
            timeModDay *= CustomTimeScale;

            timeModDay %= SecondsInDay;

            if (timeModDay is <= NIGHT_START_CLOCK and > NIGHT_END_CLOCK)
            {
                Sun.intensity = 1;
                Moon.intensity = 0;

                float frac = (float)((timeModDay - NIGHT_END_CLOCK) / (NIGHT_START_CLOCK - NIGHT_END_CLOCK));

                Sun.transform.rotation = Quaternion.LookRotation(Vector3.Slerp(fixedRisingSunDir, fixedFallingSunDir, frac));
            }
            else
            {
                Sun.intensity = 0;
                Moon.intensity = 1;

                if (timeModDay <= NIGHT_END_CLOCK)
                    timeModDay += SecondsInDay;

                float frac = (float)((timeModDay - NIGHT_START_CLOCK) / (SecondsInDay - NIGHT_START_CLOCK + NIGHT_END_CLOCK));

                Moon.transform.rotation = Quaternion.LookRotation(Vector3.Slerp(fixedRisingMoonDir, fixedFallingMoonDir, frac));
            }
        }


        private void OnDrawGizmos()
        {
            Gizmos.color = Color.white;
            Gizmos.DrawRay(Vector3.zero, fixedLightDirSunRise);
            Gizmos.DrawRay(Vector3.zero, fixedLightDirSunSet);

            Gizmos.color = Color.black;
            Gizmos.DrawRay(Vector3.zero, fixedLightDirMoonRise);
            Gizmos.DrawRay(Vector3.zero, fixedLightDirMoonSet);

            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(Vector3.zero, fixedRisingSunDir);
            Gizmos.DrawRay(Vector3.zero, fixedFallingSunDir);

            Gizmos.color = Color.magenta;
            Gizmos.DrawRay(Vector3.zero, fixedRisingMoonDir);
            Gizmos.DrawRay(Vector3.zero, fixedFallingMoonDir);
        }
    }
}