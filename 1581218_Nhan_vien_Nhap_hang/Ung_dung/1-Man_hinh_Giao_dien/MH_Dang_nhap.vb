Public Class MH_Dang_nhap
    Dim Luu_tru As New XL_LUU_TRU
    Dim Du_lieu As XL_DU_LIEU = Luu_tru.Doc_Du_lieu
    Dim Danh_sach_Nguoi_dung As List(Of XL_NHAN_VIEN_NHAP_HANG) = Du_lieu.Cua_hang.Danh_sach_Nhan_vien_Nhap_hang

    Private Sub Th_Dong_y_Click(sender As Object, e As EventArgs) Handles Th_Dong_y.Click
        Dim Ten_Dang_nhap = Th_Ten_Dang_nhap.Text.Trim
        Dim Mat_khau = Th_Mat_khau.Text.Trim

        Dim Nguoi_dung_Dang_nhap = Danh_sach_Nguoi_dung.FirstOrDefault(
             Function(Nguoi_dung)
                 Return Nguoi_dung.Ten_Dang_nhap = Ten_Dang_nhap AndAlso
                        Nguoi_dung.Mat_khau = Mat_khau
             End Function)
        If Nguoi_dung_Dang_nhap IsNot Nothing Then
            Dim Mh As New MH_Chinh
            Mh.Khoi_dong(Nguoi_dung_Dang_nhap)
            Mh.ShowDialog()
        Else
            Th_Thong_bao.Text = "Đăng nhập không hợp lệ"
        End If
    End Sub
End Class