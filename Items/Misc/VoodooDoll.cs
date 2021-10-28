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
	public class VoodooDoll : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Voodoo Doll");
			Tooltip.SetDefault("Your very own doll\nWill make you take part of your dealt damage");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Кукла Вуду");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Ваша кукла\nЗаставляет вас получать часть урона, наносимого боссу");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "巫毒娃娃");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "你自己的娃娃\n所造成伤害的一部分会施加给自己");
        }

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.value = 0;
			Item.rare = 5;
		}
		
		public override void UpdateInventory(Player player)
		{
		((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).Voodoo = true;
		}
	}
}
