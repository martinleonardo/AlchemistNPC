using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class PinkGuyBody : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Pink Guy's Suit");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Комбинезон Розового Парня"); 
			Tooltip.SetDefault("Forged from the darkest of materials. Only the best of the best can wear it.");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Скован из темнейших материалов. Лишь лучшие из лучших могут носить его.");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "Pink Guy的衣服");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "用最黑暗的材料锻造而出, 只有最棒最牛的人可以穿上它.\n温馨提示：想简单了解Pink Guy, 可以去B站搜索'Pink Guy'");
        }

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 24;
			Item.value = 1650000;
			Item.rare = -11;
			Item.vanity = true;
		}
	}
}