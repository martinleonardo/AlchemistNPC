using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class EaterOfWorldsBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eater Of Worlds booster");
			Tooltip.SetDefault("Increases melee speed by 5%, movement and mining speed by 25%");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Усилитель Пожирателя Миров");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Увеличивает скорость ближнего боя на 5%, скорость перелвижения и копания на 25%");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "世界吞噬者增益容器");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增加5%近战速度，增加25%移动和挖掘速度");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.consumable = false;
			Item.value = 100000;
		}

		public override bool? UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().EaterOfWorldsBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().EaterOfWorldsBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().EaterOfWorldsBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().EaterOfWorldsBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
