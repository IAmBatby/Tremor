using Terraria.ID;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class HeavyBeamCannon : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 52;
			item.magic = true;
			item.mana = 9;
			item.width = 42;
			item.height = 30;
			item.useTime = 40;
			item.useAnimation = 40;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 4f;
			item.value = Item.sellPrice(0, 10, 0, 0);
			item.rare = 7;
                        item.channel = true;
			item.UseSound = SoundID.Item12;

			item.autoReuse = false;
			item.shootSpeed = 25f;
			item.shoot = mod.ProjectileType("ExampleLaser");
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Heavy Beam Cannon");
      Tooltip.SetDefault("Fires a constant powerful beam");
    }



        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, -1);
        }  

	}
}
