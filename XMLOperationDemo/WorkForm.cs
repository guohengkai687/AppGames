using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace XMLOperationDemo
{
    public partial class WorkForm : Form
    {
        public WorkForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 读取XML信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ReadXML_Click(object sender, EventArgs e)
        {
            List<BookModel> bookModels = new List<BookModel>();
            //加载XML
            XmlDocument document = new XmlDocument();
            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings
            {
                IgnoreComments = true
            };
            XmlReader reader = XmlReader.Create("BookXML.xml", xmlReaderSettings);
            document.Load(reader);

            //获取XML根节点
            XmlNode xmlNode = document.SelectSingleNode("bookstore");
            //获取XML根节点下所有子节点
            XmlNodeList xmlNodeList = xmlNode.ChildNodes;

            foreach (XmlNode node in xmlNodeList)
            {
                BookModel bookModel = new BookModel();
                //将节点转换为元素，便于得到节点属性
                XmlElement xmlElement = (XmlElement)node;
                bookModel.BookType = xmlElement.GetAttribute("Type").ToString();
                bookModel.BookISBN = xmlElement.GetAttribute("ISBN").ToString();
                //获取book节点中的所有子节点
                XmlNodeList nodeList = node.ChildNodes;
                bookModel.BookName = nodeList.Item(0).InnerText;
                bookModel.BookAuthor = nodeList.Item(1).InnerText;
                bookModel.BookPrice = Convert.ToDouble(nodeList.Item(2).InnerText);

                bookModels.Add(bookModel);

            }
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = bookModels;
            reader.Close();

            //Linq 读取
            IEnumerable<XElement> elements = LinqXML.LinqReadXM了Func();
            showInfoByElements(elements);
        }
        /// <summary>
        /// 添加一条信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_AddItem_Click(object sender, EventArgs e)
        {
            XmlDocument document = new XmlDocument();
            document.Load("BookXML.xml");
            //选择一个要节点
            XmlNode xmlNode = document.SelectSingleNode("bookstore");
            //创建一个节点并设置属性
            XmlElement element = document.CreateElement("book");
            XmlAttribute attribute = document.CreateAttribute("Type");
            attribute.InnerText = "asdfg";
            element.SetAttributeNode(attribute);
            XmlAttribute attribute1 = document.CreateAttribute("ISBN");
            attribute1.InnerText = "1234";
            element.SetAttributeNode(attribute1);

            //设置子节点属性
            XmlElement elementchild = document.CreateElement("title");
            elementchild.InnerText = "qaz";
            element.AppendChild(elementchild);
            XmlElement elementchild1 = document.CreateElement("auther");
            elementchild1.InnerText = "qwert";
            element.AppendChild(elementchild1);
            XmlElement elementchlid2 = document.CreateElement("price");
            elementchlid2.InnerText = "22.00";
            element.AppendChild(elementchlid2);

            xmlNode.AppendChild(element);
            document.Save("BookXML.xml");

            //Linq 插入数据
            LinqXML.LinqXMLAddFunc();
            MessageBox.Show("插入成功！");

        }        

        /// <summary>
        /// 修改一条信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Modify_Click(object sender, EventArgs e)
        {
            XmlDocument document = new XmlDocument();
            document.Load("BookXML.xml");

            XmlElement xe = document.DocumentElement; // DocumentElement 获取xml文档对象的根XmlElement.
            string strPath = string.Format("/bookstore/book[@ISBN=\"{0}\"]", dataGridView1.CurrentRow.Cells[1].Value.ToString());
            XmlElement selectXe = (XmlElement)xe.SelectSingleNode(strPath);  //selectSingleNode 根据XPath表达式,获得符合条件的第一个节点.
            selectXe.SetAttribute("Type", dataGridView1.CurrentRow.Cells[0].Value.ToString());//也可以通过SetAttribute来增加一个属性
            selectXe.GetElementsByTagName("title").Item(0).InnerText = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            selectXe.GetElementsByTagName("author").Item(0).InnerText = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            selectXe.GetElementsByTagName("price").Item(0).InnerText = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            document.Save("Book.xml");

            //Linq 修改数据
            LinqXML.LinqXMLModifyFunc(dataGridView1);
            MessageBox.Show("修改成功！");
        }

        /// <summary>
        /// 删除一条信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            XmlDocument document = new XmlDocument();
            document.Load("BookXML.xml");
            //选择一个根元素
            XmlElement element = document.DocumentElement;
            string strPath = string.Format("/bookstore/book[@ISBN=\"{0}\"]", dataGridView1.CurrentRow.Cells[1].Value.ToString());
            XmlElement selectXe = (XmlElement)element.SelectSingleNode(strPath);  //selectSingleNode 根据XPath表达式,获得符合条件的第一个节点.
            selectXe.ParentNode.RemoveChild(selectXe);

            //Linq 删除数据
            LinqXML.LinqXMLDeleteFunc(dataGridView1);
            MessageBox.Show("删除成功！");
            //Linq 删除所有数据
            LinqXML.LinqXMLDeleteAllFunc();
            MessageBox.Show("删除成功！");
        }
        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_XMLTextRead_Click(object sender, EventArgs e)
        {
            List<BookModel> modelList = new List<BookModel>();
            modelList = ReadandWriteXML.XMLTextReadFunc();
            this.dataGridView1.DataSource = modelList;
        }

        /// <summary>
        /// 写文件，默认覆盖原文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_XMLTextWrite_Click(object sender, EventArgs e)
        {           
            ReadandWriteXML.XMLTextWriteFunc();
            Btn_XMLTextRead_Click(sender, e);
        }
        /// <summary>
        /// 绑定显示数据
        /// </summary>
        /// <param name="elements"></param>
        private void showInfoByElements(IEnumerable<XElement> elements)
        {
            List<BookModel> modelList = new List<BookModel>();
            foreach (var ele in elements)
            {
                BookModel model = new BookModel();
                model.BookAuthor = ele.Element("author").Value;
                model.BookName = ele.Element("title").Value;
                model.BookPrice = Convert.ToDouble(ele.Element("price").Value);
                model.BookISBN = ele.Attribute("ISBN").Value;
                model.BookType = ele.Attribute("Type").Value;

                modelList.Add(model);
            }
            dataGridView1.DataSource = modelList;
        }
    }
}
