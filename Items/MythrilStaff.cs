using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class MythrilStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 37;
			item.magic = true;
			item.mana = 8;
			item.width = 40;
			item.height = 40;
			item.useTime = 10;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 18440;
			item.rare = 4;
			item.UseSound = SoundID.Item82;
			item.autoReuse = false;
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			item.shoot = mod.ProjectileType("MythrilBolt");
			item.shootSpeed = 14f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mythril Staff");
			Tooltip.SetDefault("");
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MythrilBar, 12);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
