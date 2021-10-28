using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Localization;
using Microsoft.Xna.Framework;

namespace AlchemistNPC.Items.Summoning
{
	public class MusicianHorcrux : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Musician Horcrux");
			Tooltip.SetDefault("The piece of Musician's soul is inside it.");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Крестраж Музыканта");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Russian), "Часть души Музыканта находится внутри");
			DisplayName.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "音乐家魂器");
			Tooltip.AddTranslation(GameCulture.FromCultureName(GameCulture.CultureName.Chinese), "里面有音乐家的一片灵魂.");
        }

		public override void SetDefaults()
		{
			Item.width = 46;
            Item.height = 42;
            Item.maxStack = 30;
            Item.rare = 10;
            Item.useStyle = 1;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.consumable = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = SoundID.Item37;
			Item.makeNPC = (short)NPCType<NPCs.Musician>();
		}

		public override void HoldItem(Player player)
		{
		Player.tileRangeX += 600;
        Player.tileRangeY += 600;
		}
		
		public override bool CanUseItem(Player player)
		{
			Vector2 vector2 = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
			return (!NPC.AnyNPCs(NPCType<NPCs.Musician>()) && !Collision.SolidCollision(vector2, player.width, player.height));
		}
		
		public override void OnConsumeItem(Player player)
		{
			Main.NewText("A Musician is spawned.", 255, 255, 255);
		}
	}
}