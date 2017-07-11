using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BoneRepeater : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 28;

			item.width = 18;
			item.height = 56;
			item.ranged = true;
			item.useTime = 30;
			item.shoot = 1;
			item.shootSpeed = 12f;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 1.8f;
			item.value = 2500;
			item.useAmmo = 154;
			item.rare = 3;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bone Repeater");
			Tooltip.SetDefault("Uses bones as ammo");
		}


		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = mod.ProjectileType("BoneBoltPro");
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HellstoneBar, 8);
			recipe.AddIngredient(null, "PetrifiedSpike", 15);
			recipe.AddIngredient(null, "SharpenedTooth", 9);
			recipe.AddTile(18);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
