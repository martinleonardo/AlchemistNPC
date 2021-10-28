using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Buffs
{
	public class Yui : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Yui");
			Description.SetDefault("Welcome back to the A-- Wait, that is not Alfheim! Where are we?"
			+"\nHighlights treasure, creatures and traps");
			Main.buffNoTimeDisplay[Type] = true;
			Main.lightPet[Type] = true;
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Юи");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Добро пожаловать обратно в А... Погоди-ка, это не Альфхейм! Где мы?\nПодсвечивает сокровища, существ и ловушки");
            DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "小悠");
            Description.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "'欢迎回到亚... 等等, 这儿不是亚尔夫海姆! 我们在哪儿?'\n照亮宝物, 生物和陷阱");
        }

		public override void Update(Player player, ref int buffIndex)
		{
			player.findTreasure = true;
			player.nightVision = true;
			player.detectCreature = true;
			player.dangerSense = true;
			player.GetModPlayer<AlchemistNPCPlayer>().Yui = true;
			player.GetModPlayer<AlchemistNPCPlayer>().YuiS = false;
			player.buffTime[buffIndex] = 18000;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.Yui>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.GetProjectileSource_Buff(buffIndex), player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<Projectiles.Pets.Yui>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
			if ((player.controlDown && player.releaseDown))
			{
				if (player.doubleTapCardinalTimer[0] > 0 && player.doubleTapCardinalTimer[0] != 15)
				{
					for (int j = 0; j < 1000; j++)
					{
						if (Main.projectile[j].active && Main.projectile[j].type == ModContent.ProjectileType<Projectiles.Pets.Yui>() && Main.projectile[j].owner == player.whoAmI)
						{
							Projectile lightpet = Main.projectile[j];
							Vector2 vectorToMouse = Main.MouseWorld - lightpet.Center;
							lightpet.velocity += 5f * Vector2.Normalize(vectorToMouse);
						}
					}
				}
			}
		}
	}
}
