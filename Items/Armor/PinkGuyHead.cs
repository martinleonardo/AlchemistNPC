using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class PinkGuyHead : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pink Guy's Hood");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Капюшон Розового Парня"); 
			Tooltip.SetDefault("Could this be a legendary piece of clothing? No one knows, but once you wear it, you can't go back.");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Возможно, это легендарное одеяние? Никто не знает, но, одев его однажды, вы уже не сможете его снять.");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "Pink Guy的兜帽");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "也许是个传奇的衣服？没人知道, 但是一旦你穿上它, 你就再也回不来了.");

            ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "PGSetBonus");
		    text.SetDefault("Increases current ranged/melee damage by 15% and adds 15% to ranged/melee critical strike chance"
		    + "\n+56 defense"
		    + "\nIncreases movement speed greatly"
		    + "\nPlayer is under permanent effect of Tank Combination"
            + "\nNational Ugandan Treasure can now be dropped from Moon Lord");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Увеличивает текущий урон в дальнем/ближнем бою на 15% и добавляет 15% к шансу критического удара\n+56 защиты\nИгрок находится под постоянным эффектом комбинации Танка\nНациональное Сокровище Уганды может выпасть с Лунного Лорда");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增加15%当前近战/远程伤害, 增加15%近战/远程暴击率"
            + "\n增加 56 防御力"
            + "\n极大增加移动速度"
            + "\n给予永久坦克药剂包效果"
            + "\n乌干达国宝现在可以从月亮领主身上掉落");
            LocalizationLoader.AddTranslation(text);
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 1650000;
			Item.rare = -11;
			Item.vanity = true;
		}
		
		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<Items.Armor.PinkGuyBody>() && legs.type == ModContent.ItemType<Items.Armor.PinkGuyLegs>();
		}

		public override void UpdateArmorSet(Player player)
		{
			AlchemistNPCPlayer modPlayer = player.GetModPlayer<AlchemistNPCPlayer>();
            modPlayer.PGSWear = true;
            string PGSetBonus = Language.GetTextValue("Mods.AlchemistNPC.PGSetBonus");
			player.setBonus = PGSetBonus;
            player.statDefense += 56;
			player.GetDamage(DamageClass.Ranged) += 0.15f;
            player.GetDamage(DamageClass.Melee) += 0.15f;
            player.GetCritChance(DamageClass.Ranged) += 15;
			player.GetCritChance(DamageClass.Melee) += 15;
			player.moveSpeed += 0.50f;
			player.AddBuff(ModContent.BuffType<Buffs.TankComb>(), 2);
		}
	}
}