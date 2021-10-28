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
	[AutoloadEquip(EquipType.Body)]
	public class ReverberationBody : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reverberation Suit (T-04-53)");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Костюм Реверберации (T-04-53)");
            Tooltip.SetDefault("The sleek surface is tough as if it had been cured several times."
            + "\n[c/FF0000:EGO armor piece]"
            + "\nIncreases ranged critical strike chance by 20%");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Гладкая поверхность тверда, как будто была усилена несколько раз.\n[c/FF0000:Часть брони Э.П.О.С.]\nПовышает шанс критического удара в дальнем бою на 20%");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "余香衬衫 (T-04-53)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'经过数次加工处理后, 这件护甲的表面变得光滑而又坚硬.'\n[c/FF0000:EGO 盔甲]\n增加20%远程暴击率");
        }

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 100000;
			Item.rare = 9;
			Item.defense = 15;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Ranged) += 20;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.HallowedBar, 15)
				.AddIngredient(ItemID.DynastyWood, 150)
				.AddIngredient(ItemID.SoulofLight, 15)
				.AddIngredient(ItemID.SoulofNight, 15)
				.AddTile(null, "WingoftheWorld")
				.Register();
		}
	}
}