using Terraria;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items
{
	[AutoloadEquip(EquipType.Body)]
public class SpecterChestplate : ModItem
{

    public override void SetDefaults()
    {

        item.width = 38;
        item.height = 22;

        item.value = 10000;
        item.rare = 11;
        item.defense = 22;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Specter Chestplate");
      Tooltip.SetDefault("Increases melee damage by 12%\nIncreases maximum number of minions by 2");
    }

    public override void UpdateEquip(Player player)
    {
        player.GetModPlayer<MPlayer>(mod).alchemicalDamage += 0.2f;
            player.meleeDamage += 0.12f;
            player.maxMinions += 2;
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CryptStone", 8);
            recipe.AddIngredient(null, "CursedCloth", 10);
            recipe.SetResult(this);
        recipe.AddTile(null, "MagicWorkbenchTile");
            recipe.AddRecipe();
        }
}}
