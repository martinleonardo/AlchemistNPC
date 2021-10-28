using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class IceGolemBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ice Golem Booster");
			Tooltip.SetDefault("Provides immunity to Chilled, Frozen and Frostburn debuffs");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Усилитель Ледяного Голема");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт невосприимчивость к Охлаждению, Заморозке и Морозному Ожогу");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "冰巨人增益容器");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "免疫寒冷，冻结和霜火");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.consumable = false;
			Item.value = 100000;
		}

		public override bool? UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().IceGolemBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().IceGolemBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().IceGolemBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().IceGolemBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
