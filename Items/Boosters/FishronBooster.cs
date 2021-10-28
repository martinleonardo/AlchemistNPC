using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class FishronBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Duke Fishron booster");
			Tooltip.SetDefault("+4% all stats up while on surface, mount is always accelerated");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Усилитель Рыброна");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Все параметры усилены на 4% когда на поверхности, ездовой питомец всегда ускорен");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "猪鲨增益容器");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "表面上的所有统计数据增加");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.consumable = false;
			Item.value = 100000;
		}

		public override bool? UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().FishronBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().FishronBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().FishronBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().FishronBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
