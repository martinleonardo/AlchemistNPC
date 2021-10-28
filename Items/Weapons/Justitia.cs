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
	public class Justitia : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Justitia (O-02-62)");
			Tooltip.SetDefault("''It remembers the balance of the Long Bird that never forgot others' sins."
			+"\nThis weapon may be able to not only cut flesh but trace of sins as well.''"
			+ "\n[c/FF0000:EGO weapon]");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Юстиция (O-02-62)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Он помнит баланс Высокой Птицы, никогда не забывавшей грехи других.\nЭто оружие может уничтожать не только плоть, но и следы грехов.\n[c/FF0000:Оружие Э.П.О.С.]");

            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "正义裁决者 (O-02-62)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'这把武器象征着审判鸟的公平制裁, 这也意味着它需要去权衡全部的罪恶.'\n[c/FF0000:EGO 武器]");
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
			Item.rare = 11;
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
			Item.shoot = ProjectileType<Projectiles.JP>();
			Item.shootSpeed = 15f;
		}
		
		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int p = Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileType<Projectiles.JP>(), damage, knockback, player.whoAmI);
			Main.projectile[p].scale = 1.5f;
            return false;
        }
		
		public override bool CanUseItem(Player player)
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).ParadiseLost == true)
			{
				Item.damage = 225;
			}
			else
			{
				Item.damage = 120;
			}
			return base.CanUseItem(player);
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.LunarBar, 16)
				.AddIngredient(ItemID.FragmentNebula, 20)
            	.AddIngredient(ItemID.FragmentSolar, 20)
				.AddTile(null, "WingoftheWorld")
				.Register();
		}
	}
}
