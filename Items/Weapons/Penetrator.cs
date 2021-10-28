using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.Utilities;

namespace AlchemistNPC.Items.Weapons
{
    public class Penetrator : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Penetrator");
            Tooltip.SetDefault("Pretty slow, unpleasent looking rifle"
            + "\n[c/00FF00:Legendary Weapon]"
            + "\nCritical hits damage varies from 3x to 6x"
            + "\nUses health instead of ammo"
            + "\n[c/00FF00:Stats are growing up through progression]"
            + "\nBoosted stats will be shown after the first use");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пронзатель");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Довольно медленная, неприятно выглядящая винтовка\n[c/00FF00:Легендарное Оружие]\nПробивает значительное количество противников одним выстрелом\nКритические попадания наносят вариативный урон (от 3 до 6-кратного)\nОтнимает по 3 очка здоровья за выстрел\n[c/00FF00:Показатели увеличивается по мере прохождения]");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "洞察者");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "非常缓慢, 看起来让人不愉快的步枪"
            + "\n[c/00FF00:传奇武器]"
            + "\n暴击伤害从3倍到6倍浮动"
            + "\n消耗生命而不是弹药"
            + "\n[c/00FF00:属性随进程成长]"
            + "\n提升过后的属性将会在使用后显示");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.SniperRifle);
            Item.damage = 15;
            Item.crit = 45;
            Item.autoReuse = true;
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.ammo = 0;
            Item.useAmmo = 0;
        }

        public override int ChoosePrefix(UnifiedRandom rand)
        {
            return 82;
        }

        public override bool CanUseItem(Player player)
        {
            if (NPC.downedSlimeKing)
            {
                Item.damage = 25;
            }
            if (NPC.downedBoss1)
            {
                Item.damage = 30;
            }
            if (NPC.downedBoss2)
            {
                Item.damage = 35;
            }
            if (NPC.downedQueenBee)
            {
                Item.damage = 40;
            }
            if (NPC.downedBoss3)
            {
                Item.damage = 45;
            }
            if (Main.hardMode)
            {
                Item.damage = 55;
            }
            if (NPC.downedMechBossAny)
            {
                Item.damage = 65;
            }
            if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
            {
                Item.damage = 80;
            }
            if (NPC.downedPlantBoss)
            {
                Item.damage = 100;
            }
            if (NPC.downedGolemBoss)
            {
                Item.damage = 125;
            }
            if (NPC.downedFishron)
            {
                Item.damage = 175;
            }
            if (NPC.downedAncientCultist)
            {
                Item.damage = 250;
            }
            if (NPC.downedMoonlord)
            {
                Item.damage = 500;
            }
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
            Mod Calamity = ModLoader.GetMod("CalamityMod");
            if (Calamity != null)
            {
                if ((bool)Calamity.Call("Downed", "profaned guardians"))
                {
                    Item.damage = 600;
                }
            }
            if (ModLoader.GetMod("ThoriumMod") != null)
            {
                if (ThoriumModDownedRagnarok)
                {
                    Item.damage = 750;
                }
            }
            if (Calamity != null)
            {
                if ((bool)Calamity.Call("Downed", "providence"))
                {
                    Item.damage = 1000;
                }
                if ((bool)Calamity.Call("Downed", "polterghast"))
                {
                    Item.damage = 1350;
                }
                if ((bool)Calamity.Call("Downed", "dog"))
                {
                    Item.damage = 3000;
                }
                if ((bool)Calamity.Call("Downed", "yharon"))
                {
                    Item.damage = 5000;
                }
                if ((bool)Calamity.Call("Downed", "supreme calamitas"))
                {
                    Item.damage = 10000;
                }
            }
			*/
            return true;
        }

		// IMPLEMENT WHEN WEAKREFERENCES FIXED
		/*
        public bool ThoriumModDownedRagnarok
        {
            get { return ThoriumMod.ThoriumWorld.downedRealityBreaker; }
        }
		*/

        public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.statLife -= 3;
            if (player.statLife <= 0)
            {
                PlayerDeathReason damageSource = PlayerDeathReason.ByOther(13);
                if (player.Male) damageSource = PlayerDeathReason.ByCustomReason(player.name + " drained himself to death.");
                if (!player.Male) damageSource = PlayerDeathReason.ByCustomReason(player.name + " drained herself to death.");
                player.KillMe(damageSource, 1.0, 0, false);
            }
            type = 638;
            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, 0);
        }
    }
}