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
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using IronPython.Runtime;

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
        int numberInput = 0;
        bool manualInput = false;

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

        private void ModelFolder_TextChanged(object sender, EventArgs e)
        {

        }

        private void WorkspaceDirectory_DragEnter(object sender, DragEventArgs e)
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
        }

        private void ModelFolder_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void ModelFolder_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                ModelFolder.Text = file;
            }
        }
        private void chr00_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void chr00_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                chr00.Text = file;
                FindCharacter(chr00.Text);
            }
        }
        private void chr11_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void chr11_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                chr11.Text = file;
                FindCharacter(chr11.Text);
                
            }
        }
        private void chr13_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void chr13_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                chr13.Text = file;
                FindCharacter(chr13.Text);
            }
        }
        private void stock90_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void stock90_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                stock90.Text = file;
                FindCharacter(stock90.Text);
            }
        }
        private void soundSE_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }
        private void soundSE_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                soundSE.Text = file;
            }
        }
        private void soundVC_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void soundVC_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                soundVC.Text = file;
            }
        }
        private void model2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;

        }

        private void model2_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                model2.Text = file;
            }
        }

        private void model3_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void model3_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                model3.Text = file;
            }
        }

        private void model4_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void model4_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                model4.Text = file;
            }
        }
        private void eightPlayerModel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void eightPlayerModel_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                Console.WriteLine(file);
                eightPlayerModel.Text = file;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoveToDirectory(ModelFolder.Text, 1);
            MoveToDirectory(chr00.Text, 0);
            MoveToDirectory(chr11.Text, 0);
            MoveToDirectory(chr13.Text, 0);
            MoveToDirectory(stock90.Text, 0);
            MoveToDirectory(soundSE.Text, 5);
            MoveToDirectory(soundVC.Text, 5);
            MoveToDirectory(model2.Text, 12);
            MoveToDirectory(model3.Text, 13);
            MoveToDirectory(model4.Text, 14);
            MoveToDirectory(eightPlayerModel.Text, 8);
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
                        break;
                    case 13:
                        if (currentCharacter.model3 == "N/A") return;
                        targetPath = targetPath + currentCharacter.model3;
                        break;
                    case 14:
                        if (currentCharacter.model4 == "N/A") return;
                        targetPath = targetPath + currentCharacter.model4;
                        break;
                    default:
                        costumeNumber = numberInput;
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
            }
        }

        private void FindCharacter(string uiName)
        {
            string[] line = uiName.Split("_".ToCharArray());
            character = line[3];
            characterLabel.Text = line[3];
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
            }
            foreach (Character c in Characters)
            {
                if (c.name == character)
                {
                    currentCharacter = c;
                    return;
                }
            }
        }

        private void chr00_TextChanged(object sender, EventArgs e)
        {

        }

        private void chr11_TextChanged(object sender, EventArgs e)
        {

        }

        private void chr13_TextChanged(object sender, EventArgs e)
        {

        }

        private void stock90_TextChanged(object sender, EventArgs e)
        {

        }

        private void updateCharacterParam_Click(object sender, EventArgs e)
        {

            int totalCostumes = 0;
            string targetPath = "";
            var engine = Python.CreateEngine();
            dynamic scope = engine.CreateScope();
            engine.ExecuteFile(@"C:\Ilir\Games\WooU\Mod\Title\vol\content\Sm4shBundle\Sm4shExplorer\V0.07.1\AddCostumeSlots\UpdateCostumeNumber.py", scope);
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

