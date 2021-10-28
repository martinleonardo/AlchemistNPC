using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Terraria.Utilities;
using System.Linq;

namespace AlchemistNPC.Items.Weapons
{
	public class FlaskoftheAlchemist : ModItem
	{
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flask of the Alchemist");
            Tooltip.SetDefault("Very own weapon of legendary Alchemist, Gregg"
			+"\n[c/00FF00:Legendary Weapon]"
			+"\nThrows Flask of random type"
			+"\n[c/00FF00:Stats are growing through progression]");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Колба Алхимика");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Оружие легендарного Алхимика, Грегга\n[c/00FF00:Легендарное Оружие]\nБросает колбу случайного типа\n[c/00FF00:Статы улучшаются по мере прохождения]");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "炼金师烧瓶");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "传奇炼金师格雷格的武器"
			+"\n[c/00FF00:传奇武器]"
			+"\n投掷随机种类的的烧瓶"
			+"\n[c/00FF00:属性随进程成长]");
        }    
		public override void SetDefaults()
		{
			Item.damage = 7;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 28;
			Item.height = 28;
			Item.useTime = 55;
			Item.useAnimation = 55;
			Item.useStyle = 1;
			Item.knockBack = 4;
			Item.value = 1000000;
			Item.rare = 9;
			Item.UseSound = SoundID.Item106;
			Item.shoot = ProjectileType<Projectiles.FA1>();
			Item.autoReuse = true;
			Item.shootSpeed = 16f;
			Item.noUseGraphic = true;
			Item.noMelee = true;
		}
		
		public override int ChoosePrefix (UnifiedRandom rand)
		{
			return 82;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (NPC.downedSlimeKing)
			{
				Item.damage = 8;
			}
			if (NPC.downedBoss1)
			{
				Item.damage = 10;
			}
			if (NPC.downedBoss2)
			{
				Item.damage = 14;
			}
			if (NPC.downedQueenBee)
			{
				Item.damage = 16;
			}
			if (NPC.downedBoss3)
			{
				Item.damage = 21;
			}
			if (Main.hardMode)
			{
				Item.damage = 28;
				Item.useTime = 45;
				Item.useAnimation = 45;
			}
			if (NPC.downedMechBossAny)
			{
				Item.damage = 36;
			}
			if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
			{
				Item.damage = 40;
			}
			if (NPC.downedPlantBoss)
			{
				Item.damage = 44;
			}
			if (NPC.downedGolemBoss)
			{
				Item.damage = 56;
			}
			if (NPC.downedFishron)
			{
				Item.damage = 64;
			}
			if (NPC.downedAncientCultist)
			{
				Item.damage = 72;
			}
			if (NPC.downedMoonlord)
			{
				Item.damage = 111;
			}
			// IMPLEMENT WHEN WEAKREFERENCES FIXED
			/*
			Mod Calamity = ModLoader.GetMod("CalamityMod");
			if(Calamity != null)
			{
				if ((bool)Calamity.Call("Downed", "profaned guardians"))
				{
					Item.damage = 140;
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
					Item.damage = 300;
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
			return true;
		}
		
		public override bool Shoot(Player player, ProjectileSource_Item_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			switch (Main.rand.Next(4))
			{
				case 0:
				type = ProjectileType<Projectiles.FA1>();
				damage /= 2;
				break;

				case 1:
				type = ProjectileType<Projectiles.FA2>();
				damage /= 2;
				break;
				
				case 2:
				type = ProjectileType<Projectiles.FA3>();
				damage /= 2;
				break;
				
				case 3:
				type = ProjectileType<Projectiles.FA4>();
				break;
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
	}
}