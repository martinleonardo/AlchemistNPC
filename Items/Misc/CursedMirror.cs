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
	public class CursedMirror : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cursed Mirror");
			Tooltip.SetDefault("Broken Mirror\nAll your projectiles would be reflected");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Проклятое Зеркало");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Разбитое Зеркало\nВсе ваши снаряды будут отражены");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "被诅咒的镜子");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "破碎的镜子\n你的所有抛射物都会被反弹");
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
			((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).CursedMirror = true;
		}
	}
}
