using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class MysteriousDrum : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 28;
			item.height = 32;
			item.maxStack = 20;
			item.useTurn = true;
			item.autoReuse = false;
			item.useAnimation = 18;
			item.useTime = 18;
			item.useStyle = 4;
			item.consumable = true;
			item.value = 150;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mysterious Drum");
			Tooltip.SetDefault("Summons Tiki Totem");
		}


		public override bool CanUseItem(Player player)
		{
			return !Main.dayTime && player.ZoneJungle && !NPC.AnyNPCs(mod.NPCType("TikiTotem"));
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("TikiTotem"));
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RichMahogany, 45);
			recipe.AddIngredient(ItemID.Stinger, 2);
			recipe.AddIngredient(ItemID.Rope, 25);
			recipe.AddIngredient(ItemID.ShadowScale, 8);
			recipe.AddIngredient(ItemID.Silk, 6);
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RichMahogany, 45);
			recipe.AddIngredient(ItemID.Stinger, 2);
			recipe.AddIngredient(ItemID.Rope, 25);
			recipe.AddIngredient(ItemID.TissueSample, 8);
			recipe.AddIngredient(ItemID.Silk, 6);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
