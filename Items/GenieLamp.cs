using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class GenieLamp : ModItem
	{
		public override void SetDefaults()
		{


			item.width = 38;
			item.height = 20;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 4;
			item.value = 40000;
			item.rare = 2;
			item.UseSound = SoundID.Item8;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Genie Lamp");
			Tooltip.SetDefault("Summons a Genie");
		}


		public override bool UseItem(Player player)
		{
			player.AddBuff(mod.BuffType("petGenie"), 2);
			for (int i = 0; i < Main.projectile.Length; i++)
				if (Main.projectile[i].type == mod.ProjectileType("projGenie") && Main.projectile[i].owner == item.owner)
					Main.projectile[i].Center = Main.player[item.owner].Center;
			return true;
		}
	}
}
