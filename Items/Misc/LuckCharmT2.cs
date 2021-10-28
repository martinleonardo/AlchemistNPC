using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Misc
{
	public class LuckCharmT2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Charm of Absolute Luck");
			Tooltip.SetDefault("While this is in your inventory, you have better chance of getting better reforges"
			+"\nAlso affects accessories (Menacing->Lucky->Warding)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Талисман Абсолютной Удачи");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если находится в инвентаре, вы имеете более высокий шанс получить лучшую перековку\nРаботает и с аксессуарами (Грозный->Удачливый->Оберегающий)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "绝对幸运符咒");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "放置于物品栏时, 重铸时有更高概率获得更好的词缀\n能够影响饰品 (险恶->幸运->护佑)");
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 2000000;
			Item.rare = 8;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "LuckCharm")
				.AddIngredient(ItemID.ShroomiteBar, 10)
				.AddIngredient(ItemID.SoulofFright, 10)
				.AddIngredient(ItemID.SoulofSight, 10)
				.AddIngredient(ItemID.SoulofMight, 10)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}
