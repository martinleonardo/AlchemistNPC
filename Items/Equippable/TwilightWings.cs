using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Equippable
{
	[AutoloadEquip(EquipType.Wings)]
	public class TwilightWings : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Twilight Wings (O-02-63)");
            Tooltip.SetDefault("''They withstood the twilight and faced the dawn. In the forest, did the birds twitter stop?''"
            + "\n[c/FF0000:EGO Gift]"
            + "\nCounts as wings"
            + "\nHas huge wing time and excellent horizontal speed");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Крылья Сумерек (O-02-63)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Они выстояли Сумерки и встретили Закат. Прекратили ли птицы чирикать в лесу?''\n[c/FF0000:Э.П.О.С. Дар]\nСчитаются крыльями\nИмеют большое время полёта и великолепную горизонтальную скорость");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "薄暝之翼 (O-02-63)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'人们最终战胜了黄昏的黑暗, 准备面对黎明的光辉.'\n'而在那片昏暗的森林中, 鸟儿的叽喳鸣唱依旧响彻着吗?'\n[c/FF0000:EGO 礼物]\n拥有很长的飞行时间和很快的飞行速度");

            int     wingTimeMax = 240;
            float   speed = 16f;
            float   acceleration = 3.5f;

            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(wingTimeMax, speed, acceleration);
        }

		public override void SetDefaults()
		{
			Item.width = 22;
			Item.height = 20;
			Item.value = 1000000;
			Item.rare = 11;
			Item.accessory = true;
		}
		
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.AddBuff(ModContent.BuffType<Buffs.BigBirdLamp>(), 60);
			player.wingTimeMax = 240;
		}

		public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0.85f;
			ascentWhenRising = 0.15f;
			maxCanAscendMultiplier = 1f;
			maxAscentMultiplier = 4f;
			constantAscend = 0.135f;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(null, "BigBirdLamp")
				.AddIngredient(null, "EmagledFragmentation", 50)
				.AddRecipeGroup("AlchemistNPC:AnyCelestialWings")
				.AddTile(null, "WingoftheWorld")
				.Register();
		}
	}
}
