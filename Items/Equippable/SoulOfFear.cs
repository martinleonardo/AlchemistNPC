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
	public class SoulOfFear : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul Of Fear");
			Tooltip.SetDefault("''I am fear!''"
				+ "\nWeakening nearby enemies, inflicting several debuffs");
				DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Душа Страха");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Я - страх''\nБлижайшие враги ослабляются, получая целый комплек дебаффов");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 6));
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "惊怖之魂");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "''我就是恐惧!''\n虚弱附近敌人, 造成多种Debuff");
        }
	
		public override void SetDefaults()
		{
			Item.stack = 1;
			Item.width = 26;
			Item.height = 26;
			Item.value = 100000;
			Item.rare = 5;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			Projectile.NewProjectile(player.GetProjectileSource_Item(Item), player.Center.X, player.Center.Y, 0f, 0f, ProjectileType<Projectiles.Fear>(), 0, 0, player.whoAmI);
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.SoulofFright, 99)
				.AddIngredient(ItemID.SoulofLight, 15)
				.AddIngredient(ItemID.SoulofNight, 15)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}