using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLOperationDemo
{
    class ReadandWriteXML
    {
        /// <summary>
        /// XML写文件
        /// </summary>
        public static void XMLTextWriteFunc()
        {
            XmlTextWriter xmlTextWriter = new XmlTextWriter("BookXML.xml", UTF8Encoding.Default);
            xmlTextWriter.Formatting = Formatting.Indented;

            xmlTextWriter.WriteStartDocument(false);
            xmlTextWriter.WriteStartElement("bookstore");
            xmlTextWriter.WriteComment("记录书本的信息");

            xmlTextWriter.WriteStartElement("book");

            xmlTextWriter.WriteAttributeString("Type", "选修课");
            xmlTextWriter.WriteAttributeString("ISBN", "1111");

            xmlTextWriter.WriteElementString("auyhor", "吴某某");
            xmlTextWriter.WriteElementString("name", "西游记");
            xmlTextWriter.WriteElementString("price", "12.00");

            xmlTextWriter.WriteEndElement();
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.Flush();
            xmlTextWriter.Close();
        }
        /// <summary>
        /// XML读文件
        /// </summary>
        /// <returns></returns>
        public static List<BookModel> XMLTextReadFunc()
        {
            List<BookModel> list = new List<BookModel>();
            //XmlTextReader读取数据的时候,首先创建一个流,然后用read()方法来不断的向下读,
            //根据读取的结点的类型来进行相应的操作
            XmlTextReader reader = new XmlTextReader("BookXML.xml");
            BookModel model = new BookModel();
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name == "book")
                    {
                        model.BookType = reader.GetAttribute(0);
                        model.BookISBN = reader.GetAttribute(1);
                    }
                    if (reader.Name == "title")
                    {
                        model.BookName = reader.ReadElementString().Trim();
                    }
                    if (reader.Name == "author")
                    {
                        model.BookAuthor = reader.ReadElementString().Trim();
                    }
                    if (reader.Name == "price")
                    {
                        model.BookPrice = Convert.ToDouble(reader.ReadElementString().Trim());
                    }
                }

                if (reader.NodeType == XmlNodeType.EndElement)
                {
                    list.Add(model);
                    model = new BookModel();
                }
            }
            list.RemoveAt(list.Count - 1);
            return list;
        }
    }
}
