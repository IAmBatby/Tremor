using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace Tremor.Ice.Items {
public class GlacierKnives : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 32;
        item.magic = true;
        item.width = 36;
            item.mana = 11;
        item.height = 46;

        item.useTime = 19;
        item.useAnimation = 19;
        item.useStyle = 1;
        item.noMelee = true;
        item.noUseGraphic = true;
        item.knockBack = 5;
        item.value = 10000;
        item.rare = 5;
        item.UseSound = SoundID.Item20;
        item.autoReuse = true;
           item.shoot = mod.ProjectileType("GlacierKnivesProj");
        item.shootSpeed = 1f;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Glacier Knives");
      Tooltip.SetDefault("Spreads out glacier knives");
    }

    	public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {   
            int ShotAmt = 5;
            int spread = 15; 
            float spreadMult = 0.35f;

			Vector2 vector2 = new Vector2();
			
			for(int i = 0; i < ShotAmt; i++)
            {
                float vX = 8*speedX+(float)Main.rand.Next(-spread,spread+1) * spreadMult;
                float vY = 8*speedY+(float)Main.rand.Next(-spread,spread+1) * spreadMult;
				
				float angle = (float)Math.Atan(vY/vX);
				vector2 = new Vector2(position.X+75f*(float)Math.Cos(angle), position.Y+75f*(float)Math.Sin(angle));
				float mouseX = (float)Main.mouseX + Main.screenPosition.X;
				if(mouseX < player.position.X)
				{
					vector2 = new Vector2(position.X-75f*(float)Math.Cos(angle), position.Y-75f*(float)Math.Sin(angle));
				}

               Projectile.NewProjectile(vector2.X,vector2.Y,vX,vY,mod.ProjectileType("GlacierKnivesProj"),damage,knockBack,Main.myPlayer);

     
            }
            return false;
        }
}}
