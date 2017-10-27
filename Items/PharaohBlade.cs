using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class PharaohBlade : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 25;
			item.melee = true;
			item.width = 50;
			item.height = 55;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;

			item.knockBack = 4;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pharaoh Blade");
			Tooltip.SetDefault("Allows you to get more coins for killing enemies\n" +
"'More gold for God of gold!'");
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(72, 1200);
		}

		public virtual void OnHitPvp(Item item, Player player, Player target, int damage, bool crit)
		{
			target.AddBuff(72, 1200);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3380, 8);
			recipe.AddIngredient(ItemID.Topaz, 5);
			recipe.AddIngredient(ItemID.AntlionMandible, 2);
			recipe.SetResult(this);
			recipe.AddTile(16);
			recipe.AddRecipe();
		}
	}
}
