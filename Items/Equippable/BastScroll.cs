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
	public class BastScroll : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bast's Scroll");
			Tooltip.SetDefault("'The strong shall hunt the weak — that is the law of nature! And my rule is law!'"
			+"\nGives effects of Master Ninja Gear"
			+"\nAllows to jump higher"
			+"\nAllows to jump 3 times"
			+"\nBonus jumps could be disabled by changing visibility of accessory"
			+"\n+10% damage reduction"
			+"\nIncreases melee/throwing damage and crits by 15%"
			+"\nMelee/throwing attacks destroy enemy defense (may not work with some weapons)"
			+"\nDefense destruction effect is global for all players"
			+"\nThrowing attacks go through tiles");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Свиток Баст");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Сильные должны охотиться на слабых - таков закон природы! И моё слово - закон!''\nДаёт все эффекты Снаряжения Мастера Ниндзя\nПозволяет прыгать выше\nПозволяет прыгать 3 раза\nДополнительные прыжки можно отключить с помощью изменения видимости аксессуара\nУменьшает получаемый урон на 10%\nПовышает урон и шанс критической атаки оружия ближнего/метательного боя на 15%\nБлижние и метательные атаки разрушают броню противника (может не работать с некоторым оружием)\nЭффект разрушения брони распространяется на все игроков\nМетательные атаки проходят сквозь блоки");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "巴斯特卷轴");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'强者猎杀弱者——那就是自然规律! 而我遵循规律!'\n给予忍者大师的效果\n让你跳的更高\n允许三段跳\n隐藏饰品可关闭三段跳\n增加10%伤害减免\n增加15%近战/投掷伤害和暴击\n攻击摧毁敌人护甲 (可能不适用于某些武器)\n穿甲效果在多人适用于所有玩家\n投掷物可穿越方块");
        }
	
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 20;
			Item.value = 100000;
			Item.rare = 11;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(ModContent.BuffType<Buffs.BastScroll>(), 60);
			player.GetModPlayer<AlchemistNPCPlayer>().Scroll = true;
			player.endurance += 0.1f;
			player.statDefense += 5;
			player.GetDamage(DamageClass.Throwing) += 0.15f;
            player.GetDamage(DamageClass.Melee) += 0.15f;
			player.GetCritChance(DamageClass.Melee) += 15;
            player.GetCritChance(DamageClass.Throwing) += 15;
			player.dash = 1;
			player.blackBelt = true;
            player.spikedBoots = 2;
			player.jumpBoost = true;
			player.noFallDmg = true;
			if (!hideVisual)
			{
				player.hasJumpOption_Sandstorm = true;
				player.hasJumpOption_Blizzard = true;
			}
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
			Mod Calamity = ModLoader.GetMod("CalamityMod");
			if(Calamity != null)
			{
				Calamity.Call("AddRogueCrit", player, 15);
			}
			*/
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.MasterNinjaGear)
				.AddIngredient(ItemID.WarriorEmblem)
				.AddIngredient(ItemID.Book)
				.AddIngredient(ItemID.BlackInk, 10)
				.AddIngredient(ItemID.VialofVenom, 10)
				.AddIngredient(ItemID.SpectreBar, 20)
				.AddIngredient(ItemID.Nanites, 10)
				.AddIngredient(ItemID.FragmentSolar, 30)
				.AddIngredient(ItemID.LunarBar, 25)
				.AddIngredient(ModContent.ItemType<Items.Materials.EmagledFragmentation>(), 250)
				.AddTile(TileType<Tiles.MateriaTransmutator>())
				.Register();
		}
	}
}