﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ketoansoft.app.Class.Data;
using DevExpress.XtraEditors;
using ketoansoft.app.Components.clsVproUtility;
using System.Collections;
using ketoansoft.app.Class.Global;
using ketoansoft.app.Diaglog;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace ketoansoft.app
{
    public partial class SoCongNoTheoKheUocVay : DevComponents.DotNetBar.Metro.MetroForm
    {
        dbVstoreAppDataContext _db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
        private KTCNKURepo _KTCNKURepo = new KTCNKURepo();
        public Unit _unit = new Unit();
        private List<int> _listUpdate = new List<int>();

        public SoCongNoTheoKheUocVay()
        {
            InitializeComponent();
        }

        #region Data
        private void Load_Data()
        {
            try
            {
                _KTCNKURepo = new KTCNKURepo();
                gridData.DataSource = _KTCNKURepo.GetAll();
                //_db = new dbVstoreAppDataContext(Const.builder.ConnectionString);
                //gridData.DataSource = null;
                //gridData.DataSource = _db.KT_DMHHs;
                //gridData.RefreshDataSource();
                //gridView1.RefreshData();
            }
            catch (Exception) { }
        }
        private void Save_Data(bool msg)
        {
            try
            {
                _KTCNKURepo = new KTCNKURepo();
                int i = 0;
                foreach (int pos in _listUpdate)
                {
                    int id = Utils.CIntDef(gridView1.GetRowCellValue(pos, "ID"), 0);
                    KT_CNKU obj = _KTCNKURepo.GetById(id);
                    if (obj != null)
                    {
                        obj.SO_HD = Utils.CStrDef(gridView1.GetRowCellValue(pos, "SO_HD"), "");
                        obj.SO_KU = Utils.CStrDef(gridView1.GetRowCellValue(pos, "SO_KU"), "");
                        obj.MA_TK = Utils.CStrDef(gridView1.GetRowCellValue(pos, "MA_TK"), "");
                        obj.MA_DTPN = Utils.CStrDef(gridView1.GetRowCellValue(pos, "MA_DTPN"), "");
                        obj.TEN_DTPN = Utils.CStrDef(gridView1.GetRowCellValue(pos, "TEN_DTPN"), "");
                        obj.NOI_DUNG = Utils.CStrDef(gridView1.GetRowCellValue(pos, "NOI_DUNG"), "");
                        DateTime? temp = null;
                        if (Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_KU"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_KU"), DateTime.MinValue);
                        obj.NGAY_KU = temp;
                        temp = null;
                        if (Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_HD"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_HD"), DateTime.MinValue);
                        obj.NGAY_HD = temp;
                        temp = null;
                        if (Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_DH"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_DH"), DateTime.MinValue);
                        obj.NGAY_DH = temp;
                        obj.LAI_SUAT_VAY = Utils.CDblDef(gridView1.GetRowCellValue(pos, "LAI_SUAT_VAY"), 0);
                        obj.DUNO_VND = Utils.CIntDef(gridView1.GetRowCellValue(pos, "DUNO_VND"), 0);
                        obj.DUCO_VND = Utils.CIntDef(gridView1.GetRowCellValue(pos, "DUCO_VND"), 0);
                        obj.PSNO_VND = Utils.CIntDef(gridView1.GetRowCellValue(pos, "PSNO_VND"), 0);
                        obj.PSCO_VND = Utils.CIntDef(gridView1.GetRowCellValue(pos, "PSCO_VND"), 0);
                        obj.CKNO_VND = Utils.CIntDef(gridView1.GetRowCellValue(pos, "CKNO_VND"), 0);
                        obj.CKCO_VND = Utils.CIntDef(gridView1.GetRowCellValue(pos, "CKCO_VND"), 0);
                        obj.TY_GIA_NO = Utils.CDblDef(gridView1.GetRowCellValue(pos, "TY_GIA_NO"), 0);
                        obj.TY_GIA_CO = Utils.CDblDef(gridView1.GetRowCellValue(pos, "TY_GIA_CO"), 0);
                        obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(pos, "DANH_DAU"), "");
                        obj.TRANG_THAI = Utils.CIntDef(gridView1.GetRowCellValue(pos, "TRANG_THAI"), 0);
                        obj.GT_HD_VND = Utils.CIntDef(gridView1.GetRowCellValue(pos, "GT_HD_VND"), 0);
                        obj.GT_HD_USD = Utils.CIntDef(gridView1.GetRowCellValue(pos, "GT_HD_USD"), 0);
                        obj.LTH_DK = Utils.CIntDef(gridView1.GetRowCellValue(pos, "LTH_DK"), 0);
                        obj.LTH_TK = Utils.CIntDef(gridView1.GetRowCellValue(pos, "LTH_TK"), 0);
                        obj.LTH_CK = Utils.CIntDef(gridView1.GetRowCellValue(pos, "LTH_CK"), 0);
                        obj.LQH_DK = Utils.CIntDef(gridView1.GetRowCellValue(pos, "LQH_DK"), 0);
                        obj.LQH_TK = Utils.CIntDef(gridView1.GetRowCellValue(pos, "LQH_TK"), 0);
                        obj.LQH_CK = Utils.CIntDef(gridView1.GetRowCellValue(pos, "LQH_CK"), 0);
                        obj.TONG_LAI = Utils.CIntDef(gridView1.GetRowCellValue(pos, "TONG_LAI"), 0);
                        temp = null;
                        if (Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_TONG"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_TONG"), DateTime.MinValue);
                        obj.NGAY_TONG = temp;
                        temp = null;
                        if (Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_TH"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_TH"), DateTime.MinValue);
                        obj.NGAY_TH = temp;
                        temp = null;
                        if (Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_QH"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(gridView1.GetRowCellValue(pos, "NGAY_QH"), DateTime.MinValue);
                        obj.NGAY_QH = temp;

                        _KTCNKURepo.Update(obj);
                        i++;
                    }
                }
                _listUpdate = new List<int>();
                //if (i > 0 && msg)
                //{
                //    MessageBox.Show("Lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Save_Tick()
        {
            try
            {
                _KTCNKURepo = new KTCNKURepo();
                int id = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID").ToString(), 0);
                KT_CNKU obj = _KTCNKURepo.GetById(id);
                if (obj != null)
                {
                    obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DANH_DAU"), "").Trim() == "T" ? "" : "T";
                    _KTCNKURepo.Update(obj);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Save_Duplicate()
        {
            try
            {                
                if (MessageBox.Show("Bạn có muốn copy dòng này thành dòng mới?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _KTCNKURepo = new KTCNKURepo();
                    KT_CNKU obj = new KT_CNKU();

                    obj.SO_HD = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SO_HD"), "");
                    obj.SO_KU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "SO_KU"), "");
                    obj.MA_TK = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_TK"), "");
                    obj.MA_DTPN = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MA_DTPN"), "");
                    obj.TEN_DTPN = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TEN_DTPN"), "");
                    obj.NOI_DUNG = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NOI_DUNG"), "");
                    DateTime? temp = null;
                    if (Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_KU"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_KU"), DateTime.MinValue);
                    obj.NGAY_KU = temp;
                    temp = null;
                    if (Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_HD"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_HD"), DateTime.MinValue);
                    obj.NGAY_HD = temp;
                    temp = null;
                    if (Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_DH"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_DH"), DateTime.MinValue);
                    obj.NGAY_DH = temp;
                    obj.LAI_SUAT_VAY = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LAI_SUAT_VAY"), 0);
                    obj.DUNO_VND = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DUNO_VND"), 0);
                    obj.DUCO_VND = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DUCO_VND"), 0);
                    obj.PSNO_VND = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSNO_VND"), 0);
                    obj.PSCO_VND = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "PSCO_VND"), 0);
                    obj.CKNO_VND = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CKNO_VND"), 0);
                    obj.CKCO_VND = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "CKCO_VND"), 0);
                    obj.TY_GIA_NO = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TY_GIA_NO"), 0);
                    obj.TY_GIA_CO = Utils.CDblDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TY_GIA_CO"), 0);
                    obj.DANH_DAU = Utils.CStrDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "DANH_DAU"), "");
                    obj.TRANG_THAI = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TRANG_THAI"), 0);
                    obj.GT_HD_VND = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GT_HD_VND"), 0);
                    obj.GT_HD_USD = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GT_HD_USD"), 0);
                    obj.LTH_DK = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LTH_DK"), 0);
                    obj.LTH_TK = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LTH_TK"), 0);
                    obj.LTH_CK = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LTH_CK"), 0);
                    obj.LQH_DK = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LQH_DK"), 0);
                    obj.LQH_TK = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LQH_TK"), 0);
                    obj.LQH_CK = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "LQH_CK"), 0);
                    obj.TONG_LAI = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TONG_LAI"), 0);
                    temp = null;
                    if (Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_TONG"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_TONG"), DateTime.MinValue);
                    obj.NGAY_TONG = temp;
                    temp = null;
                    if (Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_TH"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_TH"), DateTime.MinValue);
                    obj.NGAY_TH = temp;
                    temp = null;
                    if (Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_QH"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "NGAY_QH"), DateTime.MinValue);
                    obj.NGAY_QH = temp;

                    _KTCNKURepo.Create(obj);
                    MessageBox.Show("Đã copy dòng này vào cuối bảng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Remove_Data()
        {
            try
            {
                //if (_listUpdate.Count > 0)
                //{
                //    MessageBox.Show("Hãy thực hiện lưu trước khi xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                Save_Data(false);

                int id = Utils.CIntDef(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ID"), 0);
                _KTCNKURepo = new KTCNKURepo();
                _KTCNKURepo.Remove(id);

                //MessageBox.Show("Xóa dòng ID:" + Id + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Load_Data();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Grid Event
        private void gridData_Load(object sender, EventArgs e)
        {
            Unit.UnitGridview(gridView1);
            Load_Data();

            Load_InfoHeader();
        }
        private void gridView1_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            // Sự kiện này để người ta không chuyển qua dòng khác được khi có lỗi xảy ra nè
            // Nó nhận giá trị e.Valid của gridView1_ValidateRow để ứng xử
            // neu e,Valid =True thì nó cho chuyển qua dòng khác hoặc làm tác vụ khác
            // và ngược lại
             e.ExceptionMode = DevExpress.XtraEditors.Controls.ExceptionMode.NoAction;
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                bool b = _listUpdate.Exists(a => a == gridView1.FocusedRowHandle);
                if (!b)
                {
                    _listUpdate.Add(gridView1.FocusedRowHandle);
                }
            }));
        }
        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            _unit.Get_ColorTick(gridView1, sender, e);
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            Load_InfoRows();
        }
        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;

                //validation
                GridColumn ma_tkCol = view.Columns["MA_TK"];
                GridColumn ma_dtpnCol = view.Columns["MA_DTPN"];
                GridColumn so_kuCol = view.Columns["SO_KU"];
                GridColumn so_hdCol = view.Columns["SO_HD"];
                string ma_tk = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, ma_tkCol), "");
                string ma_dtpn = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, ma_dtpnCol), "");
                string so_ku = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, so_kuCol), "");
                string so_hd = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, so_hdCol), "");
                if (ma_tk.Trim().Length == 0 || ma_dtpn.Trim().Length == 0 || so_hd.Trim().Length == 0 || so_ku.Trim().Length == 0)
                {
                    e.Valid = false;
                    if (ma_tk.Trim().Length == 0)
                        view.SetColumnError(ma_tkCol, "Mã TK không được rổng");
                    if (ma_dtpn.Trim().Length == 0)
                        view.SetColumnError(ma_dtpnCol, "Mã đối tượng pháp nhân không được rổng");
                    if (so_ku.Trim().Length == 0)
                        view.SetColumnError(so_kuCol, "Số khế ước không được rổng");
                    if (so_hd.Trim().Length == 0)
                        view.SetColumnError(so_hdCol, "Số hợp đồng không được rổng");

                    return;
                }

                _KTCNKURepo = new KTCNKURepo();
                //Kiểm tra đây là dòng dữ liệu mới hay cũ, nếu là mới thì mình insert
                if (view.IsNewItemRow(e.RowHandle))
                {
                    //e.RowHandle trả về giá trị int là thứ tự của dòng hiện tại
                    KT_CNKU obj = new KT_CNKU();

                    obj.SO_HD = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SO_HD"), "");
                    obj.SO_KU = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SO_KU"), "");
                    obj.MA_TK = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_TK"), "");
                    obj.MA_DTPN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_DTPN"), "");
                    obj.TEN_DTPN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_DTPN"), "");
                    obj.NOI_DUNG = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "NOI_DUNG"), "");
                    DateTime? temp = null;
                    if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_KU"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_KU"), DateTime.MinValue);
                    obj.NGAY_KU = temp;
                    temp = null;
                    if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_HD"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_HD"), DateTime.MinValue);
                    obj.NGAY_HD = temp;
                    temp = null;
                    if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_DH"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_DH"), DateTime.MinValue);
                    obj.NGAY_DH = temp;
                    obj.LAI_SUAT_VAY = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "LAI_SUAT_VAY"), 0);
                    obj.DUNO_VND = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "DUNO_VND"), 0);
                    obj.DUCO_VND = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "DUCO_VND"), 0);
                    obj.PSNO_VND = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "PSNO_VND"), 0);
                    obj.PSCO_VND = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "PSCO_VND"), 0);
                    obj.CKNO_VND = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "CKNO_VND"), 0);
                    obj.CKCO_VND = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "CKCO_VND"), 0);
                    obj.TY_GIA_NO = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "TY_GIA_NO"), 0);
                    obj.TY_GIA_CO = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "TY_GIA_CO"), 0);
                    obj.DANH_DAU = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DANH_DAU"), "");
                    obj.TRANG_THAI = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "TRANG_THAI"), 0);
                    obj.GT_HD_VND = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "GT_HD_VND"), 0);
                    obj.GT_HD_USD = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "GT_HD_USD"), 0);
                    obj.LTH_DK = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "LTH_DK"), 0);
                    obj.LTH_TK = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "LTH_TK"), 0);
                    obj.LTH_CK = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "LTH_CK"), 0);
                    obj.LQH_DK = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "LQH_DK"), 0);
                    obj.LQH_TK = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "LQH_TK"), 0);
                    obj.LQH_CK = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "LQH_CK"), 0);
                    obj.TONG_LAI = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "TONG_LAI"), 0);
                    temp = null;
                    if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_TONG"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_TONG"), DateTime.MinValue);
                    obj.NGAY_TONG = temp;
                    temp = null;
                    if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_TH"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_TH"), DateTime.MinValue);
                    obj.NGAY_TH = temp;
                    temp = null;
                    if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_QH"), DateTime.MinValue) != DateTime.MinValue)
                        temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_QH"), DateTime.MinValue);
                    obj.NGAY_QH = temp;

                    _KTCNKURepo.Create(obj);

                }
                //Cũ thì update
                else
                {
                    int id = Utils.CIntDef(view.GetRowCellValue(gridView1.FocusedRowHandle, "ID"), 0);
                    KT_CNKU obj = _KTCNKURepo.GetById(id);
                    if (obj != null)
                    {
                        obj.SO_HD = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SO_HD"), "");
                        obj.SO_KU = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "SO_KU"), "");
                        obj.MA_TK = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_TK"), "");
                        obj.MA_DTPN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "MA_DTPN"), "");
                        obj.TEN_DTPN = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "TEN_DTPN"), "");
                        obj.NOI_DUNG = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "NOI_DUNG"), "");
                        DateTime? temp = null;
                        if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_KU"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_KU"), DateTime.MinValue);
                        obj.NGAY_KU = temp;
                        temp = null;
                        if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_HD"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_HD"), DateTime.MinValue);
                        obj.NGAY_HD = temp;
                        temp = null;
                        if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_DH"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_DH"), DateTime.MinValue);
                        obj.NGAY_DH = temp;
                        obj.LAI_SUAT_VAY = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "LAI_SUAT_VAY"), 0);
                        obj.DUNO_VND = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "DUNO_VND"), 0);
                        obj.DUCO_VND = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "DUCO_VND"), 0);
                        obj.PSNO_VND = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "PSNO_VND"), 0);
                        obj.PSCO_VND = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "PSCO_VND"), 0);
                        obj.CKNO_VND = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "CKNO_VND"), 0);
                        obj.CKCO_VND = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "CKCO_VND"), 0);
                        obj.TY_GIA_NO = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "TY_GIA_NO"), 0);
                        obj.TY_GIA_CO = Utils.CDblDef(view.GetRowCellValue(e.RowHandle, "TY_GIA_CO"), 0);
                        obj.DANH_DAU = Utils.CStrDef(view.GetRowCellValue(e.RowHandle, "DANH_DAU"), "");
                        obj.TRANG_THAI = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "TRANG_THAI"), 0);
                        obj.GT_HD_VND = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "GT_HD_VND"), 0);
                        obj.GT_HD_USD = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "GT_HD_USD"), 0);
                        obj.LTH_DK = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "LTH_DK"), 0);
                        obj.LTH_TK = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "LTH_TK"), 0);
                        obj.LTH_CK = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "LTH_CK"), 0);
                        obj.LQH_DK = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "LQH_DK"), 0);
                        obj.LQH_TK = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "LQH_TK"), 0);
                        obj.LQH_CK = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "LQH_CK"), 0);
                        obj.TONG_LAI = Utils.CIntDef(view.GetRowCellValue(e.RowHandle, "TONG_LAI"), 0);
                        temp = null;
                        if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_TONG"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_TONG"), DateTime.MinValue);
                        obj.NGAY_TONG = temp;
                        temp = null;
                        if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_TH"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_TH"), DateTime.MinValue);
                        obj.NGAY_TH = temp;
                        temp = null;
                        if (Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_QH"), DateTime.MinValue) != DateTime.MinValue)
                            temp = Utils.CDateDef(view.GetRowCellValue(e.RowHandle, "NGAY_QH"), DateTime.MinValue);
                        obj.NGAY_QH = temp;

                        _KTCNKURepo.Update(obj);
                    }

                }
                Load_Data();
            }
            catch (Exception ex)
            {
                e.Valid = false;
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Button Click
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save_Data(true);
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Bạn có muốn thoát không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            //{
            //    Save_Data(false);
            //    this.Close();
            //}
            this.Close();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            gridView1.ShowFindPanel();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Hỏi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                Remove_Data();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            _unit.Get_AllowEdit(gridView1);
        }
        private void btnToCol_Click(object sender, EventArgs e)
        {
            FocusCol();
        }
        private void btnTick_Click(object sender, EventArgs e)
        {
            Save_Tick();
        }
        private void btnDuplicate_Click(object sender, EventArgs e)
        {
            Save_Duplicate();
            Load_Data();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Load_Data();
        }
        #endregion

        #region Funtion
        private void FocusCol()
        {
            dlogToCol dialog = new dlogToCol(gridView1);
            dialog.ShowDialog();
            string _value = dialog.Result;
            gridView1.FocusedColumn = gridView1.Columns[_value];
        }
        private void Load_InfoHeader()
        {
            txtMonth.Text = Utils.CStrDef(fTerm._month,"");
            txtYear.Text = Utils.CStrDef(fTerm._year, "");
            txtDatabase.Text = Unit.Get_DatabaseName();
            txtCompanyName.Text = Unit.Get_CompanyName();
            txtNumRows.Text = Utils.CStrDef(gridView1.RowCount, "0") + " of " + Utils.CStrDef(gridView1.RowCount, "0");
        }
        private void Load_InfoRows()
        {
            //string[] _arr = {"SO_KU","SO_HD","MA_TK", "MA_DTPN"};
            txtInfoRows.Text = Unit.Get_InfoRows(gridView1, null);
        }
        #endregion

        #region shortcutKey
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            KeyEventArgs e = new KeyEventArgs(keyData);
            if (e.KeyCode == Keys.F1)
            {
                btnSearch_Click(null, null);
            }
            else if (e.KeyCode == Keys.F2)
            {
                Save_Tick();
            }
            else if (e.KeyCode == Keys.F3)
            {
                Save_Duplicate();
                Load_Data();
            }
            else if (e.KeyCode == Keys.F5)
            {
                Load_Data();
            }
            else if (e.KeyCode == Keys.F6)
            {
                FocusCol();
            }
            else if (e.KeyCode == Keys.S && e.Control)
            {
                Save_Data(true); return true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                btnDelete_Click(null, null);
            }
            else if (e.KeyCode == Keys.Q && e.Control)
            {
                btnExit_Click(null, null); return true;
            }
            else if (e.KeyCode == Keys.F10)
            {
                _unit.Get_AllowEdit(gridView1);
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion        

    }
}