using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class CustomBooster2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Custom Booster 2");
			Tooltip.SetDefault("Provides immunity to fire blocks, gives Obsidian Skin, Gills and Flipper effects");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Выборочный усилитель 2");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт иммунитет к огненным блокам, даёт эффекты Жабр и Обсидиановой Кожи");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "普通增益容器2号");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "给予免疫火块，黑曜石皮肤，鱼鳃，脚蹼药剂效果");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.consumable = false;
			Item.value = 100000;
		}

		public override bool? UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().CustomBooster2 == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().CustomBooster2 = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().CustomBooster2 == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().CustomBooster2 = 0;
				return true;
			}
			return base.UseItem(player);
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<Items.Boosters.BrokenBooster2>(), 1)
				.AddIngredient(ItemID.ObsidianSkinPotion, 30)
				.AddIngredient(ItemID.GillsPotion, 30)
				.AddIngredient(ItemID.FlipperPotion, 30)
				.AddRecipeGroup("AlchemistNPC:EvilBar", 8)
				.AddRecipeGroup("AlchemistNPC:EvilComponent", 15)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}
