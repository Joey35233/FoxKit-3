using UnityEngine;
using System;
using static Fox.Geo.GeoGeom;

namespace Fox.Geo
{
    [AddComponentMenu("Geo/CollisionTags")]
    public class CollisionTags : MonoBehaviour
    {
	    
        public bool RECOIL;
        public bool CHARA;
        public bool SOUND;

        public bool PLAYER;
        public bool ENEMY;
        public bool BULLET;
        public bool MISSILE;

        public bool BOMB;
        
        public bool BLOOD;
        public bool IK;

        public bool STAIRWAY;
        public bool STOP_EYE;
        public bool CLIFF;
        

        
        public bool DONT_FALL;
        public bool CAMERA;
        

        
        
        public bool CLIFF_FLOOR;
        public bool BULLET_MARK;

        public bool HEIGHT_LIMIT;
        
        
        

        
        public bool DOUBLE_SIDE;
        public bool WATER_SURFACE;
        

        public bool TARGET_BLOCK;
        public bool DOG;
        
        public bool NO_EFFECT;

        public bool EVENT_PHYSICS;
        public bool NO_WALL_MOVE;
        public bool MISSILE2;
        

        public bool TppReserve1;
        public bool TppReserve2;
        public bool TppReserve3;
        public bool TppReserve4;
        
        
        
        
        

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
			
		    RECOIL = (tags & GeoCollisionTags.RECOIL) != 0;
		    CHARA = (tags & GeoCollisionTags.CHARA) != 0;
		    SOUND = (tags & GeoCollisionTags.SOUND) != 0;
		    
		    PLAYER = (tags & GeoCollisionTags.PLAYER) != 0;
		    ENEMY = (tags & GeoCollisionTags.ENEMY) != 0;
		    BULLET = (tags & GeoCollisionTags.BULLET) != 0;
		    MISSILE = (tags & GeoCollisionTags.MISSILE) != 0;
		    
		    BOMB = (tags & GeoCollisionTags.BOMB) != 0;
		    
		    BLOOD = (tags & GeoCollisionTags.BLOOD) != 0;
		    IK = (tags & GeoCollisionTags.IK) != 0;
		    
		    STAIRWAY = (tags & GeoCollisionTags.STAIRWAY) != 0;
		    STOP_EYE = (tags & GeoCollisionTags.STOP_EYE) != 0;
		    CLIFF = (tags & GeoCollisionTags.CLIFF) != 0;
		    
		    
		    
		    DONT_FALL = (tags & GeoCollisionTags.DONT_FALL) != 0;
		    CAMERA = (tags & GeoCollisionTags.CAMERA) != 0;
		    
		    
		    
		    
		    CLIFF_FLOOR = (tags & GeoCollisionTags.CLIFF_FLOOR) != 0;
		    BULLET_MARK = (tags & GeoCollisionTags.BULLET_MARK) != 0;
		    
		    HEIGHT_LIMIT = (tags & GeoCollisionTags.HEIGHT_LIMIT) != 0;
		    
		    
		    
		    
		    
		    DOUBLE_SIDE = (tags & GeoCollisionTags.DOUBLE_SIDE) != 0;
		    WATER_SURFACE = (tags & GeoCollisionTags.WATER_SURFACE) != 0;
		    
		    
		    TARGET_BLOCK = (tags & GeoCollisionTags.TARGET_BLOCK) != 0;
		    DOG = (tags & GeoCollisionTags.DOG) != 0;
		    
		    NO_EFFECT = (tags & GeoCollisionTags.NO_EFFECT) != 0;
		    
		    EVENT_PHYSICS = (tags & GeoCollisionTags.EVENT_PHYSICS) != 0;
		    NO_WALL_MOVE = (tags & GeoCollisionTags.NO_WALL_MOVE) != 0;
		    MISSILE2 = (tags & GeoCollisionTags.MISSILE2) != 0;
		    
		    
		    TppReserve1 = (tags & GeoCollisionTags.TppReserve1) != 0;
		    TppReserve2 = (tags & GeoCollisionTags.TppReserve2) != 0;
		    TppReserve3 = (tags & GeoCollisionTags.TppReserve3) != 0;
		    TppReserve4 = (tags & GeoCollisionTags.TppReserve4) != 0;

		    
		    
		    
		    
		    
		    Sahelan = (tags & GeoCollisionTags.Sahelan) != 0;
		    RIDE_ON_OUTER = (tags & GeoCollisionTags.RIDE_ON_OUTER) != 0;
		    FLAME = (tags & GeoCollisionTags.FLAME) != 0;
		    IGNORE_PHYSICS = (tags & GeoCollisionTags.IGNORE_PHYSICS) != 0;
		    
		    CLIMB = (tags & GeoCollisionTags.CLIMB) != 0;
		    HORSE = (tags & GeoCollisionTags.HORSE) != 0;
		    VEHICLE = (tags & GeoCollisionTags.VEHICLE) != 0;
		    MARKER = (tags & GeoCollisionTags.MARKER) != 0;
		    
		    RIDE_ON = (tags & GeoCollisionTags.RIDE_ON) != 0;
		    THROUGH_LINE_OF_FIRE = (tags & GeoCollisionTags.THROUGH_LINE_OF_FIRE) != 0;
		    THROUGH_ITEM_CHECK = (tags & GeoCollisionTags.THROUGH_ITEM_CHECK) != 0;
		    NO_CREEP = (tags & GeoCollisionTags.NO_CREEP) != 0;
		    
		    NO_FULTON = (tags & GeoCollisionTags.NO_FULTON) != 0;
		    FULTON = (tags & GeoCollisionTags.FULTON) != 0;
		    ITEM = (tags & GeoCollisionTags.ITEM) != 0;
		    BOSS = (tags & GeoCollisionTags.BOSS) != 0;
		}

		public GeoCollisionTags GetTags()
		{
			GeoCollisionTags tags = 0;
    
			
		    if (RECOIL) tags |= GeoCollisionTags.RECOIL;
		    if (CHARA) tags |= GeoCollisionTags.CHARA;
		    if (SOUND) tags |= GeoCollisionTags.SOUND;

		    if (PLAYER) tags |= GeoCollisionTags.PLAYER;
		    if (ENEMY) tags |= GeoCollisionTags.ENEMY;
		    if (BULLET) tags |= GeoCollisionTags.BULLET;
		    if (MISSILE) tags |= GeoCollisionTags.MISSILE;

		    if (BOMB) tags |= GeoCollisionTags.BOMB;
		    
		    if (BLOOD) tags |= GeoCollisionTags.BLOOD;
		    if (IK) tags |= GeoCollisionTags.IK;

		    if (STAIRWAY) tags |= GeoCollisionTags.STAIRWAY;
		    if (STOP_EYE) tags |= GeoCollisionTags.STOP_EYE;
		    if (CLIFF) tags |= GeoCollisionTags.CLIFF;
		    

		    
		    if (DONT_FALL) tags |= GeoCollisionTags.DONT_FALL;
		    if (CAMERA) tags |= GeoCollisionTags.CAMERA;
		    

		    
		    
		    if (CLIFF_FLOOR) tags |= GeoCollisionTags.CLIFF_FLOOR;
		    if (BULLET_MARK) tags |= GeoCollisionTags.BULLET_MARK;

		    if (HEIGHT_LIMIT) tags |= GeoCollisionTags.HEIGHT_LIMIT;
		    
		    
		    

		    
		    if (DOUBLE_SIDE) tags |= GeoCollisionTags.DOUBLE_SIDE;
		    if (WATER_SURFACE) tags |= GeoCollisionTags.WATER_SURFACE;
		    

		    if (TARGET_BLOCK) tags |= GeoCollisionTags.TARGET_BLOCK;
		    if (DOG) tags |= GeoCollisionTags.DOG;
		    
		    if (NO_EFFECT) tags |= GeoCollisionTags.NO_EFFECT;

		    if (EVENT_PHYSICS) tags |= GeoCollisionTags.EVENT_PHYSICS;
		    if (NO_WALL_MOVE) tags |= GeoCollisionTags.NO_WALL_MOVE;
		    if (MISSILE2) tags |= GeoCollisionTags.MISSILE2;
		    

		    if (TppReserve1) tags |= GeoCollisionTags.TppReserve1;
		    if (TppReserve2) tags |= GeoCollisionTags.TppReserve2;
		    if (TppReserve3) tags |= GeoCollisionTags.TppReserve3;
		    if (TppReserve4) tags |= GeoCollisionTags.TppReserve4;
		    
		    
		    
		    
		    

		    if (Sahelan) tags |= GeoCollisionTags.Sahelan;
		    if (RIDE_ON_OUTER) tags |= GeoCollisionTags.RIDE_ON_OUTER;
		    if (FLAME) tags |= GeoCollisionTags.FLAME;
		    if (IGNORE_PHYSICS) tags |= GeoCollisionTags.IGNORE_PHYSICS;

		    if (CLIMB) tags |= GeoCollisionTags.CLIMB;
		    if (HORSE) tags |= GeoCollisionTags.HORSE;
		    if (VEHICLE) tags |= GeoCollisionTags.VEHICLE;
		    if (MARKER) tags |= GeoCollisionTags.MARKER;

		    if (RIDE_ON) tags |= GeoCollisionTags.RIDE_ON;
		    if (THROUGH_LINE_OF_FIRE) tags |= GeoCollisionTags.THROUGH_LINE_OF_FIRE;
		    if (THROUGH_ITEM_CHECK) tags |= GeoCollisionTags.THROUGH_ITEM_CHECK;
		    if (NO_CREEP) tags |= GeoCollisionTags.NO_CREEP;

		    if (NO_FULTON) tags |= GeoCollisionTags.NO_FULTON;
		    if (FULTON) tags |= GeoCollisionTags.FULTON;
		    if (ITEM) tags |= GeoCollisionTags.ITEM;
		    if (BOSS) tags |= GeoCollisionTags.BOSS;

			return tags;
		}
    }
}
