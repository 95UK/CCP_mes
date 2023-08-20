using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services
{
    public partial class BaseChildForm : Form
    {
        public BaseChildForm()
        {
            InitializeComponent();
        }

        // 상속을 받은 클래스에서 반드시 이 명칭으로 기능을 구현해야 함을 강제하는 기능 
        public virtual void DoInquire()
        {

        }
        // 조회 하는 기능은 이 이름으로 구현 할 것

        // 상속을 받은 클래스에서 구현을 선택 할 수 있게 하는 추상화 기능
        public virtual void DoSave()
        {

        }

        public virtual void DoNew()
        {
            // 툴바의 추가 버튼을 클릭 했을 때 상속받는 클래스가 공통으로 구현해야 하는 메서드
        }

        public virtual void DoDelete()
        {
            // 툴바의 삭제 버튼을 클릭 했을 때 상속받는 클래스가 공통으로 구현해야 하는 메서드

        }
    }
}
