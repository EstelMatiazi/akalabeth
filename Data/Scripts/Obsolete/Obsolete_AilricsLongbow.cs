using System;
using Server;

namespace Server.Items
{
	public class AilricsLongbow : ElvenCompositeLongbow
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		[Constructable]
		public AilricsLongbow()
		{
			Hue = 0x5B4;
			Name = "Ailric's Longbow";
			SkillBonuses.SetValues( 0, SkillName.Marksmanship, 10 );
			AccuracyLevel = WeaponAccuracyLevel.Supremely;
			DamageLevel = WeaponDamageLevel.Vanq;
			Attributes.AttackChance = 10;
			Attributes.Luck = 100;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public AilricsLongbow( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_AilricsLongbow(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );
			int version = reader.ReadInt();
		}
	}
}