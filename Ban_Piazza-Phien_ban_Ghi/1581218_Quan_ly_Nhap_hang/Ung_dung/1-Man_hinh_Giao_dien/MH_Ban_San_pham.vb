Public Class MH_Ban_San_pham
    Dim Dinh_dang_VN = System.Globalization.CultureInfo.GetCultureInfo("vi-VN")
    Dim The_hien As New XL_THE_HIEN
    Dim Nghiep_vu As New XL_NGHIEP_VU
    Dim Luu_tru As New XL_LUU_TRU
    Dim Du_lieu As XL_DU_LIEU = Luu_tru.Doc_Du_lieu
    Dim Nguoi_dung As XL_QUAN_LY_NHAP_HANG
    Dim San_pham As XL_SAN_PHAM
    Dim Th_San_pham As New FlowLayoutPanel
    Sub Khoi_dong(San_pham_Chon As XL_SAN_PHAM, Nguoi_dung As XL_QUAN_LY_NHAP_HANG)
        Me.Nguoi_dung = Nguoi_dung
        San_pham = Du_lieu.Danh_sach_San_pham.FirstOrDefault(Function(San_pham) San_pham.Ma_so = San_pham_Chon.Ma_so)
        Me.Controls.Add(Th_San_pham)
        Th_San_pham.Dock = DockStyle.Fill
        Th_San_pham.BorderStyle = BorderStyle.FixedSingle
        Xuat_San_pham()
    End Sub
    Sub Xuat_San_pham()
        Dim Th_Hinh = The_hien.Tao_The_hien_Hinh(San_pham.Ma_so, New Size(120, 80))
        Th_San_pham.Controls.Add(Th_Hinh)
        Dim Th_Ho_so As New FlowLayoutPanel
        Th_San_pham.Controls.Add(Th_Ho_so)
        Th_Ho_so.Size = New Size(200, 500)

        Dim Th_Tom_tat As New Label
        Th_Ho_so.Controls.Add(Th_Tom_tat)
        Th_Tom_tat.Size = New Size(220, 40)
        Th_Tom_tat.Text = "PHIẾU BÁN" & vbCrLf & San_pham.Ten & vbCrLf & San_pham.Don_gia_Ban.ToString("c0", Dinh_dang_VN)

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

        Dim Th_So_luong As New Label
        Th_So_luong.Text = "Số lượng:"
        Th_Ho_so.Controls.Add(Th_So_luong)
        Dim Th_Nhap_So_luong As New TextBox
        Th_Ho_so.Controls.Add(Th_Nhap_So_luong)
        Dim So_luong As Integer = 1
        Th_Nhap_So_luong.Text = So_luong

        Dim Th_Dong_y As New Button
        Th_Ho_so.Controls.Add(Th_Dong_y)
        Th_Dong_y.Text = "Đồng ý"

        AddHandler Th_Dong_y.Click,
            Sub()
                Dim Hop_le = Integer.TryParse(Th_Nhap_So_luong.Text, So_luong) _
                             AndAlso So_luong > 0
                If Hop_le Then
                    Dim Ban_hang As New XL_BAN_HANG
                    Ban_hang.Dia_chi = Th_Nhap_Dia_chi.Text
                    Ban_hang.Ho_ten_Khach_hang = Th_Nhap_Ho_ten.Text
                    Ban_hang.Mail = Th_Nhap_Mail.Text
                    Ban_hang.Dien_thoai = Th_Nhap_Dien_thoai.Text
                    Ban_hang.Ho_ten_Nhan_vien = Nguoi_dung.Ho_ten
                    Ban_hang.Ngay = DateTime.Today
                    Ban_hang.So_luong = So_luong
                    Ban_hang.Don_gia = San_pham.Don_gia_Ban
                    Ban_hang.Tien = So_luong * Ban_hang.Don_gia
                    Dim Kq As String = Luu_tru.Ghi_Ban_hang_Moi(San_pham, Ban_hang)
                    If (Kq = "OK") Then
                        MessageBox.Show("Tiền :" + Ban_hang.Tien.ToString("c0", Dinh_dang_VN))
                        Dim Danh_sach_San_pham = New List(Of XL_SAN_PHAM)
                        Du_lieu.Danh_sach_San_pham.ForEach(
                        Sub(San_pham)
                            Dim Duoc_Phan_quyen = Nguoi_dung.Danh_sach_Nhom_San_pham.Any(Function(Nhom_San_pham) Nhom_San_pham.Ma_so = San_pham.Nhom_San_pham.Ma_so)
                            If Duoc_Phan_quyen Then
                                Danh_sach_San_pham.Add(San_pham)
                            End If
                        End Sub)
                        Kich_hoat_MH_Xem_Danh_sach_San_pham(Danh_sach_San_pham, Nguoi_dung)
                    Else
                        MessageBox.Show("Lỗi Hệ thống :")
                    End If

                Else
                    Th_So_luong.Text = 1
                    MessageBox.Show("Số lượng không hợp lệ :")
                End If
            End Sub
    End Sub

    Sub Kich_hoat_MH_Xem_Danh_sach_San_pham(Danh_sach_San_pham As List(Of XL_SAN_PHAM), Nguoi_dung As XL_QUAN_LY_NHAP_HANG)
        Dim Khung_Chuc_nang As Control = Me.Parent
        Khung_Chuc_nang.Controls.Clear()
        Dim Mh = New MH_Xem_Danh_sach_San_pham()
        Mh.Khoi_dong(Danh_sach_San_pham, Nguoi_dung)
        Mh.Dock = DockStyle.Fill
        Khung_Chuc_nang.Controls.Add(Mh)
    End Sub
End Class
