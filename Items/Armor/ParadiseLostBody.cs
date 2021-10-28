using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class ParadiseLostBody : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Paradise Lost Suit (T-03-46)");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Костюм Потерянного Рая (T-03-46)");
            Tooltip.SetDefault("''Thou shall not worry; I have heard your prayers."
            + "\nHave thou not yet realized that pain is nothing?"
            + "\nThou want me to prove the miracle."
            + "\nThou shall believe in me and granted with life. I shall show you the power.''"
                + "\n[c/FF0000:EGO armor piece]"
                + "\n+200 maximum HP"
                + "\n+25% damage reduction"
                + "\nImmune to most vanilla debuffs");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Не беспокойтесь, я услышал ваши молитвы..\nНе осознали вы ещё что боль - ничто?\nВы хотите, чтобы я доказал чудо.\nВы продолжаете верить в меня и готовы расстаться с жизнью. Я покажу вам СИЛУ.''\n[c/FF0000:Часть брони Э.П.О.С.]\n+200 к максимальному здоровью\n+25% к поглощению урона\nИммунитет к большинству стандартных дебаффов");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "失乐园上衣 (T-03-46)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'你不必担心, 我已经听到了你那略带惊恐的祈祷." +
                "\n如今, 你还没有意识到, 痛苦这种事物再微小不过了吗?" +
                "\n你要我证明奇迹." +
                "\n你应该信任我, 将生命奉献给我. 然后, 我自然会向你展示, 什么叫做力量.'" +
                "\n[c/FF0000:EGO 盔甲]" +
                "\n增加 200 最大生命值" +
                "\n增加 25% 伤害减免" +
                "\n免疫大部分原版Debuff");
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 1000000;
            Item.rare = 11;
            Item.defense = 45;
        }

        public override void UpdateEquip(Player player)
        {
            player.statLifeMax2 += 200;
            player.endurance += 0.25f;
            player.buffImmune[46] = true;
            player.noKnockback = true;
            player.fireWalk = true;
            player.buffImmune[33] = true;
            player.buffImmune[36] = true;
            player.buffImmune[30] = true;
            player.buffImmune[20] = true;
            player.buffImmune[32] = true;
            player.buffImmune[31] = true;
            player.buffImmune[35] = true;
            player.buffImmune[23] = true;
            player.buffImmune[22] = true;
            player.buffImmune[24] = true;
            player.buffImmune[39] = true;
            player.buffImmune[44] = true;
            player.buffImmune[46] = true;
            player.buffImmune[47] = true;
            player.buffImmune[69] = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(null, "TwilightSuit")
                .AddIngredient(null, "ChromaticCrystal", 10)
                .AddIngredient(null, "SunkroveraCrystal", 10)
                .AddIngredient(null, "NyctosythiaCrystal", 10)
				// IMPLEMENT WHEN WEAKREFERENCES FIXED
				/*
				if (ModLoader.GetMod("CalamityMod") != null)
				{
					.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("UeliaceBar")), 15)
					.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm")), 25)

				}
				if (ModLoader.GetMod("ThoriumMod") != null)
				{
					.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence")), 5)
					.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence")), 5)
					.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence")), 5)

				}
				*/
				.AddIngredient(null, "EmagledFragmentation", 300)
                .AddTile(null, "MateriaTransmutator")
                .Register();
        }
    }
}