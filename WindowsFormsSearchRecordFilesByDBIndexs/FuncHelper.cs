using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WindowsFormsSearchRecordFilesByDBIndexs
{
    public class FuncHelper
    {
        public static List<T> ConvertFromDataSet<T>(DataSet set) where T : new()
        {
            List<T> _list = new List<T>();
            PropertyInfo[] properties = null;
            foreach (DataRow row in set.Tables[0].Rows)
            {
                T t = new T();
                if (properties == null)
                {
                    properties = typeof(T).GetProperties();
                }
                foreach (PropertyInfo p in properties)
                {
                    try
                    {
                        if (row.Table.Columns.Contains(p.Name) == true)
                        {
                            object value = row[p.Name] == DBNull.Value ? null : row[p.Name];
                            p.SetValue(t, value, null);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                _list.Add(t);
            }
            return _list;
        }
    }
}
