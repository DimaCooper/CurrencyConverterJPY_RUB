using System;
using System.Text;
using System.Xml;

namespace CurrencyConv
{
    class Program
    {
		static void Main(string[] args)
		{
			// Для работы с кодировкой 1251 используем System.Text.Encoding.CodePages.dll
			Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
			// Создаем новый документ
			XmlDocument xDoc = new XmlDocument();
			// Получаем данные
			xDoc.Load("http://www.cbr.ru/scripts/XML_daily.asp");
			// Получаем корневой элемент
			XmlElement xRoot = xDoc.DocumentElement;
			// Выбираем узлы 
			XmlNode valuenode = xRoot.SelectSingleNode("Valute[@ID='R01820']/Value");
			XmlNode namenode = xRoot.SelectSingleNode("Valute[@ID='R01820']/Name");
			XmlNode nominalnode = xRoot.SelectSingleNode("Valute[@ID='R01820']/Nominal");
			// Проверяем, чтобы значения узлов не были пусты и выводим в консоль курс валют 
			if (valuenode != null && namenode != null && nominalnode!= null)
				Console.WriteLine("Стоимость " + nominalnode.InnerText + " " + namenode.InnerText + " в рублях на сегодня - " + valuenode.InnerText + " по курсу ЦБ РФ.");
			Console.Read();
		}
	}
}
