Public Class MH_Chinh
    Dim The_hien As New XL_THE_HIEN
    Dim Luu_tru As New XL_LUU_TRU
    Dim Nghiep_vu As New XL_NGHIEP_VU
    Dim Du_lieu As XL_DU_LIEU = Luu_tru.Doc_Du_lieu
    Dim Nguoi_dung As XL_QUAN_LY_NHAP_HANG
    Dim Danh_sach_Chuc_nang As New List(Of XL_CHUC_NANG)
    Sub Khoi_dong(Nguoi_dung_Dang_nhap As XL_QUAN_LY_NHAP_HANG)
        Dim Chuc_nang_1 As New XL_CHUC_NANG()
        Chuc_nang_1.Ten = "Xem Thông tin Nhóm Tivi"
        Chuc_nang_1.Ma_so = "XEM_NHOM_TIVI"
        Danh_sach_Chuc_nang.Add(Chuc_nang_1)
        Nguoi_dung = Nguoi_dung_Dang_nhap
        Th_Tieu_de.Text = "Cửa hàng Tivi PET - Quản lý Nhập hàng"
        The_hien.Xuat_Hinh("PET", New Drawing.Size(60, 48), Th_PET)
        The_hien.Xuat_Hinh(Nguoi_dung_Dang_nhap.Ma_so, New Drawing.Size(60, 60), Th_Hinh_Nguoi_dung)
        Th_Loi_chao.Text = "Xin chào " & Nguoi_dung.Ho_ten
        Dim Thuc_don_dong As New ContextMenuStrip
        Danh_sach_Chuc_nang.ForEach(
            Sub(Chuc_nang)
                Dim Th_Chuc_nang As New ToolStripMenuItem
                Thuc_don_dong.Items.Add(Th_Chuc_nang)
                Th_Chuc_nang.Text = Chuc_nang.Ten
                Th_Chuc_nang.Dock = DockStyle.Left
                Th_Chuc_nang.Font = New Font("Arial", 14)
                AddHandler Th_Chuc_nang.Click,
                Sub()
                    If Chuc_nang.Ma_so = "XEM_NHOM_TIVI" Then
                        Kich_hoat_MH_Xem_Danh_sach_Nhom_Tivi()
                    End If
                End Sub
            End Sub)

        Th_Loi_chao.ContextMenuStrip = Thuc_don_dong
        Kich_hoat_MH_Xem_Danh_sach_Tivi(Du_lieu.Danh_sach_Tivi)

        AddHandler Th_Chuoi_Tra_cuu.KeyDown,
           Sub(Th, Bien_co)
               If Bien_co.KeyCode = Keys.Enter Then
                   Dim Chuoi_Tra_cuu As String = Th_Chuoi_Tra_cuu.Text.Trim
                   Dim Danh_sach_Tivi = Nghiep_vu.Tra_cuu_Tivi(Chuoi_Tra_cuu, Du_lieu.Danh_sach_Tivi)
                   Kich_hoat_MH_Xem_Danh_sach_Tivi(Danh_sach_Tivi)
               End If

           End Sub
    End Sub

    Sub Kich_hoat_MH_Xem_Danh_sach_Tivi(Danh_sach_Tivi As List(Of XL_TIVI))
        Khung_Chuc_nang.Controls.Clear()
        Dim Mh = New MH_Xem_Danh_sach_Tivi()
        Mh.Khoi_dong(Danh_sach_Tivi)
        Mh.Dock = DockStyle.Fill
        Khung_Chuc_nang.Controls.Add(Mh)
    End Sub
    Sub Kich_hoat_MH_Xem_Danh_sach_Nhom_Tivi()
        Khung_Chuc_nang.Controls.Clear()
        Dim Mh = New MH_Xem_Danh_sach_Nhom_Tivi()
        Mh.Khoi_dong(Du_lieu)
        Mh.Dock = DockStyle.Fill
        Khung_Chuc_nang.Controls.Add(Mh)
    End Sub



End Class