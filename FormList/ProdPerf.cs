using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FormList
{
    public partial class ProdPerf : Services.BaseChildForm
    {
        DataTable dtTemp = new DataTable();

        SqlConnection sCon = new SqlConnection(Commons.Sconnection);

        public ProdPerf()
        {
            InitializeComponent();
        }

        #region <그리드 셋팅>
            private void ProdPerf_Load(object sender, EventArgs e)
            {
                //그리드
                dtTemp.Columns.Add("PLANTCODE",         typeof(string));
                dtTemp.Columns.Add("PRODORDERDATE",     typeof(DateTime));
                dtTemp.Columns.Add("PRODORDERNO",       typeof(string));
                dtTemp.Columns.Add("LINECODE",          typeof(string));          
                dtTemp.Columns.Add("ITEMTYPE",          typeof(string));
                dtTemp.Columns.Add("ITEMNAME",          typeof(string));
                dtTemp.Columns.Add("PRODORDERQTY",       typeof(string));
                dtTemp.Columns.Add("PRODQTY",           typeof(string));
                dtTemp.Columns.Add("BADQTY",            typeof(string));



                Grid.DataSource = dtTemp;

                Grid.Columns["PLANTCODE"]       .HeaderText = "공장코드";
                Grid.Columns["PRODORDERDATE"]   .HeaderText = "작업지시일자";
                Grid.Columns["PRODORDERNO"]     .HeaderText = "작업지시번호";
                Grid.Columns["LINECODE"]        .HeaderText = "라인코드";
                Grid.Columns["ITEMTYPE"]        .HeaderText = "품목구분";
                Grid.Columns["ITEMNAME"]        .HeaderText = "품목명";
                Grid.Columns["PRODORDERQTY"]     .HeaderText = "작업지시수량";
                Grid.Columns["PRODQTY"]         .HeaderText = "양품수량";
                Grid.Columns["BADQTY"]          .HeaderText = "불량수량";


                Grid.Columns[0].Width = 100;
                Grid.Columns[1].Width = 200;
                Grid.Columns[2].Width = 200;
                Grid.Columns[3].Width = 100;
                Grid.Columns[4].Width = 100;
                Grid.Columns[5].Width = 200;
                Grid.Columns[6].Width = 200;
                Grid.Columns[7].Width = 100;
                Grid.Columns[8].Width = 100;

                // 컬럼의 정렬 지정 
                Grid.Columns["PRODORDERQTY"] .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Grid.Columns["PRODQTY"]     .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                Grid.Columns["BADQTY"]      .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                //컬럼의 수정 여부를 지정
                Grid.Columns["PLANTCODE"]       .ReadOnly = true;
                Grid.Columns["PRODORDERDATE"]   .ReadOnly = true;
                Grid.Columns["PRODORDERNO"]      .ReadOnly = true;
                Grid.Columns["LINECODE"]        .ReadOnly = true;
                Grid.Columns["ITEMTYPE"]        .ReadOnly = true;
                Grid.Columns["ITEMNAME"]        .ReadOnly = true;
                Grid.Columns["PRODORDERQTY"]     .ReadOnly = true;
                Grid.Columns["PRODQTY"]         .ReadOnly = true;
                Grid.Columns["BADQTY"]          .ReadOnly = true;

            #endregion



            // 데이터베이스 접속
            try
            {
                sCon.Open();

                #region < 품목 타입 콤보 박스 셋팅 >
                // 라인 콤보박스
                string sSelectSql = " SELECT 'ALL' AS LINE_CODE" +
                                     " UNION " +
                                     " SELECT LINECODE AS LINE_CODE" +
                                     " FROM TB_WorkCenterMaster";

                SqlDataAdapter adapter = new SqlDataAdapter(sSelectSql, sCon);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cboPerf.DataSource = dt;
                cboPerf.ValueMember = "LINE_CODE";
                cboPerf.DisplayMember = "LINE_CODE";




                // 작업지시품목 콤보박스
                string sSelectSql1 = " SELECT 'ALL' AS ITEM_CODE, 'ALL' AS ITEM_NAME" +
                                     " UNION " +
                                     " SELECT ITEMCODE AS ITEM_CODE, ITEMNAME AS ITEM_NAME" +
                                     " FROM TB_ItemMaster";

                SqlDataAdapter adapter1 = new SqlDataAdapter(sSelectSql1, sCon);
                DataTable dt1 = new DataTable();
                adapter1.Fill(dt1);

                cboPerfName.DataSource = dt1;
                cboPerfName.ValueMember = "ITEM_CODE";
                cboPerfName.DisplayMember = "ITEM_NAME";

                #endregion


                #region < 공장코드 콤보 박스 셋팅 >
                //string sSelectSql4 = " SELECT DISTINCT PLANTCODE  " +
                //                     "   FROM TB_ItemMaster       ";


                //// 데이터베이스를 조회하는 클래스
                //SqlDataAdapter adapter4 = new SqlDataAdapter(sSelectSql4, sCon);
                //DataTable dt4 = new DataTable();
                //adapter4.Fill(dt4);

                //// 콤보박스에 셋팅되어야 하는 데이터를 매핑
                //cboPlantCode.DataSource = dt4;




                //// 응용프로그램에서 사용할 코드와 사용자가 눈으로 확인할 Text 속성을 분류
                //cboPlantCode.ValueMember = "PLANTCODE";
                //cboPlantCode.DisplayMember = "PLANTCODE";
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sCon.Close();
            }
        }

        #region <생산실적 조회 인쿼리>
        public override void DoInquire()
        {
            try
            {
                sCon.Open();
                dtTemp.Clear();

                //string sPlantCode = cboPlantCode.SelectedValue as string; 공장번호 컨트롤 추가할 것인가?
                string sOrderDate = string.Format("{0:yyyy-MM-dd}", DatePerf.Value);
                string sLineCode = cboPerf.SelectedValue.ToString();    // 컨틀로 이름 변경 필요
                string sOrderNumber = textBox3.Text;                    // 컨트롤 이름 변경 필요
                string sProdName = cboPerfName.SelectedValue as string; // 컨트롤 이름 변경 필요


                //1. 공장코드 컨트롤 콤보박스가 추가되면 WHERE조건 추가
                //2. 가동 / 비가동을 입력받는 부분을 추가할 것인가? 왜? 조회하는거니까 보여줄것인가?
                //3. 작업지시 테이블에 라인코드 어트리뷰트 추가해야 인쿼리 작동
                //4. 가동중인 작업만 보고싶다면 WorkCenterStatusRec 테이블을 left join 추가할 것.
                string sSqlSelect = "SELECT     A.PLANTCODE             AS PLANTCODE                            " +
                                    "           ,A.PRODORDERDATE        AS PRODORDERDATE                        " +
                                    "           ,A.PRODORDERNO          AS PRODORDERNO                           " +
                                    "           ,A.LINECODE             AS LINECODE                             " +
                                    "           ,B.ITEMTYPE             AS ITEMTYPE                             " +
                                    "           ,B.ITEMNAME             AS ITEMNAME                             " +
                                    "           ,A.PRODORDERQTY         AS PRODORDERQTY                          " +
                                    "           ,C.PRODQTY              AS PRODQTY                              " +
                                    "           ,C.BADQTY               AS BADQTY                               " +
                                    "FROM TB_ProductOrder A(NOLOCK) LEFT JOIN TB_ItemMaster B(NOLOCK)           " +
                                    "                                      ON A.PLANTCODE = B.PLANTCODE         " +
                                    "                                     AND A.ITEMCODE = B.ITEMCODE           " +
                                    "                               LEFT JOIN TB_ProductPerformance C(NOLOCK)   " +
                                    "                                      ON A.PLANTCODE = C.PLANTCODE         " +
                                    "                                     AND A.PRODORDERNO = C.ORDERNO         " +


                                    $"WHERE     A.PRODORDERDATE        = '{sOrderDate}'" +
                                    $"  AND     A.PRODORDERNO LIKE '%' + '{sOrderNumber}' + '%'";


                if (sLineCode != "ALL")
                    sSqlSelect += $" AND A.LINECODE = '{sLineCode}'";

                if (sLineCode != "ALL")
                    sSqlSelect += $" AND B.ITEMCODE = '{sProdName}'";


                SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, sCon);
                adapter.Fill(dtTemp);
                Grid.DataSource = dtTemp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sCon.Close();
            }
            #endregion
        }

        #region <가제 : 생산실적입력창>

        private void DisplayRowDataInTextBox(DataGridViewRow row)
        {
            // 선택된 행의 데이터를 TextBox에 표시합니다.
            if (row.Cells.Count > 0)
            {
                txtLineCode.Text    =   row.Cells["LINECODE"].Value.ToString();
                txtProdOrdNo.Text   =   row.Cells["PRODORDERNO"].Value.ToString();
                txtItemName.Text    =   row.Cells["ITEMNAME"].Value.ToString();
                txtProdOrdQty.Text  =   row.Cells["PRODORDERQTY"].Value.ToString();
                txtProdQty.Text     =   row.Cells["PRODQTY"].Value.ToString();
                txtBadQty.Text      =   row.Cells["BADQTY"].Value.ToString();
            }
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            if (Grid.SelectedRows.Count == 1)
            {
                DataGridViewRow selectedRow = Grid.SelectedRows[0];
                DisplayRowDataInTextBox(selectedRow);
            }
        }
        #endregion

        #region <Timer 를 이용한 수량 변경, 및 작업 완료 시 데이터 베이스 입력>
        private Dictionary<string, string> WorkDictionary = new Dictionary<string, string>();
        private Dictionary<string, System.Timers.Timer> TimersDictionary = new Dictionary<string, System.Timers.Timer>();
        private Random random = new Random(); // 불량품 발생기
        private string currentWorkingOrderNumber;
        private bool isWorking;

        private void btnStart_Click(object sender, EventArgs e)
        {
            string orderNumber = Grid.CurrentRow.Cells["PRODORDERNO"].Value.ToString();
            string lineCode = Grid.CurrentRow.Cells["LINECODE"].Value.ToString();
            int targetQuantity = Convert.ToInt32(Grid.CurrentRow.Cells["PRODORDERQTY"].Value);

            #region <스레드 수행 전 Validation Check>
            if (isWorking)
            {
                MessageBox.Show("이미 작업 중입니다.");
                return;
            }

            DataGridViewRow selectedRow = Grid.CurrentRow;
            if (selectedRow == null)
            {
                MessageBox.Show("작업을 선택해주세요.");
                return;
            }
            // 작업 중인 상태로 설정
            currentWorkingOrderNumber = orderNumber;
            isWorking = true;

            if (WorkDictionary.ContainsKey(orderNumber))
            {
                MessageBox.Show("이미 수행중인 작업입니다.");
                return;
            }
            else if (WorkDictionary.ContainsValue(lineCode))
            {
                MessageBox.Show("이미 작업중인 라인입니다.");
                return;
            }
            else if (WorkDictionary.Count >= 3)
            {
                MessageBox.Show("모든 라인이 작업 중입니다.");
                return;
            }

            WorkDictionary.Add(orderNumber,lineCode);
            #endregion


            // 타이머가 없으면 생성하고, 이미 있다면 틱 횟수 변경
            if (!TimersDictionary.TryGetValue(orderNumber, out System.Timers.Timer existingTimer))
            {
                existingTimer = new System.Timers.Timer();
                existingTimer.Elapsed += (s, evt) =>
                {
                    TimerElapsed(s, evt, orderNumber, lineCode, targetQuantity);
                };
                TimersDictionary[orderNumber] = existingTimer;
            }

            int interval = (int)existingTimer.Interval; // 기존의 타이머 간격 그대로 사용
            existingTimer.Interval = interval;
            existingTimer.Start();

        }

        private void TimerElapsed(object sender, ElapsedEventArgs e, string orderNumber, string lineCode, int targetQuantity)
        {
            System.Timers.Timer timer = (System.Timers.Timer)sender;

            // 작업 수행...
            // Good Product과 Bad Product의 수를 계산하고 그리드 업데이트
            int goodProductCount = 0;
            int badProductCount = 0;

            if (targetQuantity > 0)
            {
                // 작업 수행할 양품/불량 수량 계산
                goodProductCount = random.Next(0, targetQuantity + 1);
                badProductCount = targetQuantity - goodProductCount;

                // Good Product과 Bad Product의 수를 그리드에 업데이트
                UpdateProductCounts(orderNumber, goodProductCount, badProductCount);

                #endregion

                if (targetQuantity <= 0)
                {
                    // 작업이 완료되면 타이머 중지
                    timer.Stop();

                    // 데이터베이스에 양품수량과 불량수량 업데이트
                    UpdateDatabaseBadProduct(orderNumber, badProductCount);
                    UpdateDatabaseGoodProduct(orderNumber, goodProductCount);
                    // 작업 완료 후 WorkDictionary 및 TimersDictionary에서 해당 라인 정보 삭제
                    WorkDictionary.Remove(orderNumber);
                    TimersDictionary.Remove(orderNumber);

                    // 작업 완료 메시지 표시
                    Console.WriteLine("작업 완료");
                    currentWorkingOrderNumber = null;
                    isWorking = false;
                }
            }
           
        }

        //private void UpdateDatabaseProductCounts(string orderNumber, int goodProductCount, int badProductCount)
        //{
        //    try
        //    {
        //        sCon.Open();

        //        string updateQuery = $"UPDATE TB_ProductPerformance " +
        //                             $"SET PRODQTY = {goodProductCount}, BADQTY = {badProductCount} " +
        //                             $"WHERE ORDERNO = '{orderNumber}'";

        //        SqlCommand update = new SqlCommand(updateQuery, sCon);
        //        update.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        sCon.Close();
        //    }
        //}

        private void UpdateDatabaseBadProduct(string orderNumber, int badProductCount)
        {
            try
            {
                sCon.Open();

                string updateQuery = $"UPDATE TB_ProductPerformance " +
                                     $"SET BADQTY = @BadQty " +
                                     $"WHERE ORDERNO = @OrderNo";

                using (SqlCommand updateCommand = new SqlCommand(updateQuery, sCon))
                {
                    updateCommand.Parameters.AddWithValue("@BadQty", badProductCount);
                    updateCommand.Parameters.AddWithValue("@OrderNo", orderNumber);

                    updateCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("불량 수량 업데이트 중 오류가 발생했습니다: " + ex.Message);
            }
            finally
            {
                sCon.Close();
            }
        }

        private void UpdateDatabaseGoodProduct(string orderNumber, int goodProductCount)
        {
            try
            {
                sCon.Open();

                string updateQuery = $"UPDATE TB_ProductPerformance " +
                                     $"SET PRODQTY = @GoodQty " +
                                     $"WHERE ORDERNO = @OrderNo";

                using (SqlCommand updateCommand = new SqlCommand(updateQuery, sCon))
                {
                    updateCommand.Parameters.AddWithValue("@GoodQty", goodProductCount);
                    updateCommand.Parameters.AddWithValue("@OrderNo", orderNumber);

                    updateCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("양품 수량 업데이트 중 오류가 발생했습니다: " + ex.Message);
            }
            finally
            {
                sCon.Close();
            }
        }

        #region <그리드에 숫자를 표현하는 로직2>
        private void UpdateProductCounts(string orderNumber, int goodProductCount, int badProductCount)
        {
            // 해당 라인에 대한 DataGridViewRow를 찾아 업데이트
            foreach (DataGridViewRow row in Grid.Rows)
            {
                if (row.Cells["PRODORDERNO"].Value.ToString() == orderNumber)
                {
                    // PRODORDERNO 값 가져오기
                    string lineCode = row.Cells["LINECODE"].Value.ToString();

                    // Good Product과 Bad Product의 수량을 업데이트
                    row.Cells["PRODQTY"].Value = goodProductCount;
                    row.Cells["BADQTY"].Value = badProductCount;

                    // DataGridView 업데이트
                    Grid.InvalidateRow(row.Index);
                    break; // 해당 라인을 찾았으므로 루프 종료
                }
            }
        }


        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            // 현재 선택된 그리드 행 가져오기
            DataGridViewRow selectedRow = Grid.CurrentRow;

            if (selectedRow != null)
            {
                try
                {
                    string plantCode = selectedRow.Cells["PLANTCODE"].Value.ToString();
                    DateTime prodOrderDate = (DateTime)selectedRow.Cells["PRODORDERDATE"].Value;
                    string prodOrderNo = selectedRow.Cells["PRODORDERNO"].Value.ToString();
                    string lineCode = selectedRow.Cells["LINECODE"].Value.ToString();
                    string itemName = selectedRow.Cells["ITEMNAME"].Value.ToString();



                    // Update TB_WorkCenterStatusRec for 'R' status
                    UpdateWorkCenterStatusRecR(plantCode, prodOrderDate, prodOrderNo);

                    // Insert into TB_WorkCenterStatusRec for 'S' status
                    InsertIntoWorkCenterStatusRecS(plantCode, prodOrderDate, prodOrderNo, lineCode, itemName);

                    MessageBox.Show("작업 상태를 업데이트하였습니다.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("오류가 발생하였습니다: " + ex.Message);
                }
            }
        }

        private void UpdateWorkCenterStatusRecR(string plantCode, DateTime prodOrderDate, string prodOrderNo)
        {
            try
            {
                sCon.Open();

                string updateQuery = "UPDATE TB_WorkCenterStatusRec " +
                                     "SET RSENDDATE = @SendDate " +
                                     "WHERE PLANTCODE = @PlantCode " +
                                     "AND ORDERNO = @OrderNo " +
                                     "AND STATUS = 'R'";

                using (SqlCommand updateCommand = new SqlCommand(updateQuery, sCon))
                {
                    updateCommand.Parameters.AddWithValue("@SendDate", DateTime.Now);
                    updateCommand.Parameters.AddWithValue("@PlantCode", plantCode);
                    updateCommand.Parameters.AddWithValue("@OrderNo", prodOrderNo);

                    updateCommand.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("작업 상태 업데이트 중 오류 발생: " + ex.Message);
            }
            finally
            {
                sCon.Close();
            }
            // 여기서 종료
        }

        private void InsertIntoWorkCenterStatusRecS(string plantCode, DateTime prodOrderDate, string prodOrderNo, string lineCode, string itemName)
        {
            try
            {
                sCon.Open();

                string insertQuery = "INSERT INTO TB_WorkCenterStatusRec (PLANTCODE, ORDERNO, LINECODE, STATUS, RSSTARTDATE) " +
                                     "VALUES (@PlantCode, @OrderNo, @LineCode,'S', @StartDate)";

                using (SqlCommand insertCommand = new SqlCommand(insertQuery, sCon))
                {
                    insertCommand.Parameters.AddWithValue("@PlantCode", plantCode);
                    insertCommand.Parameters.AddWithValue("@OrderNo", prodOrderNo);
                    insertCommand.Parameters.AddWithValue("@LineCode", lineCode);
                    insertCommand.Parameters.AddWithValue("@StartDate", DateTime.Now);


                    insertCommand.ExecuteNonQuery();
                }
                MessageBox.Show("설비 이력이 등록되었습니다.");
            }
            catch (Exception ex)
            {
                throw new Exception("작업 상태 인서트 중 오류 발생: " + ex.Message);
            }
            finally
            {
                sCon.Close();
            }
            // 여기서 종료
        }
    }
}
