Public Class MH_Xem_Danh_sach_San_pham
    Dim Dinh_dang_VN = System.Globalization.CultureInfo.GetCultureInfo("vi-VN")
    Dim The_hien As New XL_THE_HIEN
    Dim Nghiep_vu As New XL_NGHIEP_VU
    Dim Luu_tru As New XL_LUU_TRU
    Dim Du_lieu As XL_DU_LIEU = Luu_tru.Doc_Du_lieu
    Dim Danh_sach_San_pham As List(Of XL_SAN_PHAM)
    Dim Tai_lieu As HtmlDocument
    Dim Nguoi_dung As XL_QUAN_LY_CUA_HANG
    Public Danh_sach_Nhom_San_pham As New List(Of XL_NHOM_SAN_PHAM)
    Public Danh_sach_Nhan_vien_Ban_hang As New List(Of XL_NHAN_VIEN_BAN_HANG)
    Public Danh_sach_Quan_ly_Ban_hang As New List(Of XL_QUAN_LY_NHAP_HANG)
    Public Danh_sach_Quan_ly_Nhap_hang As New List(Of XL_QUAN_LY_NHAP_HANG)
    Private Sub MH_Xem_Danh_sach_San_pham_Load(sender As Object, e As EventArgs) Handles Me.Load
        AddHandler Trinh_duyet.DocumentCompleted,
            Sub()
                Tai_lieu = Trinh_duyet.Document
                If (Tai_lieu IsNot Nothing) Then
                    Xuat_Thong_ke()
                    Xuat_Danh_sach_Nhan_vien()
                    Xuat_Danh_sach_San_pham()
                End If
            End Sub
        Trinh_duyet.DocumentStream = Nothing
    End Sub
    Sub Khoi_dong(Danh_sach_San_pham_Xem As List(Of XL_SAN_PHAM), Nguoi_dung As XL_QUAN_LY_CUA_HANG)
        Danh_sach_San_pham = Danh_sach_San_pham_Xem
        Danh_sach_Nhan_vien_Ban_hang = Du_lieu.Cua_hang.Danh_sach_Nhan_vien_Ban_hang
        Me.Nguoi_dung = Nguoi_dung
    End Sub
    Sub Xuat_Danh_sach_San_pham()

        Dim Th_tieu_de = Tai_lieu.CreateElement("div")
        Th_tieu_de.InnerHtml = "<h2>Danh sách sản phẩm:</h2>"
        Tai_lieu.Body.AppendChild(Th_tieu_de)
        Danh_sach_San_pham.ForEach(
            Sub(San_pham)
                Dim Ten = San_pham.Ten
                Dim Ma_so = San_pham.Ma_so
                Dim Don_gia_Ban = San_pham.Don_gia_Ban
                Dim So_luong_Ton As Long = Nghiep_vu.Tinh_So_luong_Ton_San_pham(San_pham)
                Dim Doanh_thu_Ngay As Long = Nghiep_vu.Tinh_Doanh_thu_Ngay_Hien_hanh_San_pham(San_pham)
                Dim Doanh_thu_Thang As Long = Nghiep_vu.Tinh_Doanh_thu_Thang_Hien_hanh_San_pham(San_pham)
                Dim Doanh_thu_Nam As Long = Nghiep_vu.Tinh_Doanh_thu_Nam_Hien_hanh_San_pham(San_pham)

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
                                     $"<br />Doanh thu ngày {  Doanh_thu_Ngay.ToString("n0", Dinh_dang_VN) }" +
                                     $"<br />Doanh thu tháng {  Doanh_thu_Thang.ToString("n0", Dinh_dang_VN) }" +
                                     $"<br />Doanh thu năm {  Doanh_thu_Nam.ToString("n0", Dinh_dang_VN) }" +
                                     $"</div>"
                Dim Chuoi_HTML As String = $"<div class='float-left' style='width:320px;height:150px;margin-bottom:10px;margin-left:10px;{Dinh_dang_Trang_thai}' >" +
                               $"{Chuoi_Hinh}" + $"{Chuoi_Thong_tin}" +
                                         "</div>"
                Dim Th_San_pham = Tai_lieu.CreateElement("div")
                Th_San_pham.InnerHtml = Chuoi_HTML
                Tai_lieu.Body.AppendChild(Th_San_pham)
            End Sub)
    End Sub
    Sub Xuat_Danh_sach_Nhan_vien()
        Dim Th_tieu_de = Tai_lieu.CreateElement("div")
        Th_tieu_de.InnerHtml = "<h2>Danh sách nhân viên bán hàng:</h2>"
        Tai_lieu.Body.AppendChild(Th_tieu_de)
        Danh_sach_Nhan_vien_Ban_hang.ForEach(
            Sub(Nhan_vien)
                Dim Ho_ten = Nhan_vien.Ho_ten
                Dim Doanh_thu_Nhan_vien_ngay As Long = Nghiep_vu.Tinh_Tong_Doanh_thu_Ngay_Hien_hanh_NVBH(Nhan_vien, Danh_sach_San_pham)
                Dim Doanh_thu_Nhan_vien_thang As Long = Nghiep_vu.Tinh_Tong_Doanh_thu_Thang_Hien_hanh_NVBH(Nhan_vien, Danh_sach_San_pham)
                Dim Doanh_thu_Nhan_vien_nam As Long = Nghiep_vu.Tinh_Tong_Doanh_thu_Nam_Hien_hanh_NVBH(Nhan_vien, Danh_sach_San_pham)
                Dim Chuoi_64 As String = Luu_tru.Doc_Chuoi_64(Nhan_vien.Ma_so)
                Dim Chuoi_Hinh = $"<img src='data:image;base64,{Chuoi_64}' " +
                                 $"class='float-left' style='width:50%;height:80%;' />"
                Dim Chuoi_Thong_tin As String = $"<div Class='text-left float-left' style='width:65%;height:100%;margin-left:10px;'> " +
                                     $"{ Ho_ten}" +
                                     $"<br />Doanh thu ngày {  Doanh_thu_Nhan_vien_ngay.ToString("n0", Dinh_dang_VN) }" +
                                     $"<br />Doanh thu tháng {  Doanh_thu_Nhan_vien_thang.ToString("n0", Dinh_dang_VN) }" +
                                     $"<br />Doanh thu năm {  Doanh_thu_Nhan_vien_nam.ToString("n0", Dinh_dang_VN) }" +
                                     $"</div>"
                Dim Chuoi_HTML As String = $"<div class='float-left' style='width:320px;height:150px;margin-bottom:10px;margin-left:10px' >" +
                               $"{Chuoi_Hinh}" + $"{Chuoi_Thong_tin}" +
                                         "</div>"
                Dim Th_San_pham = Tai_lieu.CreateElement("div")
                Th_San_pham.InnerHtml = Chuoi_HTML
                Tai_lieu.Body.AppendChild(Th_San_pham)
            End Sub)
    End Sub
    Sub Xuat_Thong_ke()
        Dim Tong_So_luong_Ton As Long = Nghiep_vu.Tinh_Tong_So_luong_Ton_San_pham(Nguoi_dung, Danh_sach_San_pham)
        Dim Tong_Doanh_thu_Ngay As Long = Nghiep_vu.Tinh_Tong_Doanh_thu_Ngay_Hien_hanh_Quan_ly(Nguoi_dung, Danh_sach_San_pham)
        Dim Tong_Doanh_thu_Thang As Long = Nghiep_vu.Tinh_Tong_Doanh_thu_Thang_Hien_hanh_Quan_ly(Nguoi_dung, Danh_sach_San_pham)
        Dim Tong_Doanh_thu_Nam As Long = Nghiep_vu.Tinh_Tong_Doanh_thu_Nam_Hien_hanh_Quan_ly(Nguoi_dung, Danh_sach_San_pham)

        Dim Dinh_dang_Trang_thai As String = ""

        Dim Chuoi_Thong_tin As String = $"<div Class='text-left float-left' style='width:65%;height:100%;margin-left:10px;color: red'> " +
                             $"<br /><i><b>Tổng Số lượng Tồn {  Tong_So_luong_Ton.ToString("n0", Dinh_dang_VN) }<i><b>" +
                             $"<br />Tổng Doanh thu ngày {  Tong_Doanh_thu_Ngay.ToString("n0", Dinh_dang_VN) }" +
                             $"<br />Tổng Doanh thu tháng {  Tong_Doanh_thu_Thang.ToString("n0", Dinh_dang_VN) }" +
                             $"<br />Tổng Doanh thu năm {  Tong_Doanh_thu_Nam.ToString("n0", Dinh_dang_VN) }" +
                             $"</div>"

        Dim Th_Thong_ke = Tai_lieu.CreateElement("div")
        Th_Thong_ke.InnerHtml = Chuoi_Thong_tin
        Tai_lieu.Body.AppendChild(Th_Thong_ke)
    End Sub

End Class
