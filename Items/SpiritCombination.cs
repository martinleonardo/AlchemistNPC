using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
 
namespace AlchemistNPC.Items
{
    public class SpiritCombination : ModItem
    {
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spirit Combination");
			Tooltip.SetDefault("Grants most buffs from Spirit Mod potions (Runescribe, Soulguard, Spirit, Starburn, Steadfast and Toxin)");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Комбинация Spirit");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт большинство баффов от зелий мода Spirit (Runescribe, Soulguard, Spirit, Starburn, Steadfast and Toxin)");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "魂灵药剂包");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "获得大部分魂灵Buff (符文之力, 灵魂之护, 魂灵, 星之燃烧, 坚定和毒素)");
		}    

		public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item3;                 //this is the sound that plays when you use the item
            Item.useStyle = 2;                 //this is how the item is holded when used
            Item.useTurn = true;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.maxStack = 99;                 //this is where you set the max stack of item
            Item.consumable = true;           //this make that the item is consumable when used
            Item.width = 32;
            Item.height = 32;
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.rare = 10;
            Item.buffType = ModContent.BuffType<Buffs.SpiritComb>();           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
        }
		
		public override void AddRecipes()
		{
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
			CreateRecipe()
				.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("BismitePotion")), 1)
				.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("RunePotion")), 1)
				.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("SoulPotion")), 1)
				.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("SpiritPotion")), 1)
				.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("StarPotion")), 1)
				.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("TurtlePotion")), 1)
				.AddTile(TileID.AlchemyTable)
				.Register();
			*/
		}
    }
}
