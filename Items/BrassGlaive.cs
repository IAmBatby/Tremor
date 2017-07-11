using Terraria.ID;
using System;
using Terraria;
using Terraria.ID;
using System.Linq;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BrassGlaive : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 60;
			item.width = 76;
			item.height = 78;
			item.noUseGraphic = true;
			item.melee = true;
			item.useTime = 30;
			item.shoot = mod.ProjectileType("BrassGlaive");
			item.shootSpeed = 3f;
			item.useAnimation = 30;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = 1000;
			item.rare = 5;
			item.UseSound = SoundID.Item71;
			item.autoReuse = false;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Brass Glaive");
			Tooltip.SetDefault("");
		}

		public override void UpdateInventory(Player player)
		{
			if (Main.player[Main.myPlayer].buffType.Contains<int>(mod.BuffType("SteamSwordBuff")))
			{
				item.damage = 85;
			}
			else
			{
				item.damage = 60;
			}
		}
	}
}
