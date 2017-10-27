using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class HarvesterScythe : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 30;
			item.melee = true;
			item.width = 66;
			item.height = 50;
			item.useTime = 24;
			item.useAnimation = 24;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = 35400;
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Harvester Scythe");
			Tooltip.SetDefault("");
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			int newLife = Main.rand.Next(damage / 4) + 3;
			Main.player[item.owner].statLife += newLife;
			Main.player[item.owner].HealEffect(newLife);
		}

	}
}
