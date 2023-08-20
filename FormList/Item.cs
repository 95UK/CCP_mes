using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FormList
{
    public partial class Item : Services.BaseChildForm
    {
        DataTable dtTemp = new DataTable();
        DataTable dtChange = new DataTable();
        SqlConnection sCon = new SqlConnection(Commons.Sconnection);

        public Item()
        {
            InitializeComponent();
        }

        #region < Form Load >
        private void ItemMaster_Load(object sender, EventArgs e)
        {

            // 그리드

            dtTemp.Columns.Add("PLANTCODE", typeof(string));
            dtTemp.Columns.Add("ITEMCODE", typeof(string));
            dtTemp.Columns.Add("ITEMNAME", typeof(string));
            dtTemp.Columns.Add("ITEMTYPE", typeof(string));
            dtTemp.Columns.Add("UNITCOST", typeof(string));
            dtTemp.Columns.Add("USEFLAG", typeof(string));
            dtTemp.Columns.Add("MAKER", typeof(string));
            dtTemp.Columns.Add("MAKEDATE", typeof(DateTime));
            dtTemp.Columns.Add("EDITOR", typeof(string));
            dtTemp.Columns.Add("EDITDATE", typeof(DateTime));


            Grid.DataSource = dtTemp;

            Grid.Columns["PLANTCODE"].HeaderText = "공장";
            Grid.Columns["ITEMCODE"].HeaderText  = "품목코드";
            Grid.Columns["ITEMNAME"].HeaderText  = "품목명";
            Grid.Columns["ITEMTYPE"].HeaderText  = "품목구분";
            Grid.Columns["UNITCOST"].HeaderText  = "단가";
            Grid.Columns["USEFLAG"].HeaderText   = "사용여부";
            Grid.Columns["MAKER"].HeaderText     = "등록자";
            Grid.Columns["MAKEDATE"].HeaderText  = "등록일시";
            Grid.Columns["EDITOR"].HeaderText    = "수정자";
            Grid.Columns["EDITDATE"].HeaderText  = "수정일시";


            Grid.Columns[0].Width = 100;
            Grid.Columns[1].Width = 200;
            Grid.Columns[2].Width = 200;
            Grid.Columns[3].Width = 100;
            Grid.Columns[4].Width = 100;
            Grid.Columns[5].Width = 100;
            Grid.Columns[6].Width = 100;
            Grid.Columns[8].Width = 200;
            Grid.Columns[9].Width = 200;

            // 컬럼의 정렬 지정 
            Grid.Columns["USEFLAG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Grid.Columns["UNITCOST"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            //컬럼의 수정 여부를 지정
            Grid.Columns["ITEMCODE"].ReadOnly = true;
            Grid.Columns["MAKER"].ReadOnly    = true;
            Grid.Columns["MAKEDATE"].ReadOnly = true;
            Grid.Columns["EDITDATE"].ReadOnly = true;
            Grid.Columns["EDITOR"].ReadOnly   = true;


            
            #endregion

            // 데이터베이스 접속
            SqlConnection sCon = new SqlConnection(Commons.Sconnection);
            try
            {

                #region < 품목 타입 콤보 박스 셋팅 >
                string sSelectSql2 = "SELECT DISTINCT ITEMTYPE AS ITEM_TYPE FROM TB_ItemMaster";
                SqlDataAdapter adapter2 = new SqlDataAdapter(sSelectSql2, sCon);
                DataTable dt2 = new DataTable();
                adapter2.Fill(dt2);

                // Add "ALL" option to the DataTable
                DataRow allRow2 = dt2.NewRow();
                allRow2["ITEM_TYPE"] = "ALL";
                dt2.Rows.InsertAt(allRow2, 0);

                cboItemType.DataSource = dt2;
                cboItemType.ValueMember = "ITEM_TYPE";
                cboItemType.DisplayMember = "ITEM_TYPE";
                #endregion

                #region < 사용 여부 콤보 박스 셋팅 >
                string sSelectSql3 = "SELECT DISTINCT USEFLAG FROM TB_ItemMaster";
                SqlDataAdapter adapter3 = new SqlDataAdapter(sSelectSql3, sCon);
                DataTable dt3 = new DataTable();
                adapter3.Fill(dt3);

                // Add "ALL" option to the DataTable
                DataRow allRow3 = dt3.NewRow();
                allRow3["USEFLAG"] = "ALL";
                dt3.Rows.InsertAt(allRow3, 0);

                cboUseFlag.DataSource = dt3;
                cboUseFlag.ValueMember = "USEFLAG";
                cboUseFlag.DisplayMember = "USEFLAG";
                #endregion

                #region < 공장코드 콤보 박스 셋팅 >
                string sSelectSql4 = "SELECT DISTINCT PLANTCODE FROM TB_ItemMaster";
                SqlDataAdapter adapter4 = new SqlDataAdapter(sSelectSql4, sCon);
                DataTable dt4 = new DataTable();
                adapter4.Fill(dt4);

                // Add "ALL" option to the DataTable
                DataRow allRow4 = dt4.NewRow();
                allRow4["PLANTCODE"] = "ALL";
                dt4.Rows.InsertAt(allRow4, 0);

                cboPlantCode.DataSource = dt4;
                cboPlantCode.ValueMember = "PLANTCODE";
                cboPlantCode.DisplayMember = "PLANTCODE";
                #endregion
            }

            #region < 수정 전 콤보 박스 셋팅 >
            //string sSelectSql3 = " SELECT DISTINCT USEFLAG    " +
            //                     "   FROM TB_ItemMaster       ";


            //// 데이터베이스를 조회하는 클래스
            //SqlDataAdapter adapter3 = new SqlDataAdapter(sSelectSql3, sCon);
            //DataTable dt3 = new DataTable();
            //adapter3.Fill(dt3);

            //// 콤보박스에 셋팅되어야 하는 데이터를 매핑
            //cboUseFlag.DataSource = dt3;


            //// 응용프로그램에서 사용할 코드와 사용자가 눈으로 확인할 Text 속성을 분류
            //cboUseFlag.ValueMember   = "USEFLAG";
            //cboUseFlag.DisplayMember = "USEFLAG";
            //#endregion

            //#region < 공장코드 콤보 박스 셋팅 >
            //string sSelectSql4 = " SELECT DISTINCT PLANTCODE  " +
            //                     "   FROM TB_ItemMaster       ";


            //// 데이터베이스를 조회하는 클래스
            //SqlDataAdapter adapter4 = new SqlDataAdapter(sSelectSql4, sCon);
            //DataTable dt4 = new DataTable();
            //adapter4.Fill(dt4);

            //// 콤보박스에 셋팅되어야 하는 데이터를 매핑
            //cboPlantCode.DataSource = dt4;



            //// 응용프로그램에서 사용할 코드와 사용자가 눈으로 확인할 Text 속성을 분류
            //cboPlantCode.ValueMember   = "PLANTCODE";
            //cboPlantCode.DisplayMember = "PLANTCODE";
            //}
            #endregion

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sCon.Close();
            }
        }
        #region ▶ <TOOL BAR FUCTION> ◀
        public override void DoInquire()
        
        {
            try
            {
                sCon.Open();

                string sPlantCode = cboPlantCode.SelectedValue as string;
                string sItemType = cboItemType.SelectedValue as string;
                string sItemCode = txtItemCode.Text;
                string sUseFlag = cboUseFlag.SelectedValue as string;

                dtTemp.Clear();

                string sSqlSelect = "SELECT * FROM TB_ItemMaster WHERE 1=1";

                // Handle the "ALL" option selections
                if (sPlantCode != "ALL")
                    sSqlSelect += $" AND PLANTCODE = '{sPlantCode}'";

                if (sItemType != "ALL")
                    sSqlSelect += $" AND ITEMTYPE = '{sItemType}'";

                if (!string.IsNullOrEmpty(sItemCode))
                    sSqlSelect += $" AND ITEMCODE LIKE '%{sItemCode}%'";

                if (sUseFlag != "ALL")
                    sSqlSelect += $" AND USEFLAG = '{sUseFlag}'";

                SqlDataAdapter adapter = new SqlDataAdapter(sSqlSelect, sCon);
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
                sCon.Close();
            }
        }
        public override void DoNew()
        {
            DataRow newRow = dtTemp.NewRow();

            // Set the initial values for the new row's columns
            newRow["PLANTCODE"] = "1000"; // Set PLANTCODE to "1000"
            newRow["USEFLAG"] = "Y";      // Set USEFLAG to "Y"
            newRow["ITEMTYPE"] = cboItemType.SelectedValue;

            // Add the new row to the DataTable
            dtTemp.Rows.Add(newRow);

        }

        public override void DoDelete()
        {
            // 그리드에 데이터 행을 삭제 처리 (데이터베이스에서 처리 전) 
            if (Grid.Rows.Count == 0) return;       // 그리드에 삭제할 내역이 존재하지 않을 경우 return;
            if (Grid.CurrentRow == null)
            {
                MessageBox.Show("삭제할 대상을 선택하세요.");
                return; // 삭제할 대상 행을 선택하지 않았을때 return;
            }

            // 삭제 할 품목 데이터의 품목코드 정보
            string sItemCode = Grid.CurrentRow.Cells["ITEMCODE"].Value.ToString();

            // 데이터 테이블에서 해당 품목 코드를 가지고 있는 행을 삭제
            // i : 데이터 테이블 행의 Index
            for (int i = 0; i < dtTemp.Rows.Count; i++)
            {
                // 데이터 테이블에서 삭제할 대상 품목 코드를 찾았다면
                if (dtTemp.Rows[i].RowState != DataRowState.Deleted && dtTemp.Rows[i]["ITEMCODE"].ToString() == sItemCode)
                {
                    // 해당 데이터 테이블의 행을 삭제
                    dtTemp.Rows[i].Delete();
                    break;
                }
            }
        }

        public override void DoSave()
        {
            // 일괄 저장

            

            // 품목의 정보가 갱신된 데이터를 추출
            dtChange = dtTemp.GetChanges();

            // 수정한 행이 없을 경우
            
            if (dtChange.Rows.Count == 0) return;

            if (MessageBox.Show("변경된 내역을 등록하시겠습니까?", "데이터 저장", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            // 1. 데이터베이스 오픈
            sCon.Open();

            // 데이터베이스에 접속하여 SQL 구문 실행
            // 2. SQL Command 객체 생성 (U/D/I)
            SqlCommand cmd = new SqlCommand();

            // 3. 데이터베이스에 접속 정보 전달
            cmd.Connection = sCon;

            // 4. 트랜잭션 설정 (일괄 승인, 일괄 복원)
            cmd.Transaction = sCon.BeginTransaction();
            // 트랜잭션 (Transaction)
            //  -데이터 갱신 내역을 승인 또는 복구 가능
            //  -데이터의 일관성 (하나의 데이터라도 오류가 발생할 경우 전체 데이터를 복원하여 일부 데이터만 격차가 발생되는 현상을 막기 위함)


            // DataRow : 데이터테이블의 행을 단위별로 담는 클래스

            string sPlantCode = string.Empty;
            string sItemCode  = string.Empty;
            string sItemName  = string.Empty;
            string sItemType  = string.Empty;
            string sUnitCost  = string.Empty;
            string sUseFlag   = string.Empty;

            try
            {
                string Sql = string.Empty;
                string sMessage = string.Empty; //필수 입력값 누락 여부
                foreach (DataRow dr in dtChange.Rows)
                {
                    // 변경된 행을 하나씩 추출하여 행의 상태에 따라서 데이터베이스에 처리
                    switch (dr.RowState)
                    {
                        case DataRowState.Deleted:
                            dr.RejectChanges();
                            Sql = $" DELETE TB_ItemMaster WHERE ITEMCODE = '{dr["ITEMCODE"]}'";
                            break;
                        case DataRowState.Added:
                            sPlantCode = dr["PLANTCODE"].ToString();
                            sItemCode  = dr["ITEMCODE"].ToString();
                            sItemName  = dr["ITEMNAME"].ToString();
                            sItemType  = dr["ITEMTYPE"].ToString();
                            sUnitCost  = dr["UNITCOST"].ToString() ;
                            sUseFlag   = dr["USEFLAG"].ToString();
                            // 삼항 연산자 true false 에 따른 비교 분기.
                            // 사용 여부에 값이 없을 경우 Y 아닐 경우는 N (무조건 N, 또는 Y 만 입력 가능 하도록)
                            sUseFlag  = dr["USEFLAG"].ToString() == "" ? "Y" : "N";

                            // 품목 코드, 출시 일자 정보 누락 시 체크 밸리데이션;
                            if (sItemCode == "") sMessage += "품목 코드";
                            if (sMessage != "")
                            {
                                MessageBox.Show($"{sMessage} 를 입력하지 않았습니다.");
                                cmd.Transaction.Rollback();
                                return;
                            }

                            // 데이터가 없는경우 INSERT
                            Sql = "INSERT INTO TB_ItemMaster(PLANTCODE,      ITEMCODE,     ITEMNAME,     ITEMTYPE,     UNITCOST,     USEFLAG,    MAKEDATE,     MAKER) " +
                                 $"                 VALUES('{sPlantCode}','{sItemCode}','{sItemName}', '{sItemType}','{sUnitCost}','{sUseFlag}', GETDATE(),   'ADMIN');";


                            break;
                        case DataRowState.Modified:
                            sPlantCode = dr["PLANTCODE"].ToString();
                            sItemCode  = dr["ITEMCODE"].ToString();
                            sItemName  = dr["ITEMNAME"].ToString();
                            sItemType  = dr["ITEMTYPE"].ToString();
                            sUnitCost  = dr["UNITCOST"].ToString();
                            sUseFlag   = dr["USEFLAG"].ToString();
                            //삼항 연산자 true false 에 따른 비교 분기.
                            // 사용 여부에 값이 없을 경우 Y 아닐 경우는 N (무조건 N, 또는 Y 만 입력 가능 하도록)
                            sUseFlag = dr["USEFLAG"].ToString() == "" ? "Y" : "N";

                            // 품목 코드, 출시 일자 정보 누락 시 체크 밸리데이션;

                            if (sItemCode == "") sMessage += "품목 코드";
                            if (sMessage != "")
                            {
                                MessageBox.Show($"{sMessage} 를 입력하지 않았습니다.");
                                cmd.Transaction.Rollback();
                                return;
                            }


                            Sql = "UPDATE TB_ItemMaster                          " +
                                      $"    SET PLANTCODE = '{sPlantCode}',      " +
                                      $"        ITEMNAME  = '{sItemName}',       " +
                                      $"        ITEMTYPE  = '{sItemType}',       " +
                                      $"        UNITCOST  = '{sUnitCost}',       " +
                                      $"        USEFLAG   = '{sUseFlag}',        " +
                                      $"        EDITOR    =   'ADMIN',           " +
                                      $"        EDITDATE  =   GETDATE()          " +
                                      $"  WHERE ITEMCODE  = '{sItemCode}'        ";

                            break;
                    }
                    cmd.CommandText = Sql;   //커맨드에 실행할 SQL 명령 등록
                    cmd.ExecuteNonQuery();  //커맨드를 실행

                }

                //정상 등록 완료
                cmd.Transaction.Commit();
                MessageBox.Show("정상 처리 되었습니다.");
            }
            catch (Exception ex)
            {
                cmd.Transaction.Rollback();     //예외상황 발생 시 복구, 반드시 메세지 출력 이전에!!
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sCon.Close();
            }
        }


        #endregion
    }
}

