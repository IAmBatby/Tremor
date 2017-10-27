using Terraria;
using Terraria.ModLoader;

namespace Tremor.Ice.Items
{
	[AutoloadEquip(EquipType.Shield)]
	public class FrostGuardian : ModItem
	{
		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 34;
			item.value = 110;
			item.rare = 1;
			item.accessory = true;
			item.defense = 4;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Guardian");
			Tooltip.SetDefault("Grants immunity to all frost debuffs \n" +
"5% increased melee damage and speed");
		}

		public override void UpdateEquip(Player player)
		{
			player.moveSpeed += 0.20f;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.meleeDamage += 0.05f;
			player.meleeSpeed += 0.05f;
			player.buffImmune[44] = true;
			player.buffImmune[45] = true;
			player.buffImmune[46] = true;
			player.buffImmune[47] = true;
		}
	}
}
