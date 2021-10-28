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
	public class StatsChecker2 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pip-Boy 4K");
			Tooltip.SetDefault("Shows most of the player's stats while in your inventory"
			+"\nLeft click to teleport home, hotkey to open teleportation menu");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Пип-Бой 4K");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Если находится в инвентаре, то показывает большинство параметров игрока\nЛевый клик телепортирует вас домой, горячая клавиша открывает телепортационное меню");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "哔哔小子 4K");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "放置于物品栏时, 显示玩家的绝大部分属性\n左键传送回家, 使用快捷键打开传送菜单");
        		
			ModTranslation text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy4ktext1");
            		text.SetDefault("Melee damage/critical strike chance boosts are ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "近战伤害/暴击率增加");
            		LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy4ktext2");
            		text.SetDefault("Ranged damage/critical strike chance boosts are ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "远程伤害/暴击率增加");
            		LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy4ktext3");
            		text.SetDefault("Magic damage/critical strike chance boosts are ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "魔法伤害/暴击率增加");
            		LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy4ktext4");
            		text.SetDefault("Thrown damage/critical strike chance boosts are ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "投掷伤害/暴击率增加");
            		LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy4ktext5");
            		text.SetDefault("Summoner damage boost is ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "召唤伤害增加");
            		LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy4ktext6");
            		text.SetDefault("Damage Reduction boost is ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "伤害抗性增加");
            		LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy4ktext7");
            		text.SetDefault("Movement speed boost is ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "移动速度增加");
            		LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy4ktext8");
            		text.SetDefault("Max life boost is ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "最大生命增加");
            		LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy4ktext9");
            		text.SetDefault("Life regeneration is ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "生命再生速度");
            		LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy4ktext10");
            		text.SetDefault("Mana usage reduction is ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "魔法消耗减少");
            		LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy4ktext11");
            		text.SetDefault("Max amounts of minions/sentries are ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "最大召唤物/炮台数量");
            		LocalizationLoader.AddTranslation(text);
			
			text = LocalizationLoader.CreateTranslation(Mod, "Pip-Boy4ktext12");
            		text.SetDefault("Melee swing time is ");
			text.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "近战武器挥动");
            		LocalizationLoader.AddTranslation(text);
	}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.MagicMirror);
			Item.width = 32;
			Item.height = 32;
			Item.value = 5000000;
			Item.rare = 8;
			Item.useAnimation = 15;
            Item.useTime = 15;
			Item.consumable = false;
			Item.noUseGraphic = true;
		}
		
		public override bool? UseItem(Player player)
		{
			player.Spawn(PlayerSpawnContext.RecallFromItem);
			return true;
		}
		
		public override void UpdateInventory(Player player)
		{
			((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).PB4K = true;
			player.accWatch = 3;
			player.accDepthMeter = 1;
			player.accCompass = 1;
			player.accFishFinder = true;
			player.accWeatherRadio = true;
			player.accCalendar = true;
			player.accThirdEye = true;
			player.accJarOfSouls = true;
			player.accCritterGuide = true;
			player.accStopwatch = true;
			player.accOreFinder = true;
			player.accDreamCatcher = true;
		}
		
		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			Player player = Main.player[Main.myPlayer];
			string text1 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy4ktext1") + (int)((player.GetDamage(DamageClass.Melee)*100)-100) + "%" + " / " + (player.GetCritChance(DamageClass.Melee)-4) + "%";
			string text2 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy4ktext2") + (int)((player.GetDamage(DamageClass.Ranged)*100)-100) + "%" + " / " + (player.GetCritChance(DamageClass.Ranged)-4) + "%";
			string text3 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy4ktext3") + (int)((player.GetDamage(DamageClass.Magic)*100)-100) + "%" + " / " + (player.GetCritChance(DamageClass.Magic)-4) + "%";
			string text4 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy4ktext4") + (int)((player.GetDamage(DamageClass.Throwing)*100)-100) + "%" + " / " + (player.GetCritChance(DamageClass.Throwing)-4) + "%";
			string text5 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy4ktext5") + (int)((player.GetDamage(DamageClass.Summon)*100)-100) + "%";
			string text6 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy4ktext6") + (int)(player.endurance*100) + "%";
			string text7 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy4ktext7") + (int)((player.moveSpeed*100)-100) + "%";
			string text8 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy4ktext8") + (player.statLifeMax2 - player.statLifeMax);
			string text9 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy4ktext9") + (player.lifeRegen);
			string text10 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy4ktext10") + (int)((player.manaCost*100)-100) + "%";
			string text11 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy4ktext11") + player.maxMinions + " / " + player.maxTurrets;
			string text12 = Language.GetTextValue("Mods.AlchemistNPC.Pip-Boy4ktext12") + (int)(player.meleeSpeed*100) + "%";
			TooltipLine line = new TooltipLine(Mod, "text1", text1);
			TooltipLine line2 = new TooltipLine(Mod, "text2", text2);
			TooltipLine line3 = new TooltipLine(Mod, "text3", text3);
			TooltipLine line4 = new TooltipLine(Mod, "text4", text4);
			TooltipLine line5 = new TooltipLine(Mod, "text5", text5);
			TooltipLine line6 = new TooltipLine(Mod, "text6", text6);
			TooltipLine line7 = new TooltipLine(Mod, "text7", text7);
			TooltipLine line8 = new TooltipLine(Mod, "text8", text8);
			TooltipLine line9 = new TooltipLine(Mod, "text9", text9);
			TooltipLine line10 = new TooltipLine(Mod, "text10", text10);
			TooltipLine line11 = new TooltipLine(Mod, "text11", text11);
			TooltipLine line12 = new TooltipLine(Mod, "text12", text12);
			line.overrideColor = Color.Red;
			line2.overrideColor = Color.LimeGreen;
			line3.overrideColor = Color.SkyBlue;
			line4.overrideColor = Color.Orange;
			line5.overrideColor = Color.MediumVioletRed;
			line6.overrideColor = Color.Gray;
			line7.overrideColor = Color.Green;
			line8.overrideColor = Color.Yellow;
			line9.overrideColor = Color.Brown;
			line10.overrideColor = Color.SkyBlue;
			line11.overrideColor = Color.Magenta;
			line12.overrideColor = Color.Red;
			tooltips.Insert(2,line);
			tooltips.Insert(3,line2);
			tooltips.Insert(4,line3);
			tooltips.Insert(5,line4);
			tooltips.Insert(6,line5);
			tooltips.Insert(7,line6);
			tooltips.Insert(8,line7);
			tooltips.Insert(9,line8);
			tooltips.Insert(10,line9);
			tooltips.Insert(11,line10);
			tooltips.Insert(12,line11);
			tooltips.Insert(13,line12);
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<Items.Misc.StatsChecker>())
				.AddIngredient(ItemID.CellPhone)
				.AddIngredient(ModContent.ItemType<Items.BeachTeleporterPotion>(), 10)
				.AddIngredient(ModContent.ItemType<Items.OceanTeleporterPotion>(), 10)
				.AddIngredient(ModContent.ItemType<Items.DungeonTeleportationPotion>(), 10)
				.AddIngredient(ModContent.ItemType<Items.UnderworldTeleportationPotion>(), 10)
				.AddIngredient(ModContent.ItemType<Items.JungleTeleporterPotion>(), 10)
				.AddIngredient(ModContent.ItemType<Items.TempleTeleportationPotion>(), 10)
				.AddTile(TileID.TinkerersWorkbench)
				.Register();
		}
	}
}
