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
    public class MorePotionsCombination : ModItem
    {		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("More Potions Combination");
			Tooltip.SetDefault("Grants most buffs from More Potions *potions"
			+"\nDroughts, Enchanced Regeneration, Courage, Soulbinding, Diamond Skin, Dusk, Dawn, Swift Hands, Speed");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Комбинация More Potioins");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт большинство баффов от зелий мода More Potions"
			+"\nDroughts, Enchanced Regeneration, Courage, Soulbinding, Diamond Skin, Dusk, Dawn, Swift Hands, Speed");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "更多药剂整合包");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "获得大多数更多药剂的效果"
			+"\n干旱, 强化生命回复, 勇气, 灵魂绑定, 钻石皮肤, 暮光, 黎明, 快手, 速度");
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
            Item.value = Item.sellPrice(0, 20, 0, 0);
            Item.rare = 10;
            Item.buffType = ModContent.BuffType<Buffs.MorePotionsComb>();           //this is where you put your Buff
            Item.buffTime = 52000;    //this is the buff duration        10 = 10 Second
        }
		
		public override void AddRecipes()
		{
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
			CreateRecipe()
				.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("CouragePotion")), 1)
				.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("DawnPotion")), 1)
				.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("DuskPotion")), 1)
				.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("DiamondSkinPotion")), 1)
				.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("EnhancedRegenerationPotion")), 1)
				.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("GladiatorsPotion")), 1)
				.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("RangersDroughtPotion")), 1)
				.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("SoulbindingElixerPotion")), 1)
				.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("SpeedPotion")), 1)
				.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("SummonersDroughtPotion")), 1)
				.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("SwiftHandsPotion")), 1)
				.AddIngredient((ModLoader.GetMod("MorePotions").ItemType("WarriorsDroughtPotion")), 1)
				.AddTile(TileID.AlchemyTable)
				.Register();
			*/
		}
    }
}
