using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ModLoader.IO;
using Terraria.Localization;
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Weapons
{
	public class ChristmasW : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Christmas (F-02-49)");
			Tooltip.SetDefault("''It is patched with heavy leather. No one knows where the leather came from though."
			+ "\nIts true identity under the leather is classified, but its secrecy only makes the weapon all the more powerful.''"
			+ "\n[c/FF0000:EGO weapon]"
			+ "\nCauses some ornament balls to fall from the sky on swing"
			+ "\nGives 3% chance to get Present from any enemy as drop");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Рождество (F-02-49)");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "''Он запечатан в крепкую кожи. Никто не знает, откуда она.\nЧто находится под ней - неизвестно, но эта таинственность лишь делает оружие сильнее.''\n[c/FF0000:Оружие Э.П.О.С.]\nВызывает падение нескольких ёлочных украшений при взмахе\nДаёт 3% шанс на получение подарка при убийстве любого противника");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "悲惨圣诞 (F-02-49)");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "''掩盖在层层厚皮下的真相绝不能被人知道."
			+"\n对真相的刻意隐瞒只会使这把武器更加强大.''"
			+"\n[c/FF0000:EGO 武器]"
			+"\n挥舞时从天上掉落装饰球"
			+"\n任何敌人都有3%概率掉落礼物");
        }

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Starfury);
			Item.DamageType = DamageClass.Melee;
			Item.damage = 33;
			Item.width = 78;
			Item.height = 106;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.value = 50000;
			Item.rare = 3;
            Item.knockBack = 6;
            Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.scale = 1f;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).ParadiseLost == true)
			{
				Item.damage = 150;
				Item.useTime = 20;
				Item.useAnimation = 20;
			}
			else
			{
				Item.damage = 33;
			}
			return base.CanUseItem(player);
		}
		
		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			type = 335;
			if (((AlchemistNPCPlayer)player.GetModPlayer<AlchemistNPCPlayer>()).ParadiseLost == true)
			{
				Projectile.NewProjectile(source, position.X+Main.rand.Next(-75,75), position.Y+Main.rand.Next(-75,75), velocity.X, velocity.Y, type, damage, 3, player.whoAmI);
				Projectile.NewProjectile(source, position.X+Main.rand.Next(-100,100), position.Y+Main.rand.Next(-100,100), velocity.X, velocity.Y, type, damage, 3, player.whoAmI);
				Projectile.NewProjectile(source, position.X+Main.rand.Next(-25,25), position.Y+Main.rand.Next(-25,25), velocity.X, velocity.Y, type, damage/2, 3, player.whoAmI);
				Projectile.NewProjectile(source, position.X+Main.rand.Next(-50,50), position.Y+Main.rand.Next(-50,50), velocity.X, velocity.Y, type, damage/2, 3, player.whoAmI);
			}
			else
			{
				damage /= 2;
				Projectile.NewProjectile(source, position.X+Main.rand.Next(-25,25), position.Y+Main.rand.Next(-25,25), velocity.X, velocity.Y, type, damage/2, 3, player.whoAmI);
				Projectile.NewProjectile(source, position.X+Main.rand.Next(-50,50), position.Y+Main.rand.Next(-50,50), velocity.X, velocity.Y, type, damage/2, 3, player.whoAmI);
			}
			return base.Shoot(player, source, position, velocity, type, damage, knockback);
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 56);
			}
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.PlatinumBar, 5)
				.AddRecipeGroup("AlchemistNPC:EvilBar", 5)
				.AddIngredient(ItemID.BorealWood, 25)
				.AddRecipeGroup("AlchemistNPC:EvilComponent", 15)
				.AddTile(null, "WingoftheWorld")
				.Register();
		}
	}
}
