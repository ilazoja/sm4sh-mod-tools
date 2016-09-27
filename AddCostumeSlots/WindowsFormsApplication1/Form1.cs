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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string directory;
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
            InitializeComponent();
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
                switch (character)
                {
                    case "Bayonetta":
                        targetPath = directory + @"\content\patch\data\fighter\bayonetta\"; //
                        if (fileType > 10) return;
                        break;
                    case "Captain":
                        targetPath = directory + @"\content\patch\data\fighter\captain\";
                        if (fileType > 10) return;
                        break;
                    case "Cloud":
                        targetPath = directory + @"\content\patch\data\fighter\cloud\";
                        if (fileType > 10) return;
                        break;
                    case "Dedede":
                        targetPath = directory + @"\content\patch\data\fighter\dedede\";
                        if (fileType > 10) return;
                        break;
                    case "Diddy":
                        targetPath = directory + @"\content\patch\data\fighter\diddy\";
                        if (fileType > 10) return;
                        break;
                    case "Donkey":
                        targetPath = directory + @"\content\patch\data\fighter\donkey\";
                        if (fileType > 10) return;
                        break;
                    case "Drmario":
                        targetPath = directory + @"\content\patch\data\fighter\mariod\";
                        if (fileType == 11) targetPath = targetPath + @"model\stethoscope";
                        if (fileType > 10) return;
                        break;
                    case "Duckhunt":
                        targetPath = directory + @"\content\patch\data\fighter\duckhunt\";
                        if (fileType > 10) return;
                        break;
                    case "Falco":
                        targetPath = directory + @"\content\patch\data\fighter\falco\";
                        if (fileType > 10) return;
                        break;
                    case "Fox":
                        targetPath = directory + @"\content\patch\data\fighter\fox\";
                        if (fileType > 10) return;
                        break;
                    case "Gamewatch":
                        targetPath = directory + @"\content\patch\data\fighter\gamewatch\";
                        if (fileType > 10) return;
                        break;
                    case "Ganon":
                        targetPath = directory + @"\content\patch\data\fighter\ganon\";
                        if (fileType > 10) return;
                        break;
                    case "Gekkouga":
                        targetPath = directory + @"\content\patch\data\fighter\gekkouga\";
                        if (fileType > 10) return;
                        break;
                    case "Ike":
                        targetPath = directory + @"\content\patch\data\fighter\ike\";
                        if (fileType > 10) return;
                        break;
                    case "Kamui":
                        targetPath = directory + @"\content\patch\data\fighter\kamui\";
                        if (fileType == 11) targetPath = targetPath + @"model\dragonhand";
                        if (fileType == 12) targetPath = targetPath + @"model\spearhand";
                        if (fileType == 13) targetPath = targetPath + @"model\waterdragon";
                        break;
                    case "Kirby":
                        targetPath = directory + @"\content\patch\data\fighter\kirby\"; //
                        if (fileType > 10) return;
                        break;
                    case "Koopa":
                        targetPath = directory + @"\content\patch\data\fighter\koopa\";
                        if (fileType > 10) return;
                        break;
                    case "KoopaJr":
                        targetPath = directory + @"\content\patch\data\fighter\koopajr\"; //
                        if (fileType == 11) targetPath = targetPath + @"model\kart";
                        if (fileType == 12) targetPath = targetPath + @"model\remainclown";
                        if (fileType == 13) return;
                        break;
                    case "Link":
                        targetPath = directory + @"\content\patch\data\fighter\link\";
                        if (fileType > 10) return;
                        break;
                    case "Littlemac":
                        targetPath = directory + @"\content\patch\data\fighter\littlemac\";
                        if (fileType > 10) return;
                        break;
                    case "Lizardon":
                        targetPath = directory + @"\content\patch\data\fighter\lizardon\";
                        if (fileType > 10) return;
                        break;
                    case "Lucario":
                        targetPath = directory + @"\content\patch\data\fighter\lucario\";
                        if (fileType > 10) return;
                        break;
                    case "Lucas":
                        targetPath = directory + @"\content\patch\data\fighter\lucas\";
                        if (fileType > 10) return;
                        break;
                    case "Lucina":
                        targetPath = directory + @"\content\patch\data\fighter\lucina\";
                        if (fileType > 10) return;
                        break;
                    case "Luigi":
                        targetPath = directory + @"\content\patch\data\fighter\luigi\";
                        if (fileType > 10) return;
                        break;
                    case "Mario":
                        targetPath = directory + @"\content\patch\data\fighter\mario\";
                        if (fileType > 10) return;
                        break;
                    case "Marth":
                        targetPath = directory + @"\content\patch\data\fighter\marth\";
                        if (fileType > 10) return;
                        break;
                    case "Metaknight":
                        targetPath = directory + @"\content\patch\data\fighter\metaknight\";
                        if (fileType == 11) targetPath = targetPath + @"model\mantle";
                        if (fileType > 11) return;
                        break;
                    case "Mewtwo":
                        targetPath = directory + @"\content\patch\data\fighter\mewtwo\";
                        if (fileType > 10) return;
                        break;
                    case "Murabito":
                        targetPath = directory + @"\content\patch\data\fighter\murabito\";
                        if (fileType > 10) return;
                        break;
                    case "Ness":
                        targetPath = directory + @"\content\patch\data\fighter\ness\";
                        if (fileType > 10) return;
                        break;
                    case "Palutena":
                        targetPath = directory + @"\content\patch\data\fighter\palutena\";
                        if (fileType > 10) return;
                        break;
                    case "Peach":
                        targetPath = directory + @"\content\patch\data\fighter\peach\";
                        if (fileType == 11) targetPath = targetPath + @"model\kassar";
                        if (fileType > 11) return;
                        break;
                    case "Pikachu":
                        targetPath = directory + @"\content\patch\data\fighter\pikachu\";
                        if (fileType > 10) return;
                        break;
                    case "Pikmin":
                        targetPath = directory + @"\content\patch\data\fighter\pikmin\";
                        if (fileType > 10) return;
                        break;
                    case "Pit":
                        targetPath = directory + @"\content\patch\data\fighter\pit\";
                        if (fileType > 10) return;
                        break;
                    case "Pitb":
                        targetPath = directory + @"\content\patch\data\fighter\pitb\";
                        if (fileType > 10) return;
                        break;
                    case "Purin":
                        targetPath = directory + @"\content\patch\data\fighter\purin\";
                        if (fileType > 10) return;
                        break;
                    case "Reflet":
                        targetPath = directory + @"\content\patch\data\fighter\reflet\";
                        if (fileType > 10) return;
                        break;
                    case "Robot":
                        targetPath = directory + @"\content\patch\data\fighter\robot\"; //
                        if (fileType > 10) return;
                        break;
                    case "Rockman":
                        targetPath = directory + @"\content\patch\data\fighter\rockman\";
                        if (fileType == 11) targetPath = targetPath + @"model\hardknuckle";
                        if (fileType == 12) targetPath = targetPath + @"model\leftarm";
                        if (fileType == 13) targetPath = targetPath + @"model\rightarm";
                        break;
                    case "Rosetta":
                        targetPath = directory + @"\content\patch\data\fighter\rosetta\";
                        if (fileType > 10) return;
                        break;
                    case "Roy":
                        targetPath = directory + @"\content\patch\data\fighter\roy\";
                        if (fileType > 10) return;
                        break;
                    case "Ryu":
                        targetPath = directory + @"\content\patch\data\fighter\ryu\";
                        if (fileType > 10) return;
                        break;
                    case "Samus":
                        targetPath = directory + @"\content\patch\data\fighter\samus\";
                        if (fileType == 11) targetPath = targetPath + @"model\gun";
                        if (fileType > 11) return;
                        break;
                    case "Sheik":
                        targetPath = directory + @"\content\patch\data\fighter\sheik\";
                        if (fileType > 10) return;
                        break;
                    case "Shulk":
                        targetPath = directory + @"\content\patch\data\fighter\shulk\";
                        break;
                    case "Sonic":
                        targetPath = directory + @"\content\patch\data\fighter\sonic\";
                        if (fileType > 10) return;
                        break;
                    case "Szerosuit":
                        targetPath = directory + @"\content\patch\data\fighter\szerosuit\";
                        if (fileType > 10) return;
                        break;
                    case "Toonlink":
                        targetPath = directory + @"\content\patch\data\fighter\toonlink\";
                        if (fileType > 10) return;
                        break;
                    case "Wario":
                        targetPath = directory + @"\content\patch\data\fighter\wario\"; //
                        if (fileType > 10) return;
                        break;
                    case "Wiifit":
                        targetPath = directory + @"\content\patch\data\fighter\wiifit\";
                        if (fileType > 10) return;
                        break;
                    case "Yoshi":
                        targetPath = directory + @"\content\patch\data\fighter\yoshi\"; //
                        if (fileType > 10) return;
                        break;
                    case "Zelda":
                        targetPath = directory + @"\content\patch\data\fighter\zelda\";
                        if (fileType > 10) return;
                        break;
                    default:
                        break;
                }
                Console.WriteLine(targetPath);;
                string letter = "";
                switch (fileType)
                {
                    case 1:
                        if (!manualInput) GetCostumeNumber(targetPath);
                        letter = @"\c";
                        targetPath = targetPath + letter + costumeNumber.ToString();
                        DirectoryCopy(fileLocation, targetPath);
                        break;
                    case 8:
                        letter = @"\l";
                        targetPath = targetPath + letter + costumeNumber.ToString();
                        DirectoryCopy(fileLocation, targetPath);
                        break;
                    case 5:
                        targetPath = targetPath + "sound";
                        string[] soundFileNameArray = fileName.Split("_".ToCharArray());
                        if (!Directory.Exists(targetPath))
                        {
                            Directory.CreateDirectory(targetPath);
                        }
                        targetPath = targetPath + soundFileNameArray[0] + "_" + soundFileNameArray[1] + "_" + soundFileNameArray[2] + "_c" + (costumeNumber).ToString() + ".nus3bank";
                        File.Copy(fileLocation, targetPath, true);
                        break;
                    default:
                        costumeNumber = numberInput;
                        break;
                }
                Console.WriteLine(targetPath);
                
            }
            else
            {
                string[] chrFileNameArray = fileName.Split("_".ToCharArray());
                if (uiType == "chr_13" && (character == "Bayonetta" || character == "Cloud" || character == "Kamui" || character == "Lucas" || character == "Mewtwo" || character == "Roy" || character == "Ryu"))
                {
                    targetPath = directory + @"\content\patch\data\ui\replace\append\chr" + chrFileNameArray[0] + "_" + chrFileNameArray[1] + @"\" + chrFileNameArray[0] + "_" + chrFileNameArray[1] + "_" + chrFileNameArray[2] + "_" + (costumeNumber + 1).ToString() + ".nut";
                    if (!Directory.Exists(directory + @"\content\patch\data\ui\replace\append\chr" + chrFileNameArray[0] + "_" + chrFileNameArray[1]))
                    {
                        Directory.CreateDirectory(directory + @"\content\patch\data\ui\replace\append\chr" + chrFileNameArray[0] + "_" + chrFileNameArray[1]);
                    }
                }
                else
                {
                    targetPath = directory + @"\content\patch\data\ui\replace\chr" + chrFileNameArray[0] + "_" + chrFileNameArray[1] + @"\" + chrFileNameArray[0] + "_" + chrFileNameArray[1] + "_" + chrFileNameArray[2] + "_" + (costumeNumber + 1).ToString() + ".nut";
                    if (!Directory.Exists(directory + @"\content\patch\data\ui\replace\chr" + chrFileNameArray[0] + "_" + chrFileNameArray[1]))
                    {
                        Directory.CreateDirectory(directory + @"\content\patch\data\ui\replace\chr" + chrFileNameArray[0] + "_" + chrFileNameArray[1]);
                    }
                }

                File.Copy(fileLocation, targetPath, true);

            }
        }

        private void GetCostumeNumber(string targetPath)
        {
            DirectoryInfo dir = new DirectoryInfo(targetPath);
            DirectoryInfo[] dirs = dir.GetDirectories();
            //string[] models = Directory.GetFiles(targetPath, "c").Select(path => Path.GetFileName(path)).ToArray();
            int currentNumber = 0;
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
            character = line[2];
            characterLabel.Text = line[2];
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


    }
}

