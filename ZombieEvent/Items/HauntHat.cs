using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items
{
	public class HauntHat : ModItem
	{
		public override void SetDefaults()
		{
			item.CloneDefaults(ItemID.Carrot);

                        item.useTime = 25;
                        item.useAnimation = 25;

			item.shoot = mod.ProjectileType("TheHauntPro");
			item.buffType = mod.BuffType("HauntPetBuff");
		}

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Haunt Hat");
      Tooltip.SetDefault("Summons a friendly ghost");
    }

		public override void UseStyle(Player player)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(item.buffType, 3600, true);
			}
		}
	}
}
