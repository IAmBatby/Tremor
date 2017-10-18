using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ShroomiteMinigun : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 24;
			item.ranged = true;
			item.width = 58;
			item.height = 28;
			item.useTime = 7;
			item.useAnimation = 7;
			item.shoot = 14;
			item.shootSpeed = 8f;
			item.useAmmo = AmmoID.Bullet;
			item.useStyle = 5;
			item.knockBack = 4;
			item.value = 60000;
			item.rare = 8;
			item.UseSound = SoundID.Item11;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shroomite Minigun");
			Tooltip.SetDefault("");
		}

		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-18, -4);
		}

		public override bool ConsumeAmmo(Player p)
		{
			return Main.rand.NextBool(3);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShroomiteBar, 14);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
