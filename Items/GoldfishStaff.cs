using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class GoldfishStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Starfury);

			item.damage = 10;
			item.melee = false;
			item.magic = true;
			item.width = 50;
			item.height = 55;
			item.useTime = 20;
			item.mana = 9;

			item.useAnimation = 50;
			item.useStyle = 5;
			item.shootSpeed = 10f;
			Item.staff[item.type] = true;
			item.knockBack = 3;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item9;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Goldfish Staff");
			Tooltip.SetDefault("Causes goldfishes to fall from the sky");
		}


		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("GoldFishPro");
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 16);
			recipe.AddIngredient(ItemID.IronBar, 6);
			recipe.AddIngredient(ItemID.Goldfish, 3);
			recipe.AddTile(18);
			recipe.SetResult(this);
			recipe.AddRecipe();


			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 16);
			recipe.AddIngredient(ItemID.LeadBar, 6);
			recipe.AddIngredient(ItemID.Goldfish, 3);
			recipe.AddTile(18);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
