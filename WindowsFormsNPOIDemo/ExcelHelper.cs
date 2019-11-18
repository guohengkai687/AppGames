using System;   
using System.Collections.Generic;   
using System.Data;   
using System.IO;   
using System.Text;   
using System.Web;   
using NPOI;   
using NPOI.HPSF;   
using NPOI.HSSF;   
using NPOI.HSSF.UserModel;   
using NPOI.HSSF.Util;   
using NPOI.POIFS;   
using NPOI.Util;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;

namespace BearBBNew.MyClass
{
    public class ExcelHelper
    {
        public static void Export(DataGridView dgvSource, string fileName)
        {
            string strFileName=Application.StartupPath+"\\temp.xls";
            if (MessageBox.Show("是否保存文件？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
             
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel文件(*.xls)|*.xls";
                sfd.FileName = fileName;
                sfd.ShowDialog();
                strFileName = sfd.FileName;
            }           
            try
            {
                using (MemoryStream ms = Export(dgvSource))
                {
                    using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                    {
                        byte[] data = ms.ToArray();
                        fs.Write(data, 0, data.Length);
                        fs.Flush();
                    }
                }
                if (MessageBox.Show("是否打开文件？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {

                    System.Diagnostics.Process.Start(strFileName);

                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private static  MemoryStream Export(DataGridView dgvSource)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            HSSFSheet sheet = (NPOI.HSSF.UserModel.HSSFSheet)workbook.CreateSheet();

            HSSFCellStyle dateStyle = (NPOI.HSSF.UserModel.HSSFCellStyle)workbook.CreateCellStyle();
            HSSFDataFormat format = (NPOI.HSSF.UserModel.HSSFDataFormat)workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");
            int[] arrColWidth = new int[dgvSource.Columns.Count];
            foreach (DataGridViewColumn item in dgvSource.Columns)
            {
                if (item.Visible)
                {
                    arrColWidth[item.Index] = Encoding.GetEncoding(936).GetBytes(item.HeaderText.ToString()).Length;
                }
            }
            for (int i = 0; i < dgvSource.Rows.Count; i++)
            {
                for (int j = 0; j < dgvSource.Columns.Count; j++)
                {
                    if (dgvSource.Columns[j].Visible)
                    {
                        if (dgvSource.Rows[i].Cells[j].Value == null)
                        {
                            dgvSource.Rows[i].Cells[j].Value = "";
                        }
                        int intTemp = Encoding.GetEncoding(936).GetBytes(dgvSource.Rows[i].Cells[j].Value.ToString()).Length;
                        if (intTemp > arrColWidth[j])
                        {
                            arrColWidth[j] = intTemp;
                        }
                    }
                }
            }



            int rowIndex = 0;
            int columnIndex = 0;

            foreach (DataGridViewRow row in dgvSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    #region 列头及样式
                    {
                        HSSFRow headerRow = (NPOI.HSSF.UserModel.HSSFRow)sheet.CreateRow(rowIndex);


                        HSSFCellStyle headStyle = (NPOI.HSSF.UserModel.HSSFCellStyle)workbook.CreateCellStyle();
                        // headStyle.Alignment = CellHorizontalAlignment.CENTER;
                        HSSFFont font = (NPOI.HSSF.UserModel.HSSFFont)workbook.CreateFont();
                        font.FontHeightInPoints = 10;
                        font.Boldweight = 700;
                        headStyle.SetFont(font);


                        foreach (DataGridViewColumn column in dgvSource.Columns)
                        {
                            if (column.Visible)
                            {
                                headerRow.CreateCell(columnIndex).SetCellValue(column.HeaderText);
                                headerRow.GetCell(columnIndex).CellStyle = headStyle;

                                //设置列宽   
                                sheet.SetColumnWidth(columnIndex, (arrColWidth[column.Index] + 1) * 256);
                                columnIndex++;
                            }

                        }
                        //headerRow.Dispose();
                    }
                    #endregion

                    rowIndex = 1;
                }
                #endregion

                columnIndex = 0;
                #region 填充内容
                HSSFRow dataRow = (NPOI.HSSF.UserModel.HSSFRow)sheet.CreateRow(rowIndex);
                foreach (DataGridViewColumn column in dgvSource.Columns)
                {
                    if (column.Visible)
                    {
                        HSSFCell newCell = (NPOI.HSSF.UserModel.HSSFCell)dataRow.CreateCell(columnIndex);

                        string drValue = row.Cells[column.Index].Value.ToString();
                        if (column.ValueType == null)
                        {
                            column.ValueType = Type.GetType("System.String");
                        }
                        switch (column.ValueType.ToString())
                        {
                            case "System.String"://字符串类型   
                                newCell.SetCellValue(drValue);
                                break;
                            case "System.DateTime"://日期类型   
                                DateTime dateV;
                                DateTime.TryParse(drValue, out dateV);
                                newCell.SetCellValue(dateV);

                                newCell.CellStyle = dateStyle;//格式化显示   
                                break;
                            case "System.Boolean"://布尔型   
                                bool boolV = false;
                                bool.TryParse(drValue, out boolV);
                                newCell.SetCellValue(boolV);
                                break;
                            case "System.Int16"://整型   
                            case "System.Int32":
                            case "System.Int64":
                            case "System.Byte":
                                int intV = 0;
                                int.TryParse(drValue, out intV);
                                newCell.SetCellValue(intV);
                                break;
                            case "System.Decimal"://浮点型   
                            case "System.Double":
                                double doubV = 0;
                                double.TryParse(drValue, out doubV);
                                newCell.SetCellValue(doubV);
                                break;
                            case "System.DBNull"://空值处理   
                                newCell.SetCellValue("");
                                break;
                            default:
                                newCell.SetCellValue("");
                                break;
                        }
                        columnIndex++;
                    }
                    
                }
                #endregion

                rowIndex++;
            }


            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                sheet.Dispose();
                //workbook.Dispose();
                return ms;
            }
        }
    }
}
