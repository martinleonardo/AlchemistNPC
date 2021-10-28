using System.Collections.Generic;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	[AutoloadEquip(EquipType.Neck)]
	public class AlchemistNecklace : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Alchemist Necklace");
			Tooltip.SetDefault("Provides life regeneration, lowers cooldown of healing potions, and increases length of invincibility after taking damage");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ожерелье Алхимика");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Усиливает регенерацию, уменьшает откат лечебных зелий и увеличивает период неуязвимости после получения урона");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "炼金项链");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "加快生命回复速度, 减少生命药水的冷却时间, 并延长你受到伤害后的无敌时间");
        }
	
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 20;
			Item.value = 100000;
			Item.rare = 6;
			Item.accessory = true;
			Item.defense = 2;
			Item.lifeRegen = 2;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.pStone = true;
			player.longInvince = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.CharmofMyths, 1)
				.AddIngredient(ItemID.CrossNecklace, 1)
				.AddTile(TileID.TinkerersWorkbench)
				.Register();
		}
	}
}