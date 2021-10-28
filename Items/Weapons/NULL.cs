using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Weapons
{
	public class NULL : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Katana");
			Tooltip.SetDefault("NULL");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Катана");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "NULL");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "武士刀");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "NULL");
        }

		public override void SetDefaults()
		{
			Item.damage = 120;
			Item.width = 44;
			Item.height = 44;
			Item.useTime = 30;
			Item.useAnimation = 50;
			Item.useStyle = 5;
			Item.knockBack = 3;
			Item.value = 1000000;
			Item.rare = 10;
			Item.noUseGraphic = true;
            Item.channel = true;
            Item.noMelee = true;
            Item.damage = 166;
            Item.knockBack = 4;
            Item.autoReuse = false;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Melee;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ProjectileType<Projectiles.NULL>();
			Item.shootSpeed = 15f;
		}
		
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse != 2)
			{
				Item.damage = 120;
				Item.shootSpeed = 14f;
				Item.shoot = ProjectileType<Projectiles.NULL>();
				Item.channel = true;
				Item.useTime = 30;
				Item.useAnimation = 50;
			}
			if (player.altFunctionUse == 2)
			{
				Item.channel = false;
				Item.useTime = 30;
				Item.useAnimation = 30;
			}
			return base.CanUseItem(player);
		}
		
		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			if (player.altFunctionUse == 2 && !player.HasBuff(ModContent.BuffType<Buffs.NULLCD>()))
			{
				player.AddBuff(ModContent.BuffType<Buffs.NULL>(), 300);
				player.AddBuff(ModContent.BuffType<Buffs.NULLCD>(), 1800);
				return false;
			}
			if (player.altFunctionUse != 2)
			{
				int p = Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileType<Projectiles.NULL>(), damage, knockback, player.whoAmI);
				return false;
			}
			return false;
        }
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Katana)
				.AddIngredient(ItemID.FragmentNebula, 20)
            	.AddIngredient(ItemID.FragmentSolar, 20)
				.AddIngredient(ItemID.FragmentVortex, 20)
				.AddIngredient(ItemID.FragmentStardust, 20)
				.AddIngredient(ItemID.LunarBar, 10)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}