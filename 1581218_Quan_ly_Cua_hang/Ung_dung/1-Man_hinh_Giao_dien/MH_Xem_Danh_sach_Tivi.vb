﻿Public Class MH_Xem_Danh_sach_Tivi
    Dim Dinh_dang_VN = System.Globalization.CultureInfo.GetCultureInfo("vi-VN")
    Dim Luu_tru As New XL_LUU_TRU
    Dim Du_lieu As XL_DU_LIEU = Luu_tru.Doc_Du_lieu
    Dim The_hien As New XL_THE_HIEN
    Dim Nghiep_vu As New XL_NGHIEP_VU
    Dim Danh_sach_Tivi As List(Of XL_TIVI)
    Sub Khoi_dong(Danh_sach_Tivi_Xem As List(Of XL_TIVI))
        Danh_sach_Tivi = Danh_sach_Tivi_Xem
        Xuat_Danh_sach_Tivi()
    End Sub
    Sub Xuat_Danh_sach_Tivi()

        Danh_sach_Tivi.ForEach(
            Sub(Tivi)
                Dim Th_Tivi As New ToolStripMenuItem
                Th_Danh_sach_Tivi.Items.Add(Th_Tivi)
                Th_Tivi.Font = New Font("Arial", 14)
                Th_Tivi.TextAlign = ContentAlignment.TopLeft
                The_hien.Xuat_Hinh(Tivi.Ma_so, Th_Tivi)
                Dim Doanh_thu_ngay As Long = Nghiep_vu.Tinh_Doanh_thu_Ngay_Hien_hanh_Tivi(Tivi)
                Dim So_luong_ton As Integer = Nghiep_vu.Tinh_So_luong_Ton_Tivi(Tivi)
                Th_Tivi.Text = Tivi.Ten &
                                  vbCrLf & "Số lượng tồn: " & So_luong_ton.ToString("n0", Dinh_dang_VN) &
                                  vbCrLf & "Doanh thu ngày: " & Doanh_thu_ngay.ToString("n0", Dinh_dang_VN)
            End Sub)
    End Sub
End Class