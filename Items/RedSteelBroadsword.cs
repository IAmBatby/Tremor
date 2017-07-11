using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class RedSteelBroadsword : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 16;
			item.melee = true;
			item.width = 34;
			item.height = 36;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 5;

			item.value = 600;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Steel Broadsword");
			Tooltip.SetDefault("25% chance to confuse enemy");
		}


		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.Next(4) == 0)
			{
				target.AddBuff(31, 600);
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "ChippyRedSteelSword", 1);
			recipe.AddIngredient(null, "RedSteelBar", 11);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}

	}
}
