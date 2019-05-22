using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace XMLOperationDemo
{
    class LinqXML
    {
        /// <summary>
        /// Linq读文件
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<XElement> LinqReadXM了Func()
        {
            XElement xe = XElement.Load("BookXML.xml");
            IEnumerable<XElement> elements = from ele in xe.Elements("book")
                                             select ele;
            return elements;
        }
        /// <summary>
        /// Linq添加数据
        /// </summary>
        public static void LinqXMLAddFunc()
        {
            XElement xe = XElement.Load("BookXML.xml");
            XElement record = new XElement(
            new XElement("book",
            new XAttribute("Type", "选修课"),
            new XAttribute("ISBN", "7-111-19149-1"),
            new XElement("title", "计算机操作系统"),
            new XElement("author", "7-111-19149-1"),
            new XElement("price", 28.00)));
            xe.Add(record);
            xe.Save("BookXML.xml");
        }
        /// <summary>
        /// Linq修改数据
        /// </summary>
        /// <param name="dataGridView1"></param>
        public static void LinqXMLModifyFunc(DataGridView dataGridView1)
        {
            XElement xe1 = XElement.Load("BookXML.xml");
            if (dataGridView1.CurrentRow != null)
            {
                //dgvBookInfo.CurrentRow.Cells[1]对应着ISBN号
                string id = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                IEnumerable<XElement> element = from ele in xe1.Elements("book")
                                                where ele.Attribute("ISBN").Value == id
                                                select ele;
                if (element.Count() > 0)
                {
                    XElement first = element.First();
                    ///设置新的属性
                    first.SetAttributeValue("Type", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    ///替换新的节点
                    first.ReplaceNodes(
                         new XElement("title", dataGridView1.CurrentRow.Cells[2].Value.ToString()),
                         new XElement("author", dataGridView1.CurrentRow.Cells[3].Value.ToString()),
                         new XElement("price", (double)dataGridView1.CurrentRow.Cells[4].Value)
                         );
                }
                xe1.Save("BookXML.xml");
            }
        }
        /// <summary>
        /// Linq删除数据
        /// </summary>
        /// <param name="dataGridView1"></param>
        public static void LinqXMLDeleteFunc(DataGridView dataGridView1)
        {
            if (dataGridView1.CurrentRow != null)
            {
                //dgvBookInfo.CurrentRow.Cells[1]对应着ISBN号
                string id = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                XElement xe1 = XElement.Load("BookXML.xml");
                IEnumerable<XElement> els = from ele in xe1.Elements("book")
                                            where (string)ele.Attribute("ISBN") == id
                                            select ele;
                {
                    if (els.Count() > 0)
                        els.First().Remove();
                }
                xe1.Save("BookXML.xml");
            }
        }
        /// <summary>
        /// Linq删除所有数据
        /// </summary>
        public static void LinqXMLDeleteAllFunc()
        {
            XElement xe = XElement.Load("BookXML.xml");
            IEnumerable<XElement> elements = from ele in xe.Elements("book")
                                             select ele;
            if (elements.Count() > 0)
            {
                elements.Remove();
            }
            xe.Save("BookXML.xml");
        }
    }
}
