using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items {
public class Gurumaster : ModItem
{
    public override void SetDefaults()
    {

        item.damage = 240;
        item.width = 58;
        item.height = 30;
        item.ranged = true;
        item.useTime = 35;
        item.shoot = mod.ProjectileType("Gurumaster");
        item.shootSpeed = 15f; 
        item.useAnimation = 35;
        item.useStyle = 5;
        item.knockBack = 4;
        item.value = 1000000;
        item.rare = 11;
        item.UseSound = SoundID.Item36;
        item.autoReuse = false;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Gurumaster");
      Tooltip.SetDefault("");
    }


        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, -4);
        }  
}}
