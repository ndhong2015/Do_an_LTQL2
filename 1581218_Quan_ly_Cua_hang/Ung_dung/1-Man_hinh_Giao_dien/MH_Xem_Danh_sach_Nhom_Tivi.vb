Public Class MH_Xem_Danh_sach_Nhom_Tivi
    Dim Dinh_dang_VN = System.Globalization.CultureInfo.GetCultureInfo("vi-VN")
    Dim The_hien As New XL_THE_HIEN
    Dim Nghiep_vu As New XL_NGHIEP_VU
    Dim Luu_tru As New XL_LUU_TRU
    Dim Du_lieu As XL_DU_LIEU = Luu_tru.Doc_Du_lieu
    Dim Danh_sach_Nhom_Tivi As List(Of XL_NHOM_TIVI)
    Sub Khoi_dong(Du_lieu As XL_DU_LIEU)
        Me.Du_lieu = Du_lieu
        Danh_sach_Nhom_Tivi = Du_lieu.Cua_hang.Danh_sach_Nhom_Tivi
        Xuat_Danh_sach_Nhom_Tivi()
    End Sub
    Sub Xuat_Danh_sach_Nhom_Tivi()

        Danh_sach_Nhom_Tivi.ForEach(
            Sub(Nhom_Tivi)
                Dim Th_Nhom_Tivi As New ToolStripMenuItem
                Th_Danh_sach_Nhom_Tivi.Items.Add(Th_Nhom_Tivi)
                Th_Nhom_Tivi.Font = New Font("Arial", 18)
                Th_Nhom_Tivi.TextAlign = ContentAlignment.TopLeft
                The_hien.Xuat_Hinh(Nhom_Tivi.Ma_so, Th_Nhom_Tivi)
                Dim So_luong_Ton As Long = Nghiep_vu.Tinh_So_luong_Ton_Nhom_Tivi(Nhom_Tivi, Du_lieu)
                Th_Nhom_Tivi.Text = Nhom_Tivi.Ten &
                           vbCrLf & "Số lượng Tồn " & So_luong_Ton.ToString("n0", Dinh_dang_VN)
            End Sub)
    End Sub
End Class
