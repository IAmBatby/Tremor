using Terraria;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class DimensionalTopHat : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 22;
			item.height = 18;
			item.value = 456600;
			item.rare = 11;
			item.defense = 12;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dimensional Top Hat");
			Tooltip.SetDefault("Grants clairvoyance\n" +
"25% increased magic and minion damage\n" +
"Greatly increases mana regeneration");
		}

		public override void UpdateEquip(Player player)
		{
			player.minionDamage += 0.25f;
			player.magicDamage += 0.25f;
			player.AddBuff(29, 60, true);
			player.manaRegen += 25;
		}

	}
}
