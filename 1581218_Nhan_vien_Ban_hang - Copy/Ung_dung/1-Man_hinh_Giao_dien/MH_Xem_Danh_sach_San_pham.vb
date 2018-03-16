Public Class MH_Xem_Danh_sach_San_pham
    Dim Dinh_dang_VN = System.Globalization.CultureInfo.GetCultureInfo("vi-VN")
    Dim The_hien As New XL_THE_HIEN
    Dim Nghiep_vu As New XL_NGHIEP_VU
    Dim Luu_tru As New XL_LUU_TRU
    Dim Du_lieu As XL_DU_LIEU = Luu_tru.Doc_Du_lieu
    Dim Danh_sach_San_pham As List(Of XL_SAN_PHAM)
    Sub Khoi_dong(Danh_sach_San_pham_Xem As List(Of XL_SAN_PHAM))
        Danh_sach_San_pham = Danh_sach_San_pham_Xem
        Xuat_Danh_sach_San_pham()
    End Sub
    Sub Xuat_Danh_sach_San_pham()
        Dim Tong_Doanh_thu = Danh_sach_San_pham.Sum(Function(San_pham) Nghiep_vu.Tinh_Doanh_thu_Ngay_Hien_hanh_San_pham(San_pham))
        Dim Th_Thong_bao = New ToolStripMenuItem
        Th_Thong_bao.Text = "Tổng Doanh thu ngày: " & Tong_Doanh_thu.ToString("c0", Dinh_dang_VN)
        Th_Thong_bao.Font = New Font("Arial", 18)
        Th_Thong_bao.ForeColor = Color.Blue
        Th_Thong_bao.AutoSize = False
        Th_Thong_bao.Size = New Size(1000, 30)
        Th_Danh_sach_San_pham.Items.Add(Th_Thong_bao)
        Danh_sach_San_pham.ForEach(
            Sub(San_pham)
                Dim Th_San_pham As New ToolStripMenuItem
                Th_Danh_sach_San_pham.Items.Add(Th_San_pham)
                Th_San_pham.Font = New Font("Arial", 14)
                Th_San_pham.TextAlign = ContentAlignment.TopLeft
                The_hien.Xuat_Hinh(San_pham.Ma_so, Th_San_pham)
                Dim Doanh_thu As Long = Nghiep_vu.Tinh_Doanh_thu_Ngay_Hien_hanh_San_pham(San_pham)
                Th_San_pham.Text = San_pham.Ten &
                                  vbCrLf & "Đơn giá Bán " & San_pham.Don_gia_Ban.ToString("c0", Dinh_dang_VN) &
                                   vbCrLf & "Doanh thu " & Doanh_thu.ToString("n0", Dinh_dang_VN)

                AddHandler Th_San_pham.Click,
                       Sub()
                           Kich_hoat_Man_hinh_Xu_ly_tren_San_pham_Chon(San_pham)
                       End Sub

            End Sub)
    End Sub
    Sub Kich_hoat_Man_hinh_Xu_ly_tren_San_pham_Chon(San_pham As XL_SAN_PHAM)
        Dim Khung_Chuc_nang As Control = Me.Parent
        Khung_Chuc_nang.Controls.Clear()
        Dim Mh = New MH_Ban_San_pham()
        Mh.Khoi_dong(San_pham)
        Mh.Dock = DockStyle.Fill
        Khung_Chuc_nang.Controls.Add(Mh)
    End Sub
End Class
