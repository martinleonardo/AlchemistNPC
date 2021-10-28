using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Placeable
{
	public class Wellcheers : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("'Wellcheers' Vending Machine");
			Tooltip.SetDefault("'Opened can of Wellcheers' Vending Machine"
			+ "\n[c/FF0000:Abnormality]"
			+ "\nRisk level: [c/00FF00:ZAYIN]"
			+ "\nProduces 4 different types of Soda"
			+ "\nWorks only on Night Time"
			+ "\nCan be used 10 times without any consequences");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Машина по продаже напитков 'Wellcheers'");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Машина по продаже напитков 'Opened can of Wellcheers'\n[c/FF0000:Аномалия]\nУровень риска: [c/00FF00:ZAYIN]\nПроизводит 4 различных вида Соды\nРаботает только ночью\nМожет быть использована 10 раз без последствий");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "韦尔奇乐自动售货机");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'韦尔奇乐牌汽水'自动售货机\n[c/FF0000:异常]\n危险等级: [c/00FF00:ZAYIN]\n贩卖4种不同苏打水\n只在夜晚工作\n可以无条件使用10次");
        }

		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 30;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 150;
			Item.createTile = TileType<Tiles.Wellcheers>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.HallowedBar, 25)
				.AddIngredient(ItemID.SoulofSight, 5)
				.AddIngredient(ItemID.SoulofMight, 5)
				.AddIngredient(ItemID.SoulofFright, 5)
				.AddTile(null, "WingoftheWorld")
				.Register();
		}
	}
}