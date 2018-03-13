Public Class MH_Xem_Doanh_thu_ngay_cua_Nhan_vien
    Dim Dinh_dang_VN = System.Globalization.CultureInfo.GetCultureInfo("vi-VN")
    Dim The_hien As New XL_THE_HIEN
    Dim Nghiep_vu As New XL_NGHIEP_VU
    Dim Luu_tru As New XL_LUU_TRU
    Dim Du_lieu As XL_DU_LIEU = Luu_tru.Doc_Du_lieu
    Dim Danh_sach_Nhan_vien As List(Of XL_NHAN_VIEN_BAN_HANG)
    Sub Khoi_dong(Du_lieu As XL_DU_LIEU)
        Me.Du_lieu = Du_lieu
        Danh_sach_Nhan_vien = Du_lieu.Cua_hang.Danh_sach_Nhan_vien_Ban_hang
        Xuat_Danh_sach_Nhan_vien()
    End Sub
    Sub Xuat_Danh_sach_Nhan_vien()

        Danh_sach_Nhan_vien.ForEach(
            Sub(Nhan_vien)
                Dim Th_Nhan_vien As New ToolStripMenuItem
                Th_Danh_sach_Nhan_vien.Items.Add(Th_Nhan_vien)
                Th_Nhan_vien.Font = New Font("Arial", 14)
                Th_Nhan_vien.TextAlign = ContentAlignment.TopLeft
                The_hien.Xuat_Hinh(Nhan_vien.Ma_so, Th_Nhan_vien)
                Dim Doanh_thu_ngay As Long = Nghiep_vu.Tinh_Doanh_thu_ngay_Nhan_vien(Nhan_vien, Nghiep_vu.Danh_sach_Tivi_theo_nhan_vien(Nhan_vien, Du_lieu.Danh_sach_Tivi))
                Th_Nhan_vien.Text = Nhan_vien.Ho_ten &
                           vbCrLf & "Doanh thu ngày: " & Doanh_thu_ngay.ToString("c0", Dinh_dang_VN)


            End Sub)
        Dim Th_Tong_doanh_thu_ngay As New ToolStripMenuItem
        Th_Tong_doanh_thu_ngay.Font = New Font("Arial", 14)
        Th_Tong_doanh_thu_ngay.BackColor = Color.SkyBlue
        Th_Tong_doanh_thu_ngay.Text = "Tổng doanh thu ngày: " + Nghiep_vu.Tong_Doanh_thu_Ngay(Du_lieu.Danh_sach_Tivi).ToString("c0", Dinh_dang_VN)
        Th_Danh_sach_Nhan_vien.Items.Add(Th_Tong_doanh_thu_ngay)

        Dim Th_Tong_so_luong_ton As New ToolStripMenuItem
        Th_Tong_so_luong_ton.Font = New Font("Arial", 14)
        Th_Tong_so_luong_ton.BackColor = Color.SpringGreen
        Th_Tong_so_luong_ton.Text = "Tổng số lượng tồn: " + Nghiep_vu.Tong_so_luong_Ton(Du_lieu.Danh_sach_Tivi).ToString("n0", Dinh_dang_VN)
        Th_Danh_sach_Nhan_vien.Items.Add(Th_Tong_so_luong_ton)
    End Sub
End Class
