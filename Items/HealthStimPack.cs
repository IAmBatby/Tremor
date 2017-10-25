using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Tremor.Items.Brass;

namespace Tremor.Items
{
	public class HealthStimPack : ModItem
	{
		public override void SetDefaults()
		{
			item.Size = new Vector2(36);
			item.maxStack = 999;
			item.rare = 11;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useStyle = 2;
			item.UseSound = SoundID.Item3;
			item.consumable = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Health Stim Pack");
			Tooltip.SetDefault("Restores 50 health\n" +
"Has no cooldown");
		}

		public override bool ConsumeItem(Player player) => true;

		public override bool UseItem(Player player)
		{
			if (player.whoAmI == Main.myPlayer)
			{
				Main.PlaySound(2, (int)player.position.X, (int)player.position.Y, 3);
				player.HealEffect(50);
				player.statLife = Math.Min(player.statLifeMax2, player.statLife + 50);
				return true;
			}
			return false;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<BrassBar>(), 2);
			recipe.AddIngredient(ItemID.SuperHealingPotion);
			recipe.AddIngredient(ItemID.BottledWater);
			recipe.AddIngredient(mod.ItemType<NightmareBar>(), 5);
			recipe.SetResult(this);
			recipe.AddTile(13);
			recipe.AddRecipe();
		}

	}
}