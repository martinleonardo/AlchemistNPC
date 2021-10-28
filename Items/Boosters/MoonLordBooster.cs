using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class MoonLordBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moon Lord booster");
			Tooltip.SetDefault("You emit aura which weakens enemies around");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Усилитель Лунного Лорда");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Вы испускаете ослабляющую ауру вокруг себя");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "月球领主增益容器");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你产生能弱化周围敌人的光环");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.consumable = false;
			Item.value = 100000;
		}

		public override bool? UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().MoonLordBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().MoonLordBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().MoonLordBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().MoonLordBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
