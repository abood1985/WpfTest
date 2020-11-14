using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Messaging;
using System.Windows;
using System.Windows.Controls;

namespace WpfProg
{
    /// <summary>
    /// Interaction logic for TreeUI.xaml
    /// </summary>
    public partial class TreeUI : Window
    {
        public TreeUI()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var drive in Directory.GetLogicalDrives())
            {
                var item = new TreeViewItem();
                item.Header = drive;
                item.Tag = drive;
                item.Items.Add(null);
                item.Expanded += Folder_Expanded;

                FolderView.Items.Add(item);
            }

           



        }

        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            var item = (TreeViewItem)sender;

            if (item.Items.Count != 1 || item.Items[0] != null)
                return;

            item.Items.Clear();

            var fullpath = (string)item.Tag;

            var directories = new List<string>();

            try
            {
                var dirs = Directory.GetDirectories(fullpath);

                if (dirs.Length > 0)
                    directories.AddRange(dirs);

            }
            
             catch { }

            directories.ForEach(directoryPath =>
           {
               var subItem = new TreeViewItem();
               {
                   item.Header = GetFileFolderName(directoryPath);
                   Tag = directoryPath;

               };

               subItem.Items.Add(null);
               subItem.Expanded += Folder_Expanded;
               item.Items.Add(subItem);
           });
      
    }

    public static string GetFileFolderName(string path)
    {
        if (string.IsNullOrEmpty(path))
            return string.Empty;

        var normalizedpath = path.Replace('/', '\\');
        var lastindex = normalizedpath.LastIndexOf('\\');

        if (lastindex <= 0)
            return path;

        return path.Substring(lastindex + 1);

    }
}
}
