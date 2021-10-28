using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class SoulOfVision : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul Of Vision");
			Tooltip.SetDefault("''I can see everything!''"
				+ "\nFree ores, treasures, creatures and traps vision");
				DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Душа Видения");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Я вижу всё''\nСвободное видение сокровищ, руд, существ и ловушек");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "全视之魂");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "''我无所不见!''\n高亮矿物, 宝物, 生物和陷阱");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(4, 15));
        }
	
		public override void SetDefaults()
		{
			Item.stack = 1;
			Item.width = 30;
			Item.height = 18;
			Item.value = 100000;
			Item.rare = 5;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.findTreasure = true;
			player.detectCreature = true;
			player.dangerSense = true;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.SoulofSight, 99)
				.AddIngredient(ItemID.SoulofLight, 30)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}