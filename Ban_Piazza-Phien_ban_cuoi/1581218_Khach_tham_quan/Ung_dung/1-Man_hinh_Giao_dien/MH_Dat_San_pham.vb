Public Class MH_Dat_San_pham
    Dim Dinh_dang_VN = System.Globalization.CultureInfo.GetCultureInfo("vi-VN")
    Dim The_hien As New XL_THE_HIEN
    Dim Nghiep_vu As New XL_NGHIEP_VU
    Dim Luu_tru As New XL_LUU_TRU
    Dim Du_lieu As XL_DU_LIEU = Luu_tru.Doc_Du_lieu
    Dim Nguoi_dung As XL_KHACH_THAM_QUAN
    Dim San_pham As XL_SAN_PHAM
    Dim Danh_sach_San_pham_chon As List(Of XL_SAN_PHAM)
    Dim Th_Thong_tin_Khach_hang As New FlowLayoutPanel
    Dim Tai_lieu As HtmlDocument
    Private Sub MH_Xem_Danh_sach_San_pham_chon_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler Trinh_duyet.DocumentCompleted,
            Sub()
                Tai_lieu = Trinh_duyet.Document
                If (Tai_lieu IsNot Nothing) Then
                    Xuat_Danh_sach_San_pham_chon()
                End If
            End Sub
        Trinh_duyet.DocumentStream = Nothing
    End Sub
    Sub Khoi_dong(Danh_sach_San_pham_chon As List(Of XL_SAN_PHAM))
        Me.Nguoi_dung = Nguoi_dung
        Me.Danh_sach_San_pham_chon = Danh_sach_San_pham_chon

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
            Dim Tong_tien As Long
            Danh_sach_San_pham_chon.ForEach(
            Sub(San_pham)
                Dim Ten = San_pham.Ten
                Dim Ma_so = San_pham.Ma_so
                Dim Don_gia_Ban = San_pham.Don_gia_Ban
                Dim So_luong_Ton As Long = Nghiep_vu.Tinh_So_luong_Ton_San_pham(San_pham)
                Dim So_luong_Dat As Long = San_pham.So_luong
                Dim Thanh_tien As Long = So_luong_Dat * Don_gia_Ban
                Dim Chuoi_64 As String = Luu_tru.Doc_Chuoi_64(San_pham.Ma_so)

                Dim Chuoi_Hinh = $"<img src='data:image;base64,{Chuoi_64}' " +
                                 $"class='float-left' style='width:50%;height:80%;' />"

                Dim Chuoi_Thong_tin As String = $"<div Class='text-left float-left' style='width:100%;height:100%;margin-left:10px;'> " +
                                    $"{ Ten}" +
                                     $"<br />Đơn giá bán {Don_gia_Ban.ToString("n0", Dinh_dang_VN) }" +
                                     $"<br />Số lượng {So_luong_Dat}" +
                                     $"<br />Thành tiền {Thanh_tien.ToString("n0", Dinh_dang_VN) }" +
                                     $"</div>"
                Dim Chuoi_HTML As String = $"<div class='float-left' style='width:320px;height:150px;margin-bottom:10px;margin-left:10px;' >" +
                               $"{Chuoi_Hinh}" + $"{Chuoi_Thong_tin}" +
                                         "</div>"
                Dim Th_San_pham_chon = Tai_lieu.CreateElement("div")
                Th_San_pham_chon.InnerHtml = Chuoi_HTML
                Tai_lieu.Body.AppendChild(Th_San_pham_chon)
                Tong_tien += Thanh_tien
            End Sub)
            Dim Chuoi_Tong_tien As String = $"<h2>Tổng tiền: <input type='button' style='Background-color:white' value='{Tong_tien.ToString("c0", Dinh_dang_VN)}'></h2>"
            Dim Chuoi_Dat_hang As String = "<h1><input type='button' style='Background-color:red' value='ĐẶT HÀNG'></h1>"

            If Danh_sach_San_pham_chon.Count <> 0 Then
                Dim Th_Dat_hang = Tai_lieu.CreateElement("div")
                Th_Dat_hang.InnerHtml = Chuoi_Tong_tien + Chuoi_Dat_hang
                Tai_lieu.Body.AppendChild(Th_Dat_hang)
                AddHandler Th_Dat_hang.Click,
                       Sub()
                           Kich_hoat_MH_Gio_hang(Danh_sach_San_pham_chon)
                       End Sub
            End If
        End If
    End Sub

    Sub Kich_hoat_MH_Gio_hang(Danh_sach_San_pham_chon As List(Of XL_SAN_PHAM))
        Dim Khung_Chuc_nang As Control = Me.Parent
        Khung_Chuc_nang.Controls.Clear()
        Dim Mh = New MH_Gio_hang()
        Mh.Khoi_dong(Danh_sach_San_pham_chon)
        Mh.Dock = DockStyle.Fill
        Khung_Chuc_nang.Controls.Add(Mh)
    End Sub
    Sub Kich_hoat_MH_Xem_Danh_sach_San_pham(Danh_sach_San_pham As List(Of XL_SAN_PHAM))
        Dim Khung_Chuc_nang As Control = Me.Parent
        Khung_Chuc_nang.Controls.Clear()
        Dim Mh = New MH_Xem_Danh_sach_San_pham()
        Mh.Khoi_dong(Danh_sach_San_pham)
        Mh.Dock = DockStyle.Fill
        Khung_Chuc_nang.Controls.Add(Mh)
    End Sub
End Class

