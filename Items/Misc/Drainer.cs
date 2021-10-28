using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Misc
{
	public class Drainer : ModItem
	{
		//Possibly removed
		/*
		public override bool Autoload(ref string name)
		{
			return ModLoader.GetMod("CalamityMod") != null;
		}
		*/

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Drainer");
			Tooltip.SetDefault("Drains 1/4 of HP while used, fills 1/4 of Rage Meter"
			+"\nPerfect for filling Rage Meter");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Поглотитель");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Поглощает 1/4 ХП при применении, пополняет 1/4 Счетчика Ярости\nИдеален для заполнения шкалы Ярости");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "吸收器");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "使用时吸收1/4生命值, 填装1/4怒气值\n非常适合用来填满怒气条");
        }    
		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 36;
			Item.maxStack = 1;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 2;
			Item.value = 100000;
			Item.rare = 9;
			Item.UseSound = SoundID.Item4;
		}

		public override bool? UseItem(Player player)
		{
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			//CalamityMod.CalPlayer.CalamityPlayer CalamityPlayer = player.GetModPlayer<CalamityMod.CalPlayer.CalamityPlayer>();
			for (int h = 0; h < 1; h++) {
			Vector2 vel = new Vector2(0, -1);
			vel *= 0f;
			Projectile.NewProjectile(player.GetProjectileSource_Item(Item),player.Center.X, player.Center.Y, vel.X, vel.Y, ProjectileType<Projectiles.Drainer>(), 0, 0, player.whoAmI);
			}
			player.Hurt(PlayerDeathReason.LegacyEmpty(), 2, 0, false, false, false, -1);
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			//CalamityPlayer.rage += CalamityPlayer.rageMax/4;
			player.statLife = (player.statLife - player.statLifeMax2 / 4);
			PlayerDeathReason damageSource = PlayerDeathReason.ByOther(13);
			if (Main.rand.Next(2) == 0)	damageSource = PlayerDeathReason.ByOther(player.Male ? 14 : 15);
			if (player.statLife <= 0) player.KillMe(damageSource, 1.0, 0, false);
			player.lifeRegenCount = 0;
			player.lifeRegenTime = 0;
			return true;
		}
		
		private Vector2 GetLightPosition(Player player)
		{
			Vector2 position = Main.screenPosition;
			position.X += Main.mouseX;
			position.Y += player.gravDir == 1 ? Main.mouseY : Main.screenHeight - Main.mouseY;
			return position;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Spike, 2)
				.AddIngredient(null, "CrystalDust", 10)
				.AddIngredient(ItemID.FragmentSolar, 5)
				.AddIngredient(ItemID.FragmentVortex, 5)
				.AddIngredient(ItemID.FragmentNebula, 5)
				.AddIngredient(ItemID.FragmentStardust, 5)
				.AddTile(TileID.LunarCraftingStation)
				.Register();
		}
	}
}
