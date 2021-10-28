using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class Skyline222Body : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Skyline222's (Noire) shirt");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Блузка Нуар");
            Tooltip.SetDefault("Skyline222's cute shirt");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Милая блузка Нуар");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "Skyline222's (Noire) 的衬衫");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "Skyline222的可爱衬衫");
        }

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.value = 1650000;
			Item.rare = -11;
			Item.vanity = true;
		}
	}
}