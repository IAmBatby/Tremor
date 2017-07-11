using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class DoomKey : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 30;
			item.height = 30;
			item.maxStack = 1;

			item.rare = 4;
			item.maxStack = 20;
			item.useAnimation = 45;
			item.useTime = 45;
			item.useStyle = 4;
			item.UseSound = SoundID.Item44;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Doom Key");
			Tooltip.SetDefault("Summons the Skeletron");
		}


		public override bool CanUseItem(Player player)
		{
			return !Main.dayTime && !NPC.AnyNPCs(35);
		}

		public override bool UseItem(Player player)
		{
			NPC.SpawnOnPlayer(player.whoAmI, 35);
			Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "CursedSoul", 1);
			recipe.AddIngredient(ItemID.Bone, 25);
			recipe.SetResult(this);
			recipe.AddTile(26);
			recipe.AddRecipe();
		}

	}
}
