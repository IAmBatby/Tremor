using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class CyberStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 62;
			item.summon = true;
			item.mana = 15;
			item.width = 26;
			item.height = 28;
                                   item.expert = true;

			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.buyPrice(0, 3, 0, 0);
			item.rare = 7;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType("CyberStaffPro");
			item.shootSpeed = 2f;
			item.buffType = mod.BuffType("CyberSawBuff");
			item.buffTime = 3600;
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Cyber Staff");
      Tooltip.SetDefault("Summons a cyber saw to fight for you.");
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
			if(player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim();
			}
			return base.UseItem(player);
		}
	}
}
