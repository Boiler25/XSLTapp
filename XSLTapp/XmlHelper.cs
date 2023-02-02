using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XSLTapp.Model;

namespace XSLTapp
{
    public static class XmlHelper
    {
        public static ObservableCollection<Group> ConvertGroups(string XmlFile)
        {
            ObservableCollection<Group> groups = new ObservableCollection<Group>();

            XDocument xdoc = XDocument.Load(XmlFile);
            XElement? xGroups = xdoc.Element("groups");

            if (xGroups is not null)
            {
                foreach (XElement xGroup in xGroups.Elements("group"))
                {
                    Group group = new Group();
                    List<Item> items = new List<Item>();

                    XAttribute groupName = xGroup.Attribute("name");

                    foreach (XElement xItem in xGroup.Elements("item"))
                    {
                        XAttribute itemName = xItem.Attribute("name");
                        items.Add(new Item() { Name = itemName.Value });
                    }

                    group.Name = groupName.Value;
                    group.Items = items;
                    groups.Add(group);
                }
            }
            return groups;
        }

        public static ObservableCollection<Item> ConvertItems(string XmlFile)
        {
            ObservableCollection<Item> items = new ObservableCollection<Item>();

            XDocument xdoc = XDocument.Load(XmlFile);
            XElement? xItems = xdoc.Element("list");

            if (xItems is not null)
            {
                foreach (XElement xItem in xItems.Elements("item"))
                {
                    Item item = new Item();

                    XAttribute? itemName = xItem.Attribute("name");
                    XAttribute? groupName = xItem.Attribute("group");

                    item.Name = itemName.Value;
                    item.Group = groupName.Value;

                    items.Add(item);
                }
            }
            return items;
        }

        public static void UpdateGroupsXml(string XmlFile)
        {
            XDocument xdoc = XDocument.Load(XmlFile);
            XElement? xGroups = xdoc.Element("groups");
            int count = 0;

            if (xGroups is not null)
            {
                foreach (XElement xGroup in xGroups.Elements("group"))
                {
                    foreach (XElement xItem in xGroup.Elements("item"))
                    {
                        count++;
                    }
                    if (xGroup.Attribute("count") == null)
                    {
                        xGroup.Add(new XAttribute("count", count.ToString()));
                    }
                    else
                    {
                        xGroup.Attribute("count").Value = count.ToString();
                    }
                    xdoc.Save(XmlFile);
                }
            }
        }

        public static void UpdateListXml(string XmlFile)
        {
            XDocument xdoc = XDocument.Load(XmlFile);
            XElement? xList = xdoc.Element("list");
            int count = 0;

            if (xList is not null)
            {
                foreach (XElement xGroup in xList.Elements("item"))
                {
                    count++;
                }

                if (xList.Attribute("count") == null)
                {
                    xList.Add(new XAttribute("count", count.ToString()));
                }
                else
                {
                    xList.Attribute("count").Value = count.ToString();
                }
                xdoc.Save(XmlFile);
            }
        }

        public static ObservableCollection<Item> GetItemsFromGroups(ObservableCollection<Group> groups)
        {
            ObservableCollection<Item> items = new ObservableCollection<Item>();

            foreach (Group group in groups)
            {
                foreach (Item item in group.Items)
                {
                    items.Add(item);
                }
            }

            return items;
        }
    }
}
