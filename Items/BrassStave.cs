using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using System.Linq;
using Terraria.ModLoader;

namespace Tremor.Items {
public class BrassStave : ModItem
{	
		public override void SetDefaults()
		{

        item.damage = 80;
        item.magic = true;
        item.mana = 60;
        item.noMelee = true;
        item.width = 40;
        item.height = 40;
        item.useTime = 45;
        item.useAnimation = 45;
        item.useStyle = 5;
        item.value = 12500;
        item.rare = 5;
        item.UseSound = SoundID.Item43;
        item.autoReuse = false;
        item.shoot = 443;
        item.shootSpeed = 12f;


        Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Brass Stave");
      Tooltip.SetDefault("Shoots fast thin bolts\nPress RMB for powerful attack");
    }


		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
        item.damage = 80;
        item.magic = true;
        item.mana = 60;
        item.noMelee = true;
        item.width = 40;
        item.height = 40;
        item.useTime = 45;
        item.useAnimation = 45;
        item.useStyle = 5;

        item.rare = 5;
        item.UseSound = SoundID.Item43;
        item.autoReuse = false;
        item.shoot = 443;
        item.shootSpeed = 12f;
        //item.toolTip = "Shoots fast thin bolts";
        //item.toolTip2 = "Press RMB for powerful attack";
        Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			}
			else
			{
        item.damage = 65;
        item.magic = true;
        item.mana = 10;
        item.noMelee = true;
        item.width = 40;
        item.height = 40;
        item.useTime = 22;
        item.useAnimation = 22;
        item.useStyle = 5;

        item.rare = 5;
        item.UseSound = SoundID.Item43;
        item.autoReuse = true;
        item.shoot = 459;
        item.shootSpeed = 15f;
        //item.toolTip = "Shoots fast thin bolts";
        //item.toolTip2 = "Press RMB for powerful attack";
        Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
			}
			return base.CanUseItem(player);
		}


       public override void UpdateInventory(Player player)
{
if (player.altFunctionUse == 2)
{
if (Main.player[Main.myPlayer].buffType.Contains<int>(mod.BuffType("SteamMageBuff")))
{
        item.damage=100;
}
else
{
        item.damage=80;
}
}
else
{
if (Main.player[Main.myPlayer].buffType.Contains<int>(mod.BuffType("SteamMageBuff")))
{
        item.damage=80;
}
else
{
        item.damage=65;
}
}
}

	}
}
