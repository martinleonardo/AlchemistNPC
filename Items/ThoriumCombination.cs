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
    public class ThoriumCombination : ModItem
    {
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thorium Combination");
			Tooltip.SetDefault("Grants most buffs from Thorium Mod potions"
			+"\nAssassin, Blood, Frenzy, Creativity, Earworm, Inspirational Reach, Glowing, Holy, Hydration");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Комбинация Thorium");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт большинство баффов от зелий мода Thorium\nAssassin, Blood, Combat, Frenzy, Creativity, Earworm, Inspirational Reach, Glowing, Holy, Hydration");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "瑟银捆绑包");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "获得瑟银的大部分药水Buff" +
                "\n嗜血, 精准, 狂热, 狂怒, 创造力, 耳虫, 灵感爆发, 光辉, 圣洁");
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
            Item.buffType = ModContent.BuffType<Buffs.ThoriumComb>();           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
        }
		
		public override void AddRecipes()
		{
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
			CreateRecipe()
				.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("AssassinPotion")), 1)
				.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("BloodPotion")), 1)
				.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("FrenzyPotion")), 1)
				.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("CreativityPotion")), 1)
				.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("EarwormPotion")), 1)
				.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InspirationReachPotion")), 1)
				.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("GlowingPotion")), 1)
				.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("HolyPotion")), 1)
				.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("HydrationPotion")), 1)
				.AddTile(TileID.AlchemyTable)
				.Register();
			*/
		}
    }
}
