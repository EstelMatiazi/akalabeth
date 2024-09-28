using System;
using Server;
using System.Collections;
using Server.Misc;
using Server.Network;
using Server.Commands;
using Server.Commands.Generic;
using Server.Mobiles;
using Server.Accounting;
using Server.Regions;
using Server.Targeting;
using System.Collections.Generic;
using Server.Items;
using Server.Spells.Fifth;
using System.IO;
using System.Xml;

namespace Server.Misc
{
    class ChangeLog
    {
		public static string Version()
		{
			return "Version: Samurai (25 September 2024)";
		}

		public static string Versions()
        {
			string versionTEXT = ""

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Samurai - 25 September 2024<br>"

				+ "<br>"

				+ "* Frogs will now only tongue those they are attacking.<br>"
				+ "   - Applies to similar creatures like vrocks and ropers.<br>"
				+ "* Fixed a bug where singing monsters sang too much.<br>"
				+ "* Fixed the ninjitsu skills to match the book values.<br>"
				+ "* Added descriptions to training dummies and archer buttes.<br>"
				+ "* Fixed some mispellings in various areas.<br>"
				+ "* Magic resist can now maybe resist song effects.<br>"
				+ "* The buildworld commands now run when needed.<br>"
				+ "   - Whenever you change the script files.<br>"
				+ "   - You no longer need to run it unless you want to.<br>"
				+ "* You no longer give thieves chests and stolen deco.<br>"
				+ "   - You sell it to them instead.<br>"
				+ "   - It makes the overall mechanics consistent.<br>"
				+ "* Added some new creatures and variants.<br>"
				+ "* The staff of ultimate power will no longer vanish when held by another.<br>"
				+ "   - It will just leave their hand and no longer drain of power.<br>"
				+ "   - The lore for this item has been updated.<br>"
				+ "* Items, that once allowed only 1 to exist at time, are now character specific.<br>"
				+ "   - Each character can have one, and only one, of each type.<br>"
				+ "   - Items like staff pieces, bane items, or shadowlord items.<br>"
				+ "   - Also items for quest searches like the Chest of Suffering.<br>"
				+ "* Fixed an issue with Tarjan being spawnable too soon.<br>"
				+ "* Priest books now show coordinates and work with sextants.<br>"
				+ "* Jedi holocrons now show coordinates and work with sextants.<br>"
				+ "* Syth datacrons now show coordinates and work with sextants.<br>"
				+ "* Fixed an issue where power scrolls were not displaying the values.<br>"
				+ "* There are two custom settings to control the spawn rates of creatures.<br>"
				+ "* Merchants will say something if they have nothing in stock.<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Executioner - 22 September 2024<br>"

				+ "<br>"

				+ "* Added the remaining sextant coordinate items to use a sextant map.<br>"
				+ "* Fixed an issue where fugitives could not join the theives guild.<br>"
				+ "* The Dungeon Masters Guide has been redone for ease of use.<br>"
				+ "* You can now see hidden creatures under your control.<br>"
				+ "* Fixed an accidental issue where disguises were removed when you move.<br>"
				+ "* Books on crafting and resources have been updated for this game.<br>"
				+ "* Fixed an issue where quests had way too much gold reward.<br>"
				+ "* Scrolls on crafting and materials have been all redone.<br>"
				+ "   - They are now books, but if you found them, you still have them.<br>"
				+ "   - The contents of the books now align with the current trades.<br>"
				+ "* Fixed an error where tasting was tested on non-poisoned food or drink.<br>"
				+ "* Fixed a resource break down that produced more than expected.<br>"
				+ "   - Tried to use the weight variable, but it was unreliable.<br>"
				+ "   - Instead got each exact crafting amount and halved them.<br>"
				+ "* Wax items can now be broken down.<br>"
				+ "* Items needing one resource to craft, can no longer be broken down.<br>"
				+ "* Some merchants will now be busy doing their trades.<br>"
				+ "   - They rotate randomly every hour where half will work.<br>"
				+ "   - Simply provides atmosphere in towns.<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Berserker - 18 September 2024<br>"

				+ "<br>"

				+ "* Provided slight exceptional crafting if skill is over 100.<br>"
				+ "   - Previously, some items were really hard to craft.<br>"
				+ "   - This would make a skill of 125 have no chance at exceptional.<br>"
				+ "* Fixed vendors selling wares they shouldn't for 24x7 servers.<br>"
				+ "* Consolidated chat code for merchants.<br>"
				+ "* Fixed an issue where tools would not provide skill bonuses.<br>"
				+ "   - This would occur if you logged out and back in.<br>"
				+ "   - Prior to this, you would need to re-equip the tool.<br>"
				+ "* Bone brushes now work toward base forensic skill for bone types.<br>"
				+ "* Consolidated creature functions that sing or play instruments.<br>"
				+ "* Added buff icons for creature song effects.<br>"
				+ "* Stone masonry has been resourced like other trades.<br>"
				+ "   - They should now track their resource types.<br>"
				+ "   - You can break them down back into granite.<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Cleric - 14 September 2024<br>"

				+ "<br>"

				+ "* Fixed an issue with taking items from discovered trapped doors.<br>"
				+ "* Fixed the graphics used in the custom hairstylist interface.<br>"
				+ "* Redesigned the paperdoll for tools and trinkets.<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Joker - 12 September 2024<br>"

				+ "<br>"

				+ "* Addressed an issue where some quest rewards were zero gold.<br>"
				+ "   - If you currently have a zero gold quest, drop some gold to clear it.<br>"
				+ "* Addressed an issue where some citizens sell things for zero gold.<br>"
				+ "* Identified items will now stay in the location they are identified.<br>"
				+ "* Items sold will now provide higher values for skill bonuses.<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Bandit - 5 September 2024<br>"

				+ "<br>"

				+ "* Fixed the pirate coat to not be so confusing.<br>"
				+ "* Bracelet of Protection appearance fixed.<br>"
				+ "* Food and drink display fill values.<br>"
				+ "* Bags of holding should no longer put values in the negatives.<br>"
				+ "* Sage no longer says to click on `Status`.<br>"
				+ "* The Time Lord is invulnerable and will attack no one (even criminals).<br>"
				+ "* Treasure map coordinates glitch should be fixed.<br>"
				+ "* Scaled/Gemmed/Skinned armor should not appear in low level dungeons.<br>"
				+ "* Forgotten Halls map bug fixed.<br>"
				+ "* Rock Flesh spell crash fixed.<br>"
				+ "* Buff icons for disguise kits should now remove when the effect ends.<br>"
				+ "* Beeswax should now appear in the pack when harvested.<br>"
				+ "* All 64 Ancient Spells have been fixed and tested.<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Knight - 16 August 2024<br>"

				+ "<br>"

				+ "* Added verbiage when using the alchemy belt pouch.<br>"
				+ "* Fixed a region name that was mispelled.<br>"
				+ "* Fixed a bug where rugs showed a price before identification.<br>"
				+ "* Fixed some repair functions from not repairing some items.<br>"
				+ "* Fixed a bug where some quest world locations all said Sosaria.<br>"
				+ "* Fixed a treasure map, monster spawning crash.<br>"
				+ "* Fixed a crash for the golden ranger quest.<br>"
				+ "* Fixed an issue with rune bags and meditating.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Prophet - 8 August 2024<br>"

				+ "<br>"

				+ "* Magical necromancer wands added.<br>"
				+ "* Another treasure map crash addressed.<br>"
				+ "* Tools should now stay in the hand when meditating.<br>"
				+ "* Characters can now cast travel magic in any house.<br>"
				+ "* Bard songs, that increase resistance, now are capped.<br>"
				+ "* Ancient magic toolbar crash addressed.<br>"
				+ "* A crash with clothing losing durability addressed.<br>"
				+ "* Rune bags have been revamped with new mechanics and interface.<br>"
				+ "* Some spelling or wording errors fixed.<br>"
				+ "* The stuck menu no longer works in homes.<br>"
				+ "* Game client package now has both ClassicUO and TazUO.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Buccaneer - 20 July 2024<br>"

				+ "<br>"

				+ "* Merchants now carry random, mundane items in their backpacks.<br>"
				+ "* Stamina bug fixed.<br>"
				+ "* Minimum taming skill required no longer go past impossible.<br>"
				+ "* Peacemaking bug fixed.<br>"
				+ "* Fixed treasure map crash.<br>"
				+ "* Item durability loss tweaked to be less frequent.<br>"
				+ "* Fixed a crash with certain traps.<br>"
				+ "* Beneficial bard songs now only affect friends.<br>"
				+ "* Fixed a weapon durability flaw.<br>"
				+ "* Hippogriff Karma fixed.<br>"
				+ "* Vendor coin purse bug fixed.<br>"
				+ "* Secret door fixed.<br>"
				+ "* Sextants have been changed.<br>"
				+ "   They still perform the same function. Having one in your pack may provide<br>"
				+ "   a button on parchements that have coordinates on them. Pressing the<br>"
				+ "   button will open a world map, that will have a pin showing the location.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Magician - 16 July 2024<br>"

				+ "<br>"

				+ "This version now comes packaged with the TazUO game client preconfigured.<br>"
				+ "<br>"
				+ "* Moved the custom merchant wagon at the Stonewall Inn.<br>"
				+ "* Fixed animations when riding wyverns, etc.<br>"
				+ "* Drinking beverages will now provide messages.<br>"
				+ "* Treasure tweaks in regards to resources items.<br>"
				+ "* Some items have a new Density attribute.<br>"
				+ "   - See the Library -> Item Properties for more details.<br>"
				+ "* Custom game settings have been added.<br>"
				+ "   - Set a chance of enemy dispel summons.<br>"
				+ "   - Reduce gold given for sold items.<br>"
				+ "   - Configure guild join fees.<br>"
				+ "   - Configure resurrection fees.<br>"
				+ "   - Set a chance loot drops on corpses and chests.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Warlord - 14 June 2024<br>"

				+ "<br>"

				+ "This update has a primary goal of reorganizing, standardizing, and straightening up the current game. Although some new features have been added, they are a small part with the overall effects of this version. Obsolete things have been removed, redunandant items and systems have been combined into a more cohesive system, and the new player experience was given some much needed attention. Below are some general changes with this update, as the details are too great to list.<br>"
				+ "<br>"
				+ "* Crafting overhauled.<br>"
				+ "* Resources overhauled.<br>"
				+ "* Resource crafting properties overhauled.<br>"
				+ "* Interfaces overhauled.<br>"
				+ "* Equipment slot attributes added.<br>"
				+ "* New scalemail armors.<br>"
				+ "* Unidentified items overhauled.<br>"
				+ "* Vendors overhauled.<br>"
				+ "* Additional context menus added.<br>"
				+ "* Options for loot, harvest, and crafting default containers.<br>"
				+ "* Option to gather ordrinary resources.<br>"
				+ "* Unused scripts removed.<br>"
				+ "* Obsolete scripts staged for removal.<br>"
				+ "   - Will be deleted after beta.<br>"
				+ "* Unused scripts removed.<br>"
				+ "* Code reorganized.<br>"
				+ "* Searching skill may allow for 1 chance to avoid chest traps.<br>"
				+ "* Pet bonding delay setting fixed.<br>"
				+ "* Player guide update.<br>"
				+ "   - PDF included.<br>"
				+ "   - Characters will start with a book again.<br>"
				+ "   - The character's Library has this new version.<br>"
				+ "   - Should help new players navigate the game.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Blacksmith - 3 March 2024<br>"

				+ "<br>"

				+ "* The game manual has been updated for completeness.<br>"
				+ "   It will explain much of the changes noted below,<br>"
				+ "   but in a more comprehensive way. READ IT!<br>"
				+ "* Fixed a color issue with purchased rucksacks.<br>"
				+ "* New server setting for character starting gold.<br>"
				+ "* More server settings for network and server name options.<br>"
				+ "* New server setting for enabling custom merchants.<br>"
				+ "   - Adds a wagon and merchant in each settlement.<br>"
				+ "   - List of goods are stored in your INFO folder.<br>"
				+ "   - Allows you to sell custom items.<br>"
				+ "* Lined up item names in the crafting gump.<br>"
				+ "* Tools now have higher uses (around 100 or so).<br>"
				+ "* New setting to allow for crafting many items at once.<br>"
				+ "   Creates new buttons on the crafting window<br>"
				+ "   for making 1, 10, or 100 items at a time.<br>"
				+ "* Drag and drop script support added.<br>"
				+ "   Do these things ONLY if you are updating...<br>"
				+ "   Extract the `Scripts` folder in your INFO directory<br>"
				+ "   that you find in the update package.<br>"
				+ "* World saving has been changed to skip backing up.<br>"
				+ "   files such as articles, news, and your server rules.<br>"
				+ "   It also no longer backs up custom spawns or decorations<br>"
				+ "   as it was unnecessary.<br>"
				+ "* Hidden floor traps have been configured a bit differently.<br>"
				+ "   If they are found, they will become visible and<br>"
				+ "   have a slight glow to them. The graphics are an<br>"
				+ "   animated type when they are still dangerous. If<br>"
				+ "   They are no longer dangerous, they will be motionless.<br>"
				+ "   If you have a good searching skill, and you walk over<br>"
				+ "   a hidden trap, the game will check your skill to see<br>"
				+ "   if you discover it. This will make the trap visible<br>"
				+ "   and dangerous, but you will not trigger it at that<br>"
				+ "   moment.<br>"
				+ "* Custom game settings have been redone.<br>"
				+ "   The settings file is found in the INFO `Scripts`<br>"
				+ "   folder, in a file named `Settings.cs`. You can<br>"
				+ "   edit this to your preferences and then restart the<br>"
				+ "   game. Do a `[buildworld` with the admin account.<br>"
				+ "   Do these things ONLY if you are updating...<br>"
				+ "   - Reference your `settings.xml` file.<br>"
				+ "   - Update your `Settings.cs` to match.<br>"
				+ "   - Delete your `settings.xml` file.<br>"
				+ "* INFO directory reorganized.<br>"
				+ "   Do these things ONLY if you are updating...<br>"
				+ "   Create a `Data` folder in your `Saves` directory<br>"
				+ "   and move these files into it...<br>"
				+ "   - adventures.txt<br>"
				+ "   - battles.txt<br>"
				+ "   - deaths.txt<br>"
				+ "   - journies.txt<br>"
				+ "   - murderers.txt<br>"
				+ "   - online.txt<br>"
				+ "   - quests.txt<br>"
				+ "   - server.txt<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Archmage - 25 February 2024<br>"

				+ "<br>"

				+ "* Both client and server update.<br>"
				+ "* Strange portals now have an entrance and exit.<br>"
				+ "* Ancient Spellbooks are now in the game.<br>"
				+ "   - Part of the spell research system.<br>"
				+ "   - All text and help menus updated.<br>"
				+ "   - Book graphics added.<br>"
				+ "   - Can be equipped like other spellbooks.<br>"
				+ "   - Provides traditional casting gameplay.<br>"
				+ "   - Original research system remains intact.<br>"
				+ "   - Learn about these books from the research bag.<br>"
				+ "* Research bags now hold 50,000 of need items<br>"
				+ "   like scrolls, quills, and ink.<br>"
				+ "* Character level now calculates with the game<br>"
				+ "   skill setttings for any set extra skill points.<br>"
				+ "* Client `music` folder renamed to `Music` to<br>"
				+ "   reduce confusion for Linux clients.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Beggar - 19 February 2024<br>"

				+ "<br>"

				+ "* More item naming fixes, requiring a World.exe update.<br>"
				+ "* Added some new monsters.<br>"
				+ "* Fixed some spell references to incorrect skills.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Enchanter - 12 February 2024<br>"

				+ "<br>"

				+ "* Fixed map decoration issues in Dungeon Clues.<br>"
				+ "* Did a source change to fix naming issues of items added to the game.<br>"
				+ "* Fixed the Artist to give money for paintings you give them.<br>"
				+ "   Both client and server update<br>"
				+ "   Replace your World.exe<br>"
				+ "   Do a [buildworld<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Cultist - 30 January 2024<br>"

				+ "<br>"

				+ "* This is both a client and server update.<br>"
				+ "* Added a settings.xml option for time between hunger and thirst reduction.<br>"
				+ "* Added a settings.xml option for the number of days you can bond a tamed creature.<br>"
				+ "   The screen about the taming skill has been updated about bonding<br>"
				+ "   and it will reflect the number of days you set it at.<br>"
				+ "* Added a settings.xml option to disable the selling of tailor items.<br>"
				+ "   (cloth, cotton, flax, wool, and string)<br>"
				+ "   For those who want to eliminate gold acquisition<br>"
				+ "   from harvesting farms and profiting from cloth.<br>"
				+ "* Fix a bug caused by Razor allowing the casting of unavailable spells.<br>"
				+ "* Updated the client to the latest version of Razor (1.9.77.0).<br>"
				+ "* Updated the client to the latest version of ClassicUO (1.0.0.0).<br>"
				+ "   If upgrading, look at the new settings.xml<br>"
				+ "   where the new settings at the bottom need<br>"
				+ "   to be added to your settings.xml file.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Barbarian - 21 January 2024<br>"

				+ "<br>"

				+ "* Fixed grabbing to use line of sight (toads, ropers, etc).<br>"
				+ "* Fixed the strength potion buff icon.<br>"
				+ "* Added more buff icons for eating magic fish, bandage timers, charm and fear spells.<br>"
				+ "* Standardized curse removal magic. Added other spells that caused curse-type effects.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Jester - 8 January 2024<br>"

				+ "<br>"

				+ "* This is just a world-server update.<br>"
				+ "* Fixed saw mills placed in shops.<br>"
				+ "* Fixed other naming for addons as well.<br>"
				+ "* Like other updates, do a [buildworld.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Druid - 6 January 2024<br>"

				+ "<br>"

				+ "* Buff icons have been added to the game.<br>"
				+ "   Basic testing was done so there may be<br>"
				+ "   slight issues with things like timing,<br>"
				+ "   but the base is all done so tweaking<br>"
				+ "   will be a very simple matter if needed.<br>"
				+ "    - every skill, spell, or potion with a duration effect.<br>"
				+ "    - icons all redone to have the same visual theme.<br>"
				+ "    - information provided when hovering over them.<br>"
				+ "    - about 120 buff icons in the game now.<br>"
				+ "    - added additional icons that the base game did not.<br>"
				+ "         for magics such as necromancy, magery, and.<br>"
				+ "         knight-paladin magic.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Rogue - 26 December 2023<br>"

				+ "<br>"

				+ "* This is both a client and server update.<br>"
				+ "* Update your World.exe file as well.<br>"
				+ "* The [admin window has been cleaned up of old functions.<br>"
				+ "* Ninja animal form lists at least 1 animal to remove confusion.<br>"
				+ "* 4 server settings have been removed:<br>"
				+ "   IF UPGRADING YOU MUST remove these<br>"
				+ "   from you settings.xml file:<br>"
				+ "    - forest cats will use the larger model.<br>"
				+ "    - elephants will be in your game world.<br>"
				+ "    - zebras will be in your game world.<br>"
				+ "    - foxes will be in your game world.<br>"
				+ "* Some new animals added to the game.<br>"
				+ "* Occasional invisible elephant corpses should be fixed.<br>"
				+ "* Added server settings to adjust safari animals in some lands.<br>"
				+ "* New setting to adjust more skill points for characters.<br>"
				+ "    - set in amounts of 100 from 0 to 1,000 extra points.<br>"
				+ "    - still provides benefits for aliens, fugitives, etc.<br>"
				+ "    - in game text about skill points adapt to your settings.<br>"
				+ "* New setting to adjust skill gain for characters.<br>"
				+ "   If upgrading, look at the new settings.xml<br>"
				+ "   where the new settings at the bottom need<br>"
				+ "   to be added to your settings.xml file.<br>"

				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Gladiator - 16 December 2023<br>"

				+ "<br>"

				+ "* This is both a client and server update.<br>"
				+ "* Fixed a saw mill bug found by Nephtan.<br>"
				+ "* Changed the graphic for some player character demon paperdolls.<br>"
				+ "* Fixed a bug when using the barbaric satchel to change equipment.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Cavalier - 22 November 2023<br>"

				+ "<br>"

				+ "* Fixed a wood oil issue found by Nephtan.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Bard - 16 October 2023<br>"

				+ "<br>"

				+ "* Changed the bank box to the larger format.<br>"
				+ "    - Special Update Instructions:<br>"
				+ "    - Download a new client and copy the<br>"
				+ "    - Game/Data/Client/containers.txt<br>"
				+ "    - files and replace yours.<br>"
				+ "* Brass is now based on science where you need copper instead of iron ore.<br>"
				+ "* Fixed some spelling errors.<br>"
				+ "* Added a bit more of the various bags of holding to the treasure tables.<br>"
				+ "* Created mounting bases where you can mount certain slain monsters for the home.<br>"
				+ "* Created stuffing baskets where you can stuff certain slain monsters for the home.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Wizard - 28 July 2023<br>"

				+ "<br>"

				+ "* Did some game and world branding changes.<br>"
				+ "* Implemented a fix for boats crashing while sailing.<br>"
				+ "<br>"

				+ sepLine()

				///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

				+ "Djeryv - 24 July 2023<br>"

				+ "<br>"

				+ "Game branched off, called the Adventurers of Akalabeth.<br>"

				+ "<br>"

			+ "";

			return versionTEXT;
		}

		public static string sepLine()
		{
			return "---------------------------------------------------------------------------------<BR><BR>";
		}
	}
}