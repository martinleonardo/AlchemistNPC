using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Boosters
{
	class CultistBooster : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cultist booster");
			Tooltip.SetDefault("Reduces damage taken from Pillars enemies, mobs may drop lunar fragments");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Усилитель Лунатика-Культиста");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Уменьшен урон от существ Башен, из мобов могут выпадать фрагменты");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "邪教徒增益容器");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "减少受到月柱敌人造成的伤害，小怪可能掉落月柱碎片");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.LifeFruit);
			Item.consumable = false;
			Item.value = 100000;
		}

		public override bool? UseItem(Player player)
        {
			if (player.GetModPlayer<AlchemistNPCPlayer>().CultistBooster == 0)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().CultistBooster = 1;
				return true;
			}
			if (player.GetModPlayer<AlchemistNPCPlayer>().CultistBooster == 1)
			{
				player.GetModPlayer<AlchemistNPCPlayer>().CultistBooster = 0;
				return true;
			}
			return base.UseItem(player);
		}
	}
}
