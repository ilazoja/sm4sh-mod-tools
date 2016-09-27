using System;
using System.IO;
using System.Collections.Generic;

public class Program
{
	public static string currentMyMusicSoundTitle;
	
	public struct MyMusicSoundEntry
	{
		public string BGMID; // in SoundEntriesBGM
		public string ID;
		public string SoundLab;
		public string BGM1; // = title
		public string BGM2;
		public string BGM3;
		public string BGM4;
		public string BGM5;
		public string InSoundTest;
		public string byte2;
		public string byte3;
		public string byte4;
		public string InRegionJPN;
		public string InRegionEUUS;
		public string SoundSource;
		public string SoundMixType;
		public string IconID;
		public string SoundTestBackImageBehaviour;
		public string[] AssociatedFighters; // Mario | Luigi
		public string SoundTestOrder;
		public string StageCreationOrder;
		public string StageCreationGroup;
		public string short17;
		public string Title;
		public string SoundTestTitle;
		public string Description1;
		public string Description2;
		public string Source;
	}
	public struct BGMSoundEntry
	{
		public string BGMID;
		public string title;
	}
	
	static void FindEmpties()
	{
		string soundDBFile = @"c:\Ilir\Games\WooU\Mod\Title\vol\content\Sm4shBundle\Sm4shExplorer\V0.07.1\SoundDB.csv";
		string outFileName = @"c:\Ilir\Games\WooU\Mod\Title\vol\content\Sm4shBundle\Sm4shExplorer\V0.07.1\EmptiesOutput.txt";
		
		using (StreamWriter sw = new StreamWriter(outFileName))
		{
			using (StreamReader sr = new StreamReader (soundDBFile))
			{
				int i = 0;
				while (i <= 521)
				{
					string[] line = sr.ReadLine().Split (",".ToCharArray());
					if (line[2].StartsWith("Cus") || line[2].StartsWith("TEST"))
					{
						sw.WriteLine(line[0]);
					}
					i++;
				}
			}
		}
	}
	
	static void Main()
	{	
		int command;
		Console.Write("Enter command (1 - FindEmpties, 2 - GenerateEntries, 3 - AppendMusicPacks): ");
		command = int.Parse(Console.ReadLine());
		switch (command)
		{
			case 1:
				GenerateEntries();
				return;
			case 2:
				FindEmpties();
				return;
			case 3:
				AppendMusicPacks();
				return;
			default:
				return;
		}
	}
	
	static void AppendMusicPacks()
	{
		return;
	}
	static void GenerateEntries()
	{
		string soundDBFile = @"c:\Ilir\Games\WooU\Mod\Title\vol\content\Sm4shBundle\Sm4shExplorer\V0.07.1\SoundDB.csv";
		string soundEntriesBGMFile = @"c:\Ilir\Games\WooU\Mod\Title\vol\content\Sm4shBundle\Sm4shExplorer\V0.07.1\SoundEntriesBGMs.csv";
		string outFileName = @"c:\Ilir\Games\WooU\Mod\Title\vol\content\Sm4shBundle\Sm4shExplorer\V0.07.1\SoundEntriesOutput.txt";
		List<MyMusicSoundEntry> MyMusic = new List<MyMusicSoundEntry>();
	    List<BGMSoundEntry> BGMEntries = new List<BGMSoundEntry>();
		using (StreamReader srSE = new StreamReader (soundEntriesBGMFile))
		{
			srSE.ReadLine();
			for (int i = 2; i <= 1676; i++)
			{
				string[] row = srSE.ReadLine().Split (",".ToCharArray());
				BGMSoundEntry BGMentry = new BGMSoundEntry();
				BGMentry.BGMID = row[0];
				Console.WriteLine(i);
				BGMentry.title = row[1];
				BGMEntries.Add(BGMentry);
			}
		}
		
		using (StreamReader sr = new StreamReader (soundDBFile))
		{
			int i = 1;
			while (i <= 1046)
			{
				string[] line = sr.ReadLine().Split (",".ToCharArray());
				MyMusicSoundEntry entry = new MyMusicSoundEntry();
				entry.ID = line[0];			
				Console.WriteLine(entry.ID);
				entry.SoundLab = line[1];
				Console.WriteLine(entry.SoundLab);
				entry.BGM1 = line[2];
				entry.BGM2 = line[3];
				entry.BGM3 = line[4];
				entry.BGM4 = line[5];
				entry.BGM5 = line[6];
				entry.InSoundTest = line[7];
				entry.byte2 = line[8];
				entry.byte3 = line[9];
				entry.byte4 = line[10];
				entry.InRegionJPN = line[11];
				entry.InRegionEUUS = line[12];
				entry.SoundSource = line[13];
				entry.SoundMixType = line[14];
				entry.IconID = ConvertToID(line[15]);
				entry.SoundTestBackImageBehaviour = line[16];
				entry.AssociatedFighters = line[17].Split ("|".ToCharArray());
				if (entry.AssociatedFighters[0] != "")
				{
					for (int p = 0; p < entry.AssociatedFighters.Length; p++)
					{
						entry.AssociatedFighters[p] = ConvertToFighterID(entry.AssociatedFighters[p].Trim());
						Console.WriteLine(entry.AssociatedFighters[p]);
					}
				}
				entry.SoundTestOrder = line[18];
				entry.StageCreationOrder = line[19];
				entry.StageCreationGroup = ConvertToID(line[20]);
				entry.short17 = line[21];
				entry.Title = line[22];
				entry.SoundTestTitle = line[23];
				entry.Description1 = line[24];
				entry.Description2 = line[25];
				entry.Source = line[26];
				
				Console.WriteLine("done");
				
				//now find BGMID in SoundEntriesDB
				
				currentMyMusicSoundTitle = entry.BGM1;
				
				int idx = BGMEntries.FindIndex(FindBGMEntryIndex);
				
				if (idx != -1)
				{					
					Console.WriteLine (BGMEntries[idx].BGMID);		
					entry.BGMID = BGMEntries[idx].BGMID;
					MyMusic.Add(entry);
				}
				
				i++;
			}
		}
		using (StreamWriter sw = new StreamWriter(outFileName))
		{
			foreach (MyMusicSoundEntry m in MyMusic)
			{
				sw.WriteLine("    <se>");
				sw.WriteLine("      <sid>{0}</sid>", m.ID);
				sw.WriteLine("      <BGMFiles>");
				sw.WriteLine("        <seb>");
				sw.WriteLine("          <bid>{0}</bid>", m.BGMID);
				sw.WriteLine("        </seb>");
				sw.WriteLine("      </BGMFiles>");
				sw.WriteLine("      <b1>true</b1>");
				sw.WriteLine("      <b2>true</b2>");
				sw.WriteLine("      <b3>true</b3>");
				sw.WriteLine("      <b4>false</b4>");
				sw.WriteLine("      <b5>true</b5>");
				sw.WriteLine("      <b6>true</b6>");
				sw.WriteLine("      <source>CoreGameSound</source>");
				sw.WriteLine("      <mix>{0}</mix>", m.SoundMixType);
				sw.WriteLine("      <icon>{0}</icon>", m.IconID);
				sw.WriteLine("      <back>{0}</back>", m.SoundTestBackImageBehaviour);
				if (m.AssociatedFighters[0] != "")
				{
					sw.WriteLine("      <AssociatedFightersIDs>");
					for (int i = 0; i < m.AssociatedFighters.Length; i++)
					{
						sw.WriteLine("        <int>{0}</int>", m.AssociatedFighters[i]);
					}
					sw.WriteLine("      </AssociatedFightersIDs>");
				}
				else 
				{
					sw.WriteLine("      <AssociatedFightersIDs />");
				}
				sw.WriteLine("      <storder>999</storder>");
				sw.WriteLine("      <scorder>999</scorder>");
				sw.WriteLine("      <scgid>{0}</scgid>", m.StageCreationGroup);
				sw.WriteLine("      <sho>0</sho>");
				sw.WriteLine("      <t1>{0}</t1>", m.Title);
				sw.WriteLine("      <t2>{0}</t2>", m.SoundTestTitle);
				if (m.Description1 == "") sw.WriteLine("      <d1 />");
				else sw.WriteLine("      <d1>{0}</d1>", m.Description1);
				if (m.Description2 == "") sw.WriteLine("      <d2 />");
				else sw.WriteLine("      <d2>{0}</d2>", m.Description2);	
				sw.WriteLine("      <so>{0}</so>", m.Source);
				sw.WriteLine("    </se>");
			}
		}
		//foreach (MyMusicSoundEntry m in )
		//write in XML format
	}
	
	public static bool FindBGMEntryIndex(BGMSoundEntry soundEntry)
	{
		if (soundEntry.title == currentMyMusicSoundTitle)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	public static string ConvertToID(string icon)
	{
		switch (icon)
		{
			case "smashbros":
				return "0";
			case "donkeykong":
				return "1";
			case "starfox":
				return "2";
			case "kirby":
				return "3";
			case "fzero":
				return "4";
			case "metroid":
				return "5";
			case "mother":
				return "6";
			case "pokemon":
				return "7";
			case "zelda":
				return "8";
			case "mario":
				return "9";
			case "yoshi":
				return "10";
			case "fireemblem":
				return "11";
			case "gamewatch":
				return "12";
			case "pikmin":
				return "13";
			case "wario":
				return "14";
			case "palutena":
				return "15";
			case "famicomrobot":
				return "17";
			case "sonic":
				return "18";
			case "plankton":
				return "19";
			case "touch":
				return "20";
			case "doubutsu":
				return "21";
			case "wiifit":
				return "22";
			case "xenoblade":
				return "23";
			case "punchout":
				return "24";
			case "duckhunt":
				return "25";
			case "rhythm":
				return "26";
			case "rockman":
				return "27";
			case "nintendogs":
				return "28";
			case "miiplaza":
				return "29";
			case "pacman":
				return "30";
			case "tomodachi":
				return "31";
			case "wreckingcrew":
				return "32";
			case "wuhuisland":
				return "33";
			case "miiverse":
				return "34";
			case "lightplane":
				return "35";
			case "braintraining":
				return "36";
			case "balloonfight":
				return "37";
			case "diary":
				return "38";
			case "streetfighter":
				return "39";
			case "finalfantasy":
				return "40";
			case "bayonetta":
				return "41";
			case "etc":
				return "99";
			default:
				return "99";
		}
	}
	public static string ConvertToFighterID(string fighter)
	{
		switch (fighter)
		{
			case "Miifighter":
				return "1";
			case "Miiswordsman":
				return "2";
			case "Miigunner":
				return "3";
			case "Mario":
				return "4";
			case "Donkey":
				return "5";
			case "Link":
				return "6";
			case "Samus":
				return "7";
			case "Yoshi":
				return "8";
			case "Kirby":
				return "9";
			case "Fox":
				return "10";
			case "Pikachu":
				return "11";
			case "Luigi":
				return "12";
			case "Captain":
				return "13";
			case "Ness":
				return "14";
			case "Peach":
				return "15";
			case "Koopa":
				return "16";
			case "Zelda":
				return "17";
			case "Sheik":
				return "18";
			case "Marth":
				return "19";
			case "Gamewatch":
				return "20";
			case "Ganon":
				return "21";
			case "Falco":
				return "22";
			case "Wario":
				return "23";
			case "Metaknight":
				return "24";
			case "Pit":
				return "25";
			case "Szerosuit":
				return "26";
			case "Pikmin":
				return "27";
			case "Diddy":
				return "28";
			case "Dedede":
				return "29";
			case "Ike":
				return "30";
			case "Lucario":
				return "31";
			case "Robot":
				return "32";
			case "Toonlink":
				return "33";
			case "Lizardon":
				return "34";
			case "Sonic":
				return "35";
			case "Dmario":
				return "36";
			case "Rosetta":
				return "37";
			case "Wiifit":
				return "38";
			case "Littlemac":
				return "39";
			case "Murabito":
				return "40";
			case "Palutena":
				return "41";
			case "Reflet":
				return "42";
			case "Duckhunt":
				return "43";
			case "KoopaJr":
				return "44";
			case "Shulk":
				return "45";
			case "Purin":
				return "46";
			case "Lucina":
				return "47";
			case "Pitb":
				return "48";
			case "Gekkouga":
				return "49";
			case "Pacman":
				return "50";
			case "Rockman":
				return "51";
			case "Mewtwo":
				return "52";
			case "Ryu":
				return "53";
			case "Lucas":
				return "54";
			case "Roy":
				return "55";
			case "Cloud":
				return "56";
			case "Bayonetta":
				return "57";
			case "Kamui":
				return "58";
			default:
				return "1";
		}
		
	}
}