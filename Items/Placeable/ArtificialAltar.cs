using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Placeable
{
	public class ArtificialAltar : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Artificial Altar, made by occult powers");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Искусственный Алтарь");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Искусственный алтарь, созданный оккультными силами");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "人造祭坛");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "人造祭坛, 使用神秘力量制作而成");
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 28;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 10000;
			Item.createTile = TileType<Tiles.ArtificialAltar>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.EbonstoneBlock, 50)
				.AddIngredient(ItemID.RottenChunk, 15)
				.AddIngredient(ItemID.BattlePotion, 5)
				.AddIngredient(ItemID.ThornsPotion, 5)
				.AddIngredient(ItemID.Deathweed, 10)
				.AddTile(TileID.DemonAltar)
				.Register();
			CreateRecipe()
				.AddIngredient(ItemID.CrimstoneBlock, 50)
				.AddIngredient(ItemID.Vertebrae, 15)
				.AddIngredient(ItemID.BattlePotion, 5)
				.AddIngredient(ItemID.ThornsPotion, 5)
				.AddIngredient(ItemID.Deathweed, 10)
				.AddTile(TileID.DemonAltar)
				.Register();
		}
	}
}