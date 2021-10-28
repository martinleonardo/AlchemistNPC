using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class MemerRiposte : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Memer's Riposte");
			Tooltip.SetDefault("Mirrors 500% of damage back to all enemies on screen"
			+ "\nIncrease all damage by 15%"
			+ "\nCuts your critical strike chance by 25%, but they can deal 4x damage"
			+ "\nWeakens any hostile memes");
				DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ответ Мемеру");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Отражает 500% урона обратно всем противникам на экране\nУвеличивает весь урон на 15%\nУменьшает ваш шанс критического удара вдвое, но крит может нанести 4-х кратный урон\nОслабляет любые враждебные мемы");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "Memer的反击");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "反弹500%的伤害\n增加15%全伤害\n暴击率减25%, 但是暴击能造成4倍伤害\n削弱敌对meme");
        }
	
		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 26;
			Item.value = 1000000;
			Item.rare = 11;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Generic) += 0.15f;
			if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).AutoinjectorMK2 == false)
			{
				player.GetCritChance(DamageClass.Melee) -= 25;
				player.GetCritChance(DamageClass.Magic) -= 25;
				player.GetCritChance(DamageClass.Ranged) -= 25;
				player.GetCritChance(DamageClass.Throwing) -= 25;
				// IMPLEMENT WHEN WEAKREFERENCES FIXED
				/*
				if (ModLoader.GetMod("ThoriumMod") != null)
				{
					ThoriumBoosts(player);
				}
				if (ModLoader.GetMod("Redemption") != null)
				{
					RedemptionBoost(player);
				}
				*/
			}
			if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).AutoinjectorMK2)
			{
				player.GetCritChance(DamageClass.Melee) -= 15;
				player.GetCritChance(DamageClass.Magic) -= 15;
				player.GetCritChance(DamageClass.Ranged) -= 15;
				player.GetCritChance(DamageClass.Throwing) -= 15;
				// IMPLEMENT WHEN WEAKREFERENCES FIXED
				/*
				if (ModLoader.GetMod("ThoriumMod") != null)
				{
					ThoriumBoosts(player);
				}
				if (ModLoader.GetMod("Redemption") != null)
				{
					RedemptionBoost(player);
				}
				*/
			}
			((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).MemersRiposte = true;
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
			Mod Calamity = ModLoader.GetMod("CalamityMod");
			if(Calamity != null)
			{
				Calamity.Call("AddRogueCrit", player, -25);
				if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).AutoinjectorMK2) Calamity.Call("AddRogueCrit", player, 10);
			}
			*/
		}
		
		// IMPLEMENT WHEN WEAKREFERENCES FIXED
		/*
		private void RedemptionBoost(Player player)
        {
			Redemption.Items.DruidDamageClass.DruidDamagePlayer RedemptionPlayer = player.GetModPlayer<Redemption.Items.DruidDamageClass.DruidDamagePlayer>();
			if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).AutoinjectorMK2 == false)
			{
				Redemptionplayer.GetCritChance(DamageClass.Druid) -= 25;
			}
			if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).AutoinjectorMK2)
			{
				Redemptionplayer.GetCritChance(DamageClass.Druid) -= 15;
			}
        }
		
		private void ThoriumBoosts(Player player)
        {
            ThoriumMod.ThoriumPlayer ThoriumPlayer = player.GetModPlayer<ThoriumMod.ThoriumPlayer>();
			if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).AutoinjectorMK2 == false)
			{
				Thoriumplayer.GetCritChance(DamageClass.Symphonic) -= 25;
				Thoriumplayer.GetCritChance(DamageClass.Radiant) -= 25;
			}
			if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).AutoinjectorMK2)
			{
				Thoriumplayer.GetCritChance(DamageClass.Symphonic) -= 15;
				Thoriumplayer.GetCritChance(DamageClass.Radiant) -= 15;
			}
        }
		*/
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "KnucklesUgandaDoll", 1)
				.AddIngredient(null, "BanHammer", 1)
				.AddIngredient(null, "PinkGuyHead", 1)
				.AddIngredient(null, "PinkGuyBody", 1)
				.AddIngredient(null, "PinkGuyLegs", 1)
				.AddTile(null, "MateriaTransmutator")
				.Register();
		}
	}
}