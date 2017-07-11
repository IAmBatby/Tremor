using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BirbStaff : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 7;
			item.summon = true;
			item.mana = 10;
			item.width = 46;
			item.height = 46;

			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.noMelee = true;
			item.knockBack = 4;
			item.value = 8000;
			item.rare = 2;
			item.UseSound = SoundID.Item44;
			item.shoot = mod.ProjectileType("BirbStaffPro");
			item.shootSpeed = 1f;
			item.buffType = mod.BuffType("BirbStaffBuff");
			item.buffTime = 3600;
		}  

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Birb Staff");
      Tooltip.SetDefault("Summons a birb to fight for you.");
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
