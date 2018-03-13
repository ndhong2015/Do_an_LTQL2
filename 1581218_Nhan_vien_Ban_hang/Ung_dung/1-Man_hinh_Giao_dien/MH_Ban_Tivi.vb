Public Class MH_Ban_Tivi
    Dim Dinh_dang_VN = System.Globalization.CultureInfo.GetCultureInfo("vi-VN")
    Dim The_hien As New XL_THE_HIEN
    Dim Nghiep_vu As New XL_NGHIEP_VU
    Dim Luu_tru As New XL_LUU_TRU
    Dim Du_lieu As XL_DU_LIEU = Luu_tru.Doc_Du_lieu
    Dim Tivi As XL_TIVI
    Dim Th_Tivi As New FlowLayoutPanel


    Sub Khoi_dong(Tivi_Chon As XL_TIVI)
        Tivi = Du_lieu.Danh_sach_Tivi.FirstOrDefault(Function(Tivi) Tivi.Ma_so = Tivi_Chon.Ma_so)
        Me.Controls.Add(Th_Tivi)
        Th_Tivi.Dock = DockStyle.Fill
        Th_Tivi.BorderStyle = BorderStyle.FixedSingle
        Xuat_Tivi()
    End Sub
    Sub Xuat_Tivi()
        Dim So_luong_Ton = Nghiep_vu.Tinh_So_luong_Ton_Tivi(Tivi)
        Dim Th_Hinh = The_hien.Tao_The_hien_Hinh(Tivi.Ma_so, New Size(120, 80))
        Th_Tivi.Controls.Add(Th_Hinh)
        Dim Th_Ho_so As New FlowLayoutPanel
        Th_Tivi.Controls.Add(Th_Ho_so)
        Th_Ho_so.Size = New Size(120, 120)

        Dim Th_Tom_tat As New Label
        Th_Ho_so.Controls.Add(Th_Tom_tat)
        Th_Tom_tat.Size = New Size(220, 40)
        Th_Tom_tat.Text = Tivi.Ten & vbCrLf & Tivi.Don_gia_Ban.ToString("c0", Dinh_dang_VN) &
                         vbCrLf & "Tồn " & So_luong_Ton.ToString("n0", Dinh_dang_VN)
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
                             AndAlso So_luong > 0 AndAlso So_luong <= So_luong_Ton
                If Hop_le Then
                    Dim Ban_hang As New XL_BAN_HANG
                    Ban_hang.Ngay = DateTime.Today
                    Ban_hang.So_luong = So_luong
                    Ban_hang.Don_gia = Tivi.Don_gia_Ban
                    Ban_hang.Tien = So_luong * Ban_hang.Don_gia
                    Dim Kq As String = Luu_tru.Ghi_Ban_hang_Moi(Tivi, Ban_hang)
                    If (Kq = "OK") Then
                        MessageBox.Show("Tiền :" + Ban_hang.Tien.ToString("c0", Dinh_dang_VN))
                        Du_lieu = Luu_tru.Doc_Du_lieu
                        Kich_hoat_MH_Xem_Danh_sach_Tivi(Du_lieu.Danh_sach_Tivi)
                    Else
                        MessageBox.Show("Lỗi Hệ thống :")
                    End If

                Else
                    Th_So_luong.Text = 1
                    MessageBox.Show("Số lượng không hợp lệ :")
                End If
            End Sub
    End Sub

    Sub Kich_hoat_MH_Xem_Danh_sach_Tivi(Danh_sach_Tivi As List(Of XL_TIVI))
        Dim Khung_Chuc_nang As Control = Me.Parent
        Khung_Chuc_nang.Controls.Clear()
        Dim Mh = New MH_Xem_Danh_sach_Tivi()
        Mh.Khoi_dong(Danh_sach_Tivi)
        Mh.Dock = DockStyle.Fill
        Khung_Chuc_nang.Controls.Add(Mh)
    End Sub
End Class
