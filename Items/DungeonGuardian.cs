using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class DungeonGuardian : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dungeon Guardian");
			Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			item.CloneDefaults(3279);
			item.width = 30;
			item.height = 26;
			item.shoot = mod.ProjectileType("DungeonGuardianPro");
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 2;
			if (!NPC.downedBoss1)
			{
				item.damage = 15;
			}
			if (NPC.downedBoss1)
			{
				item.damage = 25;
			}
			if (NPC.downedBoss2)
			{
				item.damage = 30;
			}
			if (NPC.downedBoss3)
			{
				item.damage = 35;
			}
			if (Main.hardMode)
			{
				item.damage = 50;
			}
			if (NPC.downedMechBossAny)
			{
				item.damage = 75;
			}
			if (NPC.downedPlantBoss)
			{
				item.damage = 100;
			}
			if (NPC.downedGolemBoss)
			{
				item.damage = 125;
			}
			if (NPC.downedMoonlord)
			{
				item.damage = 175;
			}
		}
	}
}
