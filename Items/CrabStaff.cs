using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class CrabStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 15;
			item.summon = true;
			item.mana = 10;
			item.width = 34;
			item.height = 28;

			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 8000;
			item.rare = 2;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType("CrabStaffPro");
			item.shootSpeed = 1f;
			item.buffType = mod.BuffType("CrabBuff");
			item.buffTime = 3600;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crab Staff");
			Tooltip.SetDefault("Summons a little crab to fight for you.");
		}


		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			return player.altFunctionUse != 2;
		}

		public override bool UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim();
			}
			return base.UseItem(player);
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Coral, 16);
			recipe.AddIngredient(null, "SeaFragment", 5);
			recipe.AddIngredient(ItemID.Seashell, 2);
			recipe.AddIngredient(ItemID.Wood, 8);
			recipe.SetResult(this);
			recipe.AddTile(18);
			recipe.AddRecipe();
		}
	}
}
