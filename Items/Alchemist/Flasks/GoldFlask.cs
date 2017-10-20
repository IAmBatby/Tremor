using Terraria;
using Terraria.ID;

namespace Tremor.Items.Alchemist.Flasks
{
	public class GoldFlask : AlchemistItem
	{

		public override void SetDefaults()
		{
			item.crit = 4;
			item.damage = 22;
			//item.thrown = true;
			item.width = 26;
			item.noUseGraphic = true;
			item.maxStack = 999;
			item.consumable = true;
			item.height = 30;
			item.useTime = 20;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("GoldFlaskPro");
			item.shootSpeed = 8f;
			item.useStyle = 1;
			item.knockBack = 1;
			item.UseSound = SoundID.Item106;
			item.value = 150;
			item.rare = 1;
			item.autoReuse = false;

			item.ammo = mod.ItemType("BoomFlask");
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gold Flask");
			Tooltip.SetDefault("Throws a flask that explodes into clouds\n" +
"Clouds increase the amount of coins that drop from monsters");
		}

		public override void PickAmmo(Player player, ref int type, ref float speed, ref int damage, ref float knockback)
		{
			type = mod.ProjectileType("GoldenCloudPro");
		}

		public override void UpdateInventory(Player player)
		{
			MPlayer modPlayer = MPlayer.GetModPlayer(player);
			if (modPlayer.novaHelmet)
			{
				item.autoReuse = true;
			}
			if (!modPlayer.novaHelmet)
			{
				item.autoReuse = false;
			}

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
