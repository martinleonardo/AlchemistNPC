using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Terraria.Localization;
using System.Linq;
using Terraria.Utilities;
using Terraria.DataStructures;

namespace AlchemistNPC.Items.Weapons
{
	public class TomeOfOrder : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tome of Order");
			Tooltip.SetDefault("[c/00FF00:Legendary Weapon]"
			+"\n[c/00FF00:Stats are growing up through progression]"
			+"\n''Only the ones who are equally good and evil may weild this''"
			+"\nShoots energy bolts which stick to enemies and tiles"
			+"\nThey explode after some time or can be blown up manually, dealing double damage");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Том Порядка");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "[c/00FF00:Легендарное Оружие]\n''Лишь тот, кто в равной степени добр и зол может использовать это''\n[c/00FF00:Характеристики оружия улучшаются по мере прохождения]\nВыстреливает энергетические снаряды, способные застревать во врагах или блоках\nОни взрываются по прошествии времени или вручную, нанося дополнительный урон");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese),"秩序原典");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese),"[c/00FF00:传奇武器]"
			+"\n[c/00FF00:属性随游戏进程增长]"
			+"\n''只有于善恶的彼岸之人才能领悟''"
			+"\n发射可以扎在敌人或者地面的能量之矢"
			+"\n它们会在一段时间后爆炸，或者手动引爆，造成双倍伤害");
		}

		public override void SetDefaults()
		{
			Item.damage = 9;
			Item.noMelee = true;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 6;
			Item.rare = 11;
			Item.width = 30;
			Item.height = 30;
			Item.UseSound = SoundID.Item9;
			Item.useStyle = 5;
			Item.shootSpeed = 12f;
			Item.knockBack = 4;
			Item.value = Item.sellPrice(0, 10, 0, 0);
			Item.autoReuse = true;
			Item.useTime = 12;
			Item.useAnimation = 36;
			Item.shoot = ProjectileType<Projectiles.Bolt>();
		}
		
		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return 83;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (NPC.downedSlimeKing)
			{
				Item.damage = 10;
			}
			if (NPC.downedBoss1)
			{
				Item.damage = 12;
			}
			if (NPC.downedBoss2)
			{
				Item.damage = 15;
			}
			if (NPC.downedQueenBee)
			{
				Item.damage = 18;
			}
			if (NPC.downedBoss3)
			{
				Item.damage = 21;
			}
			if (Main.hardMode)
			{
				Item.damage = 29;
				Item.useTime = 10;
				Item.useAnimation = 30;
			}
			if (NPC.downedMechBossAny)
			{
				Item.damage = 36;
			}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				Item.damage = 42;
				Item.useTime = 8;
				Item.useAnimation = 24;
			}
			if (NPC.downedPlantBoss)
			{
				Item.damage = 52;
			}
			if (NPC.downedGolemBoss)
			{
				Item.damage = 60;
				Item.useTime = 7;
				Item.useAnimation = 21;
			}
			if (NPC.downedFishron)
			{
				Item.damage = 70;
			}
			if (NPC.downedAncientCultist)
			{
				Item.damage = 80;
			}
			if (NPC.downedMoonlord)
			{
				Item.damage = 100;
			}
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
			Mod Calamity = ModLoader.GetMod("CalamityMod");
			if(Calamity != null)
			{
				if ((bool)Calamity.Call("Downed", "profaned guardians"))
				{
					Item.damage = 150;
				}
			}
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				if (ThoriumModDownedRagnarok)
				{
					Item.damage = 200;
				}
			}
			if (Calamity != null)
			{
				if ((bool)Calamity.Call("Downed", "providence"))
				{
					Item.damage = 200;
				}
				if ((bool)Calamity.Call("Downed", "polterghast"))
				{
					Item.damage = 350;
				}
				if ((bool)Calamity.Call("Downed", "dog"))
				{
					Item.damage = 1000;
				}
				if ((bool)Calamity.Call("Downed", "yharon"))
				{
					Item.damage = 3000;
				}
				if ((bool)Calamity.Call("Downed", "supreme calamitas"))
				{
					Item.damage = 10000;
				}
			}
			*/
			if (player.altFunctionUse == 2)
			{
				for(int i = 0; i < 1000; ++i)
				{
					if (Main.projectile[i].active && Main.projectile[i].type == ProjectileType<Projectiles.Bolt>())
					{
						Main.projectile[i].damage *= 2;
						Main.projectile[i].Kill();
					}
				}
				return false;
			}
			return true;
		}
		
		// IMPLEMENT WHEN WEAKREFERENCES FIXED
		/*
        public bool ThoriumModDownedRagnarok
        {
        get { return ThoriumMod.ThoriumWorld.downedRealityBreaker; }
        }
		*/
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(4));
			Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
			float speedX = perturbedSpeed.X;
			float speedY = perturbedSpeed.Y;
			Projectile.NewProjectile(source, vector.X, vector.Y, speedX, speedY, ProjectileType<Projectiles.Bolt>(), damage, knockback, player.whoAmI);
			return false;
		}
	}
}
