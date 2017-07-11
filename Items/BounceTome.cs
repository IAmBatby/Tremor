using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class BounceTome : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(165);

			item.damage = 20;
			item.magic = true;
			item.width = 26;
			item.maxStack = 1;

			item.height = 30;
			item.useTime = 15;
			item.useAnimation = 15;
			item.shoot = mod.ProjectileType("Bounce");
			item.shootSpeed = 19f;
			item.useStyle = 5;
			item.knockBack = 4;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.mana = 5;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bounce Tome");
			Tooltip.SetDefault("Summons bouncy ball of gel");
		}

	}
}
