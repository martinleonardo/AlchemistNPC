using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Placeable
{
	public class TheWorldRevolvingMusicBox : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Music Box (Deltarune OST - The World Revolving)");
			Tooltip.SetDefault("By Toby Fox");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Музыкальная шкатулка (Deltarune OST - The World Revolving)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "音乐盒 (Deltarune OST - The World Revolving)");
		}

		public override void SetDefaults()
		{
			Item.useStyle = 1;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.createTile = TileType<Tiles.TheWorldRevolvingMusicBox>();
			Item.width = 24;
			Item.height = 24;
			Item.rare = 4;
			Item.value = 500000;
			Item.accessory = true;
		}
	}
}
