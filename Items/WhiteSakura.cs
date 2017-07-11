using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class WhiteSakura : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 122;
			item.summon = true;
			item.mana = 12;
			item.width = 30;
			item.height = 28;

			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.buyPrice(0, 0, 1, 0);
			item.rare = 1;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType("WhiteSakuraPro");
			item.shootSpeed = 1f;
			item.buffType = mod.BuffType("WhiteSakuraBuff");
			item.buffTime = 3600;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("White Sakura");
			Tooltip.SetDefault("Summons a white wind to fight for you.");
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
			recipe.AddIngredient(null, "BlueSakura", 1);
			recipe.AddIngredient(null, "WhiteGoldBar", 15);
			recipe.SetResult(this);
			recipe.AddTile(null, "DivineForgeTile");
			recipe.AddRecipe();
		}
	}
}
