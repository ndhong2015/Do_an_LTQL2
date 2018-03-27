Public Class MH_Thay_doi_gia_ban
    Dim Dinh_dang_VN = System.Globalization.CultureInfo.GetCultureInfo("vi-VN")
    Dim The_hien As New XL_THE_HIEN
    Dim Nghiep_vu As New XL_NGHIEP_VU
    Dim Luu_tru As New XL_LUU_TRU
    Dim Du_lieu As XL_DU_LIEU = Luu_tru.Doc_Du_lieu
    Dim Danh_sach_San_pham As List(Of XL_SAN_PHAM)
    Dim San_pham As XL_SAN_PHAM
    Dim Th_San_pham As New FlowLayoutPanel
    Dim Nguoi_dung As XL_QUAN_LY_BAN_HANG

    Sub Khoi_dong(San_pham_Chon As XL_SAN_PHAM, Nguoi_dung As XL_QUAN_LY_BAN_HANG)
        Me.Danh_sach_San_pham = Du_lieu.Danh_sach_San_pham
        Me.Nguoi_dung = Nguoi_dung
        San_pham = Danh_sach_San_pham.FirstOrDefault(Function(San_pham) San_pham.Ma_so = San_pham_Chon.Ma_so)
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
        Th_Ho_so.Size = New Size(120, 120)

        Dim Th_Tom_tat As New Label
        Th_Ho_so.Controls.Add(Th_Tom_tat)
        Th_Tom_tat.Size = New Size(220, 40)
        Th_Tom_tat.Text = San_pham.Ten

        Dim Th_Don_gia As New Label
        Th_Ho_so.Controls.Add(Th_Don_gia)
        Th_Don_gia.Text = "Đơn giá:"

        Dim Th_Don_gia_Ban As New TextBox
        Th_Ho_so.Controls.Add(Th_Don_gia_Ban)
        Dim Don_gia As Long = San_pham.Don_gia_Ban
        Th_Don_gia_Ban.Text = Don_gia

        Dim Th_Dong_y As New Button
        Th_Ho_so.Controls.Add(Th_Dong_y)
        Th_Dong_y.Text = "Đồng ý"

        AddHandler Th_Dong_y.Click,
    Sub()
        Dim Hop_le = Integer.TryParse(Th_Don_gia_Ban.Text, Don_gia) _
                     AndAlso Don_gia > 0
        If Hop_le Then
            San_pham.Don_gia_Ban = Th_Don_gia_Ban.Text
            Dim Kq As String = Luu_tru.Cap_nhat_gia_Ban(San_pham)
            If (Kq = "OK") Then
                MessageBox.Show("Đã cập nhật giá bán sản phẩm")
                Kich_hoat_MH_Xem_Danh_sach_San_pham(Du_lieu.Danh_sach_San_pham, Nguoi_dung)
            Else
                MessageBox.Show("Lỗi Hệ thống :")
            End If

        Else
            Th_Don_gia_Ban.Text = San_pham.Don_gia_Ban
            MessageBox.Show("Đơn giá không hợp lệ :")
        End If
    End Sub
    End Sub

    Sub Kich_hoat_MH_Xem_Danh_sach_San_pham(Danh_sach_San_pham As List(Of XL_SAN_PHAM), Nguoi_dung As XL_QUAN_LY_BAN_HANG)
        Dim Khung_Chuc_nang As Control = Me.Parent
        Khung_Chuc_nang.Controls.Clear()
        Dim Mh = New MH_Xem_Danh_sach_San_pham()
        Mh.Khoi_dong(Danh_sach_San_pham, Nguoi_dung)
        Mh.Dock = DockStyle.Fill
        Khung_Chuc_nang.Controls.Add(Mh)
    End Sub

End Class

