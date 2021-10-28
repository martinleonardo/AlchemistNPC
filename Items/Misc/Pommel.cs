using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Misc
{
    public class Pommel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pommel");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Навершие");
            Tooltip.SetDefault("Contains the Light of Purity");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Хранит Свет Чистоты");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "球饰");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "包含着纯净之光");
        }
        public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 1;
			Item.value = 100000;
			Item.rare = 8;
		}
        public override void AddRecipes()
        {
            CreateRecipe()
            	.AddIngredient(ItemID.LunarBar, 5)
				.AddIngredient(ItemID.FragmentSolar, 5)
				.AddIngredient(ItemID.FragmentNebula, 5)
				.AddIngredient(ItemID.FragmentVortex, 5)
				.AddIngredient(ItemID.FragmentStardust, 5)
				.AddIngredient(null, "ChromaticCrystal", 3)
				.AddIngredient(null, "SunkroveraCrystal", 3)
				.AddIngredient(null, "NyctosythiaCrystal", 3)
            	.AddTile(TileType<Tiles.MateriaTransmutator>())
            	.Register();
        }
    }
}