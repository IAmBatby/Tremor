using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class DeathBlaze : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 26;
			item.magic = true;
			item.width = 28;
			item.height = 30;
			item.useTime = 12;
			item.useAnimation = 12;
			item.shoot = 585;
			item.shootSpeed = 11f;
			item.mana = 4;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 99999;
			item.rare = 5;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Death Blaze");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BookofSkulls, 1);
			recipe.AddIngredient(ItemID.SpellTome, 1);
			recipe.AddIngredient(ItemID.SoulofNight, 15);
			recipe.SetResult(this);
			recipe.AddTile(101);
			recipe.AddRecipe();
		}
	}
}
