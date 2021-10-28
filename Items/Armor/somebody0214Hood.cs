using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class somebody0214Hood : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("somebody0214's Hood");
			Tooltip.SetDefault("Great for impersonating a Sun Praiser!");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Капюшон somebody0214");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Отлично подходит для подражания Молящемуся Солнцу");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "somebody0214的兜帽");
            base.Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "非常适合扮演太阳歌颂者!");

            ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "somebody0214SetBonus");
		    text.SetDefault("Increases current magic damage by 30% and adds 20% to magic critical strike chance"
		    + "\n+32 defense"
		    + "\n+25% damage reduction");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Увеличивает текущий магический урон на 30% и добаляет 20% к шансу критического удара\n+32 защиты\n25% поглощение урона");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增加30%当前魔法伤害, 增加20%魔法暴击率\n+32防御力\n增加25%伤害免疫");
            LocalizationLoader.AddTranslation(text);
		}
		
		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.rare = -11;
			Item.value = 2500000;
			Item.vanity = true;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<Items.Armor.somebody0214Robe>();
		}
		
		public override void UpdateArmorSet(Player player)
		{
			string somebody0214SetBonus = Language.GetTextValue("Mods.AlchemistNPC.somebody0214SetBonus");
			player.setBonus = somebody0214SetBonus;
			player.GetDamage(DamageClass.Magic) *= 1.30f;
			player.GetCritChance(DamageClass.Magic) += 20;
			player.statDefense += 32;
			player.endurance += 0.25f;
		}
	}
}