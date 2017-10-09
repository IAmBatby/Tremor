using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class StoneofKnowledge : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 30;
			item.maxStack = 1;

			item.rare = 12;
			item.maxStack = 20;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stone of Knowledge");
			Tooltip.SetDefault("Summons the Trinity\nRequires any mech. boss to have been slain, hardmode and night time");
		}

		public override bool CanUseItem(Player player)
		{
			return !Main.dayTime && Main.hardMode && NPC.downedMechBossAny && !NPC.AnyNPCs(mod.NPCType("SoulofHope")) && !NPC.AnyNPCs(mod.NPCType("SoulofTrust")) && !NPC.AnyNPCs(mod.NPCType("SoulofTruth"));
		}
		public override bool UseItem(Player player)
		{
			Main.NewText("The Trinity has awoken!", 175, 75, 255);
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			if (Main.netMode != 1)
			{
				int b1ID = NPC.NewNPC((int)player.Center.X - 300, (int)player.Center.Y - 800, mod.NPCType("SoulofHope"));
				int b2ID = NPC.NewNPC((int)player.Center.X, (int)player.Center.Y - 300, mod.NPCType("SoulofTrust"));
				int b3ID = NPC.NewNPC((int)player.Center.X + 100, (int)player.Center.Y - 500, mod.NPCType("SoulofTruth"));
				Main.npc[b1ID].ai[2] = b2ID;
				Main.npc[b1ID].ai[3] = b3ID;
				Main.npc[b2ID].ai[2] = b1ID;
				Main.npc[b2ID].ai[3] = b3ID;
				Main.npc[b3ID].ai[2] = b1ID;
				Main.npc[b3ID].ai[3] = b2ID;
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3467, 20);
			recipe.AddIngredient(null, "StoneDice", 1);
			recipe.AddIngredient(ItemID.CelestialSigil, 1);
			recipe.AddIngredient(null, "NightmareBar", 10);
			recipe.AddIngredient(null, "EyeofOblivion", 6);
			recipe.AddIngredient(null, "SoulofFight", 12);
			recipe.AddIngredient(ItemID.Topaz, 5);
			recipe.AddIngredient(ItemID.Ruby, 5);
			recipe.AddIngredient(ItemID.Emerald, 5);
			recipe.AddIngredient(null, "CarbonSteel", 6);
			recipe.AddIngredient(null, "Phantaplasm", 5);
			recipe.AddIngredient(null, "CosmicFuel", 1);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}

	}
}
