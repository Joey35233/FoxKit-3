using UnityEngine;
using System;
using static Fox.Geo.GeoGeom;

namespace Fox.Geo
{
    [UnityEditor.InitializeOnLoad, UnityEngine.AddComponentMenu("Geo/CollisionTags")]
    public class CollisionTags : MonoBehaviour
    {
        // public bool Padding0;
        public bool RECOIL;
        public bool CHARA;
        public bool SOUND_MGS4;

        public bool PLAYER;
        public bool ENEMY;
        public bool BULLET;
        public bool MISSILE;

        public bool BOMB;
        public bool RADOR_MGS4;
        public bool BLOOD;
        public bool IK;

        public bool STAIRWAY;
        public bool STOP_EYE;
        public bool CLIFF;
        public bool TYPTHROUGH_MGS4;

        public bool LEAN_MGS4;
        public bool DONT_FALL;
        public bool CAMERA;
        public bool SHADOW_MGS4;

        public bool INTRUDE_MGS4;
        public bool ATTACK_GUARD_MGS4;
        public bool CLIFF_FLOOR;
        public bool BULLET_MARK;

        public bool HEIGHT_LIMIT;
        public bool NO_BEHIND_MGS4;
        public bool BEHIND_THROUGH_MGS4;
        // public bool Padding1;

        // public bool Padding2;
        public bool DOUBLE_SIDE;
        public bool WATER_SURFACE;
        // public bool CHARA_Part2;

        public bool TARGET_BLOCK;
        public bool DOG;
        // public bool Padding3;
        public bool NO_EFFECT;

        public bool EVENT_PHYSICS;
        public bool NO_WALL_MOVE;
        public bool MISSILE2;
        // public bool Padding4;

        public bool TppReserve1;
        public bool TppReserve2;
        public bool TppReserve3;
        public bool TppReserve4;

        // public bool Padding5;
        // public bool Padding6;
        // public bool Padding7;
        // public bool Padding8;

        public bool Sahelan;
        public bool RIDE_ON_OUTER;
        public bool FLAME;
        public bool IGNORE_PHYSICS;

        public bool CLIMB;
        public bool HORSE;
        public bool VEHICLE;
        public bool MARKER;

        public bool RIDE_ON;
        public bool THROUGH_LINE_OF_FIRE;
        public bool THROUGH_ITEM_CHECK;
        public bool NO_CREEP;

        public bool NO_FULTON;
        public bool FULTON;
        public bool ITEM;
        public bool BOSS;

		public void SetTags(GeoCollisionTags tags)
		{
			Type ctType = typeof(CollisionTags);

            foreach (GeoCollisionTags tag in (GeoCollisionTags[])Enum.GetValues(typeof(GeoCollisionTags)))
            {
                string propertyName = Enum.GetName(typeof(GeoCollisionTags), tag);

				var fieldInfo = ctType.GetField(propertyName);
                fieldInfo.SetValue(this, tags.HasFlag(tag));
            }
		}
    }
}
