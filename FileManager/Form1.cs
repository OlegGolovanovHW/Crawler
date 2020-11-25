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
using System.IO.Compression;
//using System.IO.Compression.FileSystem;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using System.Text.RegularExpressions;
using System.Globalization;

namespace FileManager
{
    public partial class Form1 : Form
    {
        FileSystemWatcher WatcherLeft = new FileSystemWatcher();
        FileSystemWatcher WatcherRight = new FileSystemWatcher();
        public List<string> current_files_left; //список всех файлов в текущей директории
        public List<string> current_files_right;
        public List<string> gzipped_files = new List<string>(); //нужно сериализовать
        public string the_name_of_the_current_folder_or_file_left;
        public string the_name_of_the_current_folder_or_file_right;
        public string sourceFileNameToCopy;
        public string sourceFileNameToMove;
        public string sourceFileToCopy;
        public string sourceFileToMove;
        public string sourceFolderNameToCopy;
        public string sourceFolderNameToMove;
        public string sourceFolderToCopy;
        public string sourceFolderToMove;
        public string destFileToCopy;
        public string destFileToMove;
        public string destFolderToMove;
        public string destFolderToCopy;
        public string RenamingObjectDirectory;
        public string theme;
        public bool first_click_on_copy = true;
        public bool second_click_on_copy = false;
        public bool first_click_on_move = true;
        public bool second_click_on_move = false;
        public bool left_panel_was_clicked_last = false;
        public bool right_panel_was_clicked_last = false;
        public bool the_file_is_copying = false;
        public bool the_folder_is_copying = false;
        public bool the_file_is_moving = false;
        public bool the_folder_is_moving = false;
        public bool search_performed_left = false;
        public bool search_performed_right = false;
        public int bytesCopied;
        public const int BufferSize = 16384;
        public byte[] buffer = new byte[BufferSize];
        public Font DefaultFont = new Font("Microsoft Sans Serif", (float)8.25, FontStyle.Regular);
        public FileManagerSettings userPrefs;
        public BinaryFormatter binFormat = new BinaryFormatter();
        public List<Book> BooksOnTheLeft = new List<Book>();
        public List<Book> BooksOnTheRight = new List<Book>();
        public Regex SearchIDandName;
        public Regex SearchRating;
        public Regex SearchPrice;
        [Serializable]
        public class FileManagerSettings
        {
            public Color backColorForm;
            public Image backgroundImage;
            public string theme;
            public Font font;
            public Font menuStripFont;
            public double opacity;
            public FileManagerSettings(Form1 frm1)
            {
                theme = frm1.theme;
                backColorForm = frm1.BackColor;
                backgroundImage = frm1.BackgroundImage;
                font = frm1.Font;
                menuStripFont = frm1.menuStrip.Font;
                opacity = frm1.Opacity;
            }
            public FileManagerSettings()
            {

            }
        }



        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Copy.Enabled = false;
            Move.Enabled = false;
            Edit.Enabled = false;
            Delete.Enabled = false;
            Archive.Enabled = false;

            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\FileManagerSettings.dat"))
            {
                Stream fstream = File.OpenRead(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\FileManagerSettings.dat");
                userPrefs = (FileManagerSettings)binFormat.Deserialize(fstream);
                fstream.Close();
                //восстанавливаем вид формы
                if (userPrefs.theme == "WHITE")
                {
                    Form2.ChangeTheme(Color.White, Color.Black, this);
                    this.theme = "WHITE";
                }
                else if (userPrefs.theme == "BLACK")
                {
                    Form2.ChangeTheme(Color.Black, Color.Green, this);
                    this.theme = "BLACK";
                }
                this.BackColor = userPrefs.backColorForm;
                this.BackgroundImage = userPrefs.backgroundImage;
                this.Font = userPrefs.font;
                this.menuStrip.Font = userPrefs.menuStripFont;
                this.Opacity = userPrefs.opacity;
            }
            else
            {
                userPrefs = new FileManagerSettings(this);
            }
            //загружаем приводы
            ListOfItemsLeft.Items.Add("Python");
            ListOfItemsRight.Items.Add("Python");
            ListOfItemsLeft.Items.Add("Ruby");
            ListOfItemsRight.Items.Add("Ruby");
            ListOfItemsLeft.Items.Add("C++");
            ListOfItemsRight.Items.Add("C++");
            ListOfItemsLeft.Items.Add("Java");
            ListOfItemsRight.Items.Add("Java");
            ListOfItemsLeft.Items.Add("C#");
            ListOfItemsRight.Items.Add("C#");


            WatcherLeft.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            WatcherRight.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            WatcherLeft.Filter = "";
            WatcherLeft.Changed += WatcherLeft_Change;
            WatcherLeft.Created += WatcherLeft_Change;
            WatcherLeft.Deleted += WatcherLeft_Change;
            WatcherLeft.Renamed += WatcherLeft_Change;

            WatcherRight.Filter = "";
            WatcherRight.Changed += WatcherRight_Change;
            WatcherRight.Created += WatcherRight_Change;
            WatcherRight.Deleted += WatcherRight_Change;
            WatcherRight.Renamed += WatcherRight_Change;
            
            //ListOfItemsLeft.Click += new EventHandler(ListOfItemsLeft_Click);
            //ListOfItemsRight.Click += new EventHandler(ListOfItemsRight_Click);
            //обработка двойного клика мышью по объекту в ListBox
            ListOfItemsLeft.DoubleClick += new EventHandler(ListOfItemsLeft_DoubleClick);
            ListOfItemsRight.DoubleClick += new EventHandler(ListOfItemsRight_DoubleClick);             
            //обработка поиска по запросу

        }
        private void WatcherLeft_Change(object source, FileSystemEventArgs e)
        {
            ListOfItemsLeft.Items.Clear();
            GetAndDisplayDirectory(ListOfItemsLeft, CurrentPathLeft, the_name_of_the_current_folder_or_file_left, ref current_files_left);
        }
        private void WatcherRight_Change(object source, FileSystemEventArgs e)
        {
            ListOfItemsRight.Items.Clear();
            GetAndDisplayDirectory(ListOfItemsRight, CurrentPathRight, the_name_of_the_current_folder_or_file_right, ref current_files_right);
        } 

        private void ListOfItemsLeft_Click(object sender, EventArgs e)
        {
            if (CurrentPathLeft.Text != "")
            {
                WatcherLeft.Path = CurrentPathLeft.Text;
            }
            ListOfItemsRight.ClearSelected();
            left_panel_was_clicked_last = true;
            right_panel_was_clicked_last = false;
        }

        private void ListOfItemsRight_Click(object sender, EventArgs e)
        {
            if (CurrentPathRight.Text != "")
            {
                WatcherRight.Path = CurrentPathRight.Text;
            }
            ListOfItemsLeft.ClearSelected();
            left_panel_was_clicked_last = false;
            right_panel_was_clicked_last = true;
        }

        private void ListOfItemsLeft_DoubleClick(object sender, EventArgs e)
        {
            DoubleClickHandler(ListOfItemsLeft, ref BooksOnTheLeft, ref search_performed_left); //обновляем содержимое директории
        }

        private void ListOfItemsRight_DoubleClick(object sender, EventArgs e)
        {
            DoubleClickHandler(ListOfItemsRight, ref BooksOnTheRight, ref search_performed_right); //обновляем содержимое директории
        }

        private void EscapeLeft_Click(object sender, EventArgs e)
        {
            EscapeHandler(ListOfItemsLeft, CurrentPathLeft, the_name_of_the_current_folder_or_file_left, ref current_files_left);
        }

        private void EscapeRight_Click(object sender, EventArgs e)
        {
            EscapeHandler(ListOfItemsRight, CurrentPathRight, the_name_of_the_current_folder_or_file_right, ref current_files_right);
        }

        private void EscapeHandler(ListBox ListOfItems, RichTextBox CurrentPath, string the_name_of_the_current_folder_or_file, ref List<string> current_files)
        {
            
            if (CurrentPath.Text.Length > 0)
            {
                int k = CurrentPath.Text.Length - 2;
                int cnt = 0;
                bool isDrive = true;
                while (k > 0)
                {
                    if (CurrentPath.Text[k] == '\\')
                    {
                        isDrive = false;
                        break;
                    }
                    cnt++;
                    k--;
                }
                if (isDrive)
                {
                    CurrentPath.Text = "";
                    ListOfItems.Items.Clear();
                    DriveInfo[] drives = DriveInfo.GetDrives();
                    foreach (DriveInfo info in drives)
                    {
                        ListOfItems.Items.Add(info.Name);
                    }
                }
                else
                {
                    CurrentPath.Text = CurrentPath.Text.Remove(CurrentPath.Text.Length - cnt - 1, cnt + 1);
                    ListOfItems.Items.Clear();
                    GetAndDisplayDirectory(ListOfItems, CurrentPath, the_name_of_the_current_folder_or_file, ref current_files);
                }
            }      
        }

        private void DoubleClickHandler(ListBox ListOfItems, ref List<Book> Books, ref bool search_performed) //открытие папки
        {
            if (ListOfItems.SelectedItem != null) //если некоторый предмет был выбран  
            {
                if (search_performed)
                {
                    string link = "";
                    for (int i = 0; i < Books.Count(); i++)
                    {
                        if (ListOfItems.SelectedItem.ToString() == Books[i].SummOfAllParameters)
                        {
                            link = Books[i].Link;
                            break;
                        }
                    }
                    if (link != "")
                    {
                        System.Diagnostics.Process.Start("https://www.ozon.ru/context/detail/id/" + link);
                    }
                }
                else
                {
                    Books = GetBooksList(new List<Book>(), "50", ListOfItems.SelectedItem.ToString(), ref search_performed);
                    ListOfItems.Items.Clear();
                    foreach (Book book in Books)
                    {
                        ListOfItems.Items.Add(book.SummOfAllParameters);
                    }
                }
            }
        }
        
        private int IsFile(ListBox ListOfItems, RichTextBox CurrentPath, ref List<string> current_files) //
        {
            if (ListOfItems.SelectedItem != null)
            {
                bool isFile = false;
                if (current_files != null) //является предмет папкой или файлом
                {
                    foreach (string curr_file in current_files)
                    {
                        if (CurrentPath.Text + ListOfItems.SelectedItem.ToString() == curr_file)
                        {
                            isFile = true;
                        }
                    }
                }
                return (isFile ? 1 : 0); 
            }
            else
            {
                return -1; //значит элемент не выбран
            }
        }

        private void GetAndDisplayDirectory(ListBox ListOfItems, RichTextBox CurrentPath, string the_name_of_the_current_folder_or_file, ref List<string> current_files)
        {
            if (ListOfItems == ListOfItemsLeft)
            {
                WatcherLeft.Path = CurrentPathLeft.Text;
                WatcherLeft.EnableRaisingEvents = true;
            }
            else if (ListOfItems == ListOfItemsRight)
            {
                WatcherRight.Path = CurrentPathRight.Text;
                WatcherRight.EnableRaisingEvents = true;
            }
            string[] allfolders = Directory.GetDirectories(CurrentPath.Text); //получаем список всех папок в директории
            foreach (string folder in allfolders) //Добавляем названия всех папок в список, отвечающий за текущюю директорию
            {
                int i = folder.Length - 1;
                string str0 = "";
                while (folder[i] != '\\')
                {
                    str0 += folder[i];
                    i--;
                }
                string fldr = "";
                for (int j = str0.Length - 1; j >= 0; j--)
                {
                    fldr += str0[j];
                }
                ListOfItems.Items.Add(fldr);
            }
            string[] allfiles = Directory.GetFiles(CurrentPath.Text); //получаем список всех файлов в директории
            current_files = new List<string>(allfiles); //сохраняем список файлов из текущей директории
            foreach (string filename in allfiles) //Добавляем названия всех файлов в список, отвечающий за текущюю директорию
            {
                ListOfItems.Items.Add(ExtractingNameFromObjectPath(filename));
            }
        }

        private string ExtractingNameFromObjectPath(string ObjectPath)
        {
            string s0 = "";
            string FileName = "";
            int i = ObjectPath.Length - 1;
            while (ObjectPath[i] != '\\')
            {
                s0 += ObjectPath[i];
                i--;
            }
            for (int j = s0.Length - 1; j >= 0; j--)
            {
                FileName += s0[j];
            }
            return FileName;
        }
        
        private string ExtractingDirectoryFromObjectPath(string ObjectPath)
        {
            return ObjectPath.Substring(0, ObjectPath.Length - ExtractingNameFromObjectPath(ObjectPath).Length);
        }

        private string ExtractingExtensionFromFilePath(string FilePath)
        {
            string s0 = "";
            string extension = "";
            int i = FilePath.Length - 1;
            while (i >= 0 && FilePath[i] != '.')
            {
                s0 += FilePath[i];
                i--;
            }
            s0 += ".";
            for (int j = s0.Length - 1; j >= 0; j--)
            {
                extension += s0[j];
            }
            return extension;
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            CopyOrMoveInterface(Copy, ref first_click_on_copy, ref second_click_on_copy);
        }
        private void CopyOrMoveInterface(Button button, ref bool first_click_on_button, ref bool second_click_on_button)
        {
            if (first_click_on_button && (ListOfItemsLeft.SelectedItem != null || ListOfItemsRight.SelectedItem != null))
            {
                if (button == Copy)
                {
                    button.Text = "Copy [object in buffer]";
                    Move.Enabled = false;
                }
                else if (button == Move)
                {
                    button.Text = "Move [object in buffer]";
                    Copy.Enabled = false;
                }
                if (ListOfItemsLeft.SelectedItem != null)
                {
                    if (IsFile(ListOfItemsLeft, CurrentPathLeft, ref current_files_left).Equals(1)) //если копируем/перемещаем файл
                    {
                        if (button == Copy)
                        {
                            sourceFileNameToCopy = ListOfItemsLeft.SelectedItem.ToString();
                            sourceFileToCopy = CurrentPathLeft.Text + sourceFileNameToCopy;
                            the_file_is_copying = true;
                            the_folder_is_copying = false;
                        }
                        else if (button == Move)
                        {
                            sourceFileNameToMove = ListOfItemsLeft.SelectedItem.ToString();
                            sourceFileToMove = CurrentPathLeft.Text + sourceFileNameToMove;
                            the_file_is_moving = true;
                            the_folder_is_moving = false;
                        }
                    }
                    else //если копируем/перемещаем папку
                    {
                        if (button == Copy)
                        {
                            sourceFolderNameToCopy = ListOfItemsLeft.SelectedItem.ToString();
                            sourceFolderToCopy = CurrentPathLeft.Text + sourceFolderNameToCopy;
                            the_folder_is_copying = true;
                            the_file_is_copying = false;
                        }
                        else if (button == Move)
                        {
                            sourceFolderNameToMove = ListOfItemsLeft.SelectedItem.ToString();
                            sourceFolderToMove = CurrentPathLeft.Text + sourceFolderNameToMove;
                            the_folder_is_moving = true;
                            the_file_is_moving = false;
                        }
                    }
                }
                else if (ListOfItemsRight.SelectedItem != null)
                {
                    if (IsFile(ListOfItemsRight, CurrentPathRight, ref current_files_right).Equals(1))
                    {
                        if (button == Copy)
                        {
                            sourceFileNameToCopy = ListOfItemsRight.SelectedItem.ToString();
                            sourceFileToCopy = CurrentPathRight.Text + sourceFileNameToCopy;
                            the_file_is_copying = true;
                            the_folder_is_copying = false;
                        }
                        else if (button == Move)
                        {
                            sourceFileNameToMove = ListOfItemsRight.SelectedItem.ToString();
                            sourceFileToMove = CurrentPathRight.Text + sourceFileNameToMove;
                            the_file_is_moving = true;
                            the_folder_is_moving = false;
                        }
                    }
                    else
                    {
                        if (button == Copy)
                        {
                            sourceFolderNameToCopy = ListOfItemsRight.SelectedItem.ToString();
                            sourceFolderToCopy = CurrentPathRight.Text + sourceFolderNameToCopy;
                            the_folder_is_copying = true;
                            the_file_is_copying = false;
                        }
                        else if (button == Move)
                        {
                            sourceFolderNameToMove = ListOfItemsRight.SelectedItem.ToString();
                            sourceFolderToMove = CurrentPathRight.Text + sourceFolderNameToMove;
                            the_folder_is_moving = true;
                            the_file_is_moving = false;
                        }
                    }
                }
                first_click_on_button = false;
                second_click_on_button = true;
            }
            else if (second_click_on_button)
            {
                if (button == Copy)
                {
                    button.Text = "Copy";
                    Move.Enabled = true;
                }
                else if (button == Move)
                {
                    button.Text = "Move";
                    Copy.Enabled = true;
                }
                if (left_panel_was_clicked_last)
                {
                    SomePanelWasClickedLast(ListOfItemsLeft, CurrentPathLeft, ref current_files_left);
                }
                else if (right_panel_was_clicked_last)
                {
                    SomePanelWasClickedLast(ListOfItemsRight, CurrentPathRight, ref current_files_right);
                }
                first_click_on_button = true;
                second_click_on_button = false;
                the_file_is_copying = false;
                the_file_is_moving = false;
                the_folder_is_copying = false;
                the_folder_is_moving = false;
            }
        }
        private void SomePanelWasClickedLast(ListBox ListOfItems, RichTextBox CurrentPath, ref List<string> current_files)
        {
            if (ListOfItems.SelectedItem != null) //если нажали на какой-то элемент панели
            {
                //если нажали на папку, то копируем наш объект в эту папку
                if (IsFile(ListOfItems, CurrentPath, ref current_files).Equals(0))
                {
                    if (the_file_is_copying)
                    {
                        destFileToCopy = CurrentPath.Text + ListOfItems.SelectedItem.ToString() + "\\" + sourceFileNameToCopy;
                        CopyingAFileToTheSpecifiedDirectory(sourceFileToCopy, destFileToCopy);
                    }
                    else if (the_folder_is_copying)
                    {
                        destFolderToCopy = CurrentPath.Text + ListOfItems.SelectedItem.ToString() + "\\" + sourceFolderNameToCopy;
                        CopyingAFolderToTheSpecifiedDirectory(sourceFolderToCopy, destFolderToCopy);
                    }
                    if (the_file_is_moving)
                    {
                        destFileToMove = CurrentPath.Text + ListOfItems.SelectedItem.ToString() + "\\" + sourceFileNameToMove;
                        CopyingAFileToTheSpecifiedDirectory(sourceFileToMove, destFileToMove);
                        File.Delete(sourceFileToMove);
                    }
                    else if (the_folder_is_moving)
                    {
                        destFolderToMove = CurrentPath.Text + ListOfItems.SelectedItem.ToString() + "\\" + sourceFolderNameToMove;
                        CopyingAFileToTheSpecifiedDirectory(sourceFolderToMove, destFolderToMove);
                        Directory.Delete(sourceFolderToMove, true);
                    }
                }
                //если на файл, то копируем объект в текущую директорию
                else
                {
                    if (the_file_is_copying)
                    {
                        destFileToCopy = CurrentPath.Text + sourceFileNameToCopy;
                        CopyingAFileToTheSpecifiedDirectory(sourceFileToCopy, destFileToCopy);
                    }
                    else if (the_folder_is_copying)
                    {
                        destFolderToCopy = CurrentPath.Text + sourceFolderNameToCopy;
                        CopyingAFolderToTheSpecifiedDirectory(sourceFolderToCopy, destFolderToCopy);
                    }
                    if (the_file_is_moving)
                    {
                        destFileToMove = CurrentPath.Text + sourceFileNameToMove;
                        CopyingAFileToTheSpecifiedDirectory(sourceFileToMove, destFileToMove);
                        File.Delete(sourceFileToMove);
                    }
                    else if (the_folder_is_moving)
                    {
                        destFolderToMove = CurrentPath.Text + sourceFolderNameToMove;
                        CopyingAFolderToTheSpecifiedDirectory(sourceFolderToMove, destFolderToMove);
                        Directory.Delete(sourceFolderToMove, true);
                    }
                }
            }
            else //иначе, если мы кликнули по панели, но не по папке или файлу, просто копируем объект в текущую директорию
            {
                if (the_file_is_copying)
                {
                    destFileToCopy = CurrentPath.Text + sourceFileNameToCopy;
                    CopyingAFileToTheSpecifiedDirectory(sourceFileToCopy, destFileToCopy);
                }
                else if (the_folder_is_copying)
                {
                    destFolderToCopy = CurrentPath.Text + sourceFolderNameToCopy;
                    CopyingAFolderToTheSpecifiedDirectory(sourceFolderToCopy, destFolderToCopy);
                }
                if (the_file_is_moving)
                {
                    destFileToMove = CurrentPath.Text + sourceFileNameToMove;
                    CopyingAFileToTheSpecifiedDirectory(sourceFileToMove, destFileToMove);
                    File.Delete(sourceFileToMove);
                }
                else if (the_folder_is_moving)
                {
                    destFolderToMove = CurrentPath.Text + sourceFolderNameToMove;
                    CopyingAFolderToTheSpecifiedDirectory(sourceFolderToMove, destFolderToMove);
                    Directory.Delete(sourceFolderToMove, true);
                }
            }
        }
        private void CopyingAFileToTheSpecifiedDirectory(string path_to_source_file, string path_to_specific_directory) //копируем файл в заданную директорию
        {
            if (path_to_specific_directory != path_to_source_file) //если будет попытка скопировать файл в ту же директорию, то ничего не произойдёт
            {
                //копируем файл в заданную директорию
                using (FileStream inStream = File.Open(path_to_source_file, FileMode.Open, FileAccess.Read, FileShare.Read))
                using (FileStream outStream = File.Open(path_to_specific_directory, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    do
                    {
                        bytesCopied = inStream.Read(buffer, 0, BufferSize);
                        if (bytesCopied > 0)
                        {
                            outStream.Write(buffer, 0, bytesCopied);
                        }
                    } while (bytesCopied > 0);
                }
            }
        }

        private void CopyingAFolderToTheSpecifiedDirectory(string path_to_source_folder, string path_to_specific_directory) //копируем папку в заданную директорию
        {
            if (path_to_source_folder != path_to_specific_directory)
            {
                Directory.CreateDirectory(path_to_specific_directory);
                string[] allfiles = Directory.GetFiles(path_to_source_folder); //получаем все файлы расположенные в копируемой папке
                foreach(string file in allfiles)
                {
                    CopyingAFileToTheSpecifiedDirectory(file, path_to_specific_directory + "\\" + ExtractingNameFromObjectPath(file));
                }
                string[] allfolders = Directory.GetDirectories(path_to_source_folder); //получаем все папки расположенные в копируемой папке
                foreach(string folder in allfolders)
                {
                    CopyingAFolderToTheSpecifiedDirectory(folder, path_to_specific_directory + "\\" + ExtractingNameFromObjectPath(folder));
                } 
            }
        }


        private void ListOfItemsLeft_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Move_Click(object sender, EventArgs e)
        {
            CopyOrMoveInterface(Move, ref first_click_on_move, ref second_click_on_move);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (ListOfItemsLeft.SelectedItem != null)
            {
                DeleteInterface(ListOfItemsLeft, CurrentPathLeft, ref current_files_left);
            }
            else if (ListOfItemsRight.SelectedItem != null)
            {
                DeleteInterface(ListOfItemsRight, CurrentPathRight, ref current_files_right);
            }
        }
        private void DeleteInterface(ListBox ListOfItems, RichTextBox CurrentPath, ref List<string> current_files)
        {
            if (IsFile(ListOfItems, CurrentPath, ref current_files).Equals(1))
            {
                File.Delete(CurrentPath.Text + ListOfItems.SelectedItem.ToString());
            }
            else if (IsFile(ListOfItems, CurrentPath, ref current_files).Equals(0))
            {
                Directory.Delete(CurrentPath.Text + ListOfItems.SelectedItem.ToString(), true);
            }
        }        

        private void Edit_Click(object sender, EventArgs e)
        {
            if (ListOfItemsLeft.SelectedItem != null || ListOfItemsRight.SelectedItem != null)
            {
                BackGroundForRename.Visible = true;
                EnteringNewName.Visible = true;
                Enter.Visible = true;
                Cancel.Visible = true;
                TextOnPanel.Visible = true;
            }
        }

        private void Enter_Click(object sender, EventArgs e)
        {
            if (EnteringNewName.Text != "")
            {
                BackGroundForRename.Visible = false;
                EnteringNewName.Visible = false;
                Enter.Visible = false;
                Cancel.Visible = false;
                TextOnPanel.Visible = false;
                if (ListOfItemsLeft.SelectedItem != null)
                {
                    RenamingObjectDirectory = CurrentPathLeft.Text + ListOfItemsLeft.SelectedItem.ToString();
                    if (IsFile(ListOfItemsLeft, CurrentPathLeft, ref current_files_left).Equals(0))
                    {
                        Directory.Move(RenamingObjectDirectory, CurrentPathLeft.Text + EnteringNewName.Text);
                    }
                    else if (IsFile(ListOfItemsLeft, CurrentPathLeft, ref current_files_left).Equals(1))
                    {
                        File.Move(RenamingObjectDirectory, CurrentPathLeft.Text + EnteringNewName.Text + ExtractingExtensionFromFilePath(RenamingObjectDirectory));
                    }
                }
                else if (ListOfItemsRight.SelectedItem != null)
                {
                    RenamingObjectDirectory = CurrentPathRight.Text + ListOfItemsRight.SelectedItem.ToString();
                    if (IsFile(ListOfItemsRight, CurrentPathRight, ref current_files_right).Equals(0))
                    {
                        Directory.Move(RenamingObjectDirectory, CurrentPathRight.Text + EnteringNewName.Text);
                    }
                    else if (IsFile(ListOfItemsRight, CurrentPathRight, ref current_files_right).Equals(1))
                    {
                        File.Move(RenamingObjectDirectory, CurrentPathRight.Text + EnteringNewName.Text + ExtractingExtensionFromFilePath(RenamingObjectDirectory));
                    }
                }
                EnteringNewName.Text = "";
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            BackGroundForRename.Visible = false;
            EnteringNewName.Visible = false;
            Enter.Visible = false;
            Cancel.Visible = false;
            TextOnPanel.Visible = false;
            EnteringNewName.Text = "";
        }

        private void Archive_Click(object sender, EventArgs e)
        {
            ArchiveInterface(ListOfItemsLeft, CurrentPathLeft, ref current_files_left, ref gzipped_files);
            ArchiveInterface(ListOfItemsRight, CurrentPathRight, ref current_files_right, ref gzipped_files);
        }
        
        private void ArchiveInterface(ListBox ListOfItems, RichTextBox CurrentPath, ref List<string> current_files, ref List<string> gzipped_files) //зачем current_files через ref передавать????
        {
            if (ListOfItems.SelectedItem != null)
            {
                if (IsFile(ListOfItems, CurrentPath, ref current_files).Equals(1))
                {
                    if (ExtractingExtensionFromFilePath(ListOfItems.SelectedItem.ToString()) == ".zip") //декомпрессия папки 
                    {
                        CompressingOrDecompressingFolder(CurrentPath.Text + ListOfItems.SelectedItem.ToString(), CurrentPath.Text + ListOfItems.SelectedItem.ToString().Substring(0, ListOfItems.SelectedItem.ToString().Length - ExtractingExtensionFromFilePath(ListOfItems.SelectedItem.ToString()).Length), false);
                    }
                    else if (ExtractingExtensionFromFilePath(ListOfItems.SelectedItem.ToString()) == ".gz") //иначе выполняем декомпрессию файла
                    {
                        string original_extension = "";
                        foreach(string gzipped_file in gzipped_files)
                        {
                            if (ExtractingNameFromObjectPath(gzipped_file).Substring(0, ExtractingNameFromObjectPath(gzipped_file).Length - ExtractingExtensionFromFilePath(gzipped_file).Length - 1) == ListOfItems.SelectedItem.ToString().Substring(0, ListOfItems.SelectedItem.ToString().Length - ExtractingExtensionFromFilePath(ListOfItems.SelectedItem.ToString()).Length - 1)) //возможно будет баг
                            {
                                original_extension = ExtractingExtensionFromFilePath(gzipped_file);
                                break;
                            }
                        }
                        CompressingOrDecompressingFile(CurrentPath.Text + ListOfItems.SelectedItem.ToString(), CurrentPath.Text + ListOfItems.SelectedItem.ToString().Substring(0, ListOfItems.SelectedItem.ToString().Length - ExtractingExtensionFromFilePath(ListOfItems.SelectedItem.ToString()).Length) + original_extension, false);
                    }
                    else //иначе выполняем компрессию файла
                    {
                        gzipped_files.Add(CurrentPath.Text + ListOfItems.SelectedItem.ToString());
                        CompressingOrDecompressingFile(CurrentPath.Text + ListOfItems.SelectedItem.ToString(), CurrentPath.Text + ListOfItems.SelectedItem.ToString().Substring(0, ListOfItems.SelectedItem.ToString().Length - ExtractingExtensionFromFilePath(ListOfItems.SelectedItem.ToString()).Length) + ".gz", true);
                    }                                     
                }
                else //иначе компрессия папки
                {
                    CompressingOrDecompressingFolder(CurrentPath.Text + ListOfItems.SelectedItem.ToString(), CurrentPath.Text + ListOfItems.SelectedItem.ToString() + ".zip", true);
                }
            }                    
        }

        private void CompressingOrDecompressingFile(string sourceFile, string destFile, bool compress)
        {
            using (Stream inFileStream = File.Open(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (Stream outFileStream = File.Open(destFile, FileMode.Create, FileAccess.Write, FileShare.None))
            using (GZipStream gzipStream = new GZipStream(compress ? outFileStream : inFileStream, compress ? CompressionMode.Compress : CompressionMode.Decompress))
            {
                Stream inStream = compress ? inFileStream : gzipStream;
                Stream outStream = compress ? gzipStream : outFileStream;
                int bytesRead = 0;
                do
                {
                    bytesRead = inStream.Read(buffer, 0, BufferSize);
                    outStream.Write(buffer, 0, bytesRead);                 
                } while (bytesRead > 0);
                if (compress)
                {
                    MessageBox.Show("Сжатие файла " + sourceFile + " завершено. Исходный размер: " + inFileStream.Length.ToString() + " сжатый размер: " + outFileStream.Length.ToString() + ".");
                }
                else
                {
                    MessageBox.Show("Было произведено восстановление сжатого файла " + sourceFile);
                }
            }
        }

        private void CompressingOrDecompressingFolder(string sourcePath, string destPath, bool compress)
        {
            if (compress)
            {
                ZipFile.CreateFromDirectory(sourcePath, destPath);
            }
            else
            {
                ZipFile.ExtractToDirectory(sourcePath, destPath);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(this);
            form.Show();
        }


        private List<Book> GetBooksList(List<Book> Books, string AmountToDraw, string SearchLineRequest, ref bool SearchPerformed) //Crawler
        {
            SearchPerformed = true;
            string request = "";
            foreach (char character in SearchLineRequest)
            {
                if (character == '+')
                {
                    request += "%2B";
                }
                else if (character == '#')
                {
                    request += "%23";
                }
                else if (character == '(')
                {
                    request += "%28";
                }
                else if (character == ')')
                {
                    request += "%29";
                }
                else
                {
                    request += character;
                }
            }
            //так как Amazon, судя по всему, защищён от парсинга, пришлось парсить Ozon
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            SearchRating = new Regex(@"""rating"":(?'rating'(\d{1}\.\p{N}+|\d)),""countItems""");
            SearchPrice = new Regex(@"""price"":{""price"":""(?'price'.+?)""");
            SearchIDandName = new Regex(@"""id"":(?'link'\d+?),""title"":""(?'name'.+?)""");
            List<string> ID = new List<string>();
            List<string> Titles = new List<string>();
            List<string> IDnew = new List<string>();
            List<string> TitleSnew = new List<string>(); 
            List<string> Ratings = new List<string>();
            List<string> Prices = new List<string>();
            int page = 1;
            int cnt = 0;
            int cnt_buf = 0;
            while (cnt < Int32.Parse(AmountToDraw))
            {    
                //ищем только печатные книги
                string requestURL = @"https://www.ozon.ru/category/knigi-16500/?bymediatype=1147731&from_global=true&page=" + page.ToString() + "&text=" + request;
                string HtmlPage = client.DownloadString(requestURL);         
                foreach (Match m in SearchIDandName.Matches(HtmlPage))
                {
                    ID.Add(m.Groups["link"].ToString());
                    Titles.Add(m.Groups["name"].ToString());                   

                }
                foreach (Match m in SearchRating.Matches(HtmlPage))
                {
                    Ratings.Add(m.Groups["rating"].ToString());
                    cnt_buf++;
                    if (cnt + cnt_buf == Int32.Parse(AmountToDraw))
                        break;
                }
                cnt_buf = 0;
                foreach (Match m in SearchPrice.Matches(HtmlPage))
                {
                    Prices.Add(m.Groups["price"].ToString());
                    cnt_buf++;
                    if (cnt + cnt_buf == Int32.Parse(AmountToDraw))
                        break;
                }
                if (cnt_buf < 36)
                {
                    break;
                }
                cnt += cnt_buf;
                cnt_buf = 0;
                page++;
            }
            for (int i = 0; i < ID.Count; i++)
            {
                if (ID[i].Length >= 7)
                {
                    IDnew.Add(ID[i]);
                    TitleSnew.Add(Titles[i]);
                }
            }
            for (int i = 0; i < Math.Min(Math.Min(Ratings.Count, Prices.Count),IDnew.Count); i++)
            {
                Books.Add(new Book(IDnew[i], TitleSnew[i], Ratings[i], Prices[i]));
            }
            return Books;
        }

        private void StartSearchingLeft_Click(object sender, EventArgs e)
        {
            BooksOnTheLeft = GetBooksList(new List<Book>(), AmountToDrawLeft.Text, SearchLeft.Text, ref search_performed_left);
            ListOfItemsLeft.Items.Clear();
            foreach(Book book in BooksOnTheLeft)
            {
                ListOfItemsLeft.Items.Add(book.SummOfAllParameters);
            }
        }

        private void StartSearchingRight_Click(object sender, EventArgs e)
        {
            BooksOnTheRight = GetBooksList(new List<Book>(), AmountToDrawRight.Text, SearchRight.Text, ref search_performed_right);
            ListOfItemsRight.Items.Clear();
            foreach (Book book in BooksOnTheRight)
            {
                ListOfItemsRight.Items.Add(book.SummOfAllParameters);
            }
        }
    }
    public class Book
    {
        public string Link;
        public string NameAndAuthor;
        public string Rating;
        public string Price;
        public string SummOfAllParameters;
        public Book(string link, string name_and_author, string rating, string price)
        {
            Link = link;
            NameAndAuthor = name_and_author;
            if (rating.Length > 4)
            {
                double buf = Double.Parse(rating, CultureInfo.InvariantCulture);
                buf = Math.Round(buf, 2);
                Rating = buf.ToString();
            }
            else
            {
                Rating = rating;
            }
            Price = price;
            SummOfAllParameters = NameAndAuthor + ", " + Rating + "/5 stars, " + Price + ".";
        }
        public Book()
        {

        }
    }
}
