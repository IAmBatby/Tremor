using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Invasion
{
	public class EndlessPain : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 215;
			item.width = 18;
			item.height = 56;
			item.useTime = 18;
			item.magic = true;
			item.mana = 25;
			item.shoot = mod.ProjectileType("EndlessPainPro");
			item.shootSpeed = 4f;
			item.useAnimation = 18;
			item.noMelee = true;
			item.useStyle = 5;
			item.noUseGraphic = true;
			item.knockBack = 5;
			item.value = 250000;
			item.rare = 11;
			item.UseSound = SoundID.Item44;
			item.autoReuse = false;
			ItemID.Sets.ItemNoGravity[item.type] = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Endless Pain");
			Tooltip.SetDefault("Shoots a shadowflame orb\n" +
"Orb shoots shadowflames at nearby enemies");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "EyeofOblivion", 1);
			recipe.AddIngredient(null, "PhantomSoul", 20);
			recipe.AddIngredient(null, "TimeTissue", 10);
			recipe.AddIngredient(null, "NightmareBar", 5);
			recipe.AddTile(412);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
