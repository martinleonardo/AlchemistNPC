using System.Linq;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
    public class ExecutionersEyes : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Executioner's Eyes");
            Description.SetDefault("Increases your damage by 15%, increases your critical strike chance by 5%, every crit has a 5% chance to double its damage");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = false;
            LongerExpertDebuff = false;
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Глаза Палача");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Увеличивает урон на 15%, шанс критического удара на 5%, 5% шанс на нанесение критом четырёхкратного урона");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "行刑者之眼");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "增加15%伤害,增加5%暴击率,暴击有5%概率造成4倍伤害");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if (player.buffTime[buffIndex] == 1)
            {
                player.AddBuff(ModContent.BuffType<Buffs.Exhausted>(), 3600);
            }
            player.yoraiz0rEye = 7;
            player.GetCritChance(DamageClass.Melee) += 5;
            player.GetCritChance(DamageClass.Ranged) += 5;
            player.GetCritChance(DamageClass.Magic) += 5;
            player.GetCritChance(DamageClass.Throwing) += 5;
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
                Calamity.Call("AddRogueCrit", player, 5);
            }
			*/
        }

        // IMPLEMENT WHEN WEAKREFERENCES FIXED
        /*
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
            Redemptionplayer.GetCritChance(DamageClass.Druid) += 5;
        }
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
            Thoriumplayer.GetCritChance(DamageClass.Symphonic) += 5;
            Thoriumplayer.GetCritChance(DamageClass.Radiant) += 5;
        }
		*/
    }
}
