using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class Skyline222Hair : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Skyline222's (Noire) hairstyle");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Причёска Нуар"); 
			Tooltip.SetDefault("Skyline222's fancy hairstyle");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Красивая причёска Нуар");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "Skyline222's (Noire) 的发型");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "Skyline222的花俏发型");

            ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "NoireSetBonus");
		    text.SetDefault("Increases current ranged/minion damage by 20% and adds 20% to ranged critical strike chance"
		    + "\n+40 defense"
		    + "\nPrices are lower");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Увеличивает текущий урон в дальнем бою/прислужников на 20% и добаляет 20% к шансу критического удара\n+40 защиты\nЦены в магазинах ниже");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增加20%当前远程/召唤伤害, 增加20%远程暴击率\n+40防御力\n让NPC降价");
            LocalizationLoader.AddTranslation(text);
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.value = 1650000;
			Item.rare = -11;
			Item.vanity = true;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<Items.Armor.Skyline222Body>() && legs.type == ModContent.ItemType<Items.Armor.Skyline222Legs>();
		}

		public override void UpdateArmorSet(Player player)
		{
			string NoireSetBonus = Language.GetTextValue("Mods.AlchemistNPC.NoireSetBonus");
			player.setBonus = NoireSetBonus;
			player.discount = true;
            player.statDefense += 40;
			player.GetDamage(DamageClass.Ranged) += 0.2f;
            player.GetDamage(DamageClass.Summon) += 0.2f;
            player.GetCritChance(DamageClass.Ranged) += 20;
		}
	}
}