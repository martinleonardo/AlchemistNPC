using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class BloodMoonDress : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood Moon Dress");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Платье Кровавой Луны");
			Tooltip.SetDefault("Changes player's gender to female");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Меняет пол игрока на женский");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "血月裙子");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "将玩家性别变为女性");
        }

		public override void UpdateVanity(Player player)
		{
			player.Male = false;
		}
		
		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 1650000;
			Item.rare = -11;
			Item.vanity = true;
		}
	}
}