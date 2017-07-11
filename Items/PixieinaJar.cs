using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{

	public class PixieinaJar : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 20;
			item.height = 30;
			item.maxStack = 20;


			item.rare = 5;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pixie in a Jar");
			Tooltip.SetDefault("Summons the Pixie Queen\n'I think something wants to get out of the jar...'");
		}


		public override bool CanUseItem(Player player)
		{
			return NPC.downedMechBossAny && !Main.dayTime && !NPC.AnyNPCs(mod.NPCType("PixieQueen")) && player.ZoneHoly;
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("PixieQueen"));
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bottle, 1);
			recipe.AddIngredient(ItemID.PixieDust, 25);
			recipe.AddIngredient(ItemID.SoulofLight, 15);
			recipe.AddIngredient(ItemID.CrystalShard, 20);
			recipe.AddIngredient(ItemID.HallowedBar, 6);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
