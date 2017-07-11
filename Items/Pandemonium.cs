using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace Tremor.Items
{
    public class Pandemonium : ModItem
    {
        public override void SetDefaults()
        {

            item.damage = 320;
            item.ranged = true;
            item.width = 52;
            item.height = 34;
            item.useTime = 3;
            item.useAnimation = 12;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 4f;
            item.value = 600000;
            item.rare = 0;
            item.UseSound = SoundID.Item92;
            item.autoReuse = false;
            item.shootSpeed = 25f;
            item.shoot = mod.ProjectileType("PandemoniumBullet");
            item.useAmmo = AmmoID.Bullet;	
        }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Pandemonium");
      Tooltip.SetDefault("Shoots a burst of bullets\nBullets explode into firebals\n75% chance not to consume ammo");
    }


        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
        {
            tooltips[0].overrideColor = new Color(238, 194, 73);
        }

        public override bool ConsumeAmmo(Player player)
        {
            if (Main.rand.Next(0, 100) <= 75)
                return false;
            return true;
        }

        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float SpeedX = speedX + (float)Main.rand.Next(-15, 16) * 0.05f;
            float SpeedY = speedY + (float)Main.rand.Next(-15, 16) * 0.05f;
            Projectile.NewProjectile(position.X, position.Y, SpeedX, SpeedY, type, damage, knockBack, player.whoAmI, 0.0f, 0.0f);
            if (Main.rand.Next(2) == 0)
                Projectile.NewProjectile(position.X, position.Y, SpeedX, SpeedY, mod.ProjectileType("PandemoniumBullet"), damage, knockBack, player.whoAmI, 0.0f, 0.0f);
            return false;
        }
    }
}
