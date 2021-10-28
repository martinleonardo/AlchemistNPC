using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class PinkGuyLegs : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pink Guy's Leggings");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Штаны Розового Парня"); 
			Tooltip.SetDefault("The perfect pants for leg day. Perhaps they could even make you stronger.");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Превосходные штаны для пробежки. Возможно, могут даже сделать вас сильнее.");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "Pink Guy的裤子");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "为练腿日存在完美的裤子.甚至会让你更强壮.");
        }

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 16;
			Item.value = 1650000;
			Item.rare = -11;
			Item.vanity = true;
		}
	}
}