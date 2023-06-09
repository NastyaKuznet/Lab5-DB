﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using Lab5DBVersion3.Model;
using System.Windows.Input;
using System.Reflection.Metadata;
using static System.Windows.Forms.AxHost;

namespace Lab5DBVersion3.ViewModel
{
    public class MainViewModel : MyViewModel
    {
        private LoaderFiles Model;

        private ObservableCollection<BaseItem> treeElement = new ObservableCollection<BaseItem>();
        private ObservableCollection<string> combpBoxElement = new ObservableCollection<string>();
        private string comboBoxSelectItem = "";
        private ObservableCollection<DataTable> collectionTableElement = new ObservableCollection<DataTable>();
        private DataTable tableElement = new DataTable();
        private string contentErrorWindow = "";

        public ObservableCollection<BaseItem> TreeElement
        {
            get { return treeElement; }
            set
            {
                treeElement = value;
                OnPropertyChanged(nameof(TreeElement));
            }
        }
        public ObservableCollection<string> ComboBoxElement
        {
            get { return combpBoxElement; }
            set
            {
                combpBoxElement = value;
                OnPropertyChanged(nameof(ComboBoxElement));
            }
        }
        public string ComboBoxSelectItem
        {
            get { return comboBoxSelectItem; }
            set
            {
                comboBoxSelectItem = value;
                OnPropertyChanged(nameof(ComboBoxSelectItem));
            }
        }
        public ObservableCollection<DataTable> CollectionTableElement
        {
            get { return collectionTableElement; }
            set
            {
                collectionTableElement = value;
                OnPropertyChanged(nameof(CollectionTableElement));
            }
        }

        public DataTable TableElement
        {
            get { return tableElement; }
            set
            {
                tableElement = value;
                OnPropertyChanged(nameof(TableElement));
            }
        }
        public string ContentErrorWindow
        {
            get { return contentErrorWindow; }
            set
            {
                contentErrorWindow = value;
                OnPropertyChanged(nameof(ContentErrorWindow));
            }
        }

        public ICommand AddFiles
        {
            get
            {
                return new CommandDelegate(parameter =>
                {
                    FolderBrowserDialog dialog = new FolderBrowserDialog();
                    DialogResult result = dialog.ShowDialog();

                    string folder = "";
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        folder = dialog.SelectedPath;
                    }
                    Model = new LoaderFiles(folder);
                    ContentErrorWindow = Model.State;
                    if (ContentErrorWindow.Contains(CheckError.NotError))
                        CreateViewModel();
                });
                
            }
        }

        private void CreateViewModel()//ViewModelсвязывание данных модели в элементы вью, а иммено дерева и таблицы? или это чисто вью
        {
            foreach (PatternObjectDB pattern in Model.Patterns.Values)
            {
                DataTable table = new DataTable(pattern.Name);

                BaseItem item = new BaseItem(pattern.Name);
                foreach (PatternPropertyDB property in pattern.Properties.Values)
                {
                    BaseItem subitem = new BaseItem(property.Name);
                    item.Children.Add(subitem);
                    DataColumn column = new DataColumn(property.Name);
                    table.Columns.Add(column);
                }
                TreeElement.Add(item);
                ComboBoxElement.Add(pattern.Name);
                table = CreateRowTable(pattern.Name, table);
                CollectionTableElement.Add(table);

            }
        }
        private DataTable CreateRowTable(string nameObject, DataTable table)
        {
            foreach (string nameObjectDB in Model.Objects.Keys)
            {
                if (nameObjectDB.Contains(nameObject))
                {
                    foreach (ObjectDB objectDB in Model.Objects[nameObject])
                    {
                        DataRow row = table.NewRow();
                        int nuberCell = 0;
                        foreach (string text in objectDB.PropertyDB.Values)
                        {
                            row[nuberCell] = text;
                            nuberCell++;
                        }
                        table.Rows.Add(row);
                    }
                }
            }
            return table;
        }
        public ICommand CreateTable
        {
            get
            {
                return new CommandDelegate(parameter =>
                {
                    string namePattern = ComboBoxSelectItem;
                    foreach (DataTable table in CollectionTableElement)
                    {
                        if (table.TableName.Contains(namePattern))
                        {
                            TableElement = table;
                        }
                    }
                });
            }
        }
    }
}
