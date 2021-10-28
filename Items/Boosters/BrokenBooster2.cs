using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class BrokenBooster2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Broken Booster (2)");
			Tooltip.SetDefault("Can be fixed if use certain materials");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Сломанный усилитель (2)");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Может быть починен если найти необходимые материалы");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "破损的增益容器(2)");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "使用某些材料可以修复");
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 0;
			Item.rare = 4;
		}
	}
}
