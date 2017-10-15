using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Tremor.Items
{
	public abstract class _InvarHeadgear : TremorAbstractItem
	{
		public override string Texture => $"{typeof(_InvarHeadgear).NamespaceToPath()}/InvarHeadgear";

		protected sealed override void Defaults()
		{
			item.width = 32;
			item.height = 26;
			item.value = Item.sellPrice(silver: 9);
			item.rare = 1;
			item.defense = 1;
		}

		protected sealed override void StaticDefaults()
		{
			DisplayName.SetDefault("Invar Headgear");
			Tooltip.SetDefault("6% increased melee damage");
		}

		public override void UpdateEquip(Player player)
		{
			player.meleeDamage += 0.06f;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType<InvarBreastplate>() && legs.type == mod.ItemType<InvarGreaves>() || body.type == mod.ItemType<ReinforcedInvarBreastplate>() && legs.type == mod.ItemType<ReinforcedInvarGreaves>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "6% increased melee damage";
			player.meleeDamage += 0.06f;
		}
	}

	[AutoloadEquip(EquipType.Head)]
	public class ReinforcedInvarHeadgear : _InvarHeadgear
	{
		public override void SafeDefaults()
		{
			item.defense += 1;
			item.value = Item.sellPrice(silver: 11);
		}

		public override void SafeStaticDefaults()
		{
			DisplayName.SetDefault("Reinforced Invar Headgear");
			Tooltip.SetDefault(Tooltip.GetDefault() + "\nReinforced to grant +1 defense");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<InvarHeadgear>());
			recipe.AddIngredient(mod.ItemType<InvarBar>(), 2);
			recipe.SetResult(this);
			recipe.AddTile(TileID.Anvils);
			recipe.AddRecipe();
		}
	}

	[AutoloadEquip(EquipType.Head)]
	public class InvarHeadgear : _InvarHeadgear
	{
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<InvarBar>(), 8);
			recipe.SetResult(this);
			recipe.AddTile(TileID.Anvils);
			recipe.AddRecipe();
		}
	}
}
