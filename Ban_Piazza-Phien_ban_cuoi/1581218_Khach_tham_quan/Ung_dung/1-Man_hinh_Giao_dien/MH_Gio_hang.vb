Public Class MH_Gio_hang
    Dim Dinh_dang_VN = System.Globalization.CultureInfo.GetCultureInfo("vi-VN")
    Dim The_hien As New XL_THE_HIEN
    Dim Nghiep_vu As New XL_NGHIEP_VU
    Dim Luu_tru As New XL_LUU_TRU
    Dim Du_lieu As XL_DU_LIEU = Luu_tru.Doc_Du_lieu
    Dim Nguoi_dung As XL_NHAN_VIEN_BAN_HANG
    Dim San_pham As XL_SAN_PHAM
    Dim Danh_sach_San_pham_chon As List(Of XL_SAN_PHAM)
    Dim Th_Thong_tin_Khach_hang As New FlowLayoutPanel
    Sub Khoi_dong(Danh_sach_San_pham_chon As List(Of XL_SAN_PHAM))
        Me.Danh_sach_San_pham_chon = Danh_sach_San_pham_chon
        Me.Controls.Add(Th_Thong_tin_Khach_hang)
        Th_Thong_tin_Khach_hang.Dock = DockStyle.Fill
        Th_Thong_tin_Khach_hang.BorderStyle = BorderStyle.FixedSingle
        Xuat_Thong_tin_Khach_hang(Danh_sach_San_pham_chon)
    End Sub
    Sub Xuat_Thong_tin_Khach_hang(Danh_sach_San_pham_chon As List(Of XL_SAN_PHAM))
        Dim Th_Hinh = The_hien.Tao_The_hien_Hinh("KHACH_HANG", New Size(120, 80))
        Th_Thong_tin_Khach_hang.Controls.Add(Th_Hinh)
        Dim Th_Ho_so As New FlowLayoutPanel
        Th_Thong_tin_Khach_hang.Controls.Add(Th_Ho_so)
        Th_Ho_so.Size = New Size(200, 500)

        Dim Th_Tom_tat As New Label
        Th_Ho_so.Controls.Add(Th_Tom_tat)
        Th_Tom_tat.Size = New Size(220, 40)
        Th_Tom_tat.Text = "THÔNG TIN KHÁCH HÀNG"

        Dim Th_Ho_ten As New Label
        Th_Ho_so.Controls.Add(Th_Ho_ten)
        Th_Ho_ten.Text = "Họ tên:"
        Dim Th_Nhap_Ho_ten As New TextBox
        Th_Ho_so.Controls.Add(Th_Nhap_Ho_ten)
        Th_Nhap_Ho_ten.Text = ""

        Dim Th_Dien_thoai As New Label
        Th_Ho_so.Controls.Add(Th_Dien_thoai)
        Th_Dien_thoai.Text = "Điện thoại:"
        Dim Th_Nhap_Dien_thoai As New TextBox
        Th_Ho_so.Controls.Add(Th_Nhap_Dien_thoai)
        Th_Nhap_Dien_thoai.Text = ""

        Dim Th_Dia_chi As New Label
        Th_Ho_so.Controls.Add(Th_Dia_chi)
        Th_Dia_chi.Text = "Địa chỉ:"
        Dim Th_Nhap_Dia_chi As New TextBox
        Th_Ho_so.Controls.Add(Th_Nhap_Dia_chi)
        Th_Nhap_Dia_chi.Text = ""

        Dim Th_Mail As New Label
        Th_Ho_so.Controls.Add(Th_Mail)
        Th_Mail.Text = "Mail:"
        Dim Th_Nhap_Mail As New TextBox
        Th_Ho_so.Controls.Add(Th_Nhap_Mail)
        Th_Nhap_Mail.Text = ""

        Dim Th_Dong_y As New Button
        Th_Ho_so.Controls.Add(Th_Dong_y)
        Th_Dong_y.Text = "Đồng ý"

        AddHandler Th_Dong_y.Click,
            Sub()
                Dim Hop_le = Th_Nhap_Ho_ten.Text <> "" AndAlso Th_Nhap_Dien_thoai.Text <> "" AndAlso Th_Nhap_Dia_chi.Text <> "" AndAlso Th_Nhap_Mail.Text <> ""
                If Hop_le Then
                    Dim Phieu_dat As New XL_DAT_HANG()
                    Phieu_dat.Ma_so = "P_" + (Du_lieu.Danh_sach_Phieu_dat.Count() + 1).ToString()
                    Dim Khach_hang As New XL_KHACH_HANG()
                    Khach_hang.Dia_chi = Th_Nhap_Dia_chi.Text
                    Khach_hang.Ho_ten = Th_Nhap_Ho_ten.Text
                    Khach_hang.Mail = Th_Nhap_Mail.Text
                    Khach_hang.Dien_thoai = Th_Nhap_Dien_thoai.Text
                    Phieu_dat.Khach_hang = Khach_hang
                    Phieu_dat.Ngay_dat = DateTime.Today
                    Phieu_dat.Ngay_giao = DateTime.Today
                    Phieu_dat.Trang_thai = "DAT_HANG"
                    Dim Danh_sach_San_pham_Dat_hang As New List(Of XL_SAN_PHAM_DAT_HANG)
                    Danh_sach_San_pham_chon.ForEach(
                    Sub(San_pham)
                        Dim San_pham_Dat_hang As New XL_SAN_PHAM_DAT_HANG()
                        San_pham_Dat_hang.Ma_so = San_pham.Ma_so
                        San_pham_Dat_hang.Don_gia = San_pham.Don_gia_Ban
                        San_pham_Dat_hang.So_luong = San_pham.So_luong
                        San_pham_Dat_hang.Ten = San_pham.Ten
                        San_pham_Dat_hang.Tien = San_pham.So_luong * San_pham.Don_gia_Ban
                        Danh_sach_San_pham_Dat_hang.Add(San_pham_Dat_hang)
                    End Sub
                    )
                    Phieu_dat.Danh_sach_San_pham = Danh_sach_San_pham_Dat_hang
                    Dim Kq As String = Luu_tru.Ghi_Phieu_Dat_Moi(Phieu_dat, Du_lieu.Danh_sach_Phieu_dat)
                    If (Kq = "OK") Then
                        MessageBox.Show("Đã ghi nhận phiếu đặt!")
                        Du_lieu = Luu_tru.Doc_Du_lieu
                        Kich_hoat_MH_Xem_Danh_sach_San_pham(Du_lieu.Danh_sach_San_pham)
                    Else
                        MessageBox.Show("Lỗi Hệ thống :")
                    End If

                Else
                    MessageBox.Show("Bạn cần điền đầy đủ thông tin đặt hàng")
                End If
            End Sub
    End Sub

    Sub Kich_hoat_MH_Xem_Danh_sach_San_pham(Danh_sach_San_pham As List(Of XL_SAN_PHAM))
        Dim Khung_Chuc_nang As Control = Me.Parent
        Khung_Chuc_nang.Controls.Clear()
        Dim Mh = New MH_Xem_Danh_sach_San_pham()
        Mh.Khoi_dong(Danh_sach_San_pham)
        Mh.Dock = DockStyle.Fill
        Khung_Chuc_nang.Controls.Add(Mh)
    End Sub
End Class
