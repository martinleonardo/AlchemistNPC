using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Placeable
{
	public class HoloprojectorSpace : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Holoprojector ''Space''");
			Tooltip.SetDefault("Forces biome state to Space while placed"
			+"\nNo visual/music effect will appear");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Голопроектор ''Космос''");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Фиксирует биом Космос когда размещён\nНикаких визуальных эффектов или музыки не появится");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "全息投影仪 ''太空''");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "放置时强制把地形状态变为太空");
        }

		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 30;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 100000;
			Item.createTile = TileType<Tiles.HoloprojectorSpace>();
		}
	}
}