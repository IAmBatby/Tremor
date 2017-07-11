using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class NightDusk : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 9;
			item.melee = true;
			item.width = 46;
			item.height = 46;
			item.useTime = 12;
			item.useAnimation = 22;
			item.pick = 100;
			item.useStyle = 1;
			item.knockBack = 5;
			item.value = 600;
			item.useTurn = true;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Night Dusk");
			Tooltip.SetDefault("");
		}


		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(5) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 27);
			}
		}


		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MoltenPickaxe, 1);
			recipe.AddIngredient(ItemID.BonePickaxe, 1);
			recipe.AddIngredient(null, "PickaxeofBloom", 1);
			recipe.AddIngredient(ItemID.NightmarePickaxe, 1);
			recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
