using FormList;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FormList
{
    public partial class Chart : Services.BaseChildForm
    {

        DataTable dtTemp = new DataTable();
        DataTable dtTemp1 = new DataTable();
        DataTable dtChange = new DataTable();
        SqlConnection sCon = new SqlConnection(Commons.Sconnection);

        public Chart()
        {
            InitializeComponent();
        }

        private void Chart_Load(object sender, EventArgs e)
        {
            #region < 라인코드 콤보 박스 셋팅 >
            string sSelectSql = "SELECT DISTINCT LINECODE FROM TB_WorkCenterMaster";
            SqlDataAdapter adapter = new SqlDataAdapter(sSelectSql, sCon);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            // Add "ALL" option to the DataTable
            DataRow allRow = dt.NewRow();
            allRow["LINECODE"] = "ALL";
            dt.Rows.InsertAt(allRow, 0);

            cboLineCode.DataSource = dt;

            cboLineCode.ValueMember = "LINECODE";
            cboLineCode.DisplayMember = "LINECODE";
            #endregion
        }


        private void Per(object sender, EventArgs e)
        {
            try
            {
                sCon.Open();

                string sStartDate = dtpStatStart.Value.ToString("yyyy-MM-dd");
                string sEndDate = dtpStatEnd.Value.ToString("yyyy-MM-dd");
                string sLineCode = cboLineCode.SelectedValue as string;

                string sSqlSelect1 = $"SELECT " +
                                    $"DATEPART(YEAR, a.PRODDATE) AS Year, " +
                                    $"DATEPART(MONTH, a.PRODDATE) AS Month, " +
                                    $"SUM(a.PRODQTY) AS TotalProdQty, " +
                                    $"SUM(a.BADQTY) AS TotalBadQty, " +
                                    $"(SUM(a.BADQTY) * 100.0 / NULLIF(SUM(a.PRODQTY), 0)) AS DefectRate " +
                                    $"FROM TB_ProductPerformance a " +
                                    $"JOIN TB_WorkCenterStatusRec b ON a.ORDERNO = b.ORDERNO " +
                                    $"JOIN TB_WorkCenterMaster c ON b.LINECODE = c.LINECODE " +
                                    $"WHERE a.PRODDATE >= '{sStartDate}' AND a.PRODDATE <= '{sEndDate}' ";

                if (sLineCode != "ALL")
                {
                    sSqlSelect1 += $"AND c.LINECODE = '{sLineCode}' ";
                }

                sSqlSelect1 += "GROUP BY DATEPART(YEAR, a.PRODDATE), DATEPART(MONTH, a.PRODDATE)";

                SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect1, sCon);
                DataTable dtTemp1 = new DataTable();
                adapter.Fill(dtTemp1);

                // Check if there is a record for the selected period
                if (dtTemp1.Rows.Count > 0)
                {
                    // Get the defect rate for the selected period (average of all months)
                    double overallDefectRate = Convert.ToDouble(dtTemp1.Compute("AVG(DefectRate)", ""));

                    // Display the overall defect rate in Label 5
                    label5.Text = $"불량률: {overallDefectRate:F2}%";
                }
                else
                {
                    // If no record found, display a message or set the Label text as needed
                    label5.Text = "데이터 없음";
                }
            }
            catch (Exception ex)
            {
                // Handle the exception if needed
                label5.Text = "에러 발생";
            }
            finally
            {
                sCon.Close();
            }
        }








        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            sCon.Open();

            string sStartDate = dtpStatStart.Value.ToString("yyyy-MM-dd");
            string sEndDate = dtpStatEnd.Value.ToString("yyyy-MM-dd");
            string sLineCode = cboLineCode.SelectedValue as string;

            string sSqlSelect = $"SELECT a.PRODDATE, " +
                                       $"SUM(CASE WHEN c.LINECODE = 'L01' THEN a.PRODQTY ELSE 0 END) AS L01, " +
                                       $"SUM(CASE WHEN c.LINECODE = 'L02' THEN a.PRODQTY ELSE 0 END) AS L02, " +
                                       $"SUM(CASE WHEN c.LINECODE = 'L03' THEN a.PRODQTY ELSE 0 END) AS L03 " +
                                       $"FROM TB_ProductPerformance a " +
                                       $"JOIN TB_WorkCenterStatusRec b ON a.ORDERNO = b.ORDERNO " +
                                       $"JOIN TB_WorkCenterMaster c ON b.LINECODE = c.LINECODE ";

            if (sLineCode != "ALL")
            {
                sSqlSelect += $"WHERE c.LINECODE = '{sLineCode}' AND ";
            }
            else
            {
                sSqlSelect += "WHERE ";
            }

            sSqlSelect += $"a.PRODDATE >= '{sStartDate}' AND a.PRODDATE <= '{sEndDate}' " +
                          "GROUP BY a.PRODDATE";

            SqlDataAdapter adapter1 = new SqlDataAdapter(sSqlSelect, sCon);
            dtTemp.Clear();
            adapter1.Fill(dtTemp);


            chart1.DataSource = dtTemp;
            chart1.Series[0].XValueMember = "PRODDATE";
            chart1.Series[0].YValueMembers = "L01";
            chart1.Series[0].Name = "L01";
            chart1.Series[0].Color = Color.Aquamarine;
            chart1.Series[0].IsValueShownAsLabel = true;

            chart1.Series.Add("L02");
            chart1.Series["L02"].XValueMember = "PRODDATE";
            chart1.Series["L02"].YValueMembers = "L02";
            chart1.Series["L02"].Name = "L02";
            chart1.Series["L02"].Color = Color.Orange;
            chart1.Series["L02"].IsValueShownAsLabel = true;

            chart1.Series.Add("L03");
            chart1.Series["L03"].XValueMember = "PRODDATE";
            chart1.Series["L03"].YValueMembers = "L03";
            chart1.Series["L03"].Name = "L03";
            chart1.Series["L03"].Color = Color.Yellow;
            chart1.Series["L03"].IsValueShownAsLabel = true;
        }
            catch (Exception ex)
            {

            }
            finally
            {
                sCon.Close();
            }

        }
    }
}


