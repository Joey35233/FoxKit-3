using Fox.Core;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Fox.EdGameCore
{
    public class EdGameCoreModule
    {
        public static List<string> gameObjectTypes = new List<string>
        {
            "TppBear",
            "TppBuddyDog2",
            "TppBuddyPuppy",
            "TppBuddyQuiet2",
            "TppBossQuiet2",
            "TppCodeTalker2",
            "TppCommandPost2",
            "TppCommonWalkerGear2",
            "TppCorpse",
            "TppCritterBird",
            "TppDecoySystem",
            "TppEagle",
            "TppEnemyHeli",
            "TppEspionageRadioSystem",
            "TppGoat",
            "TppJackal",
            "TppMarker2LocatorSystem",
            "TppNubian",
            "TppHeli2",
            "TppHorse2",
            "TppHostage2",
            "TppHostageKaz",
            "TppHostageUnique",
            "TppHostageUnique2",
            "TppHuey2",
            "TppLiquid2",
            "TppMantis2",
            "TppOcelot2",
            "TppOtherHeli2",
            "TppParasite2",
            "TppPlacedSystem",
            "TppPlayer2",
            "TppPlayerHorseforVr", // tex: prologue volgin escape
            "TppRat",
            "TppSahalen2",
            "TppSecurityCamera2",
            "TppSkullFace2",
            "TppSoldier2", // tex: is also sniper parasites
            "TppStork",
            "TppSupplyCboxSystem",
            "TppSupportAttackSystem",
            "TppVolgin2",
            "TppVolgin2forVr", // tex: prologue volgin escape
            "TppUav",
            "TppVehicle2",
            "TppWalkerGear2",
            "TppWolf",
            "TppZebra",
        };

        public class GameObjectInfo
        {
            public string DefaultName { get; private set; }
            public uint GroupId { get; private set; }
            public uint TotalCount { get; private set; }
            public uint RealizedCount { get; private set; }
            public string ParameterName { get; private set; }

            public GameObjectInfo(string defaultName, uint groupId, uint totalCount, uint realizedCount, string parameterName)
            {
                DefaultName = defaultName;
                GroupId = groupId;
                TotalCount = totalCount;
                RealizedCount = realizedCount;
                ParameterName = parameterName;
            }

            public override string ToString()
            {
                return $"DefaultName: {DefaultName}, Parameter: {ParameterName}, GroupId: {GroupId}, TotalCount: {TotalCount}, RealizedCount: {RealizedCount}";
            }
        }

        public static readonly Dictionary<string, GameObjectInfo> typeData = new()
        {
            { "TppBear", new GameObjectInfo("BearGameObject", 0, 1, 1, "TppBearParameter") },
            { "TppBuddyDog2", new GameObjectInfo("BuddyDogGameObject", 0, 1, 1, "TppBuddyDog2Parameter") },
            { "TppBuddyPuppy", new GameObjectInfo("BuddyPuppy", 0, 1, 1, "TppBuddyPuppyParameter") },
            { "TppBuddyQuiet2", new GameObjectInfo("BuddyQuietGameObject", 0, 1, 1, "TppBuddyQuiet2Parameter") },
            { "TppBossQuiet2", new GameObjectInfo("BossQuietGameObject", 0, 1, 1, "TppBossQuiet2Parameter") },
            { "TppHostage2", new GameObjectInfo("Hostage2GameObject2", 0, 14, 5, "TppHostage2Parameter") },
            { "TppSoldier2", new GameObjectInfo("Soldier2GameObject", 0, 160, 12, "TppSoldier2Parameter") },
        };

        public static GameObjectInfo GetGameObjectInfoByType(string selectedType)
        {
            if (typeData.TryGetValue(selectedType, out var info))
            {
                return info;
            }
            else
            {
                throw new KeyNotFoundException($"Type '{selectedType}' not found in typeData.");
            }
        }



        private static DataElement CreateAndAttachParameter(GameObject parent, string name, Type paramType)
        {
            var paramGO = new GameObject(name);
            paramGO.transform.SetParent(parent.transform);
            return (DataElement)paramGO.AddComponent(paramType);
        }

        private static void AssignParameter(GameObject obj, DataElement param)
        {
            if (obj == null || param == null) return;
            obj.GetComponent<Fox.GameCore.GameObject>().parameters = param;
            Selection.activeGameObject = obj;
        }

    }
}
