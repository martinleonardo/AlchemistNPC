using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Equippable
{
	public class Godhead : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Godhead");
			Tooltip.SetDefault("''I am fear!''"
			+"\n''I see everything''"
			+"\n''No one can stop me now!''"
				+"\nGives effects of all 3 souls"
				+"\nIn addition, increases damage by 5% more and adds 5 defense");
				DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Godhead");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Я - страх''\n''Я вижу всё''\n''Никто меня теперь не остановит!''\nДаёт эффекты всех 3 душ\nДополнительно увеличивает урон на 5% и увеличивает защиту на 5");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "神性");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "''我就是恐惧!''\n''我无所不见!''\n''我无人可挡!''\n给予所有3种魂的效果\n此外, 增加5%伤害和5点防御");
        }
	
		public override void SetDefaults()
		{
			Item.stack = 1;
			Item.width = 30;
			Item.height = 30;
			Item.value = 100000;
			Item.rare = 8;
			Item.defense = 5;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			Projectile.NewProjectile(player.GetProjectileSource_Item(Item), player.Center.X, player.Center.Y, 0f, 0f, ProjectileType<Projectiles.Fear2>(), 0, 0, player.whoAmI);
			player.findTreasure = true;
			player.detectCreature = true;
			player.dangerSense = true;
			player.GetDamage(DamageClass.Generic) += 0.2f;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<Items.Equippable.SoulOfVision>())
				.AddIngredient(ModContent.ItemType<Items.Equippable.SoulOfFear>())
				.AddIngredient(ModContent.ItemType<Items.Equippable.SoulOfPower>())
				.AddIngredient(ItemID.SoulofFright, 15)
				.AddIngredient(ItemID.SoulofSight, 15)
				.AddIngredient(ItemID.SoulofMight, 15)
				.AddIngredient(ItemID.SoulofLight, 30)
				.AddIngredient(ItemID.SoulofNight, 30)
				.AddIngredient(ItemID.HallowedBar, 99)
				.AddIngredient(ModContent.ItemType<Items.Misc.MannafromHeaven>())
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}