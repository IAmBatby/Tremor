using Terraria.ID;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Linq;

namespace Tremor.Items
{
	public class BrassRapier : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 69;
			item.melee = true;
			item.width = 52;
			item.height = 54;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 12500;
			item.rare = 5;
			item.UseSound = SoundID.Item71;
			item.shoot = mod.ProjectileType("BrassCog");
			item.shootSpeed = 10f;

			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brass Rapier");
			Tooltip.SetDefault("Shoots spiky brass cogs on use");
		}


		public override void UpdateInventory(Player player)
		{
			if (Main.player[Main.myPlayer].buffType.Contains<int>(mod.BuffType("SteamSwordBuff")))
			{
				item.damage = 80;
				item.useTime = 15;
				item.useAnimation = 15;
			}
			else
			{
				item.damage = 65;
				item.useTime = 25;
				item.useAnimation = 25;
			}
		}
	}
}
