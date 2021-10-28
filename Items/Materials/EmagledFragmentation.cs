using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Materials
{
	public class EmagledFragmentation : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celestial's Particle");
			Tooltip.SetDefault("Origin of any Lunar Fragment"
				+ "\n10 of it could be transformed into 2 fragments of any type.");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(10, 4));
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Частица Божества");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "То, из чего рождаются все Лунные фрагменты\n10 могут быть преобразованы в 2 фрагмента любого типа.");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "始源碎片");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "所有天界碎片的起源. \n25片始源碎片可以转化为2片任意的天界碎片");
        }    
		public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 30;
			Item.maxStack = 999;
			Item.value = 20000;
			Item.rare = 8;
		}

	}
}
