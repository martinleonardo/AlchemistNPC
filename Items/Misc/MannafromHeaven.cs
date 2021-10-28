using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Misc
{
	class MannafromHeaven : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Manna from Heaven");
			Tooltip.SetDefault("Makes you permanently Well Fed");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Манна Небесная");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Делает вас постоянно сытым");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "天赐食粮");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "使你获得永久的'吃饱喝足'效果");

        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.width = 26;
			Item.height = 14;
			Item.value = 25000000;
		}

		public override bool CanUseItem(Player player)
		{
			return player.GetModPlayer<AlchemistNPCPlayer>().WellFed < 1;
		}

		public override bool? UseItem(Player player)
		{
			player.GetModPlayer<AlchemistNPCPlayer>().WellFed += 1;
			return true;
		}
	}
}
