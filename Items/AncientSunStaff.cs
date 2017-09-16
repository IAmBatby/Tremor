using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class AncientSunStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 80;
			item.magic = true;
			item.mana = 16;
			item.width = 88;
			item.height = 88;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = 5;
			item.shoot = mod.ProjectileType("AncientSunPro");
			item.shootSpeed = 10f;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 10;
			item.UseSound = SoundID.Item75;
			item.autoReuse = true;
			item.useTurn = false;
			Item.staff[item.type] = true;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Sun Staff");
			Tooltip.SetDefault("Summons an fiery exploding bolt");
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 64);
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "AncientTablet", 12);
			recipe.SetResult(this);
			recipe.AddTile(412);
			recipe.AddRecipe();
		}
	}
}
