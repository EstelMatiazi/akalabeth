using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.Misc;
using Server.Items;
using Server.Network;
using Server.Commands;
using Server.Commands.Generic;
using Server.Mobiles;
using Server.Accounting;
using Server.Regions;

/*
3002004	Tell
3001024	Quests
3000548	Done
*/

namespace Server.Misc
{
    class StandardQuestFunctions
    {
		public static int ChanceToFindQuestedItem()
		{
			return 10;
		}

		public static void CheckTarget( Mobile m, Mobile target, Item box )
		{
			string explorer = PlayerSettings.GetQuestInfo( m, "StandardQuest" );

			if ( PlayerSettings.GetQuestState( m, "StandardQuest" ) )
			{
				string sPCTarget = "";
				string sPCTitle = "";
				string sPCName = "";
				string sPCRegion = "";
				int nPCDone = 0;
				int nPCFee = 0;
				string sPCWorld = "";
				string sPCCategory = "";
				string sPCStory = "";

				string[] explorers = explorer.Split('#');
				int nEntry = 1;
				foreach (string explorerz in explorers)
				{
					if ( nEntry == 1 ){ sPCTarget = explorerz; }
					else if ( nEntry == 2 ){ sPCTitle = explorerz; }
					else if ( nEntry == 3 ){ sPCName = explorerz; }
					else if ( nEntry == 4 ){ sPCRegion = explorerz; }
					else if ( nEntry == 5 ){ nPCDone = Convert.ToInt32(explorerz); }
					else if ( nEntry == 6 ){ nPCFee = Convert.ToInt32(explorerz); }
					else if ( nEntry == 7 ){ sPCWorld = explorerz; }
					else if ( nEntry == 8 ){ sPCCategory = explorerz; }
					else if ( nEntry == 9 ){ sPCStory = explorerz; }

					nEntry++;
				}

				if ( sPCCategory == "Item" && target != null )
				{
					if ( sPCCategory == "Item" && StandardQuestFunctions.ChanceToFindQuestedItem() >= Utility.RandomMinMax( 1, 100 ) && Server.Misc.Worlds.GetRegionName( m.Map, m.Location ) == sPCRegion && nPCDone != 1 )
					{
						m.PrivateOverheadMessage(MessageType.Regular, 1153, false, "Ahh...they had " + sPCName + "!", m.NetState);
						explorer = explorer.Replace("#0#", "#1#");
						m.SendSound( 0x3D );
						LoggingFunctions.LogQuestItem( m, sPCName );
						PlayerSettings.SetQuestInfo( m, "StandardQuest", explorer );
					}
				}
				else if ( box != null )
				{
					if ( sPCCategory == "Item" && StandardQuestFunctions.ChanceToFindQuestedItem() >= Utility.RandomMinMax( 1, 100 ) && Server.Misc.Worlds.GetRegionName( m.Map, m.Location ) == sPCRegion && nPCDone != 1 )
					{
						m.PrivateOverheadMessage(MessageType.Regular, 1153, false, "Ahh...I found " + sPCName + "!", m.NetState);
						LoggingFunctions.LogFoundItemQuest( m, sPCName );
						explorer = explorer.Replace("#0#", "#1#");
						m.SendSound( 0x3D );
						LoggingFunctions.LogQuestItem( m, sPCName );
						PlayerSettings.SetQuestInfo( m, "StandardQuest", explorer );
					}
				}
				else if ( target != null )
				{
					string sexplorer = target.GetType().ToString();

					if ( sexplorer == sPCTarget && Server.Misc.Worlds.GetRegionName( target.Map, target.Location ) == sPCRegion && nPCDone != 1 )
					{
						m.PrivateOverheadMessage(MessageType.Regular, 1153, false, "The quested bounty has been fulfilled!", m.NetState);
						explorer = explorer.Replace("#0#", "#1#");
						m.SendSound( 0x3D );
						LoggingFunctions.LogQuestKill( m, "bounty", target );
						PlayerSettings.SetQuestInfo( m, "StandardQuest", explorer );
					}
				}
			}
		}

		public static void QuestTimeAllowed( Mobile m )
		{
			DateTime TimeFinished = DateTime.Now;
			string sFinished = Convert.ToString(TimeFinished);
			PlayerSettings.SetQuestInfo( m, "StandardQuest", sFinished );
		}

		public static int QuestTimeNew( Mobile m )
		{
			int QuestTime = 10000;
			string sTime = PlayerSettings.GetQuestInfo( m, "StandardQuest" );

			if ( sTime.Length > 0 && !( PlayerSettings.GetQuestState( m, "StandardQuest" ) ) )
			{
				DateTime TimeThen = Convert.ToDateTime(sTime);
				DateTime TimeNow = DateTime.Now;
				long ticksThen = TimeThen.Ticks;
				long ticksNow = TimeNow.Ticks;
				int minsThen = (int)TimeSpan.FromTicks(ticksThen).TotalMinutes;
				int minsNow = (int)TimeSpan.FromTicks(ticksNow).TotalMinutes;
				QuestTime = minsNow - minsThen;
			}
			return QuestTime;
		}

		public static void FindTarget( Mobile m, int fee )
		{
			Land searchLocation = Land.Sosaria;
			switch ( Utility.RandomMinMax( 0, 15 ) )
			{
				case 0:		searchLocation = Land.Sosaria;			break;
				case 1:		searchLocation = Land.Sosaria;			break;
				case 2:		searchLocation = Land.Sosaria;			break;
				case 3:		searchLocation = Land.Lodoria;			if ( !( PlayerSettings.GetDiscovered( m, "the Land of Lodoria" ) ) ){ searchLocation = Land.Sosaria; } break;
				case 4:		searchLocation = Land.Lodoria;			if ( !( PlayerSettings.GetDiscovered( m, "the Land of Lodoria" ) ) ){ searchLocation = Land.Sosaria; } break;
				case 5:		searchLocation = Land.Lodoria;			if ( !( PlayerSettings.GetDiscovered( m, "the Land of Lodoria" ) ) ){ searchLocation = Land.Sosaria; } break;
				case 6:		searchLocation = Land.Serpent;			if ( !( PlayerSettings.GetDiscovered( m, "the Serpent Island" ) ) ){ searchLocation = Land.Sosaria; } break;
				case 7:		searchLocation = Land.Serpent;			if ( !( PlayerSettings.GetDiscovered( m, "the Serpent Island" ) ) ){ searchLocation = Land.Sosaria; } break;
				case 8:		searchLocation = Land.Serpent;			if ( !( PlayerSettings.GetDiscovered( m, "the Serpent Island" ) ) ){ searchLocation = Land.Sosaria; } break;
				case 9:		searchLocation = Land.IslesDread;		if ( !( PlayerSettings.GetDiscovered( m, "the Isles of Dread" ) ) ){ searchLocation = Land.Sosaria; } break;
				case 10:	searchLocation = Land.Savaged;			if ( !( PlayerSettings.GetDiscovered( m, "the Savaged Empire" ) ) ){ searchLocation = Land.Sosaria; } break;
				case 11:	searchLocation = Land.Savaged;			if ( !( PlayerSettings.GetDiscovered( m, "the Savaged Empire" ) ) ){ searchLocation = Land.Sosaria; } break;
				case 12:	searchLocation = Land.UmberVeil;		if ( !( PlayerSettings.GetDiscovered( m, "the Island of Umber Veil" ) ) ){ searchLocation = Land.Sosaria; } break;
				case 13:	searchLocation = Land.Kuldar;			if ( !( PlayerSettings.GetDiscovered( m, "the Bottle World of Kuldar" ) ) ){ searchLocation = Land.Sosaria; } break;
				case 14:	searchLocation = Land.Underworld;		if ( !( PlayerSettings.GetDiscovered( m, "the Underworld" ) ) ){ searchLocation = Land.Underworld; } break;
				case 15:	searchLocation = Land.Ambrosia;			if ( !( PlayerSettings.GetDiscovered( m, "the Land of Ambrosia" ) ) ){ searchLocation = Land.Sosaria; } break;
			}

			if ( !( PlayerSettings.GetDiscovered( m, "the Land of Sosaria" ) ) && searchLocation == Land.Sosaria )
			{
				if ( ((PlayerMobile)m).SkillStart == 11000 ){ searchLocation = Land.Savaged; }
				else { searchLocation = Land.Lodoria; }
			}

			int aCount = 0;
			Region reg = null;
			ArrayList targets = new ArrayList();
			foreach ( Mobile target in World.Mobiles.Values )
			if ( target is BaseCreature )
			{
				reg = Region.Find( target.Location, target.Map );
				Land tWorld = Server.Lands.GetLand( target.Map, target.Location, target.X, target.Y );

				if ( target.EmoteHue !=123 && target.Karma < 0 && target.Fame < fee && ( Server.Difficult.GetDifficulty( target.Location, target.Map ) <= GetPlayerInfo.GetPlayerDifficulty( m ) ) && reg.IsPartOf( typeof( DungeonRegion ) ) )
				{
					if ( searchLocation == Land.Sosaria && tWorld == searchLocation ){ targets.Add( target ); aCount++; }
					else if ( searchLocation == Land.Lodoria  && tWorld == searchLocation ){ targets.Add( target ); aCount++; }
					else if ( searchLocation == Land.Serpent  && tWorld == searchLocation ){ targets.Add( target ); aCount++; }
					else if ( searchLocation == Land.IslesDread  && tWorld == searchLocation ){ targets.Add( target ); aCount++; }
					else if ( searchLocation == Land.Savaged  && tWorld == searchLocation ){ targets.Add( target ); aCount++; }
					else if ( searchLocation == Land.UmberVeil  && tWorld == searchLocation ){ targets.Add( target ); aCount++; }
					else if ( searchLocation == Land.Kuldar  && tWorld == searchLocation ){ targets.Add( target ); aCount++; }
					else if ( searchLocation == Land.Underworld  && tWorld == searchLocation ){ targets.Add( target ); aCount++; }
				}

				if ( aCount < 1 ) // SAFETY CATCH IF IT FINDS NO CREATURES AT ALL...IT WILL FIND AT LEAST ONE IN SOSARIA //
				{
					if ( target.Karma < 0 && target.Fame < fee && reg.IsPartOf( typeof( DungeonRegion ) ) && tWorld == Land.Sosaria )
					{
						targets.Add( target ); aCount++;
					}
				}
			}

			aCount = Utility.RandomMinMax( 1, aCount );

			int xCount = 0;
			for ( int i = 0; i < targets.Count; ++i )
			{
				xCount++;

				if ( xCount == aCount )
				{
					if ( Utility.RandomMinMax( 1, 2 ) == 1 ) // KILL SOMETHING
					{
						Mobile theone = ( Mobile )targets[ i ];
						string kWorld = Server.Lands.LandName( Server.Lands.GetLand( theone.Map, theone.Location, theone.X, theone.Y ) );

						string kexplorer = theone.GetType().ToString();
						int nFee = theone.Fame / 5;
						nFee = (int)( (MyServerSettings.QuestRewardModifier() * 0.01) * nFee ) + 20 + nFee;
						string kDollar = nFee.ToString();

						string killName = theone.Name;
						string killTitle = theone.Title;
							if ( theone is Wyrms ){ killName = "a wyrm"; killTitle = ""; }
							if ( theone is Daemon ){ killName = "a daemon"; killTitle = ""; }
							if ( theone is Balron ){ killName = "a balron"; killTitle = ""; }
							if ( theone is RidingDragon || theone is Dragons ){ killName = "a dragon"; killTitle = ""; }
							if ( theone is BombWorshipper ){ killName = "a worshipper of the bomb"; killTitle = ""; }
							if ( theone is Psionicist ){ killName = "a psychic of the bomb"; killTitle = ""; }

						string myexplorer = kexplorer + "#" + killTitle + "#" + killName + "#" + Server.Misc.Worlds.GetRegionName( theone.Map, theone.Location ) + "#0#" + kDollar + "#" + kWorld + "#Monster";
						PlayerSettings.SetQuestInfo( m, "StandardQuest", myexplorer );

						string theStory = myexplorer + "#" + StandardQuestFunctions.QuestSentence( m ); // ADD THE STORY PART

						PlayerSettings.SetQuestInfo( m, "StandardQuest", theStory );
					}
					else // FIND SOMETHING
					{
						Mobile theone = ( Mobile )targets[ i ];
						string kWorld = Server.Lands.LandName( Server.Lands.GetLand( theone.Map, theone.Location, theone.X, theone.Y ) );

						string kexplorer = theone.GetType().ToString();
						int nFee = theone.Fame / 3;
						nFee = (int)( (MyServerSettings.QuestRewardModifier() * 0.01) * nFee ) + 20 + nFee;
						string kDollar = nFee.ToString();

						string ItemToFind = QuestCharacters.QuestItems( true );

						string myexplorer = "##" + ItemToFind + "#" + Server.Misc.Worlds.GetRegionName( theone.Map, theone.Location ) + "#0#" + kDollar + "#" + kWorld + "#Item";
						PlayerSettings.SetQuestInfo( m, "StandardQuest", myexplorer );

						string theStory = myexplorer + "#" + StandardQuestFunctions.QuestSentence( m ); // ADD THE STORY PART

						PlayerSettings.SetQuestInfo( m, "StandardQuest", theStory );
					}
				}
			}
		}

		public static void PayAdventurer( Mobile m )
		{
			string explorer = PlayerSettings.GetQuestInfo( m, "StandardQuest" );

			if ( PlayerSettings.GetQuestState( m, "StandardQuest" )  )
			{
				string sPCTarget = "";
				string sPCTitle = "";
				string sPCName = "";
				string sPCRegion = "";
				int nPCDone = 0;
				int nPCFee = 0;
				string sPCWorld = "";
				string sPCCategory = "";
				string sPCStory = "";

				string[] explorers = explorer.Split('#');
				int nEntry = 1;
				foreach (string explorerz in explorers)
				{
					if ( nEntry == 1 ){ sPCTarget = explorerz; }
					else if ( nEntry == 2 ){ sPCTitle = explorerz; }
					else if ( nEntry == 3 ){ sPCName = explorerz; }
					else if ( nEntry == 4 ){ sPCRegion = explorerz; }
					else if ( nEntry == 5 ){ nPCDone = Convert.ToInt32(explorerz); }
					else if ( nEntry == 6 ){ nPCFee = Convert.ToInt32(explorerz); }
					else if ( nEntry == 7 ){ sPCWorld = explorerz; }
					else if ( nEntry == 8 ){ sPCCategory = explorerz; }
					else if ( nEntry == 9 ){ sPCStory = explorerz; }

					nEntry++;
				}

				if ( nPCDone > 0 && nPCFee > 0 )
				{
					m.SendSound( 0x3D );
					m.AddToBackpack ( new Gold( nPCFee ) );
					string sMessage = "Here is " + nPCFee.ToString() + " gold for you.";
					m.PrivateOverheadMessage(MessageType.Regular, 1150, false, sMessage, m.NetState);
					StandardQuestFunctions.QuestTimeAllowed( m );

					Titles.AwardFame( m, ((int)(nPCFee/100)), true );
					if ( ((PlayerMobile)m).KarmaLocked == true ){ Titles.AwardKarma( m, -((int)(nPCFee/100)), true ); }
					else { Titles.AwardKarma( m, ((int)(nPCFee/100)), true ); }
				}
			}
		}

		public static int DidQuest( Mobile m )
		{
			int nSucceed = 0;

			string explorer = PlayerSettings.GetQuestInfo( m, "StandardQuest" );

			if ( PlayerSettings.GetQuestState( m, "StandardQuest" ) )
			{
				string sPCTarget = "";
				string sPCTitle = "";
				string sPCName = "";
				string sPCRegion = "";
				int nPCDone = 0;
				int nPCFee = 0;
				string sPCWorld = "";
				string sPCCategory = "";
				string sPCStory = "";

				string[] explorers = explorer.Split('#');
				int nEntry = 1;
				foreach (string explorerz in explorers)
				{
					if ( nEntry == 1 ){ sPCTarget = explorerz; }
					else if ( nEntry == 2 ){ sPCTitle = explorerz; }
					else if ( nEntry == 3 ){ sPCName = explorerz; }
					else if ( nEntry == 4 ){ sPCRegion = explorerz; }
					else if ( nEntry == 5 ){ nPCDone = Convert.ToInt32(explorerz); }
					else if ( nEntry == 6 ){ nPCFee = Convert.ToInt32(explorerz); }
					else if ( nEntry == 7 ){ sPCWorld = explorerz; }
					else if ( nEntry == 8 ){ sPCCategory = explorerz; }
					else if ( nEntry == 9 ){ sPCStory = explorerz; }

					nEntry++;
				}

				if ( nPCDone > 0 && nPCFee > 0 )
				{
					nSucceed = 1;
				}
			}
			return nSucceed;
		}

		public static string QuestSentence( Mobile m )
		{
			string sMainQuest = "";

			string explorer = PlayerSettings.GetQuestInfo( m, "StandardQuest" );

			if ( PlayerSettings.GetQuestState( m, "StandardQuest" ) )
			{
				string sPCTarget = "";
				string sPCTitle = "";
				string sPCName = "";
				string sPCRegion = "";
				int nPCDone = 0;
				int nPCFee = 0;
				string sPCWorld = "";
				string sPCCategory = "";
				string sPCStory = "";

				string[] explorers = explorer.Split('#');
				int nEntry = 1;
				foreach (string explorerz in explorers)
				{
					if ( nEntry == 1 ){ sPCTarget = explorerz; }
					else if ( nEntry == 2 ){ sPCTitle = explorerz; }
					else if ( nEntry == 3 ){ sPCName = explorerz; }
					else if ( nEntry == 4 ){ sPCRegion = explorerz; }
					else if ( nEntry == 5 ){ nPCDone = Convert.ToInt32(explorerz); }
					else if ( nEntry == 6 ){ nPCFee = Convert.ToInt32(explorerz); }
					else if ( nEntry == 7 ){ sPCWorld = explorerz; }
					else if ( nEntry == 8 ){ sPCCategory = explorerz; }
					else if ( nEntry == 9 ){ sPCStory = explorerz; }

					nEntry++;
				}

				string sWorth = nPCFee.ToString("#,##0");
				string sTheyCalled = sPCName;
					if ( sPCTitle.Length > 0 ){ sTheyCalled = sPCTitle; }

				string sGiver = QuestCharacters.QuestGiverKarma( ((PlayerMobile)m).KarmaLocked );

				string sWord1 = "you";
				switch ( Utility.RandomMinMax( 0, 4 ) )
				{
					case 0:	sWord1 = "a brave adventurer";	break;
					case 1:	sWord1 = "an adventurer";		break;
					case 2:	sWord1 = "you";					break;
					case 3:	sWord1 = "someone";				break;
					case 4:	sWord1 = "one willing";			break;
				}

				string sWord2 = "go to";
				switch ( Utility.RandomMinMax( 0, 4 ) )
				{
					case 0:	sWord2 = "go to";		break;
					case 1:	sWord2 = "travel to";	break;
					case 2:	sWord2 = "journey to";	break;
					case 3:	sWord2 = "seek out";	break;
					case 4:	sWord2 = "venture to";	break;
				}

				string sWord3 = "kill";

				if ( sPCCategory == "Item" )
				{
					switch ( Utility.RandomMinMax( 0, 3 ) )
					{
						case 0:	sWord3 = "find";			break;
						case 1:	sWord3 = "seek";			break;
						case 2:	sWord3 = "search for";		break;
						case 3:	sWord3 = "bring back";		break;
					}
				}
				else
				{
					switch ( Utility.RandomMinMax( 0, 3 ) )
					{
						case 0:	sWord3 = "eliminate";		break;
						case 1:	sWord3 = "slay";			break;
						case 2:	sWord3 = "kill";			break;
						case 3:	sWord3 = "destroy";			break;
					}
				}

				sMainQuest = sGiver + " wants " + sWord1 + " to " + sWord2 + " " + sPCRegion + " in " + sPCWorld + " and " + sWord3 + " " + sTheyCalled + " for " + sWorth + " gold";
			}
			return sMainQuest;
		}

		public static string QuestStatus( Mobile m )
		{
			string sexplorerQuest = "";

			string explorer = PlayerSettings.GetQuestInfo( m, "StandardQuest" );

			if ( PlayerSettings.GetQuestState( m, "StandardQuest" ) )
			{
				string sPCTarget = "";
				string sPCTitle = "";
				string sPCName = "";
				string sPCRegion = "";
				int nPCDone = 0;
				int nPCFee = 0;
				string sPCWorld = "";
				string sPCCategory = "";
				string sPCStory = "";

				string[] explorers = explorer.Split('#');
				int nEntry = 1;
				foreach (string explorerz in explorers)
				{
					if ( nEntry == 1 ){ sPCTarget = explorerz; }
					else if ( nEntry == 2 ){ sPCTitle = explorerz; }
					else if ( nEntry == 3 ){ sPCName = explorerz; }
					else if ( nEntry == 4 ){ sPCRegion = explorerz; }
					else if ( nEntry == 5 ){ nPCDone = Convert.ToInt32(explorerz); }
					else if ( nEntry == 6 ){ nPCFee = Convert.ToInt32(explorerz); }
					else if ( nEntry == 7 ){ sPCWorld = explorerz; }
					else if ( nEntry == 8 ){ sPCCategory = explorerz; }
					else if ( nEntry == 9 ){ sPCStory = explorerz; }

					nEntry++;
				}

				sexplorerQuest = sPCStory;
				string sWorth = nPCFee.ToString("#,##0");
				if ( nPCDone == 1 ){ sexplorerQuest = "Return to any quest bulletin board for your " + sWorth + " gold payment"; }
			}
			return sexplorerQuest;
		}

		public static int QuestFailure( Mobile m )
		{
			int nPenalty = 0;

			string explorer = PlayerSettings.GetQuestInfo( m, "StandardQuest" );

			if ( PlayerSettings.GetQuestState( m, "StandardQuest" ) )
			{
				string sPCTarget = "";
				string sPCTitle = "";
				string sPCName = "";
				string sPCRegion = "";
				int nPCDone = 0;
				int nPCFee = 0;
				string sPCWorld = "";
				string sPCCategory = "";
				string sPCStory = "";

				string[] explorers = explorer.Split('#');
				int nEntry = 1;
				foreach (string explorerz in explorers)
				{
					if ( nEntry == 1 ){ sPCTarget = explorerz; }
					else if ( nEntry == 2 ){ sPCTitle = explorerz; }
					else if ( nEntry == 3 ){ sPCName = explorerz; }
					else if ( nEntry == 4 ){ sPCRegion = explorerz; }
					else if ( nEntry == 5 ){ nPCDone = Convert.ToInt32(explorerz); }
					else if ( nEntry == 6 ){ nPCFee = Convert.ToInt32(explorerz); }
					else if ( nEntry == 7 ){ sPCWorld = explorerz; }
					else if ( nEntry == 8 ){ sPCCategory = explorerz; }
					else if ( nEntry == 9 ){ sPCStory = explorerz; }

					nEntry++;
				}
				nPenalty = nPCFee;
			}

			if ( nPenalty < 10 )
				nPenalty = 10;

			return nPenalty;
		}
	}
}