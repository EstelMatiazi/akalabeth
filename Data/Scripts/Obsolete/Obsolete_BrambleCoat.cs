using System;
using Server.Items;

namespace Server.Items
{
	public class BrambleCoat : LeatherChest
	{
		public override int LabelNumber{ get{ return 1072925; } } // Bramble Coat

		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 8; } }
		public override int BaseColdResistance{ get{ return 7; } }
		public override int BasePoisonResistance{ get{ return 8; } }
		public override int BaseEnergyResistance{ get{ return 7; } }

		[Constructable]
		public BrambleCoat()
		{
			Hue = 0x1;

			ArmorAttributes.SelfRepair = 3;
			Attributes.BonusHits = 4;
			Attributes.Luck = 150;
			Attributes.ReflectPhysical = 25;
			Attributes.DefendChance = 15;
		}

		public BrambleCoat( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_BrambleCoat(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadEncodedInt();
		}
	}
}