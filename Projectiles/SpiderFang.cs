using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System;
using System.Collections.Generic;

namespace AlchemistNPC.Projectiles
{
	public class SpiderFang : ModProjectile
	{
		public float rot = 0f;
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Spider Fang");
		}

		public override void SetDefaults() {
			Projectile.width = 16;               //The width of projectile hitbox
			Projectile.height = 20;              //The height of projectile hitbox
			Projectile.aiStyle = 1;             //The ai style of the projectile, please reference the source code of Terraria
			Projectile.friendly= true;        //Can the projectile deal damage to enemies?
			Projectile.hostile = false;         //Can the projectile deal damage to the player?
			Projectile.DamageType = DamageClass.Ranged;           //Is the projectile shoot by a ranged weapon?
			Projectile.penetrate = -1;           //How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
			Projectile.timeLeft = 300;          //The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
			Projectile.alpha = 255;             //The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
			Projectile.light = 0.5f;            //How much light emit around the projectile
			Projectile.ignoreWater = true;         //Does the projectile's speed be influenced by water?
			Projectile.tileCollide = true;          //Can the projectile collide with tiles?
			Projectile.extraUpdates = 1;            //Set to above 0 if you want the projectile to update multiple time in a frame
			AIType = ProjectileID.Bullet;           //Act exactly like default Bullet
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
		}

		public override bool OnTileCollide(Vector2 oldVelocity) {
				Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
				Projectile.velocity.X = 0f;
				Projectile.velocity.Y = 0f;
				rot = Projectile.rotation;
				Projectile.friendly = false;
			return false;
		}
		
		public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI) 
		{
			// If attached to an NPC, draw behind tiles (and the npc) if that NPC is behind tiles, otherwise just behind the NPC.
			if (Projectile.ai[0] == 1f) // or if(isStickingToTarget) since we made that helper method.
			{
				int npcIndex = (int)Projectile.ai[1];
				if (npcIndex >= 0 && npcIndex < 200 && Main.npc[npcIndex].active) {
					if (Main.npc[npcIndex].behindTiles) {
						behindNPCsAndTiles.Add(index);
					}
					else {
						behindNPCs.Add(index);
					}

					return;
				}
			}
			// Since we aren't attached, add to this list
			behindProjectiles.Add(index);
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac) {
			// For going through platforms and such, javelins use a tad smaller size
			width = height = 10; // notice we set the width to the height, the height to 10. so both are 10
			return true;
		}
		
		public override void AI()
        {
			if (Projectile.velocity.X != 0f && Projectile.velocity.Y != 0f)
			{
				Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(90f);
			}
			else
			{
				Projectile.rotation = rot;
			}
						
			UpdateAlpha();
			// Run either the Sticky AI or Normal AI
			// Separating into different methods helps keeps your AI clean
			if (IsStickingToTarget) StickyAI();
			else NormalAI();
        }

		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
		}
		
		public bool IsStickingToTarget {
			get => Projectile.ai[0] == 1f;
			set => Projectile.ai[0] = value ? 1f : 0f;
		}

		// Index of the current target
		public int TargetWhoAmI {
			get => (int)Projectile.ai[1];
			set => Projectile.ai[1] = value;
		}

		private const int MAX_STICKY_JAVELINS = 100; // This is the max. amount of javelins being able to attach
		private readonly Point[] _stickingJavelins = new Point[MAX_STICKY_JAVELINS]; // The point array holding for sticking javelins

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
			rot = Projectile.rotation;
			IsStickingToTarget = true; // we are sticking to a target
			TargetWhoAmI = target.whoAmI; // Set the target whoAmI
			if (!target.boss && !target.noTileCollide) target.velocity = Projectile.velocity;
			Projectile.velocity =
				(target.Center - Projectile.Center) *
				0.75f; // Change velocity based on delta center of targets (difference between entity centers)
			Projectile.netUpdate = true; // netUpdate this javelin

			// It is recommended to split your code into separate methods to keep code clean and clear
			UpdateStickyJavelins(target);
		}

		/*
		 * The following code handles the javelin sticking to the enemy hit.
		 */
		private void UpdateStickyJavelins(NPC target)
		{
			int currentJavelinIndex = 0; // The javelin index

			for (int i = 0; i < Main.maxProjectiles; i++) // Loop all projectiles
			{
				Projectile currentProjectile = Main.projectile[i];
				if (i != Projectile.whoAmI // Make sure the looped projectile is not the current javelin
				    && currentProjectile.active // Make sure the projectile is active
				    && currentProjectile.owner == Main.myPlayer // Make sure the projectile's owner is the client's player
				    && currentProjectile.type == Projectile.type // Make sure the projectile is of the same type as this javelin
				    && currentProjectile.ModProjectile is Bolt javelinProjectile // Use a pattern match cast so we can access the projectile like an ExampleJavelinProjectile
				    && javelinProjectile.IsStickingToTarget // the previous pattern match allows us to use our properties
				    && javelinProjectile.TargetWhoAmI == target.whoAmI) {

					_stickingJavelins[currentJavelinIndex++] = new Point(i, currentProjectile.timeLeft); // Add the current projectile's index and timeleft to the point array
					if (currentJavelinIndex >= _stickingJavelins.Length)  // If the javelin's index is bigger than or equal to the point array's length, break
						break;
				}
			}

			// Remove the oldest sticky javelin if we exceeded the maximum
			if (currentJavelinIndex >= MAX_STICKY_JAVELINS)
			{
				int oldJavelinIndex = 0;
				// Loop our point array
				for (int i = 1; i < MAX_STICKY_JAVELINS; i++) {
					// Remove the already existing javelin if it's timeLeft value (which is the Y value in our point array) is smaller than the new javelin's timeLeft
					if (_stickingJavelins[i].Y < _stickingJavelins[oldJavelinIndex].Y) {
						oldJavelinIndex = i; // Remember the index of the removed javelin
					}
				}
				// Remember that the X value in our point array was equal to the index of that javelin, so it's used here to kill it.
				Main.projectile[_stickingJavelins[oldJavelinIndex].X].Kill();
			}
		}

		// Change this number if you want to alter how the alpha changes
		private const int ALPHA_REDUCTION = 25;

		private void UpdateAlpha()
		{
			// Slowly remove alpha as it is present
			if (Projectile.alpha > 0) {
				Projectile.alpha -= ALPHA_REDUCTION;
			}

			// If alpha gets lower than 0, set it to 0
			if (Projectile.alpha < 0) {
				Projectile.alpha = 0;
			}
		}

		private void NormalAI()
		{
			TargetWhoAmI++;
		}

		private void StickyAI()
		{
			Projectile.friendly = false;
			// These 2 could probably be moved to the ModifyNPCHit hook, but in vanilla they are present in the AI
			Projectile.ignoreWater = true;// Make sure the projectile ignores water
			Projectile.tileCollide = false; // Make sure the projectile doesn't collide with tiles anymore
			Projectile.localAI[0] += 1f;

			// Every 30 ticks, the javelin will perform a hit effect
			int projTargetIndex = (int)TargetWhoAmI;
			if (!Main.npc[projTargetIndex].boss && !Main.npc[projTargetIndex].noTileCollide && Projectile.localAI[0] >= 30f && Projectile.velocity.Y != 0f)
			{
				Main.npc[projTargetIndex].velocity.X *= 0.9f;
				Main.npc[projTargetIndex].velocity.Y += 2f;
			}
			if (!Main.npc[projTargetIndex].boss && !Main.npc[projTargetIndex].noTileCollide && Projectile.localAI[0] >= 30f && Projectile.velocity.Y == 0f)
			{
				Main.npc[projTargetIndex].velocity.X *= 0.5f;
				Main.npc[projTargetIndex].velocity.Y = 0f;
			}
			
			if (Main.npc[projTargetIndex].active && !Main.npc[projTargetIndex].dontTakeDamage) { // If the target is active and can take damage
				// Set the projectile's position relative to the target's center
				Projectile.Center = Main.npc[projTargetIndex].Center - Projectile.velocity * 2f;
				Projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
				}
		}
	}
}
