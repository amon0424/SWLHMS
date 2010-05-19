using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Mong
{
    static class Settings
    {
        static XmlDocument _xmlDoc;

        public static decimal WorkingHoursPerDay
        {
            get
            {
                XmlNode node = GetNode("WorkingHoursPerDay", "8");

                return decimal.Parse(node.InnerText);
            }
            set
            {
				XmlNode node = GetNode("WorkingHoursPerDay", "8");
                node.InnerText = value.ToString();
                Save();
            }
        }

        public static DateTime UnfilledDate
        {
            get
            {
				XmlNode node = GetNode("UnfilledDate", DateTime.Today.ToString("yyyy/MM/dd"));
                return DateTime.Parse(node.InnerText);
            }
            set
            {
				XmlNode node = GetNode("UnfilledDate", DateTime.Today.ToString("yyyy/MM/dd"));
                node.InnerText = value.ToString("yyyy/MM/dd");
                Save();
            }
        }

		public static int HourlyPay
		{
			get
			{
				XmlNode node = GetNode("HourlyPay", "100");
				return Convert.ToInt32(node.InnerText);
			}
			set
			{
				XmlNode node = GetNode("HourlyPay", "100");
				node.InnerText = value.ToString();
				Save();
			}
		}

        public static string LaborWageDatabaseFile
        {
            get
            {
				XmlNode node = GetNode("LaborWageDbFile", null);
                return node.InnerText;
            }
            set
            {
				XmlNode node = GetNode("LaborWageDbFile", null);
                node.InnerText = value;
                Save();
            }
        }

        static Settings()
        {
            _xmlDoc = new XmlDocument();
            _xmlDoc.Load(System.Windows.Forms.Application.StartupPath + @"\Settings.xml");
        }

        public static void Save()
        {
            _xmlDoc.Save(System.Windows.Forms.Application.StartupPath + @"\Settings.xml");
        }

		private static XmlNode GetNode(string name, string defaultValue)
		{
			XmlNode node = _xmlDoc.SelectSingleNode("/Settings/" + name);
			if (node == null)
			{
				node = _xmlDoc.CreateNode(XmlNodeType.Element, name, null);
				node.InnerText = defaultValue;
				_xmlDoc.SelectSingleNode("/Settings").AppendChild(node);
			}

			return node;
		}
    }
}
