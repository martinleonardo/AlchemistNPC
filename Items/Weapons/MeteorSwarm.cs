using System.Linq;
using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;

namespace AlchemistNPC.Items.Weapons
{
	public class MeteorSwarm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Scroll ''Meteor Swarm''");
			Tooltip.SetDefault("One-use item"
			+"\nContains the spell ''Meteor Swarm''"
			+"\nWhile used, causes short meteorite rain around player's position"
			+"\nExhausts player for 1 minute, making him unable to use magic");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Свиток ''Метеоритного Роя''");
            Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Одноразовый предмет\nЭтот свиток содержит заклинание ''Метеоритный Рой''\nИспользование вызывает короткий метеоритный дождь возле позиции игрока\nИстощает игрока на 1 минуту, не позволяя ему использовать магию");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "卷轴 '''流星雨'");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "一次性物品"
			+"\n包含着 ''流星雨''法术"
			+"\n使用时, 在玩家光标周围落下流星雨"
			+"\n使玩家精疲力尽1分钟, 期间无法使用魔法");
        }

		public override void SetDefaults()
        {
            Item.UseSound = SoundID.Item88;                 //this is the sound that plays when you use the item
            Item.useStyle = 2;                 //this is how the item is holded when used
            Item.useTurn = true;
            Item.useAnimation = 20;
            Item.useTime = 20;
            Item.maxStack = 99;                 //this is where you set the max stack of item
            Item.consumable = true;           //this make that the item is consumable when used
            Item.width = 18;
            Item.height = 28;
            Item.value = Item.sellPrice(1, 0, 0, 0);
            Item.rare = 11;
			Item.mana = 200;
        }
		
		public override bool? UseItem(Player player)
		{
			for (int index1 = 0; index1 < 50; ++index1)
            {
              float X = player.position.X + Main.rand.Next(-1200, 1200);
              float Y = player.position.Y - Main.rand.Next(500, 800);
              float num1 = (float) (player.position.X + (double) (player.width / 2) - X);
              float num2 = (float) (player.position.Y + (double) (player.height / 2) - Y);
              float num3 = num1 + (float) Main.rand.Next(-100, 101);
              float num4 = 23f / (float) Math.Sqrt((double) num3 * (double) num3 + (double) num2 * (double) num2);
              float SpeedX = (num3 * num4)/3;
              float SpeedY = num2 * num4;
              int index2 = Projectile.NewProjectile(player.GetProjectileSource_Item(Item), X, Y, SpeedX, SpeedY, 711, 1500, 5f, player.whoAmI, 0.0f, 0.0f);
              Main.projectile[index2].ai[1] = (float) player.position.Y;
            }
			player.AddBuff(ModContent.BuffType<Buffs.Exhausted>(), 3600); 
			return true;
		}
		
		public override bool CanUseItem(Player player)
		{
			if (!player.HasBuff(ModContent.BuffType<Buffs.Exhausted>()) && !player.HasBuff(ModContent.BuffType<Buffs.ExecutionersEyes>()) && !player.HasBuff(ModContent.BuffType<Buffs.CloakOfFear>()))
			{
				return true;
			}
			return false;
		}
	}
}
