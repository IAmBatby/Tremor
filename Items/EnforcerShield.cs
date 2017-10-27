using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Shield)]
	public class EnforcerShield : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 36;
			item.height = 42;
			item.value = 3000000;
			item.defense = 50;
			item.rare = 11;
			item.accessory = true;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enforcer's Shield");
			Tooltip.SetDefault("Increases melee damage and speed as health lowers\n" +
"Increased invincibility after taking damage");
		}

		public override void UpdateAccessory(Player player, bool hideVisual)

		{
			player.longInvince = true;
			if (player.statLife <= (player.statLifeMax2 * 0.8f))
			{
				player.meleeSpeed *= 1.2f;
				player.meleeDamage *= 1.05f;
			}
			else if (player.statLife <= (player.statLifeMax2 * 0.6f))
			{
				player.meleeSpeed *= 1.4f;
				player.meleeDamage *= 1.1f;
			}
			else if (player.statLife <= (player.statLifeMax2 * 0.4f))
			{
				player.meleeSpeed *= 1.6f;
				player.meleeDamage *= 1.15f;
			}
			else if (player.statLife <= (player.statLifeMax2 * 0.2f))
			{
				player.meleeSpeed *= 1.8f;
				player.meleeDamage *= 1.2f;
			}
		}

	}
}
