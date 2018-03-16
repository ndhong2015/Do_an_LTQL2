Public Class MH_Nhap_San_pham
    Dim Dinh_dang_VN = System.Globalization.CultureInfo.GetCultureInfo("vi-VN")
    Dim The_hien As New XL_THE_HIEN
        Dim Nghiep_vu As New XL_NGHIEP_VU
        Dim Luu_tru As New XL_LUU_TRU
        Dim Danh_sach_San_pham As List(Of XL_SAN_PHAM)
        Dim San_pham As XL_SAN_PHAM
        Dim Th_San_pham As New FlowLayoutPanel


        Sub Khoi_dong(San_pham_Chon As XL_SAN_PHAM, Danh_sach_San_pham As List(Of XL_SAN_PHAM))
            Me.Danh_sach_San_pham = Danh_sach_San_pham
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
            Th_Tom_tat.Text = San_pham.Ten & vbCrLf & San_pham.Don_gia_Ban.ToString("c0", Dinh_dang_VN)
            Dim Th_So_luong As New TextBox
            Th_Ho_so.Controls.Add(Th_So_luong)
            Dim So_luong As Integer = 1
            Th_So_luong.Text = So_luong
            Dim Th_Dong_y As New Button
            Th_Ho_so.Controls.Add(Th_Dong_y)
            Th_Dong_y.Text = "Đồng ý"

            AddHandler Th_Dong_y.Click,
            Sub()
                Dim Hop_le = Integer.TryParse(Th_So_luong.Text, So_luong) _
                             AndAlso So_luong > 0
                If Hop_le Then
                    Dim Nhap_hang As New XL_NHAP_HANG
                    Nhap_hang.Ngay = DateTime.Today
                    Nhap_hang.So_luong = So_luong
                    Nhap_hang.Don_gia = San_pham.Don_gia_Nhap
                    Nhap_hang.Tien = So_luong * Nhap_hang.Don_gia
                    Dim Kq As String = Luu_tru.Ghi_Nhap_hang_Moi(San_pham, Nhap_hang)
                    If (Kq = "OK") Then
                        MessageBox.Show("Tiền :" + Nhap_hang.Tien.ToString("c0", Dinh_dang_VN))
                        Kich_hoat_MH_Xem_Danh_sach_San_pham(Danh_sach_San_pham)
                    Else
                        MessageBox.Show("Lỗi Hệ thống :")
                    End If

                Else
                    Th_So_luong.Text = 1
                    MessageBox.Show("Số lượng không hợp lệ :")
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
