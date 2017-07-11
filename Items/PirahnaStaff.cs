using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class PirahnaStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Starfury);

			item.damage = 18;
			item.melee = false;
			item.magic = true;
			item.width = 50;
			item.height = 55;
			item.useTime = 20;
			item.mana = 8;

			item.useAnimation = 50;
			item.useStyle = 5;
			item.shootSpeed = 10f;
			Item.staff[item.type] = true;
			item.knockBack = 3;
			item.value = 15000;
			item.rare = 3;
			item.UseSound = SoundID.Item9;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Piranha Staff");
			Tooltip.SetDefault("Causes pirahnas to fall from the sky");
		}


		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("PirahnaPro");
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GoldfishStaff", 1);
			recipe.AddIngredient(null, "SeaFragment", 10);
			recipe.AddIngredient(ItemID.GoldBar, 8);
			recipe.AddIngredient(ItemID.Ruby, 6);
			recipe.AddTile(null, "MagicWorkbenchTile");
			recipe.SetResult(this);
			recipe.AddRecipe();

			recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "GoldfishStaff", 1);
			recipe.AddIngredient(null, "SeaFragment", 10);
			recipe.AddIngredient(ItemID.PlatinumBar, 8);
			recipe.AddIngredient(ItemID.Ruby, 6);
			recipe.AddTile(null, "MagicWorkbenchTile");
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
