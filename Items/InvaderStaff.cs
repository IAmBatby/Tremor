using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class InvaderStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 85;
			item.summon = true;
			item.mana = 12;
			item.width = 26;
			item.height = 28;

			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.buyPrice(1, 30, 0, 0);
			item.rare = 11;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType("SpaceInvader");
			item.shootSpeed = 1f;
			item.buffType = mod.BuffType("SpaceInvaderBuff");
			item.buffTime = 3600;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Invader Staff");
			Tooltip.SetDefault("Summons a strange invader from space to fight for you.");
		}

	}
}
