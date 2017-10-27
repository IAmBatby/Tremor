using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items.Cobalt
{
	public class CobaltStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 32;
			item.magic = true;
			item.mana = 9;
			item.width = 40;
			item.height = 40;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = 13800;
			item.rare = 4;
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			item.shoot = mod.ProjectileType("CobaltBolt");
			item.shootSpeed = 12f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cobalt Staff");
			Tooltip.SetDefault("");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CobaltBar, 12);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
