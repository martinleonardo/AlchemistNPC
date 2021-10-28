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
	[AutoloadEquip(EquipType.Legs)]
	public class ParadiseLostLegs : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Paradise Lost Leggings (T-03-46)");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Поножи Потерянного Рая (T-03-46)");
            Tooltip.SetDefault("''Thou shall not worry; I have heard your prayers."
            + "\nHave thou not yet realized that pain is nothing?"
            + "\nThou want me to prove the miracle."
            + "\nThou shall believe in me and granted with life. I shall show you the power.''"
            + "\n[c/FF0000:EGO armor piece]"
            + "\n66% increased movement speed");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Не беспокойтесь, я услышал ваши молитвы..\nНе осознали вы ещё что боль - ничто?\nВы желаете, чтобы я доказал чудо.\nВы продолжаете верить в меня и готовы расстаться с жизнью. Я покажу вам СИЛУ.''\n[c/FF0000:Часть брони Э.П.О.С.]\nУвеличивает скорость передвижения на 66%");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "失乐园护腿 (T-03-46)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'你不必担心, 我已经听到了你那略带惊恐的祈祷." +
                "\n如今, 你还没有意识到, 痛苦这种事物再微小不过了吗?" +
                "\n你要我证明奇迹." +
                "\n你应该信任我, 将生命奉献给我. 然后, 我自然会向你展示, 什么叫做力量.'" +
                "\n[c/FF0000:EGO 盔甲]" +
                "\n增加 66% 移动速度");
        }

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 1000000;
			Item.rare = 11;
			Item.defense = 40;
		}

		public override void UpdateEquip(Player player)
		{
			player.AddBuff(ModContent.BuffType<Buffs.BigBirdLamp>(), 60);
			player.moveSpeed += 0.66f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "TwilightLeggings")
				.AddIngredient(null, "ChromaticCrystal", 8)
				.AddIngredient(null, "SunkroveraCrystal", 8)
				.AddIngredient(null, "NyctosythiaCrystal", 8)
				// IMPLEMENT WHEN WEAKREFERENCES FIXED
				/*
				if (ModLoader.GetMod("CalamityMod") != null)
				{
						.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("UeliaceBar")), 11)
						.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm")), 20)
				}
				if (ModLoader.GetMod("ThoriumMod") != null)
				{
						.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence")), 4)
						.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence")), 4)
						.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence")), 4)
				}
				*/
				.AddIngredient(null, "EmagledFragmentation", 200)
				.AddTile(null, "MateriaTransmutator")
				.Register();
		}
	}
}