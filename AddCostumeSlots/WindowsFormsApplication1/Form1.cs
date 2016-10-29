using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//using IronPython.Hosting;
//using Microsoft.Scripting.Hosting;
//using IronPython.Runtime;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public class Character
        {
            public string name;
            public string characterDir;
            public string model2;
            public string model3;
            public string model4;
            public bool dlc;
            public int cID;
            
            public Character(string name, string characterDir, string model2, string model3, string model4, bool dlc, int cID)
            {
                this.name = name;
                this.characterDir = characterDir;
                this.model2 = model2;
                this.model3 = model3;
                this.model4 = model4;
                this.dlc = dlc;
                this.cID = cID;
            }
        }

        public List<Character> Characters = new List<Character>();
        string directory;
        Character currentCharacter;
        /*string modelFolder;
        string chr_00;
        string chr_11;
        string chr_13;
        string stock_90;*/

        string character;
        int costumeNumber;
        bool manualInput = false;
        int totalAddedCostumes = 0;

        public Form1()
        {
            Character Bayonetta = new Character("Bayonetta", @"\content\patch\data\fighter\bayonetta\", "N/A", "N/A", "N/A", true, 56);
            Characters.Add(Bayonetta);
            Character Captain = new Character("Captain", @"\content\patch\data\fighter\captain\", "N/A", "N/A", "N/A", false, 12);
            Characters.Add(Captain);
            Character Cloud = new Character("Cloud", @"\content\patch\data\fighter\cloud\", "N/A", "N/A", "N/A", true, 55);
            Characters.Add(Cloud);
            Character Dedede = new Character("Dedede", @"\content\patch\data\fighter\dedede\", "N/A", "N/A", "N/A", false, 28);
            Characters.Add(Dedede);
            Character Diddy = new Character("Diddy", @"\content\patch\data\fighter\diddy\", "N/A", "N/A", "N/A", false, 27);
            Characters.Add(Diddy);
            Character Donkey = new Character("Donkey", @"\content\patch\data\fighter\donkey\", "N/A", "N/A", "N/A", false, 4);
            Characters.Add(Donkey);
            Character Drmario = new Character("Drmario", @"\content\patch\data\fighter\mariod\", @"model\stethoscope", "N/A", "N/A", false, 36);
            Characters.Add(Drmario);
            Character Duckhunt = new Character("Duckhunt", @"\content\patch\data\fighter\duckhunt\", "N/A", "N/A", "N/A", false, 45);
            Characters.Add(Duckhunt);
            Character Falco = new Character("Falco", @"\content\patch\data\fighter\falco\", "N/A", "N/A", "N/A", false, 21);
            Characters.Add(Falco);
            Character Fox = new Character("Fox", @"\content\patch\data\fighter\fox\", "N/A", "N/A", "N/A", false, 9);
            Characters.Add(Fox);
            Character Gamewatch = new Character("Gamewatch", @"\content\patch\data\fighter\gamewatch\", "N/A", "N/A", "N/A", false, 19);
            Characters.Add(Gamewatch);
            Character Ganon = new Character("Ganon", @"\content\patch\data\fighter\ganon\", "N/A", "N/A", "N/A", false, 20);
            Characters.Add(Ganon);
            Character Gekkouga = new Character("Gekkouga", @"\content\patch\data\fighter\gekkouga\", "N/A", "N/A", "N/A", false, 48);
            Characters.Add(Gekkouga);
            Character Ike = new Character("Ike", @"\content\patch\data\fighter\ike\", "N/A", "N/A", "N/A", false, 29);
            Characters.Add(Ike);
            Character Kamui = new Character("Kamui", @"\content\patch\data\fighter\kamui\", @"model\dragonhand", @"model\spearhand", @"model\waterdragon", true, 57);
            Characters.Add(Kamui);
            Character Kirby = new Character("Kirby", @"\content\patch\data\fighter\kirby\", "N/A", "N/A", "N/A", false, 8);
            Characters.Add(Kirby);
            Character Koopa = new Character("Koopa", @"\content\patch\data\fighter\koopa\", "N/A", "N/A", "N/A", false, 15);
            Characters.Add(Koopa);
            Character KoopaJr = new Character("KoopaJr", @"\content\patch\data\fighter\koopajr\", @"model\kart", @"model\remainclown", "N/A", false, 46);
            Characters.Add(KoopaJr);
            Character Link = new Character("Link", @"\content\patch\data\fighter\link\", "N/A", "N/A", "N/A", false, 5);
            Characters.Add(Link);
            Character Littlemac = new Character("Littlemac", @"\content\patch\data\fighter\littlemac\", "N/A", "N/A", "N/A", false, 41);
            Characters.Add(Littlemac);
            Character Lizardon = new Character("Lizardon", @"\content\patch\data\fighter\lizardon\", "N/A", "N/A", "N/A", false, 33);
            Characters.Add(Lizardon);
            Character Lucario = new Character("Lucario", @"\content\patch\data\fighter\lucario\", "N/A", "N/A", "N/A", false, 30);
            Characters.Add(Lucario);
            Character Lucas = new Character("Lucas", @"\content\patch\data\fighter\lucas\", "N/A", "N/A", "N/A", true, 53);
            Characters.Add(Lucas);
            Character Lucina = new Character("Lucina", @"\content\patch\data\fighter\lucina\", "N/A", "N/A", "N/A", false, 37);
            Characters.Add(Lucina);
            Character Luigi = new Character("Ike", @"\content\patch\data\fighter\luigi\", "N/A", "N/A", "N/A", false, 11);
            Characters.Add(Luigi);
            Character Mario = new Character("Mario", @"\content\patch\data\fighter\mario\", "N/A", "N/A", "N/A", false, 3);
            Characters.Add(Mario);
            Character Marth = new Character("Marth", @"\content\patch\data\fighter\marth\", "N/A", "N/A", "N/A", false, 18);
            Characters.Add(Marth);
            Character Metaknight = new Character("Metaknight", @"\content\patch\data\fighter\metaknight\", @"model\mantle", "N/A", "N/A", false, 23);
            Characters.Add(Metaknight);
            Character Mewtwo = new Character("Mewtwo", @"\content\patch\data\fighter\mewtwo\", "N/A", "N/A", "N/A", true, 51);
            Characters.Add(Mewtwo);
            Character Murabito = new Character("Murabito", @"\content\patch\data\fighter\murabito\", "N/A", "N/A", "N/A", false, 42);
            Characters.Add(Murabito);
            Character Ness = new Character("Ness", @"\content\patch\data\fighter\ness\", "N/A", "N/A", "N/A", false, 13);
            Characters.Add(Ness);
            Character Pacman = new Character("Pacman", @"\content\patch\data\fighter\pacman\", "N/A", "N/A", "N/A", false, 49);
            Characters.Add(Pacman);
            Character Palutena = new Character("Palutena", @"\content\patch\data\fighter\palutena\", "N/A", "N/A", "N/A", false, 43);
            Characters.Add(Palutena);
            Character Peach = new Character("Peach", @"\content\patch\data\fighter\peach\", @"model\kassar", "N/A", "N/A", false, 14);
            Characters.Add(Peach);
            Character Pikachu = new Character("Pikachu", @"\content\patch\data\fighter\pikachu\", "N/A", "N/A", "N/A", false, 10);
            Characters.Add(Pikachu);
            Character Pikmin = new Character("Pikmin", @"\content\patch\data\fighter\pikmin\", "N/A", "N/A", "N/A", false, 26);
            Characters.Add(Pikmin);
            Character Pit = new Character("Pit", @"\content\patch\data\fighter\pit\", "N/A", "N/A", "N/A", false, 24);
            Characters.Add(Pit);
            Character Pitb = new Character("Pitb", @"\content\patch\data\fighter\pitb\", "N/A", "N/A", "N/A", false, 38);
            Characters.Add(Pitb);
            Character Purin = new Character("Purin", @"\content\patch\data\fighter\purin\", "N/A", "N/A", "N/A", false, 35);
            Characters.Add(Purin);
            Character Reflet = new Character("Reflet", @"\content\patch\data\fighter\reflet\", "N/A", "N/A", "N/A", false, 44);
            Characters.Add(Reflet);
            Character Robot = new Character("Robot", @"\content\patch\data\fighter\robot\", "N/A", "N/A", "N/A", false, 31);
            Characters.Add(Robot);
            Character Rockman = new Character("Rockman", @"\content\patch\data\fighter\rockman\", @"model\hardknuckle", @"model\leftarm", @"model\rightarm", false, 50);
            Characters.Add(Rockman);
            Character Rosetta = new Character("Rosetta", @"\content\patch\data\fighter\rosetta\", "N/A", "N/A", "N/A", false, 39);
            Characters.Add(Rosetta);
            Character Roy = new Character("Roy", @"\content\patch\data\fighter\roy\", "N/A", "N/A", "N/A", true, 54);
            Characters.Add(Roy);
            Character Ryu = new Character("Ryu", @"\content\patch\data\fighter\ryu\", "N/A", "N/A", "N/A", true, 52);
            Characters.Add(Ryu);
            Character Samus = new Character("Samus", @"\content\patch\data\fighter\samus\", @"model\gun", "N/A", "N/A", false, 6);
            Characters.Add(Samus);
            Character Sheik = new Character("Sheik", @"\content\patch\data\fighter\sheik\", "N/A", "N/A", "N/A", false, 17);
            Characters.Add(Sheik);
            Character Shulk = new Character("Shulk", @"\content\patch\data\fighter\shulk\", "N/A", "N/A", "N/A", false, 47);
            Characters.Add(Shulk);
            Character Sonic = new Character("Sonic", @"\content\patch\data\fighter\sonic\", "N/A", "N/A", "N/A", false, 34);
            Characters.Add(Sonic);
            Character Szerosuit = new Character("Szerosuit", @"\content\patch\data\fighter\szerosuit\", "N/A", "N/A", "N/A", false, 25);
            Characters.Add(Szerosuit);
            Character Toonlink = new Character("Toonlink", @"\content\patch\data\fighter\toonlink\", "N/A", "N/A", "N/A", false, 32);
            Characters.Add(Toonlink);
            Character Wario = new Character("Wario", @"\content\patch\data\fighter\wario\", "N/A", "N/A", "N/A", false, 22);
            Characters.Add(Wario);
            Character Wiifit = new Character("Wiifit", @"\content\patch\data\fighter\wiifit\", "N/A", "N/A", "N/A", false, 40);
            Characters.Add(Wiifit);
            Character Yoshi = new Character("yoshi", @"\content\patch\data\fighter\yoshi\", "N/A", "N/A", "N/A", false, 7);
            Characters.Add(Yoshi);
            Character Zelda = new Character("Zelda", @"\content\patch\data\fighter\zelda\", "N/A", "N/A", "N/A", false, 16);
            Characters.Add(Zelda);
            InitializeComponent();
            WorkspaceDirectory.Text = Properties.Settings.Default.SavedSetting1;
            directory = Properties.Settings.Default.SavedSetting1;
            this.AllowDrop = true;
            FindTotalAddedCostumes();



            // this.DragEnter += new DragEventHandler(ModelFolder_DragEnter);
            //this.DragDrop += new DragEventHandler(ModelFolder_DragDrop);

            /* string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
             foreach (string file in files)
             {
                 Console.WriteLine(file);
                 if (directoryPlaced == true)
                 {
                     directory = file;
                     directoryPlaced = false;
                 }

                 else PlaceInDirectory(file);
             }*/
        }

        private void FindTotalAddedCostumes()
        {
            if (WorkspaceDirectory.Text.IndexOf("workspace") == -1) return;
            string targetPath = "";
            foreach (Character c in Characters)
            {
                targetPath = directory + c.characterDir + @"model\body";
                totalAddedCostumes = totalAddedCostumes + GetCostumeNumber(targetPath) - 8;
                characterLabel.Text = totalAddedCostumes.ToString();
            }
        }
        void DirectoryCopy(string file, string targetPath)
        {
            DirectoryInfo dir = new DirectoryInfo(file);
            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo f in files)
            {
                string temppath = Path.Combine(targetPath, f.Name);
                f.CopyTo(temppath, true);
            }
            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(targetPath, subdir.Name);
                DirectoryCopy(subdir.FullName, temppath);
            }
        }
        private void TB_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void WorkspaceDirectory_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {                
                Console.WriteLine(file);
                WorkspaceDirectory.Text = file;

                directory = file;
            }
            Properties.Settings.Default.SavedSetting1 = directory;
            Properties.Settings.Default.Save();
            FindTotalAddedCostumes();
        }

        private void ModelFolder_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (ModelFolder.Text.Length == 0)
                    ModelFolder.Text = file;
                else
                    ModelFolder.AppendText("\r\n" + file);
                Console.WriteLine(file);
            }
        }

        private void chr00_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                WriteToTextbox(chr00, file);
            }                
        }

        private void chr11_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                WriteToTextbox(chr11, file);
            }
        }

        private void chr13_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                WriteToTextbox(chr13, file);
            }
        }

        private void stock90_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                Console.WriteLine(file);
                WriteToTextbox(stock90, file);
            }
        }

        private void soundSE_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                if (soundSE.Text.Length == 0)
                    soundSE.Text = file;
                else
                    soundSE.AppendText("\r\n" + file);
            }
        }

        private void soundVC_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                if (soundVC.Text.Length == 0)
                    soundVC.Text = file;
                else
                    soundVC.AppendText("\r\n" + file);
            }
        }

        private void model2_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                if (model2.Text.Length == 0)
                    model2.Text = file;
                else
                    model2.AppendText("\r\n" + file);
            }
        }

        private void model3_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                if (model3.Text.Length == 0)
                    model3.Text = file;
                else
                    model3.AppendText("\r\n" + file);
            }
        }

        private void model4_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                if (model4.Text.Length == 0)
                    model4.Text = file;
                else
                    model4.AppendText("\r\n" + file);
            }
        }

        private void eightPlayerModel_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                if (eightPlayerModel.Text.Length == 0)
                    eightPlayerModel.Text = file;
                else
                    eightPlayerModel.AppendText("\r\n" + file);
            }
        }

        private void QuickDrop_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (file.ToLower().IndexOf("chr_00") != -1)
                {
                    WriteToTextbox(chr00, file);
                }
                else if (file.ToLower().IndexOf("chr_11") != -1)
                {
                    WriteToTextbox(chr11, file);
                }
                else if (file.ToLower().IndexOf("chr_13") != -1)
                {
                    WriteToTextbox(chr13, file);
                }
                else if (file.ToLower().IndexOf("stock_90") != -1)
                {
                    WriteToTextbox(stock90, file);
                }
                else if (file.ToLower().IndexOf(".nus3bank") != -1)
                {
                    FileInfo f = new FileInfo(file);
                    if (f.Name.IndexOf("se") != -1) WriteToTextbox(soundSE, file);
                    else if (f.Name.IndexOf("vc") != -1) WriteToTextbox(soundVC, file);
                }
                else
                {
                    DirectoryInfo dir = new DirectoryInfo(file);
                    if (IsModelFolder(dir.Name) == 1) WriteToTextbox(ModelFolder, dir.FullName);
                    else if (IsModelFolder(dir.Name) == 1) WriteToTextbox(eightPlayerModel, dir.FullName);
                    else SearchForFiles(file);
                }
            }
        }

        private int IsModelFolder (string name)
        {
            string firstLetter = name[0].ToString();

            if (firstLetter == "c" && name.Length <= 3 && name != "chr") return 1;
            else if (firstLetter == "l" && name.Length <= 3 && name != "chr") return 2;
            else return 0;
        }

        private void SearchForFiles(string currentFolder)
        {
            DirectoryInfo dir = new DirectoryInfo(currentFolder);
            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();
            foreach (DirectoryInfo d in dirs)
            {
                if (IsModelFolder(d.Name.ToLower()) == 1) WriteToTextbox(ModelFolder, d.FullName);
                else if (IsModelFolder(d.Name.ToLower()) == 2) WriteToTextbox(eightPlayerModel, d.FullName);
                else SearchForFiles(d.FullName);
            }
            foreach (FileInfo f in files)
            {
                if (f.Name.ToLower().IndexOf("chr_00") != -1 && f.Name.ToLower().IndexOf(".nut") != -1)
                    WriteToTextbox(chr00, f.FullName);
                else if (f.Name.ToLower().IndexOf("chr_11") != -1 && f.Name.ToLower().IndexOf(".nut") != -1)
                    WriteToTextbox(chr11, f.FullName);
                else if (f.Name.ToLower().IndexOf("chr_13") != -1 && f.Name.ToLower().IndexOf(".nut") != -1)
                    WriteToTextbox(chr13, f.FullName);
                else if (f.Name.ToLower().IndexOf("stock_90") != -1 && f.Name.ToLower().IndexOf(".nut") != -1)
                    WriteToTextbox(stock90, f.FullName);
                else if (f.Name.ToLower().IndexOf("vc") != -1)
                    WriteToTextbox(soundVC, f.FullName);
                else if (f.Name.ToLower().IndexOf("se") != -1)
                    WriteToTextbox(soundSE, f.FullName);
            }
             
        }
        private void WriteToTextbox(TextBox tb, string file)
        {
            if (tb.Text.Length == 0)
            {
                if (file.IndexOf(".nut") == -1 && file.IndexOf(".nus3bank") == -1 && file.IndexOf("c") == -1 && file.IndexOf("l") == -1)
                {
                    DirectoryInfo dir = new DirectoryInfo(file);
                    FileInfo[] filesInFolder = dir.GetFiles();
                    bool first = true;
                    foreach (FileInfo f in filesInFolder)
                    {
                        if (first)
                        {
                            tb.Text = f.FullName;
                            first = false;
                        }
                        else tb.AppendText("\r\n" + f.FullName);
                    }
                }
                else
                    tb.Text = file;
            }
            else
            {
                if (file.IndexOf(".nut") == -1 && file.IndexOf(".nus3bank") == -1 && file.IndexOf("c") == -1 && file.IndexOf("l") == -1)
                {
                    DirectoryInfo dir = new DirectoryInfo(file);
                    FileInfo[] filesInFolder = dir.GetFiles();
                    foreach (FileInfo f in filesInFolder)
                    {
                        tb.AppendText("\r\n" + f.FullName);
                    }
                }
                else
                    tb.AppendText("\r\n" + file);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (WorkspaceDirectory.Text.IndexOf("workspace") == -1)
            {
                MessageBox.Show(@"Please drag Sm4shExplorer workspace directory to Directory", "Missing/Incorrect Workspace Directory",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            button1.Enabled = false;
            updateCharacterParam.Enabled = false;
            for (int i = 0; i < ModelFolder.Lines.Length; i++)
            {
                FindCharacter(i);
                MoveToDirectory(ModelFolder.Lines[i], 1);
                MoveToDirectory(chr00.Lines[i], 0);
                MoveToDirectory(chr11.Lines[i], 0);
                MoveToDirectory(chr13.Lines[i], 0);
                MoveToDirectory(stock90.Lines[i], 0);
                if (i < soundSE.Lines.Length) MoveToDirectory(soundSE.Lines[i], 5);
                if (i < soundVC.Lines.Length) MoveToDirectory(soundVC.Lines[i], 5);
                if (i < model2.Lines.Length) MoveToDirectory(model2.Lines[i], 12);
                if (i < model3.Lines.Length) MoveToDirectory(model3.Lines[i], 13);
                if (i < model4.Lines.Length) MoveToDirectory(model4.Lines[i], 14);
                if (i < eightPlayerModel.Lines.Length) MoveToDirectory(eightPlayerModel.Lines[i], 8);
                totalAddedCostumes++;
                characterLabel.Text = totalAddedCostumes.ToString();
            }
            ModelFolder.Text = "";
            chr00.Text = "";
            chr11.Text = "";
            chr13.Text = "";
            stock90.Text = "";
            soundSE.Text = "";
            soundVC.Text = "";
            model2.Text = "";
            model3.Text = "";
            model4.Text = "";
            eightPlayerModel.Text = "";
            button1.Enabled = true;
            updateCharacterParam.Enabled = true;
        }
        private void MoveToDirectory(string fileLocation, int fileType)
        {
            if (fileLocation == "") return;
            string[] line = fileLocation.Split(@"\".ToCharArray());
            string targetPath = "";
            string uiType = "";
            string fileName = @"\" + line[line.Length - 1];
            Console.WriteLine(fileName);
            if (fileType > 0)
            {
                targetPath = directory + currentCharacter.characterDir;
                Console.WriteLine(targetPath);
                string letter = "";
                string zero = "";
                switch (fileType)
                {
                    case 1:
                        targetPath = targetPath + @"model\body";
                        if (!manualInput) GetCostumeNumber(targetPath);
                        letter = @"\c";
                        if (costumeNumber < 10) zero = "0";
                        targetPath = targetPath + letter + zero +  costumeNumber.ToString();
                        DirectoryCopy(fileLocation, targetPath);
                        break;
                    case 8:
                        targetPath = targetPath + @"model\body";
                        letter = @"\l";
                        if (costumeNumber < 10) zero = "0";
                        targetPath = targetPath + letter + zero + costumeNumber.ToString();
                        DirectoryCopy(fileLocation, targetPath);
                        break;
                    case 5:
                        targetPath = targetPath + "sound";
                        string[] soundFileNameArray = fileName.Split("_".ToCharArray());
                        if (!Directory.Exists(targetPath))
                        {
                            Directory.CreateDirectory(targetPath);
                        }
                        if (costumeNumber < 10) zero = "0";
                        targetPath = targetPath + soundFileNameArray[0] + "_" + soundFileNameArray[1] + "_" + soundFileNameArray[2] + "_c" + zero + (costumeNumber).ToString() + ".nus3bank";
                        File.Copy(fileLocation, targetPath, true);
                        break;
                    case 12:
                        if (currentCharacter.model2 == "N/A") return;
                        targetPath = targetPath + currentCharacter.model2;
                        letter = @"\c";
                        if (costumeNumber < 10) zero = "0";
                        targetPath = targetPath + letter + zero + costumeNumber.ToString();
                        DirectoryCopy(fileLocation, targetPath);
                        break;
                    case 13:
                        if (currentCharacter.model3 == "N/A") return;
                        targetPath = targetPath + currentCharacter.model3;
                        letter = @"\c";
                        if (costumeNumber < 10) zero = "0";
                        targetPath = targetPath + letter + zero + costumeNumber.ToString();
                        DirectoryCopy(fileLocation, targetPath);
                        break;
                    case 14:
                        if (currentCharacter.model4 == "N/A") return;
                        targetPath = targetPath + currentCharacter.model4;
                        letter = @"\c";
                        if (costumeNumber < 10) zero = "0";
                        targetPath = targetPath + letter + zero + costumeNumber.ToString();
                        DirectoryCopy(fileLocation, targetPath);
                        break;
                    default:
                        break;
                }
                Console.WriteLine(targetPath);
                
            }
            else
            {
                string zero = "";
                if (costumeNumber + 1 < 10) zero = "0";
                string[] chrFileNameArray = fileName.Split("_".ToCharArray());
                if (uiType == "chr_13" && (character == "Bayonetta" || character == "Cloud" || character == "Kamui" || character == "Lucas" || character == "Mewtwo" || character == "Roy" || character == "Ryu"))
                {
                    targetPath = directory + @"\content\patch\data\ui\replace\append\chr" + chrFileNameArray[0] + "_" + chrFileNameArray[1] + @"\" + chrFileNameArray[0] + "_" + chrFileNameArray[1] + "_" + chrFileNameArray[2] + "_" + zero + (costumeNumber + 1).ToString() + ".nut";
                    if (!Directory.Exists(directory + @"\content\patch\data\ui\replace\append\chr" + chrFileNameArray[0] + "_" + chrFileNameArray[1]))
                    {
                        Directory.CreateDirectory(directory + @"\content\patch\data\ui\replace\append\chr" + chrFileNameArray[0] + "_" + chrFileNameArray[1]);
                    }
                }
                else
                {
                    targetPath = directory + @"\content\patch\data\ui\replace\chr" + chrFileNameArray[0] + "_" + chrFileNameArray[1] + @"\" + chrFileNameArray[0] + "_" + chrFileNameArray[1] + "_" + chrFileNameArray[2] + "_" + zero + (costumeNumber + 1).ToString() + ".nut";
                    if (!Directory.Exists(directory + @"\content\patch\data\ui\replace\chr" + chrFileNameArray[0] + "_" + chrFileNameArray[1]))
                    {
                        Directory.CreateDirectory(directory + @"\content\patch\data\ui\replace\chr" + chrFileNameArray[0] + "_" + chrFileNameArray[1]);
                    }
                }

                File.Copy(fileLocation, targetPath, true);

            }
        }

        private int GetCostumeNumber(string targetPath)
        {
            if (!Directory.Exists(targetPath))
            {
                Directory.CreateDirectory(targetPath);
            }
            DirectoryInfo dir = new DirectoryInfo(targetPath);
            DirectoryInfo[] dirs = dir.GetDirectories();
            //string[] models = Directory.GetFiles(targetPath, "c").Select(path => Path.GetFileName(path)).ToArray();
            int currentNumber = 7;
            foreach (DirectoryInfo m in dirs)
            {
                if (m.Name.IndexOf("c") != -1)
                {
                    string[] modelFolderName = m.Name.Split("c".ToCharArray());
                    Console.WriteLine(modelFolderName[1]);
                    currentNumber = Math.Max(int.Parse(modelFolderName[1]), currentNumber);
                } 
                
            }
            costumeNumber = currentNumber + 1;
            return currentNumber + 1;
        }

        private void costumeNum_TextChanged(object sender, EventArgs e)
        {
            int numberInput = 0;
            if (int.TryParse(costumeNum.Text, out numberInput) == true)
            {
                manualInput = true;
                costumeNumber = numberInput;
            }
            else manualInput = false;

        }

        private void FindCharacter(int i)
        {
            string uiName = "";

            if (i < chr00.Lines.Length) uiName = chr00.Lines[i];
            if (i < chr11.Lines.Length) uiName = chr11.Lines[i];
            if (i < chr13.Lines.Length) uiName = chr13.Lines[i];
            if (i < stock90.Lines.Length) uiName = chr13.Lines[i];

            string[] line = uiName.Split("_".ToCharArray());
            character = line[line.Length - 2];
            /*characterLabel.Text = character;
            switch (character)
            {
                case "Drmario":
                    label11.Text = "stethoscope";
                    label12.Text = "N/A";
                    label13.Text = "N/A";
                    break;
                case "Kamui":
                    label11.Text = "dragonhand";
                    label12.Text = "spearhand";
                    label13.Text = "waterdragon";
                    break;
                case "KoopaJr":
                    label11.Text = "kart";
                    label12.Text = "remainclown";
                    label13.Text = "N/A";
                    break;
                case "Metaknight":
                    label11.Text = "mantle";
                    label12.Text = "N/A";
                    label13.Text = "N/A";
                    break;
                case "Peach":
                    label11.Text = "kassar";
                    label12.Text = "N/A";
                    label13.Text = "N/A";
                    break;
                case "Robot":
                    label11.Text = "gyro";
                    label12.Text = "gyroholder";
                    label13.Text = "N/A";
                    break;
                case "Rockman":
                    label11.Text = "hardknuckle";
                    label12.Text = "leftarm";
                    label13.Text = "rightarm";
                    break;
                case "Samus":
                    label11.Text = "gun";
                    label12.Text = "N/A";
                    label13.Text = "N/A";
                    break;
                case "Yoshi":
                    label11.Text = "tamago";
                    label12.Text = "N/A";
                    label13.Text = "N/A";
                    break;
                default:
                    label11.Text = "N/A";
                    label12.Text = "N/A";
                    label13.Text = "N/A";
                    break;
                    //Pit add option?
                    //Pitb add option?
                    //Littlemac: Add hoodie option?
                    //Gamewatch Fix later
            }*/
            foreach (Character c in Characters)
            {
                if (c.name == character)
                {
                    currentCharacter = c;
                    return;
                }
            }
        }

        private void updateCharacterParam_Click(object sender, EventArgs e)
        {
            if (WorkspaceDirectory.Text == "")
            {
                MessageBox.Show(@"Please drag Sm4shExplorer workspace directory to Directory", "Missing Workspace Directory",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            updateCharacterParam.Enabled = false;
            button1.Enabled = false;

            int totalCostumes = 0;
            string targetPath = "";
            foreach (Character c in Characters)
            {
                targetPath = directory + c.characterDir + @"model\body";
                totalCostumes = GetCostumeNumber(targetPath);
                if (!modifyUICharacterDB(c.cID + 1, totalCostumes)) break;
            }

            updateCharacterParam.Enabled = true;
            button1.Enabled = true;

            /*var engine = Python.CreateEngine();
            dynamic scope = engine.CreateScope();
            engine.ExecuteFile(@"C:\_______\Games\WooU\Mod\Title\vol\content\Sm4shBundle\Sm4shExplorer\V0.07.1\AddCostumeSlots\UpdateCostumeNumber.py", scope);
            foreach (Character c in Characters)
            {
                targetPath = directory + c.characterDir + @"model\body";
                totalCostumes = GetCostumeNumber(targetPath);
                scope.modifiedCostume(c.cID, totalCostumes);
            }
            scope.saveParam();
            Console.WriteLine("done");
            System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
            this.Close(); //to turn off current app
            */


            /* string cPath = ",";
             long[] characterParams;
             long[] characterParamType;
             long characterNumber;
            try
              {
               openParam(directory, out characterParams, out characterParamType, out characterNumber);
               cPath = directory;
              }
               catch (InvalidCastException e)
               {

                }   */
        }

        public bool modifyUICharacterDB(int characterposition, int value)
        {
            Stream stream = null;
            try
            {
                stream = File.Open(directory + @"\content\patch\data(us_en)\param\ui\ui_character_db.bin", FileMode.Open);
            }
            catch (Exception e)
            {
                MessageBox.Show(@"Cannot find ui_character_db.bin in \content\patch\data(us_en)\param\ui\ui_character_db.bin", "Missing ui_character_db.bin",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            using (BinaryReader br = new BinaryReader(stream))
           {
               long pose = 13 + (127 * characterposition) + 26;
               Console.WriteLine(characterposition);
               stream.Seek(pose, SeekOrigin.Begin);
               int bit = br.ReadByte();
               switch (bit)
               {
                   case 2:
                       stream.WriteByte(BitConverter.GetBytes(value)[0]);
                       break;

                   case 5:
                       Byte[] bytes = BitConverter.GetBytes(value);
                       Array.Reverse(bytes);
                       stream.Write(bytes, 0, 4);
                       break;
                   case 6:
                       Byte[] bytes2 = BitConverter.GetBytes(value);
                       Array.Reverse(bytes2);
                       stream.Write(bytes2, 0, 4);
                       break;
               }
           }
            return true;

        }

        private void TB_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            if (e.Control && e.KeyCode == Keys.A) textbox.SelectAll();
        }


        private void TB_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TextBox textbox = (TextBox)sender;

            //Get character positions for the current line
            int firstCharPosition = textbox.GetFirstCharIndexOfCurrentLine();
            int lineNumber = textbox.GetLineFromCharIndex(firstCharPosition);
            int lastCharPosition = textbox.GetFirstCharIndexFromLine(lineNumber + 1);
            if (lastCharPosition == -1) lastCharPosition = textbox.TextLength;

            textbox.SelectionStart = firstCharPosition;
            textbox.SelectionLength = lastCharPosition - firstCharPosition;
        }

        private void CreateTextboxToolTip(object sender, TextBox textbox)
        {
            Label L = (Label)sender;
            int VisibleTime = 1000;  //in milliseconds

            ToolTip tt = new ToolTip();
            tt.Show("Number of entries: " + textbox.Lines.Length + "\r\n" + textbox.Text, L, 0, 10, VisibleTime);
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            CreateTextboxToolTip(sender, ModelFolder);
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            CreateTextboxToolTip(sender, chr00);
        }

        private void label14_MouseHover(object sender, EventArgs e)
        {
            CreateTextboxToolTip(sender, eightPlayerModel);
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            CreateTextboxToolTip(sender, chr11);
        }

        private void label11_MouseHover(object sender, EventArgs e)
        {
            CreateTextboxToolTip(sender, model2);
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            CreateTextboxToolTip(sender, chr13);
        }

        private void label12_MouseHover(object sender, EventArgs e)
        {
            CreateTextboxToolTip(sender, model3);
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            CreateTextboxToolTip(sender, stock90);
        }

        private void label13_MouseHover(object sender, EventArgs e)
        {
            CreateTextboxToolTip(sender, model4);
        }

        private void label9_MouseHover(object sender, EventArgs e)
        {
            CreateTextboxToolTip(sender, soundSE);
        }

        private void label10_MouseHover(object sender, EventArgs e)
        {
            CreateTextboxToolTip(sender, soundVC);
        }

        private void label15_MouseHover(object sender, EventArgs e)
        {
            Label L = (Label)sender;
            int VisibleTime = 1000;  //in milliseconds

            ToolTip tt = new ToolTip();
            tt.Show("Drag and drop modelFolder, chr_00, chr_11, chr_13 and stock_90", L, 0, 10, VisibleTime);
        }

        /* private void openParam(string fileName, out long[] characterParams, out long[] characterParamType, out long characterNumber)
         {
             using (BinaryReader f = new BinaryReader(File.Open(fileName, FileMode.Open)))
             {
                 long entryNums = 0;
                 List<long> entries = new List<long>();
                 List<long> entryType = new List<long>();

                 f.BaseStream.Seek(8, SeekOrigin.Begin);
                 var fr = f.ReadByte();
                 Console.WriteLine(fr);
                 if (fr == 0x20)
                 {
                     entryNums = StringToInt(f.ReadBytes(4));
                     byte temp = 0;
                     while (f.BaseStream.Position != f.BaseStream.Length)
                     {
                         temp = f.ReadByte();
                         if (f.BaseStream.Position != f.BaseStream.Length)
                         {
                             var typeCode = temp; //typeCode
                             entryType.Add(typeCode);
                             if (typeCode == 0x1) //type is 8 bit int (unsigned)
                             {
                                 entryType.Add(StringToInt(f.ReadBytes(1)));
                             }
                             if (typeCode == 0x2) //type is 8 bit int (signed)
                             {
                                 entryType.Add(HexInt(f.ReadBytes(1)));
                             }
                             if (typeCode == 0x3) //type is 16 bit int (unsigned)
                             {
                                 entryType.Add(StringToInt(f.ReadBytes(2)));
                             }
                             if (typeCode == 0x4) //type is 16 bit int (signed)
                             {
                                 entryType.Add(HexInt(f.ReadBytes(2)));
                             }
                             if (typeCode == 0x5) //type is 32 bit int (unsigned)
                             {
                                 entryType.Add(StringToInt(f.ReadBytes(3)));
                             }
                             if (typeCode == 0x6) //type is 32 bit int (signed)
                             {
                                 entryType.Add(HexInt(f.ReadBytes(3)));
                             }
                             if (typeCode == 0x7) //type is 32 bit float
                             {
                                 entryType.Add(StringToInt(f.ReadBytes(3)));
                             }
                         }


                     }
                 }
                 characterParams = entries.ToArray();
                 characterParamType = entryType.ToArray();
                 characterNumber = entryNums;
             }

         }

         private long StringToInt(byte[] s)
         {
             int current = 0;
             foreach (byte c in s)
             {
                 current = (current * 256) + c;
             }
             return current;
         }
         private long HexInt(byte[] s)
         {
             string hex = BitConverter.ToString(s);
             hex = hex.Replace("-", "");
             long x = long.Parse(hex, System.Globalization.NumberStyles.HexNumber);
             if (x > 0x7FFFFFFF) x -= 0x100000000;
             return x;
         }*/
    }
}

