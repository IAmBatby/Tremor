using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	[AutoloadEquip(EquipType.Shield)]
	public class HeroShield : ModItem
	{

		public override void SetDefaults()
		{

			item.width = 26;
			item.height = 26;
			item.value = 15000;
			item.rare = 8;
			item.accessory = true;
			item.defense = 8;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hero Shield");
			Tooltip.SetDefault("Grants immunity to most debuffs\n" +
"Grants immunity to knockback and fire blocks\n" +
"Prolonged after hit invicibility");
		}

		public override void UpdateEquip(Player p)
		{
			p.noKnockback = true;
			//p.paladinBuff = true;
			p.fireWalk = true;
			p.longInvince = true;
			p.buffImmune[44] = true; //Frostburn
			p.buffImmune[46] = true; //Chilled
			p.buffImmune[47] = true; //Frozen
			p.buffImmune[20] = true; //Poisoned
			p.buffImmune[22] = true; //Darkness
			p.buffImmune[24] = true; //Fire
			p.buffImmune[23] = true; //Cursed
			p.buffImmune[30] = true; //Bleeding
			p.buffImmune[31] = true; //Confused
			p.buffImmune[32] = true; //Slowed
			p.buffImmune[33] = true; //Weak
			p.buffImmune[35] = true; //Silenced
			p.buffImmune[36] = true; //Broken Armor
			p.buffImmune[69] = true; //Ichor
			p.buffImmune[70] = true; //Venom
			p.buffImmune[80] = true; //Black Out
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "HolyShield", 1);
			recipe.AddIngredient(ItemID.AnkhShield, 1);
			recipe.SetResult(this);
			recipe.AddTile(114);
			recipe.AddRecipe();
		}
	}
}
