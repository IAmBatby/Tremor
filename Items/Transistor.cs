using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace Tremor.Items {
public class Transistor : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 133;
        item.melee = true;
        item.width = 66;
        item.height = 66;

        item.useTime = 25;
        item.useAnimation = 25;
        item.useStyle = 1;
        item.knockBack = 3;
        item.value = 13500;
        item.rare = 8;
        item.UseSound = SoundID.Item1;
        item.autoReuse = true;
            item.shoot = mod.ProjectileType("BrainiacWavePro");
            item.shootSpeed = 9f;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Transistor");
      Tooltip.SetDefault("'Crash() everyone!'\nSends energy waves in different directions on swing");
    }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 speed = new Vector2(speedX, speedY);
            speed = speed.RotatedByRandom(MathHelper.ToRadians(60));
            damage = (int)(damage);
            speedX = speed.X;
            speedY = speed.Y;
            return true;
        }
    }
}
