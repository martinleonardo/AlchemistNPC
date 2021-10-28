using Microsoft.Xna.Framework.Audio;
using Terraria.ModLoader;
using Terraria.Audio;
using static Terraria.ModLoader.ModContent;

namespace AlchemistNPC.Sounds.Item
{
	public class PortalTurretDeploy : ModSound
	{
		public override SoundEffectInstance PlaySound(ref SoundEffectInstance soundInstance, float volume, float pan) {
			// By creating a new instance, this ModSound allows for overlapping sounds. Non-ModSound behavior is to restart the sound, only permitting 1 instance.
			soundInstance = Sound.Value.CreateInstance();
			soundInstance.Play();	// Test Sound
			SoundInstanceGarbageCollector.Track(soundInstance);
			soundInstance.Volume = volume;
			soundInstance.Pan = pan;
			soundInstance.Pitch = 0f;
			return soundInstance;
		}
	}
}
