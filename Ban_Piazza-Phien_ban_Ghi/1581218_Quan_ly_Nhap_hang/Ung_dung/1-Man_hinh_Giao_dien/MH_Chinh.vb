Public Class MH_Chinh
    Dim The_hien As New XL_THE_HIEN
    Dim Luu_tru As New XL_LUU_TRU
    Dim Nghiep_vu As New XL_NGHIEP_VU
    Dim Du_lieu As XL_DU_LIEU = Luu_tru.Doc_Du_lieu
    Dim Nguoi_dung As XL_QUAN_LY_NHAP_HANG

    Sub Khoi_dong(Nguoi_dung_Dang_nhap As XL_QUAN_LY_NHAP_HANG)
        Nguoi_dung = Nguoi_dung_Dang_nhap
        Th_Tieu_de.Text = "Cửa hàng bán Piazza PET - Quản lý Nhập hàng"
        The_hien.Xuat_Hinh("PET", New Drawing.Size(60, 48), Th_PET)
        The_hien.Xuat_Hinh(Nguoi_dung_Dang_nhap.Ma_so, New Drawing.Size(60, 60), Th_Hinh_Nguoi_dung)
        Th_Loi_chao.Text = "Xin chào " & Nguoi_dung.Ho_ten
        Dim Danh_sach_San_pham = New List(Of XL_SAN_PHAM)
        Du_lieu.Danh_sach_San_pham.ForEach(
            Sub(San_pham)
                Dim Duoc_Phan_quyen = Nguoi_dung.Danh_sach_Nhom_San_pham.Any(Function(Nhom_San_pham) Nhom_San_pham.Ma_so = San_pham.Nhom_San_pham.Ma_so)
                If Duoc_Phan_quyen Then
                    Danh_sach_San_pham.Add(San_pham)
                End If
            End Sub)
        Dim Danh_sach_San_pham_Xem = Danh_sach_San_pham
        Kich_hoat_MH_Xem_Danh_sach_San_pham(Danh_sach_San_pham_Xem, Nguoi_dung)

        AddHandler Th_Chuoi_Tra_cuu.KeyDown,
           Sub(Th, Bien_co)
               If Bien_co.KeyCode = Keys.Enter Then
                   Dim Chuoi_Tra_cuu As String = Th_Chuoi_Tra_cuu.Text.Trim
                   Du_lieu = Luu_tru.Doc_Du_lieu
                   Dim Danh_sach_San_pham_lam_moi = New List(Of XL_SAN_PHAM)
                   Du_lieu.Danh_sach_San_pham.ForEach(
                    Sub(San_pham)
                        Dim Duoc_Phan_quyen = Nguoi_dung.Danh_sach_Nhom_San_pham.Any(Function(Nhom_San_pham) Nhom_San_pham.Ma_so = San_pham.Nhom_San_pham.Ma_so)
                        If Duoc_Phan_quyen Then
                            Danh_sach_San_pham_lam_moi.Add(San_pham)
                        End If
                    End Sub)
                   Danh_sach_San_pham_Xem = Nghiep_vu.Tra_cuu_San_pham(Chuoi_Tra_cuu, Danh_sach_San_pham_lam_moi)
                   Kich_hoat_MH_Xem_Danh_sach_San_pham(Danh_sach_San_pham_Xem, Nguoi_dung)
               End If
           End Sub
    End Sub

    Sub Kich_hoat_MH_Xem_Danh_sach_San_pham(Danh_sach_San_pham As List(Of XL_SAN_PHAM), Nguoi_dung As XL_QUAN_LY_NHAP_HANG)
        Khung_Chuc_nang.Controls.Clear()
        Dim Mh = New MH_Xem_Danh_sach_San_pham()
        Mh.Khoi_dong(Danh_sach_San_pham, Nguoi_dung)
        Mh.Dock = DockStyle.Fill
        Khung_Chuc_nang.Controls.Add(Mh)
    End Sub

End Class