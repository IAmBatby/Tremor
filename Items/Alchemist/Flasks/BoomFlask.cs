using Terraria;
using Terraria.ID;

namespace Tremor.Items.Alchemist.Flasks
{
	public class BoomFlask : AlchemistItem
	{

		public override void SetDefaults()
		{
			item.crit = 4;
			item.damage = 18;
			//item.thrown = true;
			item.width = 26;
			item.noUseGraphic = true;
			item.maxStack = 999;
			item.consumable = true;
			item.height = 30;
			item.useTime = 40;
			item.useAnimation = 40;
			item.shoot = mod.ProjectileType("BoomFlaskPro");
			item.shootSpeed = 10f;
			item.useStyle = 1;
			item.knockBack = 1;
			item.UseSound = SoundID.Item106;
			item.value = 145;
			item.rare = 2;
			item.autoReuse = false;

		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Boom Flask");
			Tooltip.SetDefault("A vial of exploding chemicals");
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
