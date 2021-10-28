using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class Devilsknife : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Devilsknife");
			Tooltip.SetDefault("Summons Devilsknife to destroy your foes"
			+"\nMore than 1 cannot be summoned"
			+"\nMETAMORPHOSIS!");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Дьявольский Нож");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Призывает Дьявольский Нож для уничтожения ваших врагов\nНельзя призвать более одного\nМЕТАМОРФОЗ!");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "恶魔之刃");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "召唤恶魔之刃摧毁你的敌人"
			+"\n最多只能召唤1体"
			+"\nMETAMORPHOSIS!");
        }
		
		public override void SetDefaults()
		{
			Item.damage = 222;
			Item.mana = 33;
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.noMelee = true;
			Item.knockBack = 8;
			Item.value = Item.buyPrice(15, 0, 0, 0);
			Item.rare = 11;
			Item.UseSound = SoundID.Item44;
			Item.autoReuse = true;
			Item.noUseGraphic = true;
			Item.shoot = ProjectileType<Projectiles.Minions.Devilsknife>();
			Item.shootSpeed = 16f;
			Item.buffType = ModContent.BuffType<Buffs.Devilsknife>();
			Item.DamageType = DamageClass.Summon;
		}

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override void UseStyle(Player player, Rectangle rectangle)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(Item.buffType, 3600, true);
			}
		}
		
		public override bool? UseItem(Player player)
		{
			if (player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim(false);
			}
			return base.UseItem(player);
		}

		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			player.AddBuff(Item.buffType, 2);

			for (int l = 0; l < Main.projectile.Length; l++)
			{
				Projectile proj = Main.projectile[l];
				if (proj.active && proj.type == Item.shoot && proj.owner == player.whoAmI)
				{
					proj.active = false;
				}
			}
			
			Vector2 SPos = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			position = SPos;

			var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, Main.myPlayer);
			projectile.originalDamage = Item.damage;
			return false;
		}
	}
}
