using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public class Hurricane : ModItem
	{
		public override void SetDefaults()
		{

			item.damage = 38;

			item.magic = true;
			item.width = 28;
			item.height = 30;
			item.useTime = 36;
			item.useAnimation = 36;
			item.shoot = 704;
			item.shootSpeed = 11f;
			item.mana = 14;
			item.useStyle = 5;
			item.knockBack = 3;
			item.value = 40000;
			item.rare = 5;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Hurricane");
			Tooltip.SetDefault("Summons a sand whirlwing which moves only on ground");
		}

	}
}
