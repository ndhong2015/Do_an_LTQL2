Public Class MH_Xem_Danh_sach_San_pham
    Dim Dinh_dang_VN = System.Globalization.CultureInfo.GetCultureInfo("vi-VN")
    Dim The_hien As New XL_THE_HIEN
    Dim Nghiep_vu As New XL_NGHIEP_VU
    Dim Luu_tru As New XL_LUU_TRU
    Dim Du_lieu As XL_DU_LIEU = Luu_tru.Doc_Du_lieu
    Dim Danh_sach_San_pham As List(Of XL_SAN_PHAM)
    Dim Danh_sach_San_pham_chon As New List(Of XL_SAN_PHAM)
    Dim Tai_lieu As HtmlDocument
    Private Sub MH_Xem_Danh_sach_San_pham_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler Trinh_duyet.DocumentCompleted,
            Sub()
                Tai_lieu = Trinh_duyet.Document
                If (Tai_lieu IsNot Nothing) Then
                    Xuat_Danh_sach_San_pham_chon()
                    Xuat_Danh_sach_San_pham()
                End If
            End Sub
        Trinh_duyet.DocumentStream = Nothing
    End Sub
    Sub Khoi_dong(Danh_sach_San_pham_Xem As List(Of XL_SAN_PHAM))
        Danh_sach_San_pham = Danh_sach_San_pham_Xem
    End Sub
    Sub Xuat_Danh_sach_San_pham()
        Dim Chuoi_tieu_de As String = "<h1 style='color:red' >DANH SÁCH SẢN PHẨM</h1>"
        Dim Th_Danh_sach_San_pham = Tai_lieu.CreateElement("div")
        Th_Danh_sach_San_pham.InnerHtml = Chuoi_tieu_de
        Tai_lieu.Body.AppendChild(Th_Danh_sach_San_pham)
        Danh_sach_San_pham.ForEach(
            Sub(San_pham)
                Dim Ten = San_pham.Ten
                Dim Ma_so = San_pham.Ma_so
                Dim Don_gia_Ban = San_pham.Don_gia_Ban
                Dim So_luong_Ton As Long = Nghiep_vu.Tinh_So_luong_Ton_San_pham(San_pham)
                Dim Dinh_dang_Trang_thai As String = ""
                Dim Chuoi_64 As String = Luu_tru.Doc_Chuoi_64(San_pham.Ma_so)
                If (So_luong_Ton <= 0) Then
                    Dinh_dang_Trang_thai = "Hết sản phẩm"
                Else
                    Dinh_dang_Trang_thai = "Còn sản phẩm"
                End If

                Dim Chuoi_Hinh = $"<img src='data:image;base64,{Chuoi_64}' " +
                                 $"class='float-left' style='width:50%;height:80%;' />"

                Dim Chuoi_Thong_tin As String = $"<div Class='text-left float-left' style='width:100%;height:100%;margin-left:10px;'> " +
                                    $"{ Ten}" +
                                     $"<br />Đơn giá bán {Don_gia_Ban.ToString("n0", Dinh_dang_VN) }" +
                                     $"<br />Trạng thái sản phẩm <b>{Dinh_dang_Trang_thai}</b>" +
                                     $"<br /><i><b><input type='button' style='Background-color:red' value='CHỌN'><i><b>" +
                                     $"</div>"
                Dim Chuoi_HTML As String = $"<div class='float-left' style='width:320px;height:150px;margin-bottom:10px;margin-left:10px;{Dinh_dang_Trang_thai}' >" +
                               $"{Chuoi_Hinh}" + $"{Chuoi_Thong_tin}" +
                                         "</div>"
                Dim Th_San_pham = Tai_lieu.CreateElement("div")
                Th_San_pham.InnerHtml = Chuoi_HTML
                Tai_lieu.Body.AppendChild(Th_San_pham)
                AddHandler Th_San_pham.Click,
                       Sub()
                           If So_luong_Ton > 0 Then
                               Danh_sach_San_pham_chon.Add(San_pham)
                               Danh_sach_San_pham.Remove(San_pham)
                               Tai_lieu.Body.InnerHtml = ""
                               Xuat_Danh_sach_San_pham_chon()
                               Xuat_Danh_sach_San_pham()
                           Else
                               MessageBox.Show("Sản phẩm đã hết hàng")
                           End If
                       End Sub
            End Sub)
    End Sub
    Sub Xuat_Danh_sach_San_pham_chon()
        If Danh_sach_San_pham_chon IsNot Nothing Then
            Dim Chuoi_tieu_de As String = "<h1 style='color:red' >GIỎ HÀNG</h1>"
            If Danh_sach_San_pham_chon.Count = 0 Then
                Chuoi_tieu_de += "<h2>Giỏ hàng trống</h2>"
            End If
            Dim Th_Gio_hang = Tai_lieu.CreateElement("div")
            Th_Gio_hang.InnerHtml = Chuoi_tieu_de
            Tai_lieu.Body.AppendChild(Th_Gio_hang)
            Danh_sach_San_pham_chon.ForEach(
            Sub(San_pham)
                Dim Ten = San_pham.Ten
                Dim Ma_so = San_pham.Ma_so
                Dim Don_gia_Ban = San_pham.Don_gia_Ban
                Dim So_luong_Ton As Long = Nghiep_vu.Tinh_So_luong_Ton_San_pham(San_pham)
                Dim So_luong_chon As Long = 1
                Dim Chuoi_64 As String = Luu_tru.Doc_Chuoi_64(San_pham.Ma_so)
                Dim Chuoi_Hinh = $"<img src='data:image;base64,{Chuoi_64}' " +
                                 $"class='float-left' style='width:50%;height:80%;' />"

                Dim Chuoi_Thong_tin As String = $"<div Class='text-left float-left' style='width:100%;height:100%;margin-left:10px;'> " +
                                    $"{ Ten}" +
                                     $"<br />Đơn giá bán {Don_gia_Ban.ToString("n0", Dinh_dang_VN) }" +
                                     $"<br /><i><b><input type='button' style='Background-color:red' value='BỎ CHỌN'><i><b>" +
                                     $"</div>"
                Dim Chuoi_HTML As String = $"<div class='float-left' style='width:320px;height:150px;margin-bottom:10px;margin-left:10px;' >" +
                               $"{Chuoi_Hinh}" + $"{Chuoi_Thong_tin}" +
                                         "</div>"
                Dim Th_San_pham_chon = Tai_lieu.CreateElement("div")
                Th_San_pham_chon.InnerHtml = Chuoi_HTML
                Tai_lieu.Body.AppendChild(Th_San_pham_chon)

                Dim Th_tang_So_luong_chon = Tai_lieu.CreateElement("div")
                Th_tang_So_luong_chon.InnerHtml = "Số lượng <input type='button' style='Background-color:red' value='+'>" + $" {So_luong_chon.ToString("n0", Dinh_dang_VN) }<i><b>"
                Tai_lieu.Body.AppendChild(Th_tang_So_luong_chon)

                Dim Th_giam_So_luong_chon = Tai_lieu.CreateElement("div")
                Th_giam_So_luong_chon.InnerHtml = "Số lượng <input type='button' style='Background-color:red' value='-'>" + $" {So_luong_chon.ToString("n0", Dinh_dang_VN) }<i><b>"
                Tai_lieu.Body.AppendChild(Th_giam_So_luong_chon)
                San_pham.So_luong = 1
                AddHandler Th_tang_So_luong_chon.Click,
                       Sub()
                           So_luong_chon = So_luong_chon + 1
                           If So_luong_chon <= So_luong_Ton Then
                               Th_giam_So_luong_chon.InnerHtml = ""
                               Th_giam_So_luong_chon.InnerHtml = "Số lượng <input type='button' style='Background-color:red' value='-'>" + $" {So_luong_chon.ToString("n0", Dinh_dang_VN) }<i><b>"
                               Th_tang_So_luong_chon.InnerHtml = ""
                               Th_tang_So_luong_chon.InnerHtml = "Số lượng <input type='button' style='Background-color:red' value='+'>" + $" {So_luong_chon.ToString("n0", Dinh_dang_VN) }<i><b>"
                               San_pham.So_luong = So_luong_chon
                           Else
                               MessageBox.Show("Quý khách đã chọn quá số lượng tồn")
                               So_luong_chon = So_luong_chon - 1
                           End If
                       End Sub

                AddHandler Th_giam_So_luong_chon.Click,
                       Sub()
                           So_luong_chon = So_luong_chon - 1
                           If So_luong_chon <= So_luong_Ton AndAlso So_luong_chon > 0 Then
                               Th_giam_So_luong_chon.InnerHtml = ""
                               Th_giam_So_luong_chon.InnerHtml = "Số lượng <input type='button' style='Background-color:red' value='-'>" + $" {So_luong_chon.ToString("n0", Dinh_dang_VN) }<i><b>"
                               Th_tang_So_luong_chon.InnerHtml = ""
                               Th_tang_So_luong_chon.InnerHtml = "Số lượng <input type='button' style='Background-color:red' value='+'>" + $" {So_luong_chon.ToString("n0", Dinh_dang_VN) }<i><b>"
                               San_pham.So_luong = So_luong_chon
                           Else
                               MessageBox.Show("Số lượng phải khác 0")
                               So_luong_chon = So_luong_chon + 1
                           End If
                       End Sub

                AddHandler Th_San_pham_chon.Click,
                       Sub()
                           If So_luong_Ton > 0 Then
                               Danh_sach_San_pham.Add(San_pham)
                               Danh_sach_San_pham_chon.Remove(San_pham)
                               Tai_lieu.Body.InnerHtml = ""
                               Xuat_Danh_sach_San_pham_chon()
                               Xuat_Danh_sach_San_pham()
                           Else
                               MessageBox.Show("Sản phẩm đã hết hàng")
                           End If
                       End Sub
            End Sub)
            Dim Chuoi_Dat_hang As String = "<h1><i><b><input type='button' style='Background-color:red' value='ĐẶT HÀNG'><i><b></h1>"
            If Danh_sach_San_pham_chon.Count <> 0 Then
                Dim Th_Dat_hang = Tai_lieu.CreateElement("div")
                Th_Dat_hang.InnerHtml = Chuoi_Dat_hang
                Tai_lieu.Body.AppendChild(Th_Dat_hang)
                AddHandler Th_Dat_hang.Click,
                       Sub()
                           Kich_hoat_Gio_hang(Danh_sach_San_pham_chon)
                       End Sub
            End If
        End If
    End Sub
    Sub Kich_hoat_Gio_hang(Danh_sach_San_pham_chon As List(Of XL_SAN_PHAM))
        Dim Khung_Chuc_nang As Control = Me.Parent
        Khung_Chuc_nang.Controls.Clear()
        Dim Mh = New MH_Dat_San_pham()
        Mh.Khoi_dong(Danh_sach_San_pham_chon)
        Mh.Dock = DockStyle.Fill
        Khung_Chuc_nang.Controls.Add(Mh)
    End Sub
    'Sub Kich_hoat_Man_hinh_Xu_ly_tren_San_pham_Chon(San_pham As XL_SAN_PHAM, Danh_sach_San_pham As List(Of XL_SAN_PHAM))
    '    Dim Khung_Chuc_nang As Control = Me.Parent
    '    Khung_Chuc_nang.Controls.Clear()
    '    Dim Mh = New MH_Dat_San_pham()
    '    Mh.Khoi_dong(San_pham)
    '    Mh.Dock = DockStyle.Fill
    '    Khung_Chuc_nang.Controls.Add(Mh)
    'End Sub
End Class
