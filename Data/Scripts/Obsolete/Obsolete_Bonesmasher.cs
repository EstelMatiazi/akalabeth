using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class Bonesmasher : DiamondMace
	{
		public override int InitMinHits{ get{ return 80; } }
		public override int InitMaxHits{ get{ return 160; } }

		public override int LabelNumber{ get{ return 1075030; } } // Bonesmasher

		[Constructable]
		public Bonesmasher()
		{
			Name = "Bonesmasher";
			ItemID = 0x2D30;
			Hue = 0x482;

			SkillBonuses.SetValues( 0, SkillName.Bludgeoning, 10.0 );

			WeaponAttributes.HitLeechMana = 40;
			WeaponAttributes.SelfRepair = 2;
		}

        public override void AddNameProperties(ObjectPropertyList list)
		{
            base.AddNameProperties(list);
			list.Add( 1070722, "Artefact");
        }

		public Bonesmasher( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		private void Cleanup( object state ){ Item item = new Artifact_Bonesmasher(); Server.Misc.Cleanup.DoCleanup( (Item)state, item ); }

public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader ); Timer.DelayCall( TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( Cleanup ), this );

			int version = reader.ReadEncodedInt();
		}
	}
}