using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XSLTapp.Model;

namespace XSLTapp
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Group selectedGroup;
        private ObservableCollection<Group> groups;
        private ObservableCollection<Item> items;
        private RelayCommand transformCommand;
        private const string xslFile = "../../../Data/List.xsl";
        private const string xmlFile = "../../../Data/List.xml";
        private const string resultXmlFile = "../../../Data/Result.xml";

        public ApplicationViewModel()
        {

        }
        public Group SelectedGroup
        {
            get { return selectedGroup; }
            set
            {
                selectedGroup = value;
                OnPropertyChanged("SelectedGroup");
            }
        }
        public ObservableCollection<Group> Groups 
        {
            get { return groups; }
            set
            {
                groups = value;
                OnPropertyChanged("Groups");
            } 
        }
        public ObservableCollection<Item> Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged("Items");
            }
        }

        public RelayCommand TransformCommand
        {
            get
            {
                return transformCommand ??
                  (transformCommand = new RelayCommand(obj =>
                  {
                      XslTransformer.Transform(xslFile, xmlFile, resultXmlFile);
                      XmlHelper.UpdateGroupsXml(resultXmlFile);
                      XmlHelper.UpdateListXml(xmlFile);
                      Groups = XmlHelper.ConvertGroups(resultXmlFile);
                      Items = XmlHelper.ConvertItems(xmlFile);
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
