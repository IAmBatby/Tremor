using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class ZombatStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 20;
			item.summon = true;
			item.mana = 10;
			item.width = 34;
			item.height = 28;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 3;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType("ZombatStaffPro");
			item.shootSpeed = 1f;
			item.buffType = mod.BuffType("ZombatBuff");
			item.buffTime = 3600;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zombat Staff");
			Tooltip.SetDefault("Summons a zombat to fight for you.");
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
			recipe.AddIngredient(ItemID.Diamond, 1);
			recipe.AddIngredient(null, "RupicideBar", 6);
			recipe.AddIngredient(null, "TearsofDeath", 6);
			recipe.SetResult(this);
			recipe.AddTile(null, "NecromaniacWorkbenchTile");
			recipe.AddRecipe();
		}
	}
}
