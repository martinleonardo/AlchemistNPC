using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Placeable
{
	public class Beacon : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Beacon");
			Tooltip.SetDefault("Can be used as target for Beacon Teleporter potion while placed"
			+"\nCannot be placed if another one is already placed in the world");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Маяк");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Может быть использован в качестве цели для Телепортатора к Маяку, когда размещён\nНе может быть установлен, если он уже есть в мире");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "信标");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "放置后可以用来作为信标传送药剂的目标\n在已经放置了一个信标的情况下无法放置第二个");
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
			Item.value = 150;
			Item.createTile = TileType<Tiles.Beacon>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.CrystalBall)
				.AddIngredient(ItemID.CrystalShard, 15)
				.AddIngredient(ItemID.CursedFlame, 15)
				.AddIngredient(ItemID.SoulofLight, 10)
				.AddIngredient(ItemID.SoulofNight, 10)
				.AddRecipeGroup("AlchemistNPC:Tier3Bar", 15)
				.AddTile(TileID.MythrilAnvil)
				.Register();
			CreateRecipe()
				.AddIngredient(ItemID.CrystalBall)
				.AddIngredient(ItemID.CrystalShard, 15)
				.AddIngredient(ItemID.Ichor, 15)
				.AddIngredient(ItemID.SoulofLight, 10)
				.AddIngredient(ItemID.SoulofNight, 10)
				.AddRecipeGroup("AlchemistNPC:Tier3Bar", 15)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}