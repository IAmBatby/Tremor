using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class RoyalEgg : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 34;
			item.maxStack = 20;

			item.rare = 11;
			item.value = 150000;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Royal Egg");
			Tooltip.SetDefault("Summons the Brutallisk");
		}


		public override bool CanUseItem(Player player)
		{
			return NPC.downedMoonlord && !NPC.AnyNPCs(mod.NPCType("Brutallisk")) && player.ZoneDesert;
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Brutallisk"));
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldCoin, 25);
			recipe.AddIngredient(ItemID.Ruby, 1);
			recipe.AddIngredient(ItemID.Emerald, 1);
			recipe.AddIngredient(ItemID.Topaz, 1);
			recipe.AddIngredient(ItemID.Diamond, 1);
			recipe.AddIngredient(ItemID.Sapphire, 1);
			recipe.AddIngredient(ItemID.Amethyst, 1);
			recipe.AddIngredient(null, "NightmareBar", 10);
			recipe.AddIngredient(null, "ClusterShard", 5);
			recipe.AddIngredient(null, "Phantaplasm", 8);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
