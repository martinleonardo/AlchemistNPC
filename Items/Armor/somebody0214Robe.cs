using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	class somebody0214Robe : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("somebody0214's Robe");
            Tooltip.SetDefault("Great for impersonating a Sun Praiser!");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Роба somebody0214");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Отлично подходит для подражания Молящемуся Солнцу");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "somebody0214的长袍");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "非常适合扮演太阳歌颂者!");
        }
		
		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 14;
			Item.rare = -11;
			Item.value = 2500000;
			Item.vanity = true;
		}

		public override void SetMatch(bool male, ref int equipSlot, ref bool robes)
		{
			robes = true;
			equipSlot = Mod.GetEquipSlot("somebody0214Robe_Legs", EquipType.Legs);
		}
		
		//Fix when implemented
		/*
		public override void DrawHands(ref bool drawHands, ref bool drawArms)
		{
			drawHands = true;
		}
		*/
	}
}
