using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLOperationDemo
{
    class BookModel
    {
        /// <summary>
        /// 类型
        /// </summary>
        private string _bookType;
        public string BookType
        {
            get { return _bookType; }
            set { _bookType = value; }
        }
        /// <summary>
        /// ISBN码
        /// </summary>
        private string _bookISBN;
        public string BookISBN
        {
            get { return _bookISBN; }
            set { _bookISBN = value; }
        }
        /// <summary>
        /// 书名
        /// </summary>
        private string _bookName;
        public string BookName
        {
            get { return _bookName; }
            set { _bookName = value; }
        }
        /// <summary>
        /// 作者
        /// </summary>
        private string _bookAuther;
        public string BookAuthor
        {
            get { return _bookAuther; }
            set { _bookAuther = value; }
        }
        /// <summary>
        /// 价格
        /// </summary>
        private double _bookPrice;
        public double BookPrice
        {
            get { return _bookPrice; }
            set { _bookPrice = value; }
        }
    }
}
