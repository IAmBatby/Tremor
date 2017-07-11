using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class YellowCrossguardPhasesaber : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 71;
			item.melee = true;
			item.width = 46;
			item.height = 48;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 54000;
			item.rare = 5;
			item.UseSound = SoundID.Item15;
			item.autoReuse = true;
			item.useTurn = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Yellow Crossguard Phasesaber");
			Tooltip.SetDefault("");
		}



		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 64);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3769);
			recipe.AddIngredient(ItemID.SoulofMight, 8);
			recipe.AddIngredient(null, "SoulofMind", 8);
			recipe.SetResult(this);
			recipe.AddTile(134);
			recipe.AddRecipe();
		}
	}
}
