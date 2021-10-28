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
	public class TimeTwistBraclet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Braclet of Time Twist");
			Tooltip.SetDefault("Gives a chance to get double loot from defeated mobs"
			+"\nLowers defense/damage reduction by 20/20%");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Браслет Искривления Времени");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Даёт шанс получить удвоенный лут с убитых мобов\nПонижает защиту/сопротивление урону на 20/20%");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "时空扭曲手镯");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "从打败的敌人身上有几率双倍掉落\n降低20%伤害减免和20防御");
		}
	
		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 20;
			Item.value = 1000000;
			Item.rare = 6;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<AlchemistNPCPlayer>().TimeTwist = true;
			player.endurance -= 0.2f;
			player.statDefense -= 20;
		}
	}
}