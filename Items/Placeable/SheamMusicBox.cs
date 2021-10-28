using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Placeable
{
	public class SheamMusicBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Music Box (Deltarune OST - Lantern)");
			Tooltip.SetDefault("By Toby Fox");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Музыкальная шкатулка (Deltarune OST - Lantern)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "音乐盒 (Deltarune OST - Lantern)");
		}

		public override void SetDefaults()
		{
			Item.useStyle = 1;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.createTile = TileType<Tiles.SheamMusicBox>();
			Item.width = 24;
			Item.height = 24;
			Item.rare = 4;
			Item.value = 500000;
			Item.accessory = true;
		}
	}
}
