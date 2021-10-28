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
using AlchemistNPC;
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Weapons
{
	public class MordenkainenSword : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mordenkainen's Sword");
			Tooltip.SetDefault("Immaterial sword created by Mordenkainen"
			+ "\nSlashes enemies from the distance");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Меч Морденкайнена");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Нематериальный клинок, созданный Морденкайненом\nМожет ранить врага на значительном расстоянии");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "魔邓肯之剑");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "魔邓肯制作的无形之剑"
			+ "\n远程斩杀敌人");
        }

		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Melee;
			Item.damage = 56;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 30;
			Item.useAnimation = 39;
			Item.useStyle = 1;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.value = 10000000;
			Item.rare = 11;
            Item.knockBack = 8;
            Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileType<Projectiles.MordenkainenSword>();
		}
		
		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 SPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			position = SPos;
			return true;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Excalibur)
				.AddIngredient(ItemID.MagnetSphere)
				.AddIngredient(ItemID.Ectoplasm, 10)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}
