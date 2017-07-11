using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Tremor.Tiles {
public class MonsterBanner : ModTile
{
    public override void SetDefaults()
    {
        Main.tileFrameImportant[Type] = true;
        Main.tileNoAttach[Type] = true;
        Main.tileLavaDeath[Type] = true;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
        TileObjectData.newTile.Height = 3;
        TileObjectData.newTile.CoordinateHeights = new int[]{16, 16, 16};
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.StyleWrapLimit = 111;
        TileObjectData.addTile(Type);
        dustType = -1;
	AddMapEntry(new Color(13, 88, 130));
    }

    public override void KillMultiTile(int i, int j, int frameX, int frameY)
    {
        int style = frameX / 18;
        string item;
        switch(style)
        {
        case 0:
            item = "ZarpruteBanner";
            break;
        case 1:
            item = "ZarpriteBanner";
            break;
        case 2:
            item = "UndeadWarriorBanner";
            break;
        case 3:
            item = "PhantomBanner";
            break;
        case 4:
            item = "ParaspriteBanner";
            break;
        case 5:
            item = "DarkDruidBanner";
            break;
        case 6:
            item = "BloodmoonWarriorBanner";
            break;
        case 7:
            item = "AtisBanner";
            break;
        case 8:
            item = "OrcBanner";
            break;
        case 9:
            item = "OrcWarriorBanner";
            break;
        case 10:
            item = "MushroomCreatureBanner";
            break;
        case 11:
            item = "HallowSlimerBanner";
            break;
        case 12:
            item = "DeepwaterVilefishBanner";
            break;
        case 13:
            item = "CrimerBanner";
            break;
        case 14:
            item = "BicholmereBanner";
            break;
        case 15:
            item = "CrimsonBicholmereBanner";
            break;
        case 16:
            item = "CorruptedBicholmereBanner";
            break;
        case 17:
            item = "ChatteringTeethBanner";
            break;
        case 18:
            item = "CaveGolemBanner";
            break;
        case 19:
            item = "ArmoredJellyfishBanner";
            break;
        case 20:
            item = "ArchDemonBanner";
            break;
        case 21:
            item = "OmegaWolfBanner";
            break;
        case 22:
            item = "BetaWolfBanner";
            break;
        case 23:
            item = "AlphaWolfBanner";
            break;
        case 24:
            item = "AbominationBanner";
            break;
        case 25:
            item = "BlazerBanner";
            break;
        case 26:
            item = "BoneFlyerBanner";
            break;
        case 27:
            item = "DinictisBanner";
            break;
        case 28:
            item = "OrcSkeletonBanner";
            break;
        case 29:
            item = "DragonSkullBanner";
            break;
        case 30:
            item = "DungeonKeeperBanner";
            break;
        case 31:
            item = "FlayerBanner";
            break;
        case 32:
            item = "GiantCrabBanner";
            break;
        case 33:
            item = "HeadlessZombieBanner";
            break;
        case 34:
            item = "HeavyZombieBanner";
            break;
        case 35:
            item = "HiveHeadZombieBanner";
            break;
        case 36:
            item = "ObserverBanner";
            break;
        case 37:
            item = "PeepersBanner";
            break;
        case 38:
            item = "PyramidHeadBanner";
            break;
        case 39:
            item = "SpiderManBanner";
            break;
        case 40:
            item = "SquidZombieBanner";
            break;
        case 41:
            item = "SupremePossessedArmorBanner";
            break;
        case 42:
            item = "WoodyBanner";
            break;
        case 43:
            item = "DevilishTortoiseBanner";
            break;
        case 44:
            item = "AgloominationBanner";
            break;
        case 45:
            item = "AncientCursedSkullBanner";
            break;
        case 46:
            item = "BansheeBanner";
            break;
        case 47:
            item = "BoneArcherBanner";
            break;
        case 48:
            item = "CloudSlimeBanner";
            break;
        case 49:
            item = "ConjurerSkeletonBanner";
            break;
        case 50:
            item = "CoreBugBanner";
            break;
        case 51:
            item = "CoreSlimeBanner";
            break;
        case 52:
            item = "DeimosBanner";
            break;
        case 53:
            item = "DranixBanner";
            break;
        case 54:
            item = "DreadBeetleBanner";
            break;
        case 55:
            item = "ElderObserverBanner";
            break;
        case 56:
            item = "EnragedBatBanner";
            break;
        case 57:
            item = "EvolvedZombieBanner";
            break;
        case 58:
            item = "FallenWarriorBanner";
            break;
        case 59:
            item = "FatFlinxBanner";
            break;
        case 60:
            item = "FireBeetleBanner";
            break;
        case 61:
            item = "FlayerBanner";
            break;
        case 62:
            item = "FrostBeetleBanner";
            break;
        case 63:
            item = "GeneralSnowmanBanner";
            break;
        case 64:
            item = "GhostKnightBanner";
            break;
        case 65:
            item = "GiantGastropodBanner";
            break;
        case 66:
            item = "GiantMeteorHeadBanner";
            break;
        case 67:
            item = "GraniteBeetleBanner";
            break;
        case 68:
            item = "GraniteBowmanBanner";
            break;
        case 69:
            item = "HallowerBanner";
            break;
        case 70:
            item = "HarpyWarriorBanner";
            break;
        case 71:
            item = "HostBanner";
            break;
        case 72:
            item = "IceBlazerBanner";
            break;
        case 73:
            item = "IronGiantBanner";
            break;
        case 74:
            item = "LeprechaunBanner";
            break;
        case 75:
            item = "MechanicalFireflyBanner";
            break;
        case 76:
            item = "MeteoriteGolemBanner";
            break;
        case 77:
            item = "MightyNimbusBanner";
            break;
        case 78:
            item = "MinotaurBanner";
            break;
        case 79:
            item = "NightTerrorBanner";
            break;
        case 80:
            item = "PharaohCasterBanner";
            break;
        case 81:
            item = "PhobosBanner";
            break;
        case 82:
            item = "PossessedHornetBanner";
            break;
        case 83:
            item = "PossessedHoundBanner";
            break;
        case 84:
            item = "QuartzBeetleBanner";
            break;
        case 85:
            item = "RogueBanner";
            break;
        case 86:
            item = "SandThingBanner";
            break;
        case 87:
            item = "ScaryBatBanner";
            break;
        case 88:
            item = "ShadowRipperBanner";
            break;
        case 89:
            item = "SightedBanner";
            break;
        case 90:
            item = "SkeletonKnightBanner";
            break;
        case 91:
            item = "SkullkerBanner";
            break;
        case 92:
            item = "SnowcopterBanner";
            break;
        case 93:
            item = "SnowmanBomberBanner";
            break;
        case 94:
            item = "SnowmanWarriorBanner";
            break;
        case 95:
            item = "TheAxemanBanner";
            break;
        case 96:
            item = "TheGirlBanner";
            break;
        case 97:
            item = "TheThingBanner";
            break;
        case 98:
            item = "ThiefBanner";
            break;
        case 99:
            item = "TwilightBatBanner";
            break;
        default:
            return;
        }
        Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType(item));
    }

    public override void NearbyEffects(int i, int j, bool closer)
    {
        if(closer)
        {
            Player player = Main.player[Main.myPlayer];
            int style = Main.tile[i, j].frameX / 18;
            string type;
            switch(style)
        {
        case 0:
            type = "Zarprute";
            break;
        case 1:
            type = "Zarprite";
            break;
        case 2:
            type = "UndeadWarrior";
            break;
        case 3:
            type = "Phantom";
            break;
        case 4:
            type = "Parasprite";
            break;
        case 5:
            type = "DarkDruid";
            break;
        case 6:
            type = "BloodmoonWarrior";
            break;
        case 7:
            type = "Atis";
            break;
        case 8:
            type = "Orc";
            break;
        case 9:
            type = "OrcWarrior";
            break;
        case 10:
            type = "MushroomCreature";
            break;
        case 11:
            type = "HallowSlimer";
            break;
        case 12:
            type = "DeepwaterVilefish";
            break;
        case 13:
            type = "Crimer";
            break;
        case 14:
            type = "Bicholmere";
            break;
        case 15:
            type = "CrimsonBicholmere";
            break;
        case 16:
            type = "CorruptedBicholmere";
            break;
        case 17:
            type = "ChatteringTeeth";
            break;
        case 18:
            type = "CaveGolem";
            break;
        case 19:
            type = "ArmoredJellyfish";
            break;
        case 20:
            type = "ArchDemon";
            break;
        case 21:
            type = "OmegaWolfBanner";
            break;
        case 22:
            type = "BetaWolf";
            break;
        case 23:
            type = "AlphaWolf";
            break;
        case 24:
            type = "Abomination";
            break;
        case 25:
            type = "Blazer";
            break;
        case 26:
            type = "BoneFlyer";
            break;
        case 27:
            type = "Dinictis";
            break;
        case 28:
            type = "OrcSkeleton";
            break;
        case 29:
            type = "DragonSkull";
            break;
        case 30:
            type = "DungeonKeeper";
            break;
        case 31:
            type = "Flayer";
            break;
        case 32:
            type = "GiantCrab";
            break;
        case 33:
            type = "HeadlessZombie";
            break;
        case 34:
            type = "HeavyZombie";
            break;
        case 35:
            type = "HiveHeadZombie";
            break;
        case 36:
            type = "Observer";
            break;
        case 37:
            type = "Peepers";
            break;
        case 38:
            type = "PyramidHead";
            break;
        case 39:
            type = "SpiderMan";
            break;
        case 40:
            type = "SquidZombie";
            break;
        case 41:
            type = "SupremePossessedArmor";
            break;
        case 42:
            type = "Woody";
            break;
        case 43:
            type = "DevilishTortoise";
            break;
        case 44:
            type = "Agloomination";
            break;
        case 45:
            type = "AncientCursedSkull";
            break;
        case 46:
            type = "Banshee";
            break;
        case 47:
            type = "BoneArcher";
            break;
        case 48:
            type = "CloudSlime";
            break;
        case 49:
            type = "ConjurerSkeleton";
            break;
        case 50:
            type = "CoreBug";
            break;
        case 51:
            type = "CoreSlime";
            break;
        case 52:
            type = "Deimos";
            break;
        case 53:
            type = "Dranix";
            break;
        case 54:
            type = "DreadBeetle";
            break;
        case 55:
            type = "ElderObserver";
            break;
        case 56:
            type = "EnragedBat";
            break;
        case 57:
            type = "EvolvedZombie";
            break;
        case 58:
            type = "FallenWarrior";
            break;
        case 59:
            type = "FatFlinx";
            break;
        case 60:
            type = "FireBeetle";
            break;
        case 61:
            type = "Flayer";
            break;
        case 62:
            type = "FrostBeetle";
            break;
        case 63:
            type = "GeneralSnowman";
            break;
        case 64:
            type = "GhostKnight";
            break;
        case 65:
            type = "GiantGastropod";
            break;
        case 66:
            type = "GiantMeteorHead";
            break;
        case 67:
            type = "GraniteBeetle";
            break;
        case 68:
            type = "GraniteBowman";
            break;
        case 69:
            type = "Hallower";
            break;
        case 70:
            type = "HarpyWarrior";
            break;
        case 71:
            type = "Host";
            break;
        case 72:
            type = "IceBlazer";
            break;
        case 73:
            type = "IronGiant";
            break;
        case 74:
            type = "Leprechaun";
            break;
        case 75:
            type = "MechanicalFirefly";
            break;
        case 76:
            type = "MeteoriteGolem";
            break;
        case 77:
            type = "MightyNimbus";
            break;
        case 78:
            type = "Minotaur";
            break;
        case 79:
            type = "NightTerror";
            break;
        case 80:
            type = "PharaohCaster";
            break;
        case 81:
            type = "Phobos";
            break;
        case 82:
            type = "PossessedHornet";
            break;
        case 83:
            type = "PossessedHound";
            break;
        case 84:
            type = "QuartzBeetle";
            break;
        case 85:
            type = "Rogue";
            break;
        case 86:
            type = "SandThing";
            break;
        case 87:
            type = "ScaryBat";
            break;
        case 88:
            type = "ShadowRipper";
            break;
        case 89:
            type = "Sighted";
            break;
        case 90:
            type = "SkeletonKnight";
            break;
        case 91:
            type = "Skullker";
            break;
        case 92:
            type = "Snowcopter";
            break;
        case 93:
            type = "SnowmanBomber";
            break;
        case 94:
            type = "SnowmanWarrior";
            break;
        case 95:
            type = "TheAxeman";
            break;
        case 96:
            type = "TheGirl";
            break;
        case 97:
            type = "TheThing";
            break;
        case 98:
            type = "Thief";
            break;
        case 99:
            type = "TwilightBat";
            break;
        default:
            return;
        }
            player.NPCBannerBuff[mod.NPCType(type)] = true;
            player.hasBanner = true;
        }
    }
}}