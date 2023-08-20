using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace FormList
{
    public partial class ProdOrder : Services.BaseChildForm
    {
        #region < MEMBER AREA >
        private Dictionary<DateTime, int> sequenceDictionary = new Dictionary<DateTime, int>(); // 각 날짜별 시퀀스를 저장하는 Dictionary
        private DateTime currentDate; // 현재 날짜
        DataTable dtTemp = new DataTable(); // return DataTable 공통
        DataTable DtChange = null;
        SqlConnection connection = new SqlConnection(Commons.Sconnection);
        #endregion

        public ProdOrder()
        {
            InitializeComponent();

        }

        private void ProdOrder_Load(object sender, EventArgs e)
        {

            #region < 그리드 >
            // 그리드

            dtTemp.Columns.Add("PLANTCODE", typeof(string));
            dtTemp.Columns.Add("PRODORDERDATE", typeof(string));
            dtTemp.Columns.Add("PRODORDERNO", typeof(string));
            dtTemp.Columns.Add("LINECODE", typeof(string));
            dtTemp.Columns.Add("ITEMNAME", typeof(string));
            dtTemp.Columns.Add("PRODORDERQTY", typeof(string));
            dtTemp.Columns.Add("STATUS", typeof(string));
            dtTemp.Columns.Add("PRODORDERSEQ", typeof(string));     // 시퀀스용 
            dtTemp.Columns.Add("MAKER", typeof(string));
            dtTemp.Columns.Add("MAKEDATE", typeof(DateTime));


            Grid.DataSource = dtTemp;

            Grid.Columns["PLANTCODE"].HeaderText = "공장";
            Grid.Columns["PRODORDERDATE"].HeaderText = "작업지시일자";
            Grid.Columns["PRODORDERNO"].HeaderText = "작업지시번호";
            Grid.Columns["LINECODE"].HeaderText = "라인";
            Grid.Columns["ITEMNAME"].HeaderText = "품목명";
            Grid.Columns["PRODORDERQTY"].HeaderText = "작업지시수량";
            Grid.Columns["STATUS"].HeaderText = "가동여부";
            Grid.Columns["MAKER"].HeaderText = "등록자";
            Grid.Columns["MAKEDATE"].HeaderText = "등록일시";

            // 그리드 옵션 지정 부분 

            Grid.Columns[0].Width = 100;
            Grid.Columns[1].Width = 300;
            Grid.Columns[2].Width = 250;
            Grid.Columns[3].Width = 100;
            Grid.Columns[4].Width = 150;
            Grid.Columns[5].Width = 200;
            Grid.Columns[6].Width = 80;
            Grid.Columns[7].Width = 250;
            Grid.Columns[8].Width = 100;
            Grid.Columns[9].Width = 250;

            Grid.Columns[6].DefaultCellStyle.Font = new Font(Grid.Font, FontStyle.Bold);
            Grid.Columns[6].DefaultCellStyle.ForeColor = Color.Red;

            Grid.Columns["PRODORDERQTY"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            Grid.Columns["PRODORDERSEQ"].Visible = false;
            //컬럼의 수정 여부를 지정
            Grid.Columns["ITEMNAME"].ReadOnly = true;
            Grid.Columns["PRODORDERNO"].ReadOnly = true;
            Grid.Columns["STATUS"].ReadOnly = true;
            Grid.Columns["MAKER"].ReadOnly = true;
            Grid.Columns["MAKEDATE"].ReadOnly = true;
            #endregion




#region ▶ 콤보박스 ◀

    SqlConnection sCon = new SqlConnection(Commons.Sconnection);
            try
            {
                #region < (상단 등록부) 라인코드 콤보 박스 셋팅 >
                string sSelectSql4 = "SELECT DISTINCT LINECODE FROM TB_WorkCenterMaster";
                SqlDataAdapter adapter4 = new SqlDataAdapter(sSelectSql4, sCon);
                DataTable dt4 = new DataTable();
                adapter4.Fill(dt4);

                cboOrdLineC.DataSource = dt4;
                cboOrdLineC.ValueMember = "LINECODE";
                cboOrdLineC.DisplayMember = "LINECODE";
                #endregion

                #region < (상단 등록부) 공장코드 콤보 박스 셋팅 >

                string sSelectSql6 = "SELECT DISTINCT PLANTCODE FROM TB_ITEMMASTER";
                SqlDataAdapter adapter6 = new SqlDataAdapter(sSelectSql6, sCon);
                DataTable dt6 = new DataTable();
                adapter6.Fill(dt6);

                cboPlantCode.DataSource = dt6;
                cboPlantCode.ValueMember = "PLANTCODE";
                cboPlantCode.DisplayMember = "PLANTCODE";
                #endregion

                #region < (상단 등록부) 품목코드 콤보 박스 셋팅 >

                string sSelectSql8 = "SELECT DISTINCT ITEMCODE AS ITEM_CODE, ITEMNAME AS ITEM_NAME FROM TB_ITEMMASTER ORDERBY ";
                SqlDataAdapter adapter8 = new SqlDataAdapter(sSelectSql8, sCon);
                DataTable dt8 = new DataTable();
                adapter8.Fill(dt8);

                cboItemName.DataSource = dt8;
                cboItemName.ValueMember = "ITEM_CODE";
                cboItemName.DisplayMember = "ITEM_NAME";
                #endregion


                #region < (중단 조회부) 라인코드 콤보 박스 셋팅 >
                string sSelectSql5 = "SELECT DISTINCT LINECODE FROM TB_WorkCenterMaster";
                SqlDataAdapter adapter5 = new SqlDataAdapter(sSelectSql5, sCon);
                DataTable dt5 = new DataTable();
                adapter5.Fill(dt5);

                // Add "ALL" option to the DataTable
                DataRow allRow5 = dt5.NewRow();
                allRow5["LINECODE"] = "ALL";
                dt5.Rows.InsertAt(allRow5, 0);

                cboOrdListLineC.DataSource = dt5;

                cboOrdListLineC.ValueMember = "LINECODE";
                cboOrdListLineC.DisplayMember = "LINECODE";
                #endregion

                #region < (중단 조회부) 공장코드 콤보 박스 셋팅 >

                string sSelectSql7 = "SELECT DISTINCT PLANTCODE FROM TB_ITEMMASTER";
                SqlDataAdapter adapter7 = new SqlDataAdapter(sSelectSql7, sCon);
                DataTable dt7 = new DataTable();
                adapter7.Fill(dt7);

                // Add "ALL" option to the DataTable
                DataRow allRow7 = dt7.NewRow();
                allRow7["PLANTCODE"] = "ALL";
                dt7.Rows.InsertAt(allRow7, 0);

                cboOrdListPlantC.DataSource = dt7;
                cboOrdListPlantC.ValueMember = "PLANTCODE";
                cboOrdListPlantC.DisplayMember = "PLANTCODE";
                #endregion

                #region < (중단 조회부) 품목코드 콤보 박스 셋팅 >

                string sSelectSql9 = "SELECT DISTINCT ITEMCODE AS ITEM_CODE, ITEMNAME AS ITEM_NAME FROM TB_ITEMMASTER";
                SqlDataAdapter adapter9 = new SqlDataAdapter(sSelectSql9, sCon);
                DataTable dt9 = new DataTable();
                adapter9.Fill(dt9);

                cboOrdListItemName.DataSource = dt9;
                cboOrdListItemName.ValueMember = "ITEM_CODE";
                cboOrdListItemName.DisplayMember = "ITEM_NAME";
                #endregion


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sCon.Close();
            }


            #endregion
        }

        #region ▶ < 중단 조회부용 툴바 조회 코드 >◀
        public override void DoInquire()
        {
            try
            {
                connection.Open();

                string sPlantCode = cboOrdListPlantC.SelectedValue as string;
                string sdateOrd = DateOrdList.Text;
                string sOrdNo = txtOrdListNo.Text;
                string sOrdListLineC = cboOrdListLineC.SelectedValue as string;
                string sOrdListItemName = cboOrdListItemName.SelectedValue as string;
                string sOrdListQty = txtOrdListQty.Text;
                string sMaker = txtOrdListMaker.Text;

                dtTemp.Clear();

                string sSqlSelect = "SELECT DISTINCT a.PLANTCODE, a.LINECODE, a.PRODORDERDATE, a.PRODORDERNO, b.ITEMNAME, a.PRODORDERQTY, c.STATUS, a.MAKER, a.MAKEDATE " +
                                    "FROM TB_ProductOrder a " +
                                    "JOIN TB_ItemMaster b ON a.ITEMCODE = b.ITEMCODE " +
                                    "JOIN TB_WorkCenterStatusRec c ON a.PRODORDERNO = c.ORDERNO " +
                                    "WHERE 1=1";

                // Handle the "ALL" option selections
                if (sPlantCode != "ALL")
                    sSqlSelect += $" AND a.PLANTCODE = '{sPlantCode}'";

                if (sOrdListLineC != "ALL")
                    sSqlSelect += $" AND a.LINECODE = '{sOrdListLineC}'";

                if (!string.IsNullOrEmpty(sOrdNo)) // If PRODORDERNO is provided, filter using LIKE
                    sSqlSelect += $" AND a.PRODORDERNO LIKE '%{sOrdNo}%'";

                if (!string.IsNullOrEmpty(sdateOrd)) // If sdateOrd is provided, filter using the selected date
                    sSqlSelect += $" AND a.PRODORDERDATE = '{sdateOrd}'";

                SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, connection);
                adapter.Fill(dtTemp);

                // Update the DataGridView with the new data
                Grid.DataSource = dtTemp;
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately, e.g., display an error message
                MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }


        public override void DoNew()
        {
            MessageBox.Show(" 해당 페이지는 추가가 불가능합니다. " , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public override void DoSave()
        {
            MessageBox.Show(" 해당 페이지는 저장이 불가능합니다. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public override void DoDelete()
        {
            MessageBox.Show(" 해당 페이지는 삭제가 불가능합니다. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        private Dictionary<string, int> seqDictionary = new Dictionary<string, int>(); // seqDictionary 선언 이동

        #region < 상단 등록부 버튼 코드 >
        private void btnOrdUp_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = DateOrd.Value.Date;
            int sequence = GetNextSequence(selectedDate);
            DialogResult result = MessageBox.Show(" 등록하시겠습니까? ", "확인", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes) ;
            else { return; }


        try
            {
                connection.Open();

                // 생산계획 데이터를 데이터베이스에 저장하거나 다른 동작을 수행할 수 있습니다.
                // 예시로 생산계획을 데이터베이스에 저장하는 코드를 추가합니다.
                string PlantCode = cboPlantCode.SelectedValue as string;
                DateTime date      = DateOrd.Value;
                string dateOrd     = selectedDate.ToString("yyyyMMdd");
                string OrdLineC    = cboOrdLineC.SelectedValue as string;
                string OrdItemCode = cboItemName.SelectedValue as string;
                string OrdItemName = cboItemName.Text;
                string OrderNo     = $"ORD{OrdLineC}{dateOrd}{sequence:000}";
                string Maker       = "ADMIN";
                string OrdQty      = txtOrdQty.Text;



                // 생산계획을 데이터베이스에 저장하는 코드 예시
                String insertQuery = "BEGIN " +
                    "INSERT INTO TB_ProductOrder" +
                    "      (PRODORDERDATE, PLANTCODE, LINECODE, PRODORDERQTY, PRODORDERNO, PRODORDERSEQ, ITEMCODE, MAKER, MAKEDATE)" +
                    "VALUES(@PRODORDERDATE, @PLANTCODE, @LINECODE, @PRODORDERQTY, @PRODORDERNO, @PRODORDERSEQ, @ITEMCODE, @MAKER, @MAKEDATE)" +
                    "INSERT INTO TB_WorkCenterStatusRec(PLANTCODE, ORDERNO, PRODSEQ, STATUS, RSSTARTDATE)" +
                    "VALUES(@PLANTCODE, @PRODORDERNO, @PRODORDERSEQ, 'S', @MAKEDATE)" +
                    "INSERT INTO TB_ProductPerformance(PLANTCODE, ORDERNO, PRODSEQ, ITEMCODE)" +
                    "VALUES(@PLANTCODE, @PRODORDERNO, @PRODORDERSEQ, @ITEMCODE)" +
                    "END";


                // SQL 쿼리를 실행하기 위해 SqlCommand 객체를 생성합니다.
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    // 파라미터를 추가하여 쿼리의 매개변수에 값을 전달합니다.
                    command.Parameters.AddWithValue("@PRODORDERDATE", dateOrd);
                    command.Parameters.AddWithValue("@PLANTCODE", PlantCode);
                    command.Parameters.AddWithValue("@LINECODE", OrdLineC);
                    command.Parameters.AddWithValue("@PRODORDERQTY", OrdQty);
                    command.Parameters.AddWithValue("@PRODORDERNO", OrderNo);    // == > 작지번호 생성  
                    command.Parameters.AddWithValue("@PRODORDERSEQ", sequence);
                    command.Parameters.AddWithValue("@ITEMCODE", OrdItemCode);
                    command.Parameters.AddWithValue("@MAKER", Maker);
                    command.Parameters.AddWithValue("@MAKEDATE", DateTime.Now);

                    // 쿼리를 실행하여 데이터베이스에 삽입합니다.
                    command.ExecuteNonQuery();

                }

                 // 삽입한 데이터를 데이터 테이블에 추가합니다.
                 DataRow newRow = dtTemp.NewRow();

                 newRow["PRODORDERDATE"] = dateOrd;
                 newRow["PLANTCODE"] = cboPlantCode.SelectedValue;
                 newRow["LINECODE"] = OrdLineC;
                 newRow["PRODORDERQTY"] = OrdQty;
                 newRow["PRODORDERNO"] = OrderNo;
                 newRow["ITEMNAME"] = OrdItemName;
                 newRow["STATUS"] = "S";
                 newRow["MAKER"] = Maker;
                 newRow["MAKEDATE"] = DateTime.Now;
                 dtTemp.Rows.Add(newRow);

             // 그리드에 데이터 테이블을 바인딩합니다.
             Grid.DataSource = dtTemp;
            }
            catch (Exception ex)
            {
                // 예외가 발생한 경우 에러 메시지를 표시합니다.
                MessageBox.Show("작업지시번호 생성 중 오류가 발생했습니다: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

        }
        private int GetNextSequence(DateTime date)
        {
            int maxSequence = 0;

            try
            {
                connection.Open();

                string query = "SELECT MAX(CAST(SUBSTRING(PRODORDERNO, 15, LEN(PRODORDERNO) - 14) AS INT)) FROM TB_ProductOrder WHERE PRODORDERDATE = @PRODORDERDATE";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PRODORDERDATE", date.ToString("yyyyMMdd"));

                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        maxSequence = Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately, e.g., display an error message
                MessageBox.Show("Error occurred while fetching the maximum sequence: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }

            // Increment the sequence value by 1 to get the next sequence
            return maxSequence + 1;
            #endregion

        }

        private void btnStart_Click(object sender, EventArgs e)
        {



        }

    }
}
 
