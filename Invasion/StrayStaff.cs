using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Tremor.Invasion
{
	public class StrayStaff : ModItem
	{

		public override void SetDefaults()
		{

			item.damage = 120;
			item.summon = true;
			item.mana = 12;
			item.width = 26;
			item.height = 28;

			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.noMelee = true;
			item.value = Item.buyPrice(0, 2, 0, 0);
			item.rare = 11;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType("Mini_Cyber");
			item.shootSpeed = 1f;
			item.buffType = mod.BuffType("CyberBuff");
			item.buffTime = 3600;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Stray Staff");
			Tooltip.SetDefault("Summons a cyber stray to fight for you");
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
	}
}
