﻿Public Class MH_Xem_Danh_sach_Tivi
    Dim Dinh_dang_VN = System.Globalization.CultureInfo.GetCultureInfo("vi-VN")
    Dim The_hien As New XL_THE_HIEN
    Dim Nghiep_vu As New XL_NGHIEP_VU
    Dim Luu_tru As New XL_LUU_TRU
    Dim Du_lieu As XL_DU_LIEU = Luu_tru.Doc_Du_lieu
    Dim Danh_sach_Tivi As List(Of XL_TIVI)
    Sub Khoi_dong(Danh_sach_Tivi_Xem As List(Of XL_TIVI))
        Danh_sach_Tivi = Danh_sach_Tivi_Xem
        Xuat_Danh_sach_Tivi()
    End Sub
    Sub Xuat_Danh_sach_Tivi()
        Dim Tong_Doanh_thu = Danh_sach_Tivi.Sum(Function(Tivi) Nghiep_vu.Tinh_Doanh_thu_Ngay_Hien_hanh_Tivi(Tivi))
        Dim Th_Thong_bao = New ToolStripMenuItem
        Th_Thong_bao.Text = "Tổng Doanh thu ngày: " & Tong_Doanh_thu.ToString("c0", Dinh_dang_VN)
        Th_Thong_bao.Font = New Font("Arial", 18)
        Th_Thong_bao.ForeColor = Color.Blue
        Th_Thong_bao.AutoSize = False
        Th_Thong_bao.Size = New Size(1000, 30)
        Th_Danh_sach_Tivi.Items.Add(Th_Thong_bao)
        Danh_sach_Tivi.ForEach(
            Sub(Tivi)
                Dim Th_Tivi As New ToolStripMenuItem
                Th_Danh_sach_Tivi.Items.Add(Th_Tivi)
                Th_Tivi.Font = New Font("Arial", 14)
                Th_Tivi.TextAlign = ContentAlignment.TopLeft
                The_hien.Xuat_Hinh(Tivi.Ma_so, Th_Tivi)
                Dim So_luong_Ton As Long = Nghiep_vu.Tinh_So_luong_Ton_Tivi(Tivi)
                Dim Doanh_thu As Long = Nghiep_vu.Tinh_Doanh_thu_Ngay_Hien_hanh_Tivi(Tivi)
                Th_Tivi.Text = Tivi.Ten &
                                  vbCrLf & "Đơn giá Bán " & Tivi.Don_gia_Ban.ToString("c0", Dinh_dang_VN) &
                                  vbCrLf & "Số lượng Tồn " & So_luong_Ton.ToString("n0", Dinh_dang_VN) &
                                   vbCrLf & "Doanh thu " & Doanh_thu.ToString("n0", Dinh_dang_VN)

                AddHandler Th_Tivi.Click,
                       Sub()
                           Kich_hoat_Man_hinh_Xu_ly_tren_Tivi_Chon(Tivi)
                       End Sub

            End Sub)
    End Sub
    Sub Kich_hoat_Man_hinh_Xu_ly_tren_Tivi_Chon(Tivi As XL_TIVI)
        Dim Khung_Chuc_nang As Control = Me.Parent
        Khung_Chuc_nang.Controls.Clear()
        Dim Mh = New MH_Ban_Tivi()
        Mh.Khoi_dong(Tivi)
        Mh.Dock = DockStyle.Fill
        Khung_Chuc_nang.Controls.Add(Mh)
    End Sub
End Class
