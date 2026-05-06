using System;
using System.Collections.Generic;
using System.Text;

namespace Delve{
 internal class UmbraRoom:Room{
  public RoomType Type=RoomType.None;
  public RoomCategory Category=RoomCategory.None;
  public int PowerCost=0;    // ⚡ consumption (Power rooms produce instead)
  public RoomRequirement Requirement=RoomRequirement.None;

  // Múltiples requerimientos combinados
  // RoomRequirement.OrbitalDefencesResearch | RoomRequirement.OpenToSky
  // RoomRequirement.AlienBeaconsResearch | RoomRequirement.SurfaceOnly
  // if(room.Requirement.HasFlag(RoomRequirement.OpenToSky)){...}
  [Flags]
  public enum RoomRequirement{
   None=0,
   OpenToSky=1<<0,
   SurfaceOnly=1<<1,
   EruptionGrid=1<<2,
   OrbitalDefencesResearch=1<<3,
   AlienBeaconsResearch=1<<4,
   AnomalousMaterialsResearch=1<<5,
   CloningResearch=1<<6,
   CyberneticRevivalResearch=1<<7,
  }
  public enum RoomCategory{
   None,Surface,Unit,Power,Miscellaneous,Advanced
  }
 
  public enum RoomType{
   None,
   // Surface
   Habitat,LandingPad,OrbitalDefenceSystem,
   // Unit
   Barracks,CrewQuarters,ChargingBay,SpecialisedQuarters,FabricationBay,GeneticsLab,
   // Power
   Generator,SolarPanels,EruptionEngine,
   // Miscellaneous
   Airlock,Hydroponics,Laboratory,Medbay,RepairBay,
   ResearchAndDevelopment,Scanner,ZoologicalResearchDivision,
   // Advanced
   AlienBeacons,AnomalousResearchLab,CloningBays,Necryogenics
  }
 
  public UmbraRoom(RoomType type,RoomCategory category,int resources,int tradeGoods,int powerCost,string name,string description,RoomRequirement requirement=RoomRequirement.None){
   Type=type;
   Category=category;
   Resources=resources;
   TradeGoods=tradeGoods;
   PowerCost=powerCost;
   Name=name;
   Description=description;
   Requirement=requirement;
  }
 
  public static readonly List<UmbraRoom> Catalogue=new(){
   // Surface
   new UmbraRoom(RoomType.Habitat,               RoomCategory.Surface,        0,  0,  0, "Habitat",                    "It's much easier to build when bits aren't floating and the void ain't calling. Habitats are required for surface building for all planet types except for Goldilocks. Each Habitat can house a single room."),
   new UmbraRoom(RoomType.LandingPad,            RoomCategory.Surface,       20,  0,  5, "Landing Pad",                "Your allies need somewhere to land after all. You need at least one working Landing Pad in order to hire units. If you have the UMBRA: STATIONS expansion, you may also land ships here for additional bonuses.",RoomRequirement.OpenToSky),
   new UmbraRoom(RoomType.OrbitalDefenceSystem,  RoomCategory.Surface,       30, 20,  0, "Orbital Defence System",     "Missiles, lasers, some sort of magnetic railgun, whatever your needs, this defence system will protect this section of your colony from attack. Cancels Asteroid or Strafing Run events that would target this room and any rooms below it in this column, but must be replenished for 10♦ after each use.",RoomRequirement.OrbitalDefencesResearch|RoomRequirement.OpenToSky),
   // Unit
   new UmbraRoom(RoomType.Barracks,              RoomCategory.Unit,          15,  0,  2, "Barracks",                   "A place for your trained soldiers to maintain their fitness and practice their aim. Each grid space of Barracks houses 5 Marines."),
   new UmbraRoom(RoomType.CrewQuarters,          RoomCategory.Unit,          10,  0,  2, "Crew Quarters",              "Your crew needs somewhere to live and sleep while you search for the Reaper's Gambit. Each grid space of Crew Quarters houses 5 Hackers."),
   new UmbraRoom(RoomType.ChargingBay,           RoomCategory.Unit,          20,  0,  6, "Charging Bay",               "While droids don't sleep, they do require somewhere out of the way to recharge. Each grid space of Charging Bays houses 2 Mechanical units."),
   new UmbraRoom(RoomType.SpecialisedQuarters,   RoomCategory.Unit,          20, 10,  4, "Specialised Quarters",       "As the colony expands, so too do our horizons. Aliens, mutants, and weirder still will eventually join our ranks. Each grid space of Specialised Quarters houses 5 units that do not fit elsewhere: alien mercenaries, mutants, dwarves, etc."),
   new UmbraRoom(RoomType.FabricationBay,        RoomCategory.Unit,          18,  0,  8, "Fabrication Bay",            "The ball joint goes in the socket, the socket goes in the... other part. The Fabrication Bay allows you to construct Mechanical units, as well as Security Systems and Barriers."),
   new UmbraRoom(RoomType.GeneticsLab,           RoomCategory.Unit,          25,  0,  4, "Genetics Lab",               "Don't let popular science fiction fool you, making mutants is hard work. The Genetics Lab allows you to hire Mutants. Probably best not to think too much about what that entails..."),
   // Power
   new UmbraRoom(RoomType.Generator,             RoomCategory.Power,         30,  0,  0, "Generator",                  "If it ain't the sound, it's the smell. If it ain't the smell, it's the radiation. Generators provide 25⚡ but leak radiation into all adjacent grid spaces. No unit rooms (except those housing Mutants) can be built in these grid spaces. Units may pass through this room without any effect."),
   new UmbraRoom(RoomType.SolarPanels,           RoomCategory.Power,         15,  0,  0, "Solar Panels",               "Generates power from solar rays. Provides 10⚡; for each adjacent solar panel increase the total gain of the panels by an extra 5. This way three connected panels would provide 40⚡.",RoomRequirement.OpenToSky),
   new UmbraRoom(RoomType.EruptionEngine,        RoomCategory.Power,         25,  0,  0, "Eruption Engine",            "What better source of energy than the very planet on which we stand. These specialised generators provide 15⚡ while also capping an Eruption grid, preventing it from flooding.",RoomRequirement.EruptionGrid),
   // Miscellaneous
   new UmbraRoom(RoomType.Airlock,               RoomCategory.Miscellaneous,  5,  0,  1, "Airlock",                    "Sometimes it's just nice to have a thick metal door between you and the void. Prevents decompression and the spread of gas or liquids. Units passing through an airlock during combat must spend a round waiting inside of it."),
   new UmbraRoom(RoomType.Hydroponics,           RoomCategory.Miscellaneous, 18,  0,  4, "Hydroponics",                "Grows such colony favourites as porrots and catatoes. Each grid space of Hydroponics provides 10♥."),
   new UmbraRoom(RoomType.Laboratory,            RoomCategory.Miscellaneous, 10, 20, 10, "Laboratory",                 "The value of our mission is not measured in precious stones and conquered enemies. It is measured in the knowledge we gain. For every 50♦ invested into the Laboratory, you may draw a card and consult the Research table. Ignore results you already have."),
   new UmbraRoom(RoomType.Medbay,                RoomCategory.Miscellaneous, 20,  0,  8, "Medbay",                     "Cutting edge medical technology. Or at least, it was when we left. After combat, revive one non-Mechanical unit or Troop at full STR."),
   new UmbraRoom(RoomType.RepairBay,             RoomCategory.Miscellaneous, 20,  5,  8, "Repair Bay",                 "A couple engineers, a pot of tea and a broken robot, sounds like paradise. After combat, pay ½ the unit / Troop's cost to revive one Mechanical unit or Troop at full STR."),
   new UmbraRoom(RoomType.ResearchAndDevelopment,RoomCategory.Miscellaneous, 50,  0, 12, "Research and Development",   "The core design purpose of weaponry throughout history: how to best deliver a piece of metal into that smug face over there. All units that spawn on this floor get double STR. Security Systems on this floor may trigger twice before needing to be reset."),
   new UmbraRoom(RoomType.Scanner,               RoomCategory.Miscellaneous, 80,  0,  6, "Scanner",                    "Deep subterranean scans made possible with a mixture of thermal imaging, sonar, seismography, and other expensive things. The Scanner allows you to draw two cards while exploring and choose which one to keep. However, thanks to fate's dark humour, if the Black Joker is drawn, you may not discard it; it must be resolved."),
   new UmbraRoom(RoomType.ZoologicalResearchDivision, RoomCategory.Miscellaneous, 10, 0, 2, "Zoological Research Division", "Who would pass up the opportunity for science? When you defeat a creature from the Natural Formations ♣ table, you can revive it in this room at full STR as a unit you control."),
   // Advanced
   new UmbraRoom(RoomType.AlienBeacons,          RoomCategory.Advanced,      40, 20,  0, "Alien Beacons",              "Luring ships down to our colony is harder than it sounds but these beacons really help. Roll 1D4 at the end of every turn; on a 4, a ship has been lured into landing. Consult the Spaceships table to determine what ship lands. Once a ship has landed, the beacon is used up.",RoomRequirement.AlienBeaconsResearch|RoomRequirement.SurfaceOnly),
   new UmbraRoom(RoomType.AnomalousResearchLab,  RoomCategory.Advanced,      12,  0, 10, "Anomalous Research Lab",     "Dedicated to the study of anomalies, this lab recreates the strange effects of one. Draw a card and consult the Anomalies table to determine which anomaly this lab recreates. Place that anomaly in this grid space.",RoomRequirement.AnomalousMaterialsResearch),
   new UmbraRoom(RoomType.CloningBays,           RoomCategory.Advanced,      20, 20, 18, "Cloning Bays",               "Suspended vats filled with short-lived clones. The ethics committee would have a fit if they knew. Any unit that enters this room during combat is duplicated. However, the clones only last to the end of combat. The vats must be refilled after use for 20♥.",RoomRequirement.CloningResearch),
   new UmbraRoom(RoomType.Necryogenics,          RoomCategory.Advanced,      30,  0,  8, "Necryogenics",               "Cybernetically enhanced corpses kept in freezing temperatures to ward off decay. This room cannot be passed through as it needs to be temperature controlled and the wandering dead are enough to frighten even the most jaded of scientists. You may now recruit Cyber Zombies.",RoomRequirement.CyberneticRevivalResearch),
  };
 }
}