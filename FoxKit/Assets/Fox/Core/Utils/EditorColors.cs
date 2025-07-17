using UnityEngine;

namespace Fox.Core
{
    public static class EditorColors
    {
        public static readonly Color GenericSelectedColor = new(68.0f / 255.0f, 114.0f / 255.0f, 137.0f / 255.0f, 0.75f);
        public static readonly Color GenericUnselectedColor = new (13.0f / 255.0f, 64.0f / 255.0f, 89.0f / 255.0f, 0.5f);

        public static readonly Color AudioColor = new(0.5f, 0.95f, 0.95f, 0.5f);

        /// <summary>
        /// cmn-col-marker-friend
        /// </summary>
        public static readonly Color PlayerUtilityColor = new Color(0.4f, 0.9f, 0.7f, 0.5f);

        /// <summary>
        /// cmn-col-kill
        /// </summary>
        public static readonly Color HostileColor = new Color(1f, 0.3f, 0.2f, 0.5f);

        /// <summary>
        /// cmn-col-marker-enemy
        /// </summary>
        public static readonly Color HostileColorDeselected = new Color(1f, 0.4f, 0.3f, 0.15f);

        public static readonly Color LabelColor = new Color(184.0f / 255.0f, 204.0f / 255.0f, 202.0f / 255.0f, 0.95f);
        public static readonly Color LabelIdleColor = new Color(154.0f / 255.0f, 163.0f / 255.0f, 162.0f / 255.0f, 0.85f);
    }
}
