using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Placeable
{
	public class HoloprojectorSnow : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Holoprojector ''Snow''");
			Tooltip.SetDefault("Forces biome state to Snow while placed");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Голопроектор ''Зимний''");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Фиксирует Зимний биом когда размещён");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "全息投影仪 ''冰雪''");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "放置时强制把地形状态变为冰雪");
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
			Item.createTile = TileType<Tiles.HoloprojectorSnow>();
		}
	}
}