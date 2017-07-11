using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Tremor.Items {
public class StartrooperFlameburstPistol : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 248;
        item.width = 30;
        item.height = 20;
        item.ranged = true;
        item.useTime = 30;
        item.shoot = 666; 

        item.shootSpeed = 20f; 
        item.useAnimation = 30;
        item.useStyle = 5;
        item.knockBack = 5;
        item.value = 450000;
        item.useAmmo = AmmoID.Bullet;
        item.rare = 11;
        item.crit = 7;
        item.UseSound = SoundID.Item11;
        item.autoReuse = true;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Startrooper Flameburst Pistol");
      Tooltip.SetDefault("Uses bullets as ammo");
    }

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			type = 666;
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
		}

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 2);
        }  
}}
