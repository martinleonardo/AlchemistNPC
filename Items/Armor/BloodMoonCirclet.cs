using System.Linq;
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
    public class BloodMoonCirclet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Horns Circlet");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ободок с рожками");
            Tooltip.SetDefault("Changes player's hairstyle and hair color (can be changed back by Stylist)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Меняет причёску и цвет волос (может быть изменено с помощью Стилиста)");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "角饰环");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "改变玩家的发型和发色 (可在发型师处还原)");

            ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "BloodMoonSetBonus");
            text.SetDefault("Increases all damage by 25% and adds 20% to critical strike chance"
            + "\n+36 defense"
            + "\nIncreases movement speed by 25%"
            + "\nYou have a chance to dodge attacks"
            + "\nPlayer is under permanent effect of Mage Combination");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Увеличивает весь урон на 25% и добавляет 20% к шансу критического удара\n+36 защиты\nСкорость передвижения увеличена на 25%\nПостоянный эффект комбинации Мага\nДаёт шанс увернуться при атаке");
            text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增加25%所有伤害, 增加20%暴击率\n增加36防御\n增加25%移动速度\n有概率闪避攻击\n获得永久的魔法药剂包效果");
            LocalizationLoader.AddTranslation(text);

        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 1650000;
            Item.rare = -11;
            Item.vanity = true;
        }

        //Fix when implemented
        /*
		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawHair = true;
		}
		*/

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<Items.Armor.BloodMoonDress>() && legs.type == ModContent.ItemType<Items.Armor.BloodMoonStockings>();
        }

        public override void UpdateVanity(Player player)
        {
            player.hair = 83;
            player.hairColor = new Color(240, 210, 135);
        }

        public override void UpdateArmorSet(Player player)
        {
            string BloodMoonSetBonus = Language.GetTextValue("Mods.AlchemistNPC.BloodMoonSetBonus");
            player.setBonus = BloodMoonSetBonus;
            player.statDefense += 36;
            player.moveSpeed += 0.25f;
            player.AddBuff(ModContent.BuffType<Buffs.MageComb>(), 2);
            player.blackBelt = true;
            player.GetDamage(DamageClass.Generic) += 0.25f;
            player.GetCritChance(DamageClass.Melee) += 20;
            player.GetCritChance(DamageClass.Magic) += 20;
            player.GetCritChance(DamageClass.Ranged) += 20;
            player.GetCritChance(DamageClass.Throwing) += 20;
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
            if (ModLoader.GetMod("ThoriumMod") != null)
            {
                ThoriumBoosts(player);
            }
            if (ModLoader.GetMod("Redemption") != null)
            {
                RedemptionBoost(player);
            }
            Mod Calamity = ModLoader.GetMod("CalamityMod");
            if (Calamity != null)
            {
                Calamity.Call("AddRogueCrit", player, 20);
            }
			*/
        }

        // IMPLEMENT WHEN WEAKREFERENCES FIXED
        /*
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
            Redemptionplayer.GetCritChance(DamageClass.Druid) += 20;
        }
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
            Thoriumplayer.GetCritChance(DamageClass.Symphonic) += 20;
            Thoriumplayer.GetCritChance(DamageClass.Radiant) += 20;
        }
		*/
    }
}