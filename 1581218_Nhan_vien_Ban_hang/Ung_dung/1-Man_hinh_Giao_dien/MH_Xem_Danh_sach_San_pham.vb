Public Class MH_Xem_Danh_sach_San_pham
    Dim Dinh_dang_VN = System.Globalization.CultureInfo.GetCultureInfo("vi-VN")
    Dim The_hien As New XL_THE_HIEN
    Dim Nghiep_vu As New XL_NGHIEP_VU
    Dim Luu_tru As New XL_LUU_TRU
    Dim Danh_sach_San_pham As List(Of XL_SAN_PHAM)
    Dim Tai_lieu As HtmlDocument
    Private Sub MH_Xem_Danh_sach_San_pham_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler Trinh_duyet.DocumentCompleted,
            Sub()
                Tai_lieu = Trinh_duyet.Document
                If (Tai_lieu IsNot Nothing) Then
                    Xuat_Danh_sach_San_pham()
                End If
            End Sub
        Trinh_duyet.DocumentStream = Nothing
    End Sub
    Sub Khoi_dong(Danh_sach_San_pham_Xem As List(Of XL_SAN_PHAM))
        Danh_sach_San_pham = Danh_sach_San_pham_Xem
    End Sub
    Sub Xuat_Danh_sach_San_pham()
        Danh_sach_San_pham.ForEach(
            Sub(San_pham)
                Dim Ten = San_pham.Ten
                Dim Ma_so = San_pham.Ma_so
                Dim Don_gia_Ban = San_pham.Don_gia_Ban
                Dim So_luong_Ton As Long = Nghiep_vu.Tinh_So_luong_Ton_San_pham(San_pham)
                Dim Doanh_thu As Long = Nghiep_vu.Tinh_Doanh_thu_Ngay_Hien_hanh_San_pham(San_pham)
                Dim Dinh_dang_Trang_thai As String = ""
                Dim Chuoi_64 As String = Luu_tru.Doc_Chuoi_64(San_pham.Ma_so)
                If (So_luong_Ton <= 0) Then
                    Dinh_dang_Trang_thai = ";opacity:0.7"
                End If
                Dim Chuoi_Hinh = $"<img src='data:image;base64,{Chuoi_64}' " +
                                 $"class='float-left' style='width:50%;height:80%;' />"

                Dim Chuoi_Thong_tin As String = $"<div Class='text-left float-left' style='width:65%;height:100%;margin-left:10px;'> " +
                                    $"{ Ten}" +
                                     $"<br />Đơn giá Bán {  Don_gia_Ban.ToString("n0", Dinh_dang_VN) }" +
                                     $"<br /><i><b>Số lượng Tồn {  So_luong_Ton.ToString("n0", Dinh_dang_VN) }<i><b>" +
                                     $"<br />Doanh thu {  Doanh_thu.ToString("n0", Dinh_dang_VN) }" +
                                     $"</div>"
                Dim Chuoi_HTML As String = $"<div class='float-left' style='width:320px;height:150px;margin-bottom:10px;margin-left:10px;{Dinh_dang_Trang_thai}' >" +
                               $"{Chuoi_Hinh}" + $"{Chuoi_Thong_tin}" +
                                         "</div>"
                Dim Th_San_pham = Tai_lieu.CreateElement("div")
                Th_San_pham.InnerHtml = Chuoi_HTML
                Tai_lieu.Body.AppendChild(Th_San_pham)
                AddHandler Th_San_pham.Click,
                       Sub()
                           Kich_hoat_Man_hinh_Xu_ly_tren_San_pham_Chon(San_pham, Danh_sach_San_pham)
                       End Sub
            End Sub)
    End Sub
    Sub Kich_hoat_Man_hinh_Xu_ly_tren_San_pham_Chon(San_pham As XL_SAN_PHAM, Danh_sach_San_pham As List(Of XL_SAN_PHAM))
        Dim Khung_Chuc_nang As Control = Me.Parent
        Khung_Chuc_nang.Controls.Clear()
        Dim Mh = New MH_Ban_San_pham()
        Mh.Khoi_dong(San_pham, Danh_sach_San_pham)
        Mh.Dock = DockStyle.Fill
        Khung_Chuc_nang.Controls.Add(Mh)
    End Sub
End Class
