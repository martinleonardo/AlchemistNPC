using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class KingSlimeBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("King Slime booster");
			Tooltip.SetDefault("Increases jump height and safe fall distance greatly");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Усилитель Короля Слизней");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Увеличивает высоту прыжка и увеличивает расстояние безопасного падения");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "冰巨人增益容器");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "极大提升跳跃高度和安全坠落距离");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.consumable = false;
			Item.value = 100000;
		}

		public override bool? UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().KingSlimeBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().KingSlimeBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().KingSlimeBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().KingSlimeBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
