using System;
using Server;

namespace Server.Items
{
	public class MidnightTunic : BoneChest
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int LabelNumber{ get{ return 1061093; } } // Midnight Tunic

		public override int BasePhysicalResistance{ get{ return 25; } }

		[Constructable]
		public MidnightTunic()
		{
			Name = "Midnight Tunic";
			Hue = 0x455;
			SkillBonuses.SetValues( 0, SkillName.Necromancy, 15.0 );
			Attributes.SpellDamage = 10;
			ArmorAttributes.MageArmor = 1;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public MidnightTunic( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		private void Cleanup( object state ){ Item item = new Artifact_MidnightTunic(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadInt();

			if ( version < 1 )
				PhysicalBonus = 0;
		}
	}
}