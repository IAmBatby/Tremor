using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class BrassChainRepeater : ModItem
{
    public override void SetDefaults()
    {

        item.ranged = true;
        item.width = 36;
        item.height = 24;


        item.useTime = 11;
        item.useAnimation = 11;
        item.shoot = 1;
	item.useAmmo = AmmoID.Arrow;
        item.shootSpeed = 30f; 
        item.useStyle = 5;
        item.damage=30;
        item.knockBack = 4;
        item.value = 30000;
        item.rare = 5;
        item.UseSound = SoundID.Item5;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Brass Chain Repeater");
      Tooltip.SetDefault("Quickly launches arrows\n25% to shoot a heat ray");
    }


       public override void UpdateInventory(Player player)
{
if (Main.player[Main.myPlayer].buffType.Contains<int>(mod.BuffType("SteamRangerBuff")))
{
        item.damage=45;
}
else
{
        item.damage=30;
}
}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
                        if(Main.rand.Next(4) == 0)
                        {
			type = 260;
                        }

			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}
}}
