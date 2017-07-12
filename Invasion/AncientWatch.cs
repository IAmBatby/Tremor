using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class AncientWatch : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 40;
			item.height = 28;
			item.maxStack = 20;
			item.value = 100;
			item.rare = 11;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 4;
			item.consumable = true;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Watch");
			Tooltip.SetDefault("Summons Paradox Cohort");
		}


		public override bool CanUseItem(Player player)
		{
			CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>(mod);
			if (InvasionWorld.CyberWrath)
				return false;
			return true;
		}

		public override bool UseItem(Player player)
		{
			CyberWrathInvasion modPlayer = Main.player[Main.myPlayer].GetModPlayer<CyberWrathInvasion>(mod);
			Main.NewText("Paradox Cohort is striking from nowhere!", 39, 86, 134);
			Main.PlaySound(mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Wrath1"), (int)player.position.X, (int)player.position.Y, 0);
			Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
			if (Main.netMode != 1)
			{
				NPC.NewNPC((int)player.Center.X, (int)player.Center.Y - 200, mod.NPCType("Titan_"));
			}
			InvasionWorld.CyberWrath = true;
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "NightmareBar", 5);
			recipe.AddIngredient(null, "SoulofFight", 3);
			recipe.AddIngredient(ItemID.Glass, 5);
			recipe.AddIngredient(null, "HuskofDusk", 2);
			recipe.AddIngredient(null, "LapisLazuli", 1);
			recipe.SetResult(this);
			recipe.AddTile(null, "StarvilTile");
			recipe.AddRecipe();
		}
	}
}
