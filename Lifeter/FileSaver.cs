using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiteDB;

namespace Lifeter
{
    internal static class FileSaver
    {
        private static string MainFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Lifeter"
            );
        private static string OldSaveFile = Path.Combine(
                MainFolder, "Save.txt"
            );

        private static string MainSaveFile = Path.Combine(
                MainFolder, "save.data"
            );
        private static string CurrentProjFile = Path.Combine(
                MainFolder, "cfg.data"
            );
        private static string OldProjFile = Path.Combine(
                MainFolder, "Current.txt"
            );

        public static bool InitializeFileSystem()
        {
            bool FirstTime = true;

            if (!Directory.Exists(MainFolder))
                Directory.CreateDirectory(MainFolder);
            else FirstTime = false;

            if (!File.Exists(CurrentProjFile))
            {
                File.Create(CurrentProjFile).Close();
                File.WriteAllLines(CurrentProjFile, new string[] { "", "False", ""});
            }

            return FirstTime;
        }

        public static void SaveFile()
        {
            export(MainSaveFile);

            if (MainFrm.syncEnable)
                export(MainFrm.syncPath);
        }
        public static void SaveCurrent()
        {
            using (StreamWriter sw = new StreamWriter(CurrentProjFile))
            {
                sw.Write("");
                sw.WriteLine(MainFrm.currProject);
                sw.WriteLine(MainFrm.syncEnable.ToString());
                sw.WriteLine(MainFrm.syncPath);
            }
        }

        public static void ExportProject(string path)
        {
            try
            {
                if (File.Exists(path)) File.Delete(path);
                using (LiteDatabase db = new LiteDatabase(path))
                {
                    db.Mapper.EmptyStringToNull = false;
                    db.GetCollection<LfProject>("items").Insert(ItemDB.Coll[MainFrm.currProject]);
                }
            }
            catch {
                MessageBox.Show("Could not load save!", "Lifeter");
            }
        }
        public static void ImportProject(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show("File does not exist!");
            }
            else
            {
                import(path);
            }
        }

        public static void Old_LoadFile()
        {
            if (MainFrm.syncEnable && 
                File.Exists(MainFrm.syncPath) && 
                File.GetLastWriteTime(MainFrm.syncPath) > File.GetLastWriteTime(MainSaveFile))

                import(MainFrm.syncPath);
            else import(MainSaveFile);
        }
        public static void Old_LoadCurrent()
        {
            using (StreamReader sr = new StreamReader(CurrentProjFile))
            {
                MainFrm.currProject = sr.ReadLine();
                string b = sr.ReadLine();
                MainFrm.syncEnable = (b == null ? false : bool.Parse(b));
                if(b != null)
                {
                    MainFrm.syncPath = sr.ReadLine();
                }
            }
        }

        public static void LoadFile()
        {
            if (MainFrm.syncEnable &&
                File.Exists(MainFrm.syncPath) &&
                File.GetLastWriteTime(MainFrm.syncPath) > File.GetLastWriteTime(MainSaveFile))
                import(MainFrm.syncPath);
            else if(File.Exists(MainSaveFile)) import(MainSaveFile);
            if (File.Exists(OldSaveFile))
            {
                Old_import(OldSaveFile);
                SaveFile();
                File.Delete(OldSaveFile);
            }
        }
        public static void LoadCurrent()
        {
            if(!File.Exists(OldProjFile))
                using (StreamReader sr = new StreamReader(CurrentProjFile))
                {
                    MainFrm.currProject = sr.ReadLine();
                    string b = sr.ReadLine();
                    MainFrm.syncEnable = (b == null ? false : bool.Parse(b));
                    if (b != null)
                    {
                        MainFrm.syncPath = sr.ReadLine();
                    }
                }
            else
            {
                using (StreamReader sr = new StreamReader(OldProjFile))
                {
                    MainFrm.currProject = sr.ReadLine();
                    string b = sr.ReadLine();
                    MainFrm.syncEnable = (b == null ? false : bool.Parse(b));
                    if (b != null)
                    {
                        MainFrm.syncPath = sr.ReadLine();
                    }
                }
                File.Delete(OldProjFile);
            }
        }

        private static void import(string path)
        {
            using (LiteDatabase db = new LiteDatabase(path))
            {
                LiteCollection<LfProject> coll = db.GetCollection<LfProject>("items");

                foreach(LfProject proj in coll.FindAll())
                {
                    if (!ItemDB.Coll.ContainsKey(proj.Name)) ItemDB.Coll.Add(proj.Name, proj);
                }
            }
        }
        private static void Old_import(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line = "";
                string lastProj = "";

                while (line != null)
                {
                    line = sr.ReadLine();

                    if (line == null)
                        break;


                    if (line.StartsWith("[") && line.EndsWith("]"))
                    {
                        lastProj = line.Substring(1, line.Length - 2);
                        if (!ItemDB.Coll.ContainsKey(lastProj))
                        {
                            ItemDB.Coll.Add(lastProj, new LfProject(lastProj));
                        }
                    }
                    else if (lastProj != "")
                    {
                        int splitIndex;
                        splitIndex = line.IndexOf("|") + 3;

                        string colorStr = line.Remove(0, splitIndex);
                        string itemName = line.Remove(splitIndex - 3, line.Length - splitIndex + 3);

                        Color c = Color.FromArgb(Convert.ToInt32(colorStr));

                        if (ItemDB.Coll.ContainsKey(lastProj))
                        {
                            ItemDB.Coll[lastProj].Items.Add(new LfItem() {Name = itemName, BackColor= Convert.ToInt32(colorStr) });
                        }
                        else
                        {
                            ItemDB.Coll.Add(lastProj, new LfProject(lastProj));

                            ItemDB.Coll[lastProj].Items.Add(new LfItem{Name=itemName, BackColor= Convert.ToInt32(colorStr) });
                        }
                    }
                }
            }
        }

        private static void export(string path)
        {
            try
            {
                if (File.Exists(path)) File.Delete(path);
                using (LiteDatabase db = new LiteDatabase(path))
                {
                    db.Mapper.EmptyStringToNull = false;
                    var coll = db.GetCollection<LfProject>("items");
                    coll.Insert(ItemDB.Coll.Values);
                    //foreach (LfProject p in ItemDB.Coll.Values)
                    //    coll.Upsert(p);
                }
            }
            catch
            {
                MessageBox.Show("Could not load save!", "Lifeter");
            }
        }
    }
}
