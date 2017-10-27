using Terraria;
using Terraria.ID;

namespace Tremor.Items.Alchemist.Flasks
{
	public class DukeFlask : AlchemistItem
	{

		public override void SetDefaults()
		{
			item.crit = 4;
			item.damage = 74;
			item.width = 30;
			item.noUseGraphic = true;
			item.height = 30;
			item.useTime = 16;
			item.useAnimation = 16;
			item.shoot = mod.ProjectileType("DukeFlaskPro");
			item.shootSpeed = 9f;
			item.useStyle = 1;
			item.knockBack = 1;
			item.UseSound = SoundID.Item106;
			item.value = 20;
			item.rare = 8;
			item.maxStack = 999;
			item.consumable = true;
			item.autoReuse = false;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Duke Flask");
			Tooltip.SetDefault("Throws a flask that explodes into water tornados\n" +
"Tornados deal damage to enemies");
		}

		public override void UpdateInventory(Player player)
		{
			MPlayer modPlayer = MPlayer.GetModPlayer(player);
			if (player.FindBuffIndex(mod.BuffType("LongFuseBuff")) != -1)
			{
				item.shootSpeed = 11f;
			}
			if (player.FindBuffIndex(mod.BuffType("LongFuseBuff")) < 1)
			{
				item.shootSpeed = 8f;
			}
			if (modPlayer.core)
			{
				item.autoReuse = true;
			}
			if (!modPlayer.core)
			{
				item.autoReuse = false;
			}
		}
	}
}
