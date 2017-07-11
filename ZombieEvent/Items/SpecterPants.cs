using Terraria;
using Terraria.ModLoader;

namespace Tremor.ZombieEvent.Items
{
	[AutoloadEquip(EquipType.Legs)]
public class SpecterPants : ModItem
{

    public override void SetDefaults()
    {

        item.width = 38;
        item.height = 22;


        item.value = 10000;
        item.rare = 11;
        item.defense = 15;
    }

    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Specter Pants");
      Tooltip.SetDefault("Increases melee damage by 10%\nIncreases minion damage by 10%");
    }


    public override void UpdateEquip(Player player)
    {
            player.meleeDamage += 0.1f;
            player.minionDamage += 0.1f;
    }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "CryptStone", 5);
            recipe.AddIngredient(null, "CursedCloth", 6);
            recipe.SetResult(this);
        recipe.AddTile(null, "MagicWorkbenchTile");
            recipe.AddRecipe();
        }

}}
