using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class YinYangLance : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 30;
			item.melee = true;
			item.width = 32;
			item.height = 32;
			item.useTime = 11;
			item.useAnimation = 9;
			item.useStyle = 3;
			item.knockBack = 0;
			item.value = 2800;
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Yin Yang Lance");
			Tooltip.SetDefault("");
		}


		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(31, 60);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "RipperKnife");
			recipe.AddIngredient(ItemID.DarkShard, 1);
			recipe.AddIngredient(ItemID.LightShard, 1);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
