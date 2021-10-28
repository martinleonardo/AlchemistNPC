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
	[AutoloadEquip(EquipType.Legs)]
	public class BloodMoonStockings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood Moon stockings and boots");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Колготки и сапожки Кровавой Луны");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "血月长袜和靴子");
        }

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 1650000;
			Item.rare = -11;
			Item.vanity = true;
		}
	}
}