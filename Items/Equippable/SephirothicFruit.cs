using System.Collections.Generic;
using System.Linq;
using System;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using AlchemistNPC;

namespace AlchemistNPC.Items.Equippable
{
	public class SephirothicFruit : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Sephirotic Fruit");
			Tooltip.SetDefault("The last of Echidna's seeds... Holds incredible powers inside."
			+"\nIncreases minions damage by 15%"
			+"\nIncreases max amount of minions by 2"
			+"\nMinions nearly ignore enemy invincibility frames");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Плод Сефирот");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Последнее из семян Ехидны... Хранит невероятные силы внутри\nПовышает урон прислужников на 15%\nУвеличивает максимальное количество прислужников на 2\nПрислужники почти полностью игнорируют период неуязвимости у противника");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "瑟芙罗克之果");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "埃凯德娜最后的种子... 拥有不可思议的力量.\n增加15%召唤伤害\n增加2个最大召唤物数量\n召唤物无视敌人无敌帧");
        }
	
		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 100000;
			Item.rare = 11;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AlchemistNPCPlayer>().SF = true;
            player.GetDamage(DamageClass.Summon) += 0.15f;
			++player.maxMinions;
			++player.maxMinions;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.LifeFruit, 10)
				.AddIngredient(ItemID.VialofVenom, 10)
				.AddIngredient(ItemID.Nanites, 50)
				.AddIngredient(ItemID.SpectreBar, 15)
				.AddIngredient(ItemID.NecromanticScroll)
				.AddIngredient(ItemID.PygmyNecklace)
				.AddIngredient(ItemID.FragmentStardust, 30)
				.AddIngredient(ItemID.LunarBar, 15) 
				.AddIngredient(null, "EmagledFragmentation", 150)
				.AddTile(null, "MateriaTransmutator")
				.Register();
		}
	}
}