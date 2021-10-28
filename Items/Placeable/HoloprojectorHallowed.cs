using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Placeable
{
	public class HoloprojectorHallowed : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Holoprojector ''Hallow''");
			Tooltip.SetDefault("Forces biome state to Hallow while placed");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Голопроектор ''Святой''");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Фиксирует Святой биом когда размещён");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "全息投影仪 ''神圣''");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "放置时强制把地形状态变为神圣");
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
			Item.createTile = TileType<Tiles.HoloprojectorHallowed>();
		}
	}
}