using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class Skyline222Legs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skyline222's (Noire) skirt");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Юбка Нуар"); 
			Tooltip.SetDefault("Skyline222's short skirt with boots");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Коротенькая юбка Нуар с ботинками");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "Skyline222 (Noire) 的裙子");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "Skyline222的短裙, 配有一双靴子");
        }

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 16;
			Item.value = 1650000;
			Item.rare = -11;
			Item.vanity = true;
		}
	}
}