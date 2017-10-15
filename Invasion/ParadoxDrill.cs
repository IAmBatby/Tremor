using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Invasion
{

	public class ParadoxDrill : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 9;
			item.melee = true;
			item.width = 40;
			item.height = 22;
			item.useTime = 4;
			item.useAnimation = 12;
			item.channel = true;

			item.noUseGraphic = true;
			item.noMelee = true;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 11;
			item.UseSound = SoundID.Item23;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ParadoxDrillPro");
			item.shootSpeed = 20f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paradox Drill");
			Tooltip.SetDefault("Press LMB to use drill\n" +
"Press RMB to use axe and hammer");
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				item.useStyle = 5;
				item.useTime = 15;
				item.useAnimation = 15;
				item.axe = 40;
				item.hammer = 200;
				item.pick = 0;
				item.shoot = mod.ProjectileType("ParadoxDrillPro");
			}
			else
			{
				item.useStyle = 5;
				item.useTime = 4;
				item.useAnimation = 12;
				item.axe = 0;
				item.hammer = 0;
				item.pick = 265;
				item.shoot = mod.ProjectileType("ParadoxDrillPro");
			}
			return base.CanUseItem(player);
		}
	}
}
